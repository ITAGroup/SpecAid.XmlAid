using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpecAid.XmlAid;

namespace SpecAid.XmlAidTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class XmlAidViewConverterTests
    {
        private IXmlAidViewConverter _xmlAidViewConverter;

        [TestInitialize]
        public void Init()
        {
            _xmlAidViewConverter = new XmlAidViewConverter();
        }
        [TestMethod]
        public void Format_WithNoFormatters_CountEquals0()
        {
            var formatters = new List<IXmlAidFormatter>();

            var doc = new XDocument(new XElement("Foo"));
            var result = _xmlAidViewConverter.Convert(doc, formatters);

            Assert.AreEqual(0, result.Count());
        }
    }
}
