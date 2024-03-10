using System;
using System.Collections.Generic;
using System.Xml;

namespace MEPaintedBlock
{
    public class MyColorNode
    {
        public string data { get; private set; }
        public int affectedObjects { get; private set; }
        public MyColorNode(XmlNode colorNode)
        {
            data = "";
            affectedObjects = 0;

            foreach(XmlNode node in colorNode.ChildNodes)
            {
                switch(node.Name)
                {
                    case "Data":
                        {
                            data = node.InnerText;
                            break;
                        }
                    case "Object":
                        {
                            affectedObjects++;
                            break;
                        }
                    default:
                        break;
                }
            }
        }
        public override string ToString()
        {
            if(affectedObjects == 1)
            {
                return String.Format("Color {0} : {1} block\n", data, affectedObjects);
            }
            else
            {
                return String.Format("Color {0} : {1} blocks\n", data, affectedObjects);
            }
        }
    }
    public class MyColorModifiers
    {
        XmlNode modifierComponent;
        List<MyColorNode> colorNodes;
        public MyColorModifiers(XmlDocument doc)
        {
            modifierComponent = null;
            colorNodes = new List<MyColorNode>();

            foreach (XmlNode component in doc.GetElementsByTagName("Component"))
            {
                foreach (XmlAttribute attribute in component.Attributes)
                {
                    if (attribute.Name == "xsi:type")
                    {
                        if (attribute.InnerText == "MyObjectBuilder_EquiGridModifierComponent")
                        {
                            modifierComponent = component;
                        }
                    }
                }
            }

            if(modifierComponent != null)
            {
                bool hasModifier = false;

                foreach (XmlNode child in doc.GetElementsByTagName("Storage"))
                {
                    foreach(XmlNode modifier in child.ChildNodes)
                    {
                        if(modifier.Name == "Modifier")
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
                    
                    if(hasModifier)
                    {
                        colorNodes.Add(new MyColorNode(child));
                    }
                }
            }
        }

        public override string ToString()
        {
            string ret = "";
            foreach (MyColorNode node in colorNodes)
            {
                ret += node.ToString();
            }
            return ret;
        }
    }
}