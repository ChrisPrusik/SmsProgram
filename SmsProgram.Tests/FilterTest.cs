using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SmsProgram.Tests
{
    [TestClass]
    public class FilterTest
    {
        [TestMethod]
        public void DecodeFilterFullNameTest()
        {
            Assert.AreEqual("Nazwa filtra", Filter.DecodeFullName("Nazwa filtra|"));
            Assert.AreEqual("Nazwa filtra", Filter.DecodeFullName("Nazwa filtra   |"));
            Assert.AreEqual("Nazwa filtra", Filter.DecodeFullName("Nazwa filtra| adhskj dskljdhkds"));
            Assert.AreEqual("Nazwa filtra", Filter.DecodeFullName(" Nazwa filtra| adhskj dskljdhkds"));
            Assert.AreEqual("", Filter.DecodeFullName("|Nazwa filtra"));
            Assert.AreEqual("", Filter.DecodeFullName("taki tam"));
        }

        [TestMethod]
        public void DecodeFilterTableNameTest()
        {
            Assert.AreEqual("Table", Filter.DecodeTableName("Table.Nazwa filtra|"));
            Assert.AreEqual("Table", Filter.DecodeTableName("  Table  .   Nazwa filtra   |"));
            Assert.AreEqual("", Filter.DecodeTableName("Nazwa filtra| adhskj dskljdhkds"));
            Assert.AreEqual("", Filter.DecodeTableName(" Nazwa filtra| adhskj dskljdhkds"));
            Assert.AreEqual("", Filter.DecodeTableName("Nazwa filtra|"));
            Assert.AreEqual("", Filter.DecodeTableName("taki tam"));
        }

        [TestMethod]
        public void DecodeFilterShortNameTest()
        {
            Assert.AreEqual("Nazwa filtra", Filter.DecodeShortName("Table.Nazwa filtra|"));
            Assert.AreEqual("Nazwa filtra", Filter.DecodeShortName("  Table  .   Nazwa filtra   |"));
            Assert.AreEqual("Nazwa filtra", Filter.DecodeShortName("Nazwa filtra| adhskj dskljdhkds"));
            Assert.AreEqual("Nazwa filtra", Filter.DecodeShortName(" Nazwa filtra| adhskj dskljdhkds"));
            Assert.AreEqual("", Filter.DecodeShortName("|Nazwa filtra"));
            Assert.AreEqual("", Filter.DecodeShortName("taki tam"));
        }

        [TestMethod]
        public void DecodeFilterExpressionTest()
        {
            Assert.AreEqual("", Filter.DecodeExpression("Nazwa filtra|"));
            Assert.AreEqual("", Filter.DecodeExpression("Nazwa filtra   |"));
            Assert.AreEqual("PhoneNumber = 12", Filter.DecodeExpression("Nazwa filtra| PhoneNumber = 12"));
            Assert.AreEqual("PhoneNumber = 12", Filter.DecodeExpression(" Nazwa filtra|      PhoneNumber = 12    "));
            Assert.AreEqual("PhoneNumber = 12", Filter.DecodeExpression(" Nazwa filtra|PhoneNumber = 12"));
            Assert.AreEqual("PhoneNumber = 12", Filter.DecodeExpression(" PhoneNumber = 12"));
        }

        [TestMethod]
        public void EncodeTest()
        {
            Assert.AreEqual("Table.Nazwa filtra| filtr", Filter.Encode("Table", "Nazwa filtra", "  filtr  "));
            Assert.AreEqual("Nazwa filtra| filtr", Filter.Encode("   ", "Nazwa filtra", "     filtr   "));
        }

        [TestMethod]
        public void RemoveTableTest()
        {
            Assert.AreEqual("Nazwa filtra| filtr", Filter.RemoveTable("Table.Nazwa filtra| filtr"));
            Assert.AreEqual("Nazwa filtra|", Filter.RemoveTable("Table.Nazwa filtra|"));
            Assert.AreEqual("", Filter.RemoveTable("Table.|"));
            Assert.AreEqual("", Filter.RemoveTable("|"));
            Assert.AreEqual("filtr", Filter.RemoveTable("  filtr  "));
        }

        [TestMethod]
        public void InsertTableTest()
        {
            Assert.AreEqual("Table.Nazwa filtra| filtr", Filter.InsertTable("Table.Nazwa filtra| filtr", "Table"));
            Assert.AreEqual("Nazwa filtra|", Filter.InsertTable("Nazwa filtra|", ""));
            Assert.AreEqual("Table.|", Filter.InsertTable("|", "Table"));
            Assert.AreEqual("Table.|", Filter.InsertTable("", "Table"));
            Assert.AreEqual("Table.| filtr", Filter.InsertTable("filtr", "Table"));
        }
    }
}
