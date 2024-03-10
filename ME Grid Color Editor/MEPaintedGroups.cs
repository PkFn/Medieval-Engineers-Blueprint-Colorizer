using MEPaintedBlock;
using MEPaintedCanvas;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Xml;
using System.Linq;

namespace MEPaintedGroups
{
    public class MyColorModifiers
    {
        XmlNode blockModifierComponent;
        XmlNode canvasModifierComponent;
        public List<MyBlockColorNode> blockColorNodes { get; private set; }
        public List<MyCanvasColorNode> canvasColorNodes { get; private set; }
        public MyColorModifiers(XmlDocument doc)
        {
            blockModifierComponent = null;
            blockColorNodes = new List<MyBlockColorNode>();
            canvasColorNodes = new List<MyCanvasColorNode>();

            foreach (XmlNode component in doc.GetElementsByTagName("Component"))
            {
                foreach (XmlAttribute attribute in component.Attributes)
                {
                    if (attribute.Name == "xsi:type")
                    {
                        if (attribute.InnerText == "MyObjectBuilder_EquiGridModifierComponent")
                        {
                            blockModifierComponent = component;
                        }
                        if (attribute.InnerText == "MyObjectBuilder_EquiDecorativeMeshComponent")
                        {
                            canvasModifierComponent = component;
                        }
                    }
                }
            }

            if (blockModifierComponent != null)
            {
                foreach (XmlNode child in doc.GetElementsByTagName("Storage"))
                {
                    bool hasModifier = false;
                    foreach (XmlNode modifier in child.ChildNodes)
                    {
                        if (modifier.Name == "Modifier")
                        {
                            foreach (XmlAttribute attribute in modifier.Attributes)
                            {
                                if (attribute.InnerText == "EquiModifierChangeColorDefinition")
                                {
                                    hasModifier = true;
                                }
                            }
                        }
                    }

                    if (hasModifier)
                    {
                        blockColorNodes.Add(new MyBlockColorNode(child));
                    }
                }
            }

            if (canvasModifierComponent != null)
            {
                foreach (XmlNode canvas in doc.GetElementsByTagName("Surfaces"))
                {
                    string color = "";
                    foreach (XmlNode canvasProperties in canvas.ChildNodes)
                    {
                        switch (canvasProperties.Name)
                        {
                            case "Surf":
                                {
                                    foreach (XmlNode canvasAttribute in canvasProperties.Attributes)
                                    {
                                        switch (canvasAttribute.Name)
                                        {
                                            case "Color":
                                                {
                                                    color = canvasAttribute.InnerText;
                                                    break;
                                                }
                                            default: break;
                                        }
                                    }
                                    break;
                                }
                            default: break;
                        }
                    }

                    bool hasColor = false;
                    foreach(MyCanvasColorNode colorNode in canvasColorNodes)
                    {
                        if(colorNode.hasSameColor(color))
                        {
                            colorNode.addCanvas(canvas);
                            hasColor = true;
                        }
                    }

                    if(!hasColor)
                    {
                        canvasColorNodes.Add(new MyCanvasColorNode(color));
                        canvasColorNodes.Last().addCanvas(canvas);
                    }
                }
            }
        }

        public override string ToString()
        {
            string ret = "";
            foreach (MyBlockColorNode node in blockColorNodes)
            {
                ret += node.ToString();
                ret += '\n';
            }
            return ret;
        }

        public void updateAffectedSubtypes(XmlDocument doc)
        {
            foreach (MyBlockColorNode node in blockColorNodes)
            {
                node.updateAffectedSubtypes(doc);
            }
        }
    }
}