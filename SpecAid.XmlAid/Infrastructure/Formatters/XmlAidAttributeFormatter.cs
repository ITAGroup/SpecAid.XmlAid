using System.Xml.Linq;

namespace SpecAid.XmlAid.Infrastructure.Formatters
{
    public class XmlAidAttributeFormatter: IXmlAidFormatter
    {
        public XmlAidView Format(XObject xobject, int currentLevel)
        {
            var attribute = xobject as XAttribute;
            if (attribute != null)
            {
                if (attribute.Name == "xmlns") return null;

                return new XmlAidView()
                           {
                               NodeName = string.Format("+{0}", attribute.Name.LocalName),
                               Value = attribute.Value,
                               Level = currentLevel
                           };
                
            }
            return null;
        }
    }
}