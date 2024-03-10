using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Xml;
using System.Xml.Linq;

namespace MEPaintedBlock
{
    public struct MyMeHsv
    {
        public int h;
        public int s;
        public int v;
        public MyMeHsv(int _h, int _s, int _v)
        {
            h = _h;
            s = _s;
            v = _v;
        }
    }
    public class MyColorNode
    {
        string myString;
        XmlNode dataNode;
        public string data { get; private set; }
        public int affectedObjects { get; private set; }
        public List<string> affectedObjectsIds { get; private set; }
        public List<string> affectedObjectsSubtypes { get; private set; }

        private string findSubtypeById(XmlDocument doc, string id)
        {
            string ret = "";

            foreach (XmlNode blocks in doc.GetElementsByTagName("Blocks"))
            {
                bool matchId = false;
                foreach(XmlNode block in blocks.ChildNodes)
                {
                    if(block.Name == "Block")
                    {
                        foreach(XmlNode blockField in block.ChildNodes)
                        {
                            switch (blockField.Name)
                            {
                                case "DefinitionId":
                                    {
                                        foreach (XmlAttribute attribute in blockField.Attributes)
                                        {
                                            switch (attribute.Name)
                                            {
                                                case "Subtype":
                                                    {
                                                        if (matchId)
                                                        {
                                                            return attribute.InnerText;
                                                        }
                                                        break;
                                                    }
                                                default:
                                                    break;
                                            }
                                        }
                                        break;
                                    }
                                case "Id":
                                    {
                                        matchId = String.Equals(id, blockField.InnerText);
                                        break;
                                    }
                                default:
                                    break;
                            }
                        }
                    }
                }
            }

            return ret;
        }
        public MyColorNode(XmlNode colorNode)
        {
            dataNode = null;
            affectedObjectsIds = new List<string>();
            affectedObjectsSubtypes = new List<string>();
            data = "";
            affectedObjects = 0;

            foreach(XmlNode node in colorNode.ChildNodes)
            {
                switch(node.Name)
                {
                    case "Data":
                        {
                            dataNode = node;
                            data = node.InnerText;
                            break;
                        }
                    case "Object":
                        {
                            affectedObjects++;
                            foreach(XmlAttribute attrribute in node.Attributes)
                            {
                                if(attrribute.Name == "Block")
                                {
                                    affectedObjectsIds.Add(attrribute.InnerText);
                                }
                            }
                            break;
                        }
                    default:
                        break;
                }
            }

            if (affectedObjects == 1)
            {
                myString = String.Format("Color {0} : {1} block", data, affectedObjects);
            }
            else
            {
                myString = String.Format("Color {0} : {1} blocks", data, affectedObjects);
            }
        }
        public override string ToString()
        {
            return myString;
        }

        public void updateAffectedSubtypes(XmlDocument doc)
        {
            affectedObjectsSubtypes = new List<string>();
            if (affectedObjectsIds.Count > 0)
            {
                foreach (string id in affectedObjectsIds)
                {
                    string buf = findSubtypeById(doc, id);
                    if(!affectedObjectsSubtypes.Contains(buf))
                    {
                        affectedObjectsSubtypes.Add(buf);
                    }
                }
                affectedObjectsSubtypes.Sort();
            }
        }

        public bool isMyString(string comp)
        {
            return String.Equals(myString, comp);
        }

        public MyMeHsv getColor()
        {
            MyMeHsv col = new MyMeHsv(0,0,0);

            try
            {
                col.h = Convert.ToInt32("" + data[0] + data[1] + data[2]);
                col.s = Convert.ToInt32("" + data[4] + data[5] + data[6]);
                col.v = Convert.ToInt32("" + data[8] + data[9] + data[10]);
            }
            catch
            {
                col.h = 0;
                col.s = 1;
                col.v = 1;
            }

            return col;
        }

        public void changeColor(XmlDocument doc, string filePath, MyMeHsv newColor)
        {
            dataNode.InnerText = String.Format("{0:000}+{1:000}-{2:000}", newColor.h, newColor.s, newColor.v);
            doc.Save(filePath);
        }
    }
    public class MyColorModifiers
    {
        XmlNode modifierComponent;
        public List<MyColorNode> colorNodes { get; private set; }
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
                ret += '\n';
            }
            return ret;
        }

        public void updateAffectedSubtypes(XmlDocument doc)
        {
            foreach(MyColorNode node in colorNodes)
            {
                node.updateAffectedSubtypes(doc);
            }
        }
    }
}