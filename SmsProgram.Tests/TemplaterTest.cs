using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SmsProgram.Tests
{
    [TestClass]
    public class TemplaterTest
    {
        [TestMethod]
        public void ToValueLetterCaseTest()
        {
            Assert.AreEqual("-ala-", Templater.ToValue("-[field]-", "field", "ala"));
            Assert.AreEqual("-ala-", Templater.ToValue("-[Field]-", "field", "ala"));
            Assert.AreEqual("-ala-", Templater.ToValue("-[fIeld]-", "fieLd", "ala"));
        }

        [TestMethod]
        public void ToValueDifferentPlacesTest()
        {
            Assert.AreEqual("ala-", Templater.ToValue("[field]-", "field", "ala"));
            Assert.AreEqual("-ala", Templater.ToValue("-[Field]", "field", "ala"));
            Assert.AreEqual("ala", Templater.ToValue("[fIeld]", "fieLd", "ala"));
        }

        [TestMethod]
        public void ToValueMoreTimesTest()
        {
            Assert.AreEqual("ala ala", Templater.ToValue("[fIeld] [fIeld]", "fieLd", "ala"));
            Assert.AreEqual("-ala ala", Templater.ToValue("-[fIeld] [fIeld]", "fieLd", "ala"));
            Assert.AreEqual("ala ala-", Templater.ToValue("[fIeld] [fIeld]-", "fieLd", "ala"));
        }

        [TestMethod]
        public void ToValueTrimTest()
        {
            Assert.AreEqual("-ala ala-", Templater.ToValue("-[ fIeld] [ fIeld ]-", "fieLd", "ala"));
            Assert.AreEqual("-ala ala-", Templater.ToValue("-[ fIeld] [ fIeld ]-", "fieLd", "ala"));
            Assert.AreEqual("-ala ala-", Templater.ToValue("-[ fIeld] [ fIeld ]-", "fieLd", "ala"));
        }

        [TestMethod]
        public void ToValueRecursionTest()
        {
            Assert.AreEqual("-[ [ field ] fIeld] ala-", 
                Templater.ToValue("-[ [ field ] fIeld] [ fIeld ]-", "fieLd", "ala"));
        }

        [TestMethod]
        public void ToValueBadBracketsTest()
        {
            Assert.AreEqual("-fIeld] ala-", Templater.ToValue("-fIeld] [ fIeld ]-", "fieLd", "ala"));
            Assert.AreEqual("-[fIeld [ fIeld ]-", Templater.ToValue("-[fIeld [ fIeld ]-", "fieLd", "ala"));
        }

        [TestMethod]
        public void ToValueWithDateFormatText()
        {
            Assert.AreEqual("-2010-10-01 00:00:00-",
                Templater.ToValue("-[Datka]-", "datka", new DateTime(2010, 10, 1)));
            Assert.AreEqual("-2010-10-01-", 
                Templater.ToValue("-[Datka:yyyy-MM-dd]-", "datka", new DateTime(2010, 10, 1)));
        }

        [TestMethod]
        public void ToValueWithIntFormatText()
        {
            Assert.AreEqual("-2010-", Templater.ToValue("-[Int]-", "int", 2010));
            Assert.AreEqual("-002010-", Templater.ToValue("-[Int:000000]-", "Int", 2010));
        }

        [TestMethod]
        public void ToValueWithDoubleFormatText()
        {
            Assert.AreEqual("-2010,15-", Templater.ToValue("-[double]-", "double", 2010.15));
            Assert.AreEqual("-002010,150-", Templater.ToValue("-[Double:000000.000]-", "Double", 2010.15));
        }

        [TestMethod]
        public void ToValueQuotedTest()
        {
            Assert.AreEqual("Please enter correct data. Kolumna 'SendDate' nie zezwala na wartości zerowe.",
                Templater.ToValue("Please enter correct data. Kolumna 'SendDate' nie zezwala na wartości zerowe.", 
                "index", "test"));
            Assert.AreEqual("Please enter correct data. Kolumna [Data utworzenia] nie zezwala na wartości zerowe.",
                Templater.ToValue("Please enter correct data. Kolumna 'SendDate' nie zezwala na wartości zerowe.",
                "senddate", "[Data utworzenia]"));

            Assert.AreEqual("test", Templater.ToValue("'field'", "field", "test"));
            Assert.AreEqual("field'", Templater.ToValue("field'", "field", "test"));
            Assert.AreEqual("'field", Templater.ToValue("'field", "field", "test"));
        }

        [TestMethod]
        public void ToValueWithReplaceBracketTest()
        {
            Assert.AreEqual("[Second]", Templater.ToValue("[First]", "first", "[Second]"));
            Assert.AreEqual("  [Second]", Templater.ToValue("  [First]", "first", "[Second]"));
            Assert.AreEqual("[Second]  ", Templater.ToValue("[First]  ", "first", "[Second]"));

            Assert.AreEqual("Created [CreateDate] modified [ModifyDate]\r\nby [Login] on [Computer]",
                Templater.ToValue("Created [CreateDate] modified [ModifyDate]\r\nby [Login] on [Computer]",
                    "Computer", "[Computer]"));
        }

        [TestMethod]
        public void ToCaptionsTest()
        {
            DataTable table = new DataTable();
            DataColumn column1 = table.Columns.Add();
            column1.ColumnName = "first";
            column1.Caption = "Przykład pierwszy";
            DataColumn column2 = table.Columns.Add();
            column2.ColumnName = "second";
            column2.Caption = "Druga kolumna";

            Assert.AreEqual("-[Przykład pierwszy]-", Templater.ToCaptions(table.Columns, "-[Przykład pierwszy]-"));
            Assert.AreEqual("-[Druga kolumna]-", Templater.ToCaptions(table.Columns, "-[Druga kolumna]-"));

            Assert.AreEqual("-[Przykład pierwszy]-", Templater.ToCaptions(table.Columns, "-[first]-"));
            Assert.AreEqual("-[Przykład pierwszy]-", Templater.ToCaptions(table.Columns, "-[ first ]-"));
            Assert.AreEqual("-[Przykład pierwszy]/[Druga kolumna]-", Templater.ToCaptions(table.Columns, "-[ first ]/[second]-"));
            Assert.AreEqual("-[Druga kolumna]-", Templater.ToCaptions(table.Columns, "-[ second ]-"));
        }

        [TestMethod]
        public void ToNamesTest()
        {
            DataTable table = new DataTable();
            DataColumn column1 = table.Columns.Add();
            column1.ColumnName = "first";
            column1.Caption = "Przykład pierwszy";
            DataColumn column2 = table.Columns.Add();
            column2.ColumnName = "second";
            column2.Caption = "Druga kolumna";

            Assert.AreEqual("-[first]-", Templater.ToNames(table.Columns, "-[first]-"));
            Assert.AreEqual("-[second]-", Templater.ToNames(table.Columns, "-[second]-"));

            Assert.AreEqual("-[first]-", Templater.ToNames(table.Columns, "-[Przykład pierwszy]-"));
            Assert.AreEqual("-[first]-", Templater.ToNames(table.Columns, "-[ Przykład pierwszy ]-"));
            Assert.AreEqual("-[first]/[second]-", Templater.ToNames(table.Columns, "-[ Przykład pierwszy ]/[Druga kolumna]-"));
            Assert.AreEqual("-[second]-", Templater.ToNames(table.Columns, "-[ Druga kolumna ]-"));
        }
    }
}
