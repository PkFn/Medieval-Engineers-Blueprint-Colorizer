using MEPaintedBlock;
using MEPaintedCanvas;
using System.Collections.Generic;
using System.Xml;

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
                    //canvasColorNodes.Add(new MyCanvasColorNode(canvas));
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