using System.Xml;
using MEPaintedDefs;

namespace MEPaintedCanvas
{
    public class MyCanvasColorNode
    {
        public ulong a0 { get; private set; }
        public MyCanvasColorNode(XmlNode colorNode)
        {
            a0 = 0;
        }
    }
}