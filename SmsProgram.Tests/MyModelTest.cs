using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmsProgram;
using SmsProgram.Model;

namespace SmsProgram.Tests
{
    [TestClass]
    public class MyModelTest
    {
        [TestMethod]
        public void IntegrityTest()
        {
            SmsProject project = MyModel.Init();
            foreach(DataTable table in project.Tables)
                if (table.TableName != project.Columns.TableName && 
                    table.TableName != project.LookupList.TableName) 
                    foreach (DataColumn column in table.Columns)
                    {
                        if (column.AllowDBNull == false)
                            Assert.IsTrue(column.ColumnName == table.PrimaryKey[0].ColumnName ||
                                column.DefaultValue != null);
                        foreach (DataRelation relation in project.Relations)
                            if (relation.ChildTable == table &&
                                relation.ChildColumns[0].ColumnName == column.ColumnName)
                                Assert.AreEqual(relation.ParentColumns[0].ColumnName, column.ColumnName);
                    }
        }

        [TestMethod]
        public void CountTest()
        {
            SmsProject project = MyModel.Init();
            Assert.AreEqual(1, project.Companies.Count);
            project.Validate();

            Assert.IsNotNull(project.Companies.FindByCompany("PK-Soft Sp. z o.o."));
            Assert.AreEqual(4, project.Companies[0].AllCount);
            Assert.AreEqual(2, project.Companies[0].SentCount);
            Assert.AreEqual(2, project.Companies[0].ReceivedCount);
            Assert.AreEqual(2, project.Companies[0].ContactsCount);

            Assert.AreEqual(2, project.Contacts.FindByContact("510236587").SentCount);
            Assert.AreEqual(2, project.Contacts.FindByContact("510236587").ReceivedCount);
            Assert.AreEqual(4, project.Contacts.FindByContact("510236587").AllCount);

            Assert.AreEqual(0, project.Contacts.FindByContact("504128737").SentCount);
            Assert.AreEqual(0, project.Contacts.FindByContact("504128737").ReceivedCount);
            Assert.AreEqual(0, project.Contacts.FindByContact("504128737").AllCount);

            Assert.AreEqual(2, project.Campaigns.FindByCampaign("Wysyłka1").SentCount);
            Assert.AreEqual(2, project.Campaigns.FindByCampaign("Wysyłka1").ReceivedCount);
            Assert.AreEqual(4, project.Campaigns.FindByCampaign("Wysyłka1").AllCount);

            Assert.AreEqual(2, project.Groups.FindByGroup("VIP").SentCount);
            Assert.AreEqual(2, project.Groups.FindByGroup("VIP").ReceivedCount);
            Assert.AreEqual(4, project.Groups.FindByGroup("VIP").AllCount);

            Assert.AreEqual(2, project.Messages.FindByMessage("PrzypomnienieX").SentCount);
            Assert.IsTrue(project.Messages.FindByMessage("Płatność").IsSentCountNull());
        }

        [TestMethod]
        public void CustomFieldsTest()
        {
            SmsProject project = MyModel.Init();

            int contactsColumnCount = project.Contacts.Columns.Count;
            Assert.AreEqual(0, project.CustomFields.Count);
            SmsProject.CustomFieldsRow pkwiu = project.CustomFields.AddCustomFieldsRow(
                project.Contacts.TableName, "KlientPKWiU");
            Assert.AreEqual(1, project.CustomFields.Count);
            Assert.AreEqual(contactsColumnCount + 1, project.Contacts.Columns.Count);

            SmsProject.CustomFieldsRow mojaKategoria = project.CustomFields.AddCustomFieldsRow(
                project.Contacts.TableName, "MojaKategoria");
            Assert.AreEqual(2, project.CustomFields.Count);
            Assert.AreEqual(contactsColumnCount + 2, project.Contacts.Columns.Count);
            
            SmsProject.CustomFieldsRow zaplacil = project.CustomFields.AddCustomFieldsRow(
                project.Contacts.TableName, "Zapłacił");
            Assert.AreEqual(3, project.CustomFields.Count);
            Assert.AreEqual(contactsColumnCount + 3, project.Contacts.Columns.Count);

            SmsProject.ContactsRow kap = project.Contacts.FindByContact("510236587");
            kap["KlientPKWiU"] = "TAK";
            kap["Zapłacił"] = "TAK";

            Assert.AreEqual("TAK", project.Contacts.FindByContact("510236587")["KlientPKWiU"].ToString());
            Assert.AreEqual("TAK", project.Contacts.FindByContact("510236587")["Zapłacił"].ToString());

            SmsProject.ContactsRow agp = project.Contacts.FindByContact("504128737");
            agp["KlientPKWiU"] = "NIE";
            agp["Zapłacił"] = "TAK";

            Assert.AreEqual("NIE", project.Contacts.FindByContact("504128737")["KlientPKWiU"].ToString());
            Assert.AreEqual("TAK", project.Contacts.FindByContact("504128737")["Zapłacił"].ToString());
        }

        [TestMethod]
        public void AddRowsTest()
        {
            // UNDONE: Automatyczne nadawanie daty i godziny nie działa prawidłowo
            /*
            SmsProject project = MyModel.Init();
            foreach(DataTable table in project.Tables)
                if (table.TableName != "Columns" && table.TableName != "LookupList")
                {
                    DataRow row = table.Rows.Add("XXX");
                    Assert.IsNotNull(row);
                    Assert.IsNotNull(row["CreateDate"]);
                    Assert.IsNotNull(row["ModifyDate"]);
                    Assert.IsFalse(row["CreateDate"] is DBNull);
                    Assert.IsFalse(row["ModifyDate"] is DBNull);
                    DateTime createDate = (DateTime)row["CreateDate"];
                    DateTime modifyDate = (DateTime)row["CreateDate"];
                    Assert.AreEqual(DateTime.Now.Year, createDate.Year);
                    Assert.AreEqual(DateTime.Now.Year, modifyDate.Year);
                    Assert.AreEqual(DateTime.Now.Month, createDate.Month);
                    Assert.AreEqual(DateTime.Now.Month, modifyDate.Month);
                    Assert.AreEqual(DateTime.Now.Day, createDate.Day);
                    Assert.AreEqual(DateTime.Now.Day, modifyDate.Day);
                    //DataRow addRow = 
                }
             */
        }

        [TestMethod]
        public void EncryptDecryptTest()
        {
            // TODO: Decrypt i Encrypt przenieść do oddzielnej klasy!
            SmsProject project = MyModel.Init();
            Assert.AreEqual("test", project.Decrypt(project.Encrypt("test")));
        }

    }
}