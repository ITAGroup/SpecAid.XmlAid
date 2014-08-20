using System.Xml.Linq;

namespace SpecAid.XmlAid.Infrastructure.Formatters
{
    public class XmlAidElementFormatter: IXmlAidFormatter
    {
        public XmlAidView Format(XObject xobject, int currentLevel)
        {
            var element = xobject as XElement;
            if (element != null)
            {
                var view = new XmlAidView();
                view.NodeName = element.Name.LocalName;
                view.Level = currentLevel;
                if (!element.HasElements && !element.HasAttributes)
                {
                    view.Value = element.Value;
                }
                return view;
            }
            return null;
        }
    }
}