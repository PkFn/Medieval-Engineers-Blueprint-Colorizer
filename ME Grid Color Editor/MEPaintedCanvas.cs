using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Xml;
using MEPaintedDefs;

namespace MEPaintedCanvas
{
    public class MyCanvasColorNode
    {
        string color;
        string myString = "";
        public List<string> affectedObjectsSubtypes { get; private set; }
        List<XmlNode> colorNodes;
        public MyCanvasColorNode(string _color)
        {
            color = _color;
            colorNodes = new List<XmlNode>();
            affectedObjectsSubtypes = new List<string>();
        }
        public void addCanvas(XmlNode colorNode, string _subtype)
        {
            colorNodes.Add(colorNode);

            if (colorNodes.Count == 1)
            {
                myString = String.Format("[Canvas] {0} : {1} surface", color, colorNodes.Count);
            }
            else
            {
                myString = String.Format("[Canvas] {0} : {1} surfaces", color, colorNodes.Count);
            }

            foreach (string subtype in affectedObjectsSubtypes)
            {
                if(String.Equals(subtype, _subtype))
                {
                    return;
                }
            }

            affectedObjectsSubtypes.Add(_subtype);
        }

        public bool hasSameColor(string _color)
        {
            return String.Equals(color, _color);
        }

        public void changeColor(MyMeHsv newColor)
        {
            foreach(XmlNode canvas in colorNodes)
            {
                canvas.InnerText = String.Format("{0:000}+{1:000}+{2:000}", newColor.h, newColor.s, newColor.v);
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