using System.Collections.Generic;
using System.Xml.Linq;
using SpecAid.XmlAid.Infrastructure;

namespace SpecAid.XmlAid
{
    public interface IXmlAidViewConverter
    {
        IEnumerable<XmlAidView> Convert(XDocument document, IEnumerable<IXmlAidFormatter> formatters);
    }
}
