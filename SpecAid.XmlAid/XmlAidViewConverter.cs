using System;
using System.Collections.Generic;
using System.Xml.Linq;
using SpecAid.XmlAid.Infrastructure;

namespace SpecAid.XmlAid
{
    public class XmlAidViewConverter: IXmlAidViewConverter
    {
        protected XmlAidView Format(XObject xobject, int currentLevel, IEnumerable<IXmlAidFormatter> formatters)
        {
            foreach (var formatter in formatters)
            {
                var result = formatter.Format(xobject, currentLevel);
                if (result != null)
                    return result;
            }
            return null;
        }

        protected IEnumerable<XmlAidView> Convert(int level, XElement element, IEnumerable<IXmlAidFormatter> formatters)
        {
            var result = Format(element, level, formatters);
            if (result != null) yield return result;

            foreach (var attrib in element.Attributes())
            {
                result = Format(attrib, level, formatters);
                if (result != null) yield return result;
            }

            foreach (var nestedElement in element.Elements())
            {
                foreach (var nested in Convert(level+1, nestedElement, formatters))
                {
                    yield return nested;
                }
            }
        }

        public IEnumerable<XmlAidView> Convert(XDocument document, 
            IEnumerable<IXmlAidFormatter> formatters)
        {
            foreach (var view in Convert(0, document.Root, formatters))
            {
                yield return view;
            }
        }
    }
}