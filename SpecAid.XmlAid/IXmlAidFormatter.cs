using System.Xml.Linq;
using SpecAid.XmlAid.Infrastructure;

namespace SpecAid.XmlAid
{
    public interface IXmlAidFormatter
    {
        XmlAidView Format(XObject xobject, int currentLevel);
    }
}