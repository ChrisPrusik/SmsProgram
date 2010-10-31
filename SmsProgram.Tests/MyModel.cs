using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SmsProgram;
using SmsProgram.Model;

namespace SmsProgram.Tests
{
    public static class MyModel
    {
        public static void Init(SmsProject dataSet)
        {
            dataSet.InitDelegates();
            dataSet.Properties.AddPropertiesRow("Kampanie PK-Soft",
                "KAP", "Wszystkie kampanie smsowe realizowane przez firmę");

            SmsProject.CompaniesRow company = dataSet.Companies.AddCompaniesRow("PK-Soft Sp. z o.o.");
            company.Description = "Moja firma";
            SmsProject.GroupsRow group = dataSet.Groups.AddGroupsRow("VIP");
            group.Description = "Grupa najlepszych";

            SmsProject.ContactsRow kap = dataSet.Contacts.AddContactsRow("510236587");
            kap.MobilePhoneNumber = "510236587";
            kap.FirstName = "Krzysztof Arkadiusz";
            kap.LastName = "Prusik";
            kap.CompaniesRow = company;
            kap.GroupsRow = group;
            kap.Email = "kap@pk-soft.com";
            kap.Url = "http://kap1.salon24.pl";
            kap.Description = "Ja we własnej osobie";
            kap.Title = "CEO";
            kap.HomeStreet = "Al. Jana Pawła II 61/144";
            kap.HomeCity = "Warszawa";
            kap.HomePostCode = "01-031";
            kap.HomeState = "Mazowieckie";
            kap.HomeCountry = "Polska";
            kap.BirthDate = new DateTime(1973, 8, 30);
            kap.Token = "1234";
            kap.Source = "Clipboard";

            SmsProject.ContactsRow agp = dataSet.Contacts.AddContactsRow("504128737");
            agp.MobilePhoneNumber = "504128737";
            agp.FirstName = "Ariadna";
            agp.LastName = "Gołębicka";
            agp.CompaniesRow = company;
            agp.GroupsRow = group;
            agp.Email = "ariadna@pk-soft.com";
            agp.Url = "http://pk-soft.com";
            agp.Description = "żonka";
            agp.Title = "";
            agp.HomeStreet = "Al. Jana Pawła II 61/144";
            agp.HomeCity = "Warszawa";
            agp.HomePostCode = "01-031";
            agp.HomeState = "Mazowieckie";
            agp.HomeCountry = "Polska";
            agp.BirthDate = new DateTime(1973, 8, 1);
            agp.Token = "1111";
            agp.Source = "Clipboard";

            SmsProject.MessagesRow message = dataSet.Messages.AddMessagesRow("PrzypomnienieX");
            message.Description = "Przypomnienie o zajęciach w sali gimnastycznej X";
            message.MessageTopic = "Przypomnienie";
            message.MessageText = "Zajęcia odbywają się w sali X o godzinie YY";

            SmsProject.MessagesRow m2 = dataSet.Messages.AddMessagesRow("Płatność");
            m2.Description = "Prośba o płatność";
            m2.MessageTopic = "Przypomnienie";
            m2.MessageText = "Uprzejmie prosimy o uregulowanie płatności za fakturę XXX z dnia YYY";

            SmsProject.ProvidersRow provider = dataSet.Providers.AddProvidersRow(DeliveryTypes.Sms, DeliveryProviders.Novatel,
                "", true, true, 0);

            SmsProject.CampaignsRow campaign = dataSet.Campaigns.AddCampaignsRow("Wysyłka1");
            campaign.Description = "Pierwsze przypomnienie o płatności";
            campaign.MessagesRow = message;
            campaign.Code = "Kodzik1";
            campaign.ProvidersRowParent = provider;

            SmsProject.SentRow sent1 = dataSet.Sent.AddSentRow("1");
            sent1.ContactsRow = kap;
            sent1.SendDate = DateTime.Now;
            sent1.ProvidersRowParent = provider;
            sent1.ToAddress = kap.Email;
            sent1.CampaignsRow = campaign;
            sent1.TemplatesRow = message;


            SmsProject.SentRow sent2 = dataSet.Sent.AddSentRow("2");
            sent2.ContactsRow = kap;
            sent2.SendDate = DateTime.Now;
            sent2.ProvidersRowParent = provider;
            sent2.ToAddress = agp.Email;
            sent2.CampaignsRow = campaign;
            sent2.TemplatesRow = message;

            SmsProject.ReceivedRow received1 = dataSet.Received.AddReceivedRow("3");
            received1.ContactsRow = kap;
            received1.ReceivedDate = DateTime.Now;
            received1.ProvidersRowParent = provider;
            received1.MessageText = "taki tam sms";
            received1.CampaignsRow = campaign;

            SmsProject.ReceivedRow received2 = dataSet.Received.AddReceivedRow("4");
            received2.ContactsRow = kap;
            received2.ReceivedDate = DateTime.Now;
            received2.ProvidersRowParent = provider;
            received2.MessageText = "taki tam sms";
            received2.CampaignsRow = campaign;

            // UNDONE: Czy AcceptChanges jest potrzebne? Jak nie to wyrzucić wszystkie!
            dataSet.AcceptChanges();
        }

        public static SmsProject Init()
        {
            SmsProject project = new SmsProject();
            project.InitDelegates();
            Init(project);
            return project;
        }
    }
}