using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmsProgram.Model;

namespace SmsProgram.Tests
{
    [TestClass]
    public class ProvidersTest
    {
        [TestMethod]
        public void LoadTest()
        {
            StringBuilder fileText = new StringBuilder();
            fileText.AppendLine("@Fields: Type, Provider, HomePageUrl, AllowAnswer, IsHardware, DefaultUnitCost");
            fileText.AppendLine("sms, Ovation, http://www.novatelwireless.com, 1, 1, 0.05");
            fileText.AppendLine("sms, Merlin, http://www.novatelwireless.com, 1, 1, 0.05");
            fileText.AppendLine("sms, Novatel, http://www.novatelwireless.com, 1, 1, 0.05");
            fileText.AppendLine("sms, Nokia, http://www.novatelwireless.com, 1, 1, 0.05");
            fileText.AppendLine("sms, SmsApiEcoSms, http://smsapi.pl, 1, 0, 0.07");
            fileText.AppendLine("sms, SmsApiProSms, http://smsapi.pl, 1, 0, 0.165");
            fileText.AppendLine("sms, SmsApiProSmsOutside, http://smsapi.pl, 1, 0, 0.027");

            SmsProject project = MyModel.Init();
            project.Providers.Read(fileText);
            Assert.AreEqual(7, project.Providers.Rows.Count);

            SmsProject.ProvidersRow row = project.Providers.FindByProviderType(
                DeliveryProviders.Merlin, DeliveryTypes.Sms);
            Assert.IsNotNull(row);

            Assert.AreEqual("sms", row.Type);
            Assert.AreEqual("Merlin", row.Provider);
            Assert.AreEqual("http://www.novatelwireless.com", row.HomePageUrl);
            Assert.AreEqual(true, row.AllowAnswer);
            Assert.AreEqual(true, row.IsInternal);
            Assert.AreEqual((decimal)0.05, row.DefaultUnitCost);

            StringBuilder settingsText = new StringBuilder();
            settingsText.AppendLine("@Fields: Type, Provider, UserName, Password");
            settingsText.AppendLine("sms, SmsApiEcoSms, loginek, haselko");
            project.Providers.Read(settingsText);

            row = project.Providers.FindByProviderType(DeliveryProviders.SmsApiEcoSms, DeliveryTypes.Sms);
            Assert.IsNotNull(row);
            Assert.AreEqual("sms", row.Type);
            Assert.AreEqual("SmsApiEcoSms", row.Provider);
            Assert.AreEqual("loginek", row.UserName);
            Assert.AreEqual("haselko", row.Password);
        }
    }
}
