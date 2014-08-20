using System.Xml.Linq;
using TechTalk.SpecFlow;

namespace SpecAid.XmlAid
{
    public static class XmlAidHelpersExtentions
    {
        public static void XmlCompareWithTable(this SpecAidHelper helper, XDocument document, Table table)
        {
            new XmlAidHelper().XmlCompareWithTable(document, table);
        }

        public static void XmlCompareWithTable(this SpecAidHelper helper, string xml, Table table)
        {
            new XmlAidHelper().XmlCompareWithTable(XDocument.Parse(xml), table);
        }

        public static string ToSpecThenString(this SpecAidHelper helper, string xml)
        {
            return new XmlAidHelper().OutputSpecThenSample(XDocument.Parse(xml));
        }

        public static string ToSpecThenString(this SpecAidHelper helper, XDocument xml)
        {
            return new XmlAidHelper().OutputSpecThenSample(xml);
        }
    }
}