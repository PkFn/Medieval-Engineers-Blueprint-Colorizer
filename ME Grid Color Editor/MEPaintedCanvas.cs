using System;
using System.Collections.Generic;
using System.Drawing;
using System.Xml;
using MEPaintedDefs;

namespace MEPaintedCanvas
{
    public class MyCanvasBlock
    {
        public string a0 { get; private set; }
        public string color { get; private set; }
        public string subtype {  get; private set; }
        XmlNode node;
        public MyCanvasBlock(XmlNode colorNode)
        {
            foreach (XmlNode canvasProperties in colorNode.ChildNodes)
            {
                switch(canvasProperties.Name)
                {
                    case "Surf":
                        {
                            foreach (XmlNode canvasAttribute in canvasProperties.Attributes)
                            {
                                switch (canvasAttribute.Name)
                                {
                                    case "AO":
                                        {
                                            a0 = canvasAttribute.InnerText;
                                            break;
                                        }
                                    case "Color":
                                        {
                                            node = canvasAttribute;
                                            color = canvasAttribute.InnerText;
                                            break;
                                        }
                                    default: break;
                                }
                            }
                            break;
                        }
                    case "Definition":
                        {
                            foreach (XmlNode canvasAttribute in canvasProperties.Attributes)
                            {
                                if(canvasAttribute.Name == "Subtype")
                                {
                                    subtype = canvasAttribute.InnerText;
                                }
                            }
                            break;
                        }
                    default:break;
                }
            }
        }

        public bool sameA0(string _a0)
        {
            return String.Equals(a0, _a0);
        }

        public bool hasColor(string _color)
        {
            return String.Equals(_color, _color);
        }
        public bool hasSubtype(string _subtype)
        {
            return String.Equals(_subtype, subtype);
        }

        public void changeColor(MyMeHsv newColor)
        {
            node.InnerText = String.Format("{0:000}+{1:000}+{2:000}", newColor.h, newColor.s, newColor.v);
        }

        public override string ToString()
        {
            return subtype;
        }
    }
    public class MyCanvasColorNode
    {
        string color;
        string myString = "";
        public List<MyCanvasBlock> blocks { get; private set; }
        public List<string> affectedObjectsSubtypes { get; private set; }
        public MyCanvasColorNode(string _color)
        {
            color = _color;
            blocks = new List<MyCanvasBlock>();
            affectedObjectsSubtypes = new List<string>();
        }
        public void addCanvas(XmlNode colorNode)
        {
            MyCanvasBlock canvas = new MyCanvasBlock(colorNode);

            bool subtypeMatch = false;
            foreach(MyCanvasBlock block in blocks)
            {
                if(block.hasSubtype(canvas.subtype))
                {
                    subtypeMatch = true;
                }
            }

            if(!subtypeMatch)
            {
                affectedObjectsSubtypes.Add(canvas.subtype);
            }

            blocks.Add(canvas);

            if (blocks.Count == 1)
            {
                myString = String.Format("[Canvas] {0} : {1} surface", color, blocks.Count);
            }
            else
            {
                myString = String.Format("[Canvas] {0} : {1} surfaces", color, blocks.Count);
            }
        }

        public bool hasSameColor(string _color)
        {
            return String.Equals(color, _color);
        }

        public void changeColor(MyMeHsv newColor)
        {
            foreach(MyCanvasBlock canvas in blocks)
            {
                canvas.changeColor(newColor);
            }
        }
        public MyMeHsv getColor()
        {
            MyMeHsv col = new MyMeHsv(0, 0, 0);

            try
            {
                col.h = Convert.ToInt32("" + color[0] + color[1] + color[2]);
                col.s = Convert.ToInt32("" + color[4] + color[5] + color[6]);
                col.v = Convert.ToInt32("" + color[7] + color[8] + color[9] + color[10]);
                col.v += 70;
            }
            catch
            {
                col.h = 0;
                col.s = 1;
                col.v = 1;
            }

            return col;
        }

        public bool isMyString(string inp)
        {
            return String.Equals(inp, myString);
        }
        public override string ToString()
        {
            return myString;
        }
    }
}