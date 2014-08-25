using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpecAid.XmlAid;

namespace SpecAid.XmlAidTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class XmlAidViewTests
    {
        [TestMethod]
        public void ToString_IncludesFullPathAndValue()
        {
            var unit = new XmlAidView()
                           {
                               NodeName = "TEST",
                               Value = "RESULT",
                               Level = 5
                           };

            Assert.AreEqual(".....TEST=RESULT", unit.ToString());
        }

        [TestMethod]
        public void Equals_DifferentLevel_AreNotEqual()
        {
            var unit1 = new XmlAidView()
            {
                NodeName = "TEST",
                Value = "RESULT",
                Level = 5
            };
            var unit2 = new XmlAidView()
            {
                NodeName = "TEST",
                Value = "RESULT",
                Level = 6
            };
            Assert.AreNotEqual(unit1, unit2);
        }

        [TestMethod]
        public void Equals_DifferentNodeName_AreNotEqual()
        {
            var unit1 = new XmlAidView()
            {
                NodeName = "TEST",
                Value = "RESULT",
                Level = 5
            };
            var unit2 = new XmlAidView()
            {
                NodeName = "TESTT",
                Value = "RESULT",
                Level = 5
            };
            Assert.AreNotEqual(unit1, unit2);
        }

        [TestMethod]
        public void Equals_DifferentValue_AreNotEqual()
        {
            var unit1 = new XmlAidView()
            {
                NodeName = "TEST",
                Value = "RESULT",
                Level = 5
            };
            var unit2 = new XmlAidView()
            {
                NodeName = "TEST",
                Value = "RESULTT",
                Level = 5
            };

            Assert.AreNotEqual(unit1, unit2);
        }

        [TestMethod]
        public void ReferenceEquals_DifferentValue_IsFalse()
        {
            var unit1 = new XmlAidView()
            {
                NodeName = "TEST",
                Value = "RESULT",
                Level = 5
            };
            var unit2 = new XmlAidView()
            {
                NodeName = "TEST",
                Value = "RESULTT",
                Level = 5
            };

            Assert.IsFalse(object.ReferenceEquals(unit1, unit2));
        }

        [TestMethod]
        public void ReferenceEquals_DifferentValue_IsTrue()
        {
            var unit1 = new XmlAidView()
            {
                NodeName = "TEST",
                Value = "RESULT",
                Level = 5
            };
            var unit2 = new XmlAidView()
            {
                NodeName = "TEST",
                Value = "RESULT",
                Level = 5
            };

            Assert.IsFalse(object.ReferenceEquals(unit1, unit2));
        }

        [TestMethod]
        public void ReferenceEquals_Rhs_IsTrue()
        {
            var unit1 = new XmlAidView()
            {
                NodeName = "TEST",
                Value = "RESULT",
                Level = 5
            };

            Assert.IsTrue(unit1.Equals(unit1));
        }

        [TestMethod]
        public void ReferenceEquals_RhsNull_IsFalse()
        {
            var unit = new XmlAidView()
            {
                NodeName = "TEST",
                Value = "RESULT",
                Level = 5
            };

            XmlAidView unit2 = null;

            Assert.IsFalse(unit.Equals(unit2));
        }
        [TestMethod]
        public void Equals_DifferentInstances_AreEqual()
        {
            var unit1 = new XmlAidView()
            {
                NodeName = "TEST",
                Value = "RESULT",
                Level = 5
            };
            var unit2 = new XmlAidView()
            {
                NodeName = "TEST",
                Value = "RESULT",
                Level = 5
            };

            Assert.AreEqual(unit1, unit2);
        }

        [TestMethod]
        public void Equals_SameInstance_AreEqual()
        {
            var unit1 = new XmlAidView()
            {
                NodeName = "TEST",
                Value = "RESULT",
                Level = 5
            };
            Assert.AreEqual(unit1, unit1);
        }

        [TestMethod]
        public void Equals_Null_AreNotEqual()
        {
            var unit1 = new XmlAidView()
            {
                NodeName = "TEST",
                Value = "RESULT",
                Level = 5
            };
            Assert.AreNotEqual(unit1, null);
        }

        [TestMethod]
        public void Equals_CastedObjectNull_AreNotEqual()
        {
            var unit1 = new XmlAidView()
            {
                NodeName = "TEST",
                Value = "RESULT",
                Level = 5
            };

            XmlAidView unit2 = null;

            Assert.IsFalse(unit1.Equals((Object)unit2));
        }

        [TestMethod]
        public void Equals_CastedObject_AreEqual()
        {
            var unit1 = new XmlAidView()
            {
                NodeName = "TEST",
                Value = "RESULT",
                Level = 5
            };

            var unit2 = new XmlAidView()
            {
                NodeName = "TEST",
                Value = "RESULT",
                Level = 5
            };

            Assert.IsFalse(unit1.Equals((Object)unit2));
        }

        [TestMethod]
        public void Equals_OtherCastedObject_AreEqual()
        {
            var unit1 = new XmlAidView()
            {
                NodeName = "TEST",
                Value = "RESULT",
                Level = 5
            };

            Object unit2 = new XmlAidView()
            {
                NodeName = "TEST",
                Value = "RESULT",
                Level = 5
            };

            Assert.IsTrue(unit1.Equals(unit2));
        }
        [TestMethod]
        public void EqualOp_SameInstance_IsTrue()
        {
            var unit1 = new XmlAidView()
            {
                NodeName = "TEST",
                Value = "RESULT",
                Level = 5
            };

            Assert.IsTrue(unit1 == unit1);
        }

        [TestMethod]
        public void EqualOp_DifferentInstances_IsTrue()
        {
            var unit1 = new XmlAidView()
            {
                NodeName = "TEST",
                Value = "RESULT",
                Level = 5
            };

            var unit2 = new XmlAidView()
            {
                NodeName = "TEST",
                Value = "RESULT",
                Level = 5
            };

            Assert.IsTrue(unit1 == unit2);
        }

        [TestMethod]
        public void GetHashCode_NodeNameNull()
        {
            var unit1 = new XmlAidView()
            {
                NodeName = null,
                Value = "RESULT",
                Level = 5
            };

            int expected = unit1.Level;
            expected = (expected*397) ^ 0;
            expected = (expected*397) ^ "RESULT".GetHashCode();

            Assert.AreEqual(unit1.GetHashCode(), expected);
        }

        [TestMethod]
        public void GetHashCode_NodeValueNull()
        {
            string nodeName = "TEST";
            string nodeValue = null;
            int level = 5;

            var unit1 = new XmlAidView()
            {
                NodeName = nodeName,
                Value = nodeValue,
                Level = level
            };

            int expected = level;
            expected = (expected * 397) ^ (nodeName == null ? 0 : nodeName.GetHashCode());
            expected = (expected * 397) ^ (nodeValue==null ? 0 : nodeValue.GetHashCode());

            Assert.AreEqual(unit1.GetHashCode(), expected);
        }

        [TestMethod]
        public void FullPath_WhenLevel0_EqualsNodeName()
        {
            var unit1 = new XmlAidView()
            {
                NodeName = "TEST",
                Value = "RESULT",
                Level = 0
            };

            Assert.AreEqual("TEST", unit1.FullPath);
        }
    }
}
