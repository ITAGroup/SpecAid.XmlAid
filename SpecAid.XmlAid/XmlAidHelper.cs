using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using SpecAid.XmlAid.Infrastructure;
using TechTalk.SpecFlow;

namespace SpecAid.XmlAid
{
    public class XmlAidHelper
    {
        private List<IXmlAidFormatter> _formatters;

        protected virtual IXmlAidViewConverter BuildConverter()
        {
            return new XmlAidViewConverter();
        }

        public void XmlCompareWithTable(XDocument document, Table table)
        {
            var results = BuildConverter().Convert(document, this.Formatters).ToList();
            ReportElementCountDifferences(table, results);
            TableAid.ObjectComparer(table, results);
        }

        public string OutputSpecThenSample(XDocument document)
        {
            var results = BuildConverter().Convert(document, this.Formatters).ToList();
            var sb = new StringBuilder();
            sb.AppendLine("|FullPath|Value|");
            foreach (var view in results)
            {
                sb.AppendFormat("|{0}|{1}|", view.FullPath, view.Value);
                sb.AppendLine();
            }
            return sb.ToString();
        }

        private static void ReportElementCountDifferences(Table table, List<XmlAidView> results)
        {
            if (table.Rows.Count() != results.Count())
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine(new String('\\', 81));
                Console.WriteLine("{0} XML-AID {0}", new String('/', 36));

                Console.WriteLine(">>>> Table Line Count does not match! Expected: [{0}] Results: [{1}]", table.Rows.Count(),
                                  results.Count());
                Console.WriteLine(
                    ">>>> SUGGESTION: Examine XML results against expected XML-AID results -- results need to line up");
                Console.WriteLine(new String('\\', 81));
                Console.WriteLine(new String('/', 81));
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
            }
        }

        protected IEnumerable<IXmlAidFormatter> DefaultFormatters()
        {
            yield return new Infrastructure.Formatters.XmlAidElementFormatter();
            yield return new Infrastructure.Formatters.XmlAidAttributeFormatter();
        }
        protected List<IXmlAidFormatter> Formatters
        {
            get { return _formatters ?? (_formatters = new List<IXmlAidFormatter>(this.DefaultFormatters())); }
            set { _formatters = value; }
        }

        public XmlAidHelper()
        {
            
        }

        public XmlAidHelper(IEnumerable<IXmlAidFormatter> formatters)
            :this()
        {
            this.Formatters = new List<IXmlAidFormatter>(formatters);
        }
    }
}
