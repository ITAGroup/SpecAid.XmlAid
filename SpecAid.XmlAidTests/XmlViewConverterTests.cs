using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpecAid.XmlAid;
using SpecAid.XmlAid.Infrastructure;
using SpecAid.XmlAid.Infrastructure.Formatters;

namespace SpecAid.XmlAidTests
{
    [TestClass]
    public class XmlViewConverterTests
    {
        private List<IXmlAidFormatter> _formatters;
        private XmlAidViewConverter _converter;

        [TestInitialize]
        public void Init()
        {
            _converter = new XmlAidViewConverter();
            _formatters = new List<IXmlAidFormatter>()
                              {
                                  new XmlAidAttributeFormatter(),
                                  new XmlAidElementFormatter()
                              };
        }

        [TestMethod]
        public void Convert_XmlWithOneLevelDeep_ShowsLevel0()
        {
            var doc = new XDocument(new XElement("root", "test1"));
            var results = _converter.Convert(doc, _formatters).ToList();
            Assert.AreEqual(0, results.First().Level);
        }

        [TestMethod]
        public void Convert_XmlElementWithAttribute_MatchesElementLevel()
        {
            var doc = new XDocument(new XElement("root", new XAttribute("foo", "bar")));
            var results = _converter.Convert(doc, _formatters).ToList();
            Assert.AreEqual(results.First().Level, results.Last().Level);
        }

        [TestMethod]
        public void Convert_XmlWithOneLevelDeepWithAttribute_ShowsLevel0()
        {
            var doc = new XDocument(new XElement("root", new XAttribute("foo", "bar")));
            var results = _converter.Convert(doc, _formatters).ToList();
            Assert.AreEqual(0, results.Last().Level);
        }

        [TestMethod]
        public void Convert_XmlWithTwoLevelsDeep_ShowsLevel1()
        {
            var doc = new XDocument(new XElement("root", new XElement("nested", "value")));

            var results = _converter.Convert(doc, _formatters).ToList();

            Assert.AreEqual(1, results.Last().Level);
        }

        [TestMethod]
        public void Convert_XmlWithThreeLevelsDeep_ShowsLevel2()
        {
            var doc = new XDocument(new XElement("root", new XElement("nested", new XElement("level3", "value"))));

            var results = _converter.Convert(doc, _formatters).ToList();

            Assert.AreEqual(2, results.Last().Level);
        }

        [TestMethod]
        public void Convert_XmlAttribute_NodeName_HasAttributePrefix()
        {
            var doc = new XDocument(new XElement("root", new XAttribute("attribute1", "value")));
            var results = _converter.Convert(doc, _formatters).ToList();
            Assert.AreEqual(XmlAidView.AttributePrefix + "attribute1", results.Last().NodeName);
        }

        [TestMethod]
        public void Convert_XmlElement_NodeName_DoesNotHaveAttributePrefix()
        {
            var doc = new XDocument(new XElement("root", new XElement("element1", "value")));
            var results = _converter.Convert(doc, _formatters).ToList();
            Assert.AreEqual("element1", results.Last().NodeName);
        }

        [TestMethod]
        public void Convert_WithRootAndElement_FullPath_IsIndented()
        {
            var doc = new XDocument(new XElement("root", new XElement("element1", "value")));
            var results = _converter.Convert(doc, _formatters).ToList();
            Assert.AreEqual(XmlAidView.IndentChar + "element1", results.Last().FullPath);
        }

        [TestMethod]
        public void Convert_WithRootAndElementAndAttribute_FullPath_IsIndented()
        {
            var doc = new XDocument(new XElement("root", new XElement("element1", new XAttribute("foo", "value"))));
            var results = _converter.Convert(doc, _formatters).ToList();
            Assert.AreEqual(XmlAidView.IndentChar + "+foo", results.Last().FullPath);
        }

        [TestMethod]
        public void Convert_XmlThreeNestedElementAndTwoAttribute()
        {
            var expected = new[]
                               {
                                   new XmlAidView()
                                       {
                                           Level = 0,
                                           NodeName = "root",
                                       },
                                   new XmlAidView()
                                       {
                                           Level = 1,
                                           NodeName = "element1",
                                       },
                                    new XmlAidView()
                                    {
                                        Level = 2,
                                        NodeName = "element2",
                                    },
                                    new XmlAidView()
                                    {
                                        Level = 2,
                                        NodeName = "+attribute1",
                                        Value = "attribute1 value"
                                    },
                                    new XmlAidView()
                                    {
                                        Level = 2,
                                        NodeName = "+attribute2",
                                        Value = "attribute2 value"
                                    }
                               };
            var doc = new XDocument(
                new XElement("root",
                             new XElement("element1",
                                          new XElement("element2",
                                                       new XAttribute("attribute1", "attribute1 value"),
                                                       new XAttribute("attribute2", "attribute2 value"))
                                 )));

            var results = _converter.Convert(doc, _formatters).ToList();

            Assert.IsTrue(expected.SequenceEqual(results));
        }
    }
}
