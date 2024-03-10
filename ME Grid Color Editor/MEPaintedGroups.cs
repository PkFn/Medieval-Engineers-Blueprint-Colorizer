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
                foreach (XmlNode canvasSurface in doc.GetElementsByTagName("Surf"))
                {
                    string color = "";
                    foreach (XmlNode canvasAttribute in canvasSurface.Attributes)
                    {
                        switch (canvasAttribute.Name)
                        {
                            case "Color":
                                {
                                    color = canvasAttribute.InnerText;
                                    string parentSubtype = "";

                                    foreach(XmlNode definition in canvasSurface.ParentNode.ChildNodes)
                                    {
                                        if(definition.Name == "Definition")
                                        {
                                            foreach(XmlNode attribute in  definition.Attributes)
                                            {
                                                if(attribute.Name == "Subtype")
                                                {
                                                    parentSubtype = attribute.InnerText;
                                                }
                                            }
                                        }
                                    }

                                    bool existingColor = false;

                                    foreach(MyCanvasColorNode colorNode in canvasColorNodes)
                                    {
                                        if(colorNode.hasSameColor(color))
                                        {
                                            colorNode.addCanvas(canvasAttribute, parentSubtype);
                                            existingColor = true;
                                        }
                                    }

                                    if(!existingColor)
                                    {
                                        canvasColorNodes.Add(new MyCanvasColorNode(color));
                                        canvasColorNodes.Last().addCanvas(canvasAttribute, parentSubtype);
                                    }

                                    break;
                                }
                            default: break;
                        }
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