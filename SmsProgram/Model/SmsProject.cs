using System;
using System.Data;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using System.Security.Cryptography;
using Ionic.Zip;
using SmsProgram.Properties;

namespace SmsProgram.Model 
{
    public partial class SmsProject 
    {
        partial class CustomFieldsDataTable
        {
            public CustomFieldsRow AddCustomFieldsRow(string table, string field)
            {
                CustomFieldsRow row = (CustomFieldsRow)Rows.Add(table, field);
                row.CreateDate = DateTime.Now;
                row.ModifyDate = DateTime.Now;
                return row;
            }
        }
    
        partial class PropertiesDataTable
        {
            public PropertiesRow AddPropertiesRow(string title, string author, string description)
            {
                PropertiesRow row = AddPropertiesRow();
                row.Title = title;
                row.Author = author;
                row.Description = description;
                return row;
            }

            public PropertiesRow AddPropertiesRow()
            {
                PropertiesRow row = (PropertiesRow)Rows.Add(Guid.NewGuid().ToString());
                row.Computer = Environment.MachineName;
                row.Login = Environment.UserName;
                row.Revision = new Version(Application.ProductVersion).Revision;
                row.CreateDate = DateTime.Now;
                row.ModifyDate = DateTime.Now;
                return row;
            }

            public void Update()
            {
                if (Count < 1)
                    Update("", "", "");
                else
                    Update(this[0].Title, this[0].Author, this[0].Description);
            }

            public void Update(string title, string author, string description)
            {
                if (Rows.Count < 1)
                    AddPropertiesRow(title, author, description);
                else
                {
                    this[0].Title = title;
                    this[0].Author = author;
                    this[0].Description = description;
                    this[0].Computer = Environment.MachineName;
                    this[0].Login = Environment.UserName;
                    this[0].ModifyDate = DateTime.Now;
                    this[0].Revision = new Version(Application.ProductVersion).Revision;
                }
            }
        }
    
        partial class ProvidersDataTable
        {
            public ProvidersRow AddProvidersRow(DeliveryTypes type, DeliveryProviders provider, 
                string homePageUrl, bool allowAnswer, bool isHardware, decimal defaultUnitCost)
            {
                return AddProvidersRow(SmsConverter.ToString(type), SmsConverter.ToString(provider),
                    homePageUrl, allowAnswer, isHardware, true, "", "", "", "", defaultUnitCost);
            }

            public ProvidersRow FindOrAdd(List<string> keys, string[] values)
            {
                if (keys.IndexOf(TypeColumn.ColumnName) < 0)
                    throw new Exception(String.Format(
                        SmsProgram.Messages.ErrorExpectedProviderColumn, TypeColumn.ColumnName));
                if (keys.IndexOf(ProviderColumn.ColumnName) < 0)
                    throw new Exception(String.Format(
                        SmsProgram.Messages.ErrorExpectedProviderColumn, ProviderColumn.ColumnName));

                string url = "";
                if (keys.IndexOf(HomePageUrlColumn.ColumnName) >= 0)
                    url = values[keys.IndexOf(HomePageUrlColumn.ColumnName)].Trim();
                bool allowAnswer = false;
                if (keys.IndexOf(AllowAnswerColumn.ColumnName) >= 0)
                    allowAnswer = values[keys.IndexOf(AllowAnswerColumn.ColumnName)].Trim() == "1";
                bool isHardware = false;
                if (keys.IndexOf(IsInternalColumn.ColumnName) >= 0)
                    isHardware = values[keys.IndexOf(IsInternalColumn.ColumnName)].Trim() == "1";

                ProvidersRow row = FindOrAdd(
                    SmsConverter.ToDeliveryTypes(values[keys.IndexOf(TypeColumn.ColumnName)].Trim()),
                    SmsConverter.ToDeliveryProviders(values[keys.IndexOf(ProviderColumn.ColumnName)].Trim()),
                    url, allowAnswer, isHardware, 0);

                for(int columnIndex = 0; columnIndex < keys.Count; columnIndex++)
                    if (Columns[keys[columnIndex]].ReadOnly == false)
                        if (String.Compare(keys[columnIndex], DefaultUnitCostColumn.ColumnName, true) == 0)
                            row[keys[columnIndex]] = Convert.ToDecimal(values[columnIndex].Trim(), new CultureInfo("en-us"));
                        else
                            row[keys[columnIndex]] = values[columnIndex].Trim();
                row.AcceptChanges();

                return row;
            }

            public ProvidersRow FindByProviderType(DeliveryProviders provider, DeliveryTypes type)
            {
                return FindByProviderType(SmsConverter.ToString(provider), SmsConverter.ToString(type));
            }

            public ProvidersRow FindOrAdd(DeliveryTypes type, DeliveryProviders provider, 
                string homePageUrl, bool allowAnswer, bool isHardware, decimal defaultUnitCost)
            {
                ProvidersRow row = FindByProviderType(provider, type);
                if (row == null)
                    row = AddProvidersRow(type, provider, homePageUrl, allowAnswer, isHardware, defaultUnitCost);
                if (row == null)
                    throw new Exception(String.Format(
                        SmsProgram.Messages.ErrorProviderDoesntExists, provider, type));
                return row;
            }

            public ProvidersRow Update(DeliveryTypes type, DeliveryProviders provider, 
                string url, string userName, string password, decimal defaultUnitCost)
            {
                object[] keys = new object[2];
                keys[0] = SmsConverter.ToString(type);
                keys[1] = SmsConverter.ToString(provider);
                ProvidersRow row = (ProvidersRow)Rows.Find(keys);
                if (row == null)
                    throw new Exception(String.Format(SmsProgram.Messages.ErrorProviderDoesntExists, provider, type));

                row.Url = url;
                row.UserName = userName;
                row.Password = password;
                row.DefaultUnitCost = defaultUnitCost;
                return row;
            }

            public void ReadSettings()
            {
                Read(new StringBuilder(Settings.Default.ProviderSettings));
            }

            public void WriteSettings(StringBuilder settings)
            {
                settings.AppendLine("@Fields: Type, Provider, Url, UserName, Password, DefaultUnitCost");
                foreach (ProvidersRow row in this)
                    if (row.IsUserNameNull() == false && row.IsPasswordNull() == false)
                        settings.AppendLine(row.Type + ", " + row.Provider + ", " +
                            row.Url + ", " + row.UserName + ", " + row.Password + ", " + 
                            row.DefaultUnitCost.ToString(new CultureInfo("en-us")));
            }

            public void WriteSettings()
            {
                StringBuilder settings = new StringBuilder(Settings.Default.ProviderSettings);
                WriteSettings(settings);
                if (settings.ToString() != Settings.Default.ProviderSettings)
                {
                    Settings.Default.ProviderSettings = settings.ToString();
                    Settings.Default.Save();
                }
            }

            public void SetDefaultSettings()
            {
                foreach (ProvidersRow row in this)
                {
                    row.UserName = "";
                    row.Password = "";
                    row.Url = "";
                }
                Read();
            }

            public void Read()
            {
                Read("SmsProgram.smsp");
            }

            public void Read(string fileName)
            {
                Read(new StringBuilder(File.ReadAllText(fileName)));
            }

            public void Read(StringBuilder text)
            {
                int errorAtLine = 0;
                try
                {
                    List<string> columnNames = new List<string>();
                    string[] lines = text.ToString().Split('\n');
                    for (int lineIndex = 0; lineIndex < lines.Length; lineIndex++)
                    {
                        errorAtLine = lineIndex;
                        if (lines[lineIndex].Trim() != "")
                        {
                            string[] values = lines[lineIndex].Trim().Split(',');
                            if (values[0].StartsWith("@Fields:"))
                            {
                                values[0] = values[0].Substring("@Fields:".Length).Trim();
                                columnNames.Clear();
                                foreach (string value in values)
                                    columnNames.Add(value.Trim());
                            }
                            else if (values[0].StartsWith(";") == false)
                            {
                                if (values.Length > columnNames.Count)
                                    throw new Exception(String.Format(
                                        SmsProgram.Messages.ErrorBadProviderValues, columnNames.Count));
                                FindOrAdd(columnNames, values);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(String.Format(SmsProgram.Messages.ErrorAtLine, errorAtLine) + " " + ex.Message);
                }
            }
        }
    
        partial class MessagesDataTable
        {
            public MessagesRow AddMessagesRow(string message)
            {
                MessagesRow row = (MessagesRow)Rows.Add(message);
                row[CreateDateColumn] = DateTime.Now;
                row[ModifyDateColumn] = DateTime.Now;
                return row;
            }

            public MessagesRow AddMessagesRow(string message, string messageText)
            {
                MessagesRow row = AddMessagesRow(message);
                row.MessageText = messageText;
                return row;
            }
        }
    
        partial class CampaignsDataTable
        {
            public CampaignsRow AddCampaignsRow(string campaign)
            {
                CampaignsRow row = (CampaignsRow)Rows.Add(campaign);
                row[CreateDateColumn] = DateTime.Now;
                row[ModifyDateColumn] = DateTime.Now;
                row[SendDateColumn] = DateTime.Now;
                row[IsClosedColumn] = false;
                row[UnitCostColumn] = 0;
                return row;
            }
        }
    
        partial class SentDataTable
        {
            public SentRow AddSentRow(string index)
            {
                SentRow row = (SentRow)Rows.Add(index);
                row[CreateDateColumn] = DateTime.Now;
                row[ModifyDateColumn] = DateTime.Now;
                row[SendDateColumn] = DateTime.Now;
                row[IsSentColumn] = false;
                row[IsErrorColumn] = false;
                row[TypeColumn] = SmsConverter.ToString(DeliveryTypes.Sms);
                return row;
            }
        }

        partial class ReceivedDataTable
        {
            public ReceivedRow AddReceivedRow(string index)
            {
                ReceivedRow row = (ReceivedRow)Rows.Add(index);
                row[CreateDateColumn] = DateTime.Now;
                row[ModifyDateColumn] = DateTime.Now;
                row[ReceivedDateColumn] = DateTime.Now;
                row[TypeColumn] = SmsConverter.ToString(DeliveryTypes.Sms);
                return row;
            }
        }
    
        partial class CompaniesDataTable
        {
            public CompaniesRow AddCompaniesRow(string company)
            {
                CompaniesRow row = (CompaniesRow)Rows.Add(company);
                row[CreateDateColumn] = DateTime.Now;
                row[ModifyDateColumn] = DateTime.Now;
                return row;
            }
        }
    
        partial class GroupsDataTable
        {
            public GroupsRow AddGroupsRow(string group)
            {
                GroupsRow row =(GroupsRow)Rows.Add(group);
                row[CreateDateColumn] = DateTime.Now;
                row[ModifyDateColumn] = DateTime.Now;
                return row;
            }
        }

        partial class ContactsDataTable
        {
            public ContactsRow AddContactsRow()
            {
                return AddContactsRow(Guid.NewGuid().ToString());
            }

            public ContactsRow AddContactsRow(string contact)
            {
                ContactsRow row = (ContactsRow)Rows.Add(contact);
                row[CreateDateColumn] = DateTime.Now;
                row[ModifyDateColumn] = DateTime.Now;
                return row;
            }
        }
    
        private object isCustomField = new object();

        private bool delegatesInitialized = false;
        public bool DelegatesInitialized
        {
            get { return delegatesInitialized; }
        }

        private bool busy = false;
        public bool Busy
        {
            get { return busy; }
            set { busy = value; }
        }

        private bool reading = false;
        public bool Reading
        {
            get { return reading; }
        }

        private bool modified = false;
        public bool Modified
        {
            get { return modified; }
        }

        public string FileName
        {
            get 
            {
                if (Properties.Count > 0 && Properties[0].IsFileNameNull() == false)
                    return Properties[0].FileName;
                else
                    return "";
            }
        }

        new public void Clear()
        {
            base.Clear();
            Properties.Update();
            busy = false;
            reading = false;
            modified = true;
        }

        public void InitDelegates()
        {
            if (delegatesInitialized == false)
            {
                // Change row
                Contacts.RowChanged += new DataRowChangeEventHandler(Table_RowChanged);
                Companies.RowChanged += new DataRowChangeEventHandler(Table_RowChanged);
                Groups.RowChanged += new DataRowChangeEventHandler(Table_RowChanged);
                Messages.RowChanged += new DataRowChangeEventHandler(Table_RowChanged);
                Campaigns.RowChanged += new DataRowChangeEventHandler(Table_RowChanged);
                Sent.RowChanged += new DataRowChangeEventHandler(Table_RowChanged);
                Received.RowChanged += new DataRowChangeEventHandler(Table_RowChanged);
                CustomFields.RowChanged += new DataRowChangeEventHandler(Table_RowChanged);
                Properties.RowChanged += new DataRowChangeEventHandler(Table_RowChanged);

                // New row
                Contacts.TableNewRow += new DataTableNewRowEventHandler(Table_TableNewRow);
                Companies.TableNewRow += new DataTableNewRowEventHandler(Table_TableNewRow);
                Groups.TableNewRow += new DataTableNewRowEventHandler(Table_TableNewRow);
                Messages.TableNewRow += new DataTableNewRowEventHandler(Table_TableNewRow);
                Campaigns.TableNewRow += new DataTableNewRowEventHandler(Table_TableNewRow);
                Sent.TableNewRow += new DataTableNewRowEventHandler(Table_TableNewRow);
                Received.TableNewRow += new DataTableNewRowEventHandler(Table_TableNewRow);
                CustomFields.TableNewRow += new DataTableNewRowEventHandler(Table_TableNewRow);
                Properties.TableNewRow += new DataTableNewRowEventHandler(Table_TableNewRow);

                delegatesInitialized = true;
            }
            Properties.Update();
        }

        void Table_TableNewRow(object sender, DataTableNewRowEventArgs e)
        {
            if (busy == false && reading == false)
            {
                e.Row[Contacts.CreateDateColumn.ColumnName] = DateTime.Now;
                e.Row[Contacts.ModifyDateColumn.ColumnName] = DateTime.Now;

                if (e.Row.Table.TableName == Sent.TableName)
                {
                    e.Row[Sent.IndexColumn.ColumnName] = Guid.NewGuid().ToString();
                    e.Row[Sent.SendDateColumn.ColumnName] = DateTime.Now;
                }
                else if (e.Row.Table.TableName == Received.TableName)
                {
                    e.Row[Received.IndexColumn.ColumnName] = Guid.NewGuid().ToString();
                }
                else if (e.Row.Table.TableName == Campaigns.TableName)
                {
                    e.Row[Campaigns.SendDateColumn.ColumnName] = DateTime.Now;
                }
            }
        }

        void Table_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            if (busy == false)
            {
                if (reading == false)
                {
                    busy = true;
                    try
                    {
                        e.Row[Contacts.ModifyDateColumn.ColumnName] = DateTime.Now;
                    }
                    finally
                    {
                        busy = false;
                    }
                    modified = true;
                }
                Validate();
            }
        }

        public void ValidateCustomFields()
        {
            foreach (CustomFieldsRow row in CustomFields)
            {
                DataTable table = Tables[row.CustomTable];
                DataColumn column = null;
                if (table != null)
                {
                    if (table.Columns.Contains(row.CustomField) == false)
                        column = table.Columns.Add(row.CustomField);
                    else
                        column = table.Columns[row.CustomField];
                    if (row.IsTitleNull() == false && row.Title != "")
                        column.Caption = row.Title;
                    if (column.ExtendedProperties.Contains(isCustomField) == false)
                        column.ExtendedProperties.Add(isCustomField, null);
                }
            }

            foreach(DataTable table in Tables)
                foreach (DataColumn column in table.Columns)
                    if (column.ExtendedProperties.Contains(isCustomField) &&
                        CustomFields.FindByCustomTableCustomField(table.TableName, column.ColumnName) == null)
                        Contacts.Columns.Remove(column);
        }

        public string ValidatePhoneNumber(string phoneNumber)
        {
            StringBuilder str = new StringBuilder();
            bool firstChar = true;
            foreach (char c in phoneNumber)
            {
                if (firstChar)
                {
                    if ("+0123456789".IndexOf(c) >= 0)
                        str.Append(c);
                    firstChar = false;
                }
                else if ("0123456789".IndexOf(c) >= 0)
                    str.Append(c);
            }
            return str.ToString();
        }

        public string ValidateAddress(DeliveryTypes type, string address)
        {
            // TODO: Walidacja adresu Received i Sent - na podstawie typu i providera
            if (type == DeliveryTypes.Sms)
                return ValidatePhoneNumber(address);
            else
                return address;
        }

        public void ValidateContacts()
        {
            if (busy)
                return;

            busy = true;
            try
            {
                foreach (ContactsRow row in Contacts)
                {
                    string validatedPhoneNumber;
                    if (row.IsHomePhoneNumberNull() == false)
                    {
                        validatedPhoneNumber = ValidatePhoneNumber(row.HomePhoneNumber);
                        if (validatedPhoneNumber != row.HomePhoneNumber)
                            row.HomePhoneNumber = validatedPhoneNumber;
                    }

                    if (row.IsOfficePhoneNumberNull() == false)
                    {
                        validatedPhoneNumber = ValidatePhoneNumber(row.OfficePhoneNumber);
                        if (validatedPhoneNumber != row.OfficePhoneNumber)
                            row.OfficePhoneNumber = validatedPhoneNumber;
                    }

                    if (row.IsMobilePhoneNumberNull() == false)
                    {
                        validatedPhoneNumber = ValidatePhoneNumber(row.MobilePhoneNumber);
                        if (validatedPhoneNumber != row.MobilePhoneNumber)
                            row.MobilePhoneNumber = validatedPhoneNumber;
                    }

                    if (row.IsFaxPhoneNumberNull() == false)
                    {
                        validatedPhoneNumber = ValidatePhoneNumber(row.FaxPhoneNumber);
                        if (validatedPhoneNumber != row.FaxPhoneNumber)
                            row.FaxPhoneNumber = validatedPhoneNumber;
                    }

                    if (row.CompaniesRow == null && row.IsCompanyNull() == false && row.Company != "")
                    {
                        string id = row.Company; // HACK: te deklaracje muszą być - nie wiem dlaczego
                        row.CompaniesRow = Companies.FindByCompany(id);
                        if (row.CompaniesRow == null)
                            row.CompaniesRow = Companies.AddCompaniesRow(id);
                    }
                    if (row.CompaniesRow != null && row.Company != row.CompaniesRow.Company)
                        row.Company = row.CompaniesRow.Company;

                    if (row.GroupsRow == null && row.IsGroupNull() == false && row.Group != "")
                    {
                        string id = row.Group;
                        row.GroupsRow = Groups.FindByGroup(id);
                        if (row.GroupsRow == null)
                            row.GroupsRow = Groups.AddGroupsRow(id);
                    }
                    if (row.GroupsRow != null && row.Group != row.GroupsRow.Group)
                        row.Group = row.GroupsRow.Group;

                    if (row.IsTokenNull() || row.Token == "")
                        row.Token = GetRandomToken(6);
                }
            }
            finally
            {
                busy = false;
            }
        }

        public void ValidateCampaigns()
        {
            if (busy)
                return;

            busy = true;
            try
            {
                foreach (CampaignsRow row in Campaigns)
                {
                    if (row.MessagesRow == null && row.IsMessageNull() == false && row.Message != "")
                    {
                        string id = row.Message; // HACK: te deklaracje muszą być - nie wiem dlaczego
                        row.MessagesRow = Messages.FindByMessage(id);
                        if (row.MessagesRow == null)
                            row.MessagesRow = Messages.AddMessagesRow(id);
                    }
                    if (row.MessagesRow != null && row.Message != row.MessagesRow.Message)
                        row.Message = row.MessagesRow.Message;

                    // UNDONE: Tylko dla testów 2010-10-08
                    /*
                    if (row.MessagesRow != null && row.IsMessageTextNull() == false && row.MessageText == "" && row.IsClosed)
                        if (Campaigns.MessageColumn.ReadOnly == false)
                            row.MessageText = row.MessagesRow.MessageText;
                    */

                    try
                    {
                        SmsConverter.ToDeliveryTypes(row.Type);
                    }
                    catch
                    {
                        row.Type = SmsConverter.ToString(DeliveryTypes.Sms);
                    }

                    if (row.IsCodeNull() || row.Code == "")
                        row.Code = GetRandomToken(6);
                }
            }
            finally
            {
                busy = false;
            }
        }

        public void ValidateReceived()
        {
            if (busy)
                return;

            busy = true;
            try
            {
                foreach (ReceivedRow row in Received)
                {
                    if (row.IsTypeNull() == false && row.IsFromAddressNull() == false)
                    {
                        string validatedAddress = ValidateAddress(
                            SmsConverter.ToDeliveryTypes(row.Type), row.FromAddress);
                        if (validatedAddress != row.FromAddress)
                            row.FromAddress = validatedAddress;
                    }

                    if (row.ContactsRow == null && row.IsFromAddressNull() == false)
                    {
                        string id = row.FromAddress; // HACK: te deklaracje muszą być - nie wiem dlaczego
                        //row.ContactsRow = Contacts.FindByContact(id);
                        row.ContactsRow = Contacts.FindByContact(id);
                        if (row.ContactsRow == null)
                            row.ContactsRow = Contacts.AddContactsRow(id);
                    }
                    if (row.ContactsRow != null && row.Contact != row.ContactsRow.Contact)
                        row.Contact = row.ContactsRow.Contact;

                    if (row.CampaignsRow == null && row.IsCampaignNull() == false && row.Campaign != "")
                    {
                        string id = row.Campaign;
                        row.CampaignsRow = Campaigns.FindByCampaign(id);
                        if (row.CampaignsRow == null)
                            row.CampaignsRow = Campaigns.AddCampaignsRow(id);
                    }

                    if (row.CampaignsRow != null && row.Campaign != row.CampaignsRow.Campaign)
                        row.Campaign = row.CampaignsRow.Campaign;

                    try
                    {
                        SmsConverter.ToDeliveryTypes(row.Type);
                    }
                    catch
                    {
                        row.Type = SmsConverter.ToString(DeliveryTypes.Sms);
                    }
                }
            }
            finally
            {
                busy = false;
            }
        }

        public void ValidateSent()
        {
            if (busy)
                return;

            busy = true;
            try
            {
                foreach (SentRow row in Sent)
                {
                    if (row.IsTypeNull() == false && row.IsToAddressNull() == false)
                    {
                        string validatedAddress = ValidateAddress(
                            SmsConverter.ToDeliveryTypes(row.Type), row.ToAddress);
                        if (validatedAddress != row.ToAddress)
                            row.ToAddress = validatedAddress;
                    }

                    if (row.ContactsRow == null && row.IsContactNull() == false)
                    {
                        string id = row.Contact; // HACK: te deklaracje muszą być - nie wiem dlaczego
                        row.ContactsRow = Contacts.FindByContact(row.Contact);
                        if (row.ContactsRow == null)
                            row.ContactsRow = Contacts.AddContactsRow(id);
                    }

                    if (row.ContactsRow != null && row.Contact != row.ContactsRow.Contact)
                        row.Contact = row.ContactsRow.Contact;

                    if (row.CampaignsRow == null && row.IsCampaignNull() == false && row.Campaign != "")
                    {
                        string id = row.Campaign;
                        row.CampaignsRow = Campaigns.FindByCampaign(id);
                        if (row.CampaignsRow == null)
                            row.CampaignsRow = Campaigns.AddCampaignsRow(id);
                    }

                    if (row.CampaignsRow != null && row.Campaign != row.CampaignsRow.Campaign)
                        row.Campaign = row.CampaignsRow.Campaign;

                    if (row.CampaignsRow != null && row.Type != "sms" && row.Type != "email")
                        row.Type = row.CampaignsRow.Type;

                    if (row.TemplatesRow == null && row.IsMessageNull() == false && row.Message != "")
                    {
                        string id = row.Message;
                        row.TemplatesRow = Messages.FindByMessage(id);
                        if (row.TemplatesRow == null)
                            row.TemplatesRow = Messages.AddMessagesRow(id);
                    }

                    if (row.TemplatesRow != null && row.Message != row.TemplatesRow.Message)
                        row.Message = row.TemplatesRow.Message;

                    if (row.TemplatesRow == null && row.CampaignsRow != null)
                        row.TemplatesRow = row.CampaignsRow.MessagesRow;

                    // UNDONE: Wyłączyłem dla testów
                    /*
                    if (row.CampaignsRow != null && row.MessageText == "" && row.IsSent)
                    {
                        row.MessageText = Templater.ToValues(row.TemplatesRow,
                            Templater.ToValues(row.CampaignsRow,
                            Templater.ToValues(row.PhonesRow, row.CampaignsRow.MessageText)));
                    }*/
                }
            }
            finally
            {
                busy = false;
            }
        }

        public void Validate()
        {
            ValidateCustomFields();
            ValidateContacts();
            ValidateCampaigns();
            ValidateReceived();
            ValidateSent();
        }

        public SmsFileTypes ReadFileType(string fileName)
        {
            string header = "";
            using (FileStream stream = File.Open(fileName, FileMode.Open))
            {
                byte[] bytes = new byte[2];
                bytes[0] = (byte)stream.ReadByte();
                bytes[1] = (byte)stream.ReadByte();
                header = Encoding.ASCII.GetString(bytes);
            }

            switch (header)
            {
                case "7z":
                    return SmsFileTypes.Binary;
                case "<?":
                    return SmsFileTypes.Xml;
                default:
                    return SmsFileTypes.Binary;
            }
        }

        public SmsFileTypes GetFileType(string fileName)
        {
            switch(Path.GetExtension(fileName))
            {
                case ".smsx":
                    return SmsFileTypes.Binary;
                case ".xml":
                    return SmsFileTypes.Xml;
                case ".schema":
                    return SmsFileTypes.Schema;
                default:
                    return SmsFileTypes.Unknown;
            }
        }

        public void ReadXml(string fileName)
        {
            ReadXml(fileName, ReadFileType(fileName), Settings.Default.FilePassword);
        }

        new public void ReadXml(string fileName, string password)
        {
            ReadXml(fileName, ReadFileType(fileName), password);
        }

        public void CheckXmlFile(string fileName)
        {
        }

        public MemoryStream Decompress(string fileName, string password)
        {
            using (ZipFile zip = new ZipFile(fileName))
            {
                MemoryStream outStream = new MemoryStream((int)zip[0].UncompressedSize);
                if (Decrypt(password) == "")
                    zip[0].Extract(outStream);
                else
                    zip[0].ExtractWithPassword(outStream, Decrypt(password));
                return outStream;
            }
        }

        public void Compress(MemoryStream stream, string fileName, string password)
        {
            if (File.Exists(fileName))
                File.Delete(fileName);

            using (ZipFile zip = new ZipFile(fileName))
            {
                if (Decrypt(password) != "")
                {
                    zip.Password = Decrypt(password);
                    zip.Encryption = EncryptionAlgorithm.WinZipAes256;
                }
                zip.AddEntry(Path.GetFileName(fileName), stream.GetBuffer());
                zip.Save();
            }
        }

        public void ReadXml(string fileName, SmsFileTypes type, string password)
        {
            Clear();
            busy = true;
            reading = true;
            try
            {
                switch (type)
                {
                    case SmsFileTypes.Xml:
                        base.ReadXml(fileName);
                        break;
                    case SmsFileTypes.Binary:
                        base.ReadXml(Decompress(fileName, password));
                        break;
                    default:
                        throw new Exception(String.Format(
                            SmsProgram.Messages.ErrorUnknownFileType, type, fileName));
                }
                modified = false;
                Properties[0].FileName = fileName;
            }
            finally
            {
                busy = false;
                reading = false;
                Validate();
            }
        }

        public void Import(string fileName, bool replaceNewer, bool replaceAll)
        {
            Import(fileName, ReadFileType(fileName), replaceNewer, replaceAll);
        }

        public void Import(string fileName)
        {
            Import(fileName, ReadFileType(fileName), true, false);
        }

        public void Import(string fileName, SmsFileTypes type, bool replaceNewer, bool replaceAll)
        {
            SmsProject importProject = (SmsProject)this.Clone();
            importProject.Clear();
            importProject.ReadXml(fileName);
            busy = true;
            reading = true;
            try
            {
                Import((DataTable)importProject.CustomFields, (DataTable)CustomFields, 
                    replaceNewer, replaceAll, Path.GetFileName(fileName));
                Import((DataTable)importProject.Companies, (DataTable)Companies, 
                    replaceNewer, replaceAll, Path.GetFileName(fileName));
                Import((DataTable)importProject.Groups, (DataTable)Groups, 
                    replaceNewer, replaceAll, Path.GetFileName(fileName));
                Import((DataTable)importProject.Contacts, (DataTable)Contacts, 
                    replaceNewer, replaceAll, Path.GetFileName(fileName));
                Import((DataTable)importProject.Messages, (DataTable)Messages, 
                    replaceNewer, replaceAll, Path.GetFileName(fileName));
                Import((DataTable)importProject.Campaigns, (DataTable)Campaigns, 
                    replaceNewer, replaceAll, Path.GetFileName(fileName));
                Import((DataTable)importProject.Sent, (DataTable)Sent, 
                    replaceNewer, replaceAll, Path.GetFileName(fileName));
                Import((DataTable)importProject.Received, (DataTable)Received, 
                    replaceNewer, replaceAll, Path.GetFileName(fileName));
            }
            finally
            {
                busy = false;
                reading = false;
                Validate();
            }
        }

        public void Import(DataTable fromTable, DataTable toTable, 
            bool replaceNewer, bool replaceAll, string source)
        {
            foreach (DataRow fromRow in fromTable.Rows)
            {
                DataRow toRow = toTable.Rows.Find(fromRow[0]);
                bool exists = toRow != null;
                if (exists)
                {
                    if (replaceAll == false)
                        toRow = null;
                    if (toRow != null && replaceNewer && (fromRow[Contacts.ModifyDateColumn.ColumnName] == null ||
                        ((DateTime)toRow[Contacts.ModifyDateColumn.ColumnName]).CompareTo(
                            (DateTime)fromRow[Contacts.ModifyDateColumn.ColumnName]) > 0))
                        toRow = null;
                }
                else 
                    toRow = toTable.NewRow();

                if (toRow != null)
                {
                    toRow.BeginEdit();
                    foreach (DataColumn column in fromTable.Columns)
                        if (column.ReadOnly == false)
                            toRow[column.ColumnName] = fromRow[column.ColumnName];
                    toRow.EndEdit();
                    if (exists == false)
                        toTable.Rows.Add(toRow);
                }
            }
        }

        public string Encrypt(string text)
        {
            string base64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(text), Base64FormattingOptions.None);
            StringBuilder encrypted = new StringBuilder();
            for (int pos = 0; pos < base64.Length - 1; pos += 2)
            {
                encrypted.Append(base64.Substring(pos + 1, 1));
                encrypted.Append(base64.Substring(pos, 1));
            }
            return "@" + encrypted.ToString();
        }

        public string Decrypt(string text)
        {
            if (text.StartsWith("@"))
            {
                StringBuilder decrypted = new StringBuilder();
                for (int pos = 1; pos < text.Length - 1; pos += 2)
                {
                    decrypted.Append(text.Substring(pos + 1, 1));
                    decrypted.Append(text.Substring(pos, 1));
                }
                return decrypted.ToString();
            }
            else
                return text;
        }

        new public void WriteXml(string fileName)
        {
            WriteXml(fileName, GetFileType(fileName), Settings.Default.FilePassword);
        }

        public void WriteXml(string fileName, string password)
        {
            WriteXml(fileName, GetFileType(fileName), password);
        }

        public void WriteXml(string fileName, SmsFileTypes type, string password)
        {
            Columns.Clear();
            LookupList.Clear();
            string lastFileName = Properties[0].FileName;
            switch (type)
            {
                case SmsFileTypes.Schema:
                    base.WriteXmlSchema(fileName);
                    break;
                case SmsFileTypes.Xml:
                    try
                    {
                        Properties[0].FileName = fileName;
                        base.WriteXml(fileName);
                    }
                    catch
                    {
                        Properties[0].FileName = lastFileName;
                        throw;
                    }
                    break;
                case SmsFileTypes.Binary:
                    try
                    {
                        Properties[0].FileName = fileName;
                        MemoryStream stream = new MemoryStream();
                        base.WriteXml(stream);
                        Compress(stream, fileName, password);
                    }
                    catch
                    {
                        Properties[0].FileName = lastFileName;
                        throw;
                    }
                    break;
                default:
                    throw new Exception(String.Format(SmsProgram.Messages.ErrorUnknownFileType, type, fileName));
            }
            modified = false;
        }

        public DataTable GetLookupTable(string fieldName)
        {
            foreach (DataTable t in Tables)
                if (t.PrimaryKey[0].ColumnName == fieldName)
                    return t;
            return null;
        }

        public DataTable GetParentLookupTable(DataTable table, string fieldName)
        {
            foreach (DataRelation relation in Relations)
                if (relation.ChildTable == table &&
                    relation.ChildColumns[0].ColumnName == fieldName &&
                    relation.ParentColumns[0].ColumnName == fieldName)
                    return relation.ParentTable;
            return null;
        }

        public DataTable GetLookupTable(DataTable table, string fieldName)
        {
            DataTable parentTable = GetParentLookupTable(table, fieldName);
            if (parentTable != null)
                return parentTable;

            SortedDictionary<string, int> dict = new SortedDictionary<string, int>();
            foreach (DataRow row in table.Rows)
            {
                string text = row[fieldName].ToString();
                if (text != "" && text.Length < 100)
                    if (dict.ContainsKey(text))
                        dict[text]++;
                    else
                        dict.Add(text, 1);
            }

            LookupListDataTable result = new LookupListDataTable();
            foreach (KeyValuePair<string, int> pair in dict)
                result.AddLookupListRow(pair.Key, pair.Value);
            return result;
        }

        public int AddContactsToCampaign(string campaign, List<string> contacts)
        {
            bool lastBusy = busy;

            busy = true;
            try
            {
                List<string> added = new List<string>();
                CampaignsRow campaignRow = Campaigns.FindByCampaign(campaign);
                int count = 0;
                foreach (string contact in contacts)
                {
                    if (added.Contains(contact) == false)
                    {
                        added.Add(contact);
                        ContactsRow contactsRow = Contacts.FindByContact(contact);
                        // UNDONE: Dokończyć dodawanie tutaj relacji
                        /*
                        if (phonesRow != null && Sent.AddSentRow(Guid.NewGuid().ToString(),
                            phonesRow, campaignRow.SendDate,
                            campaignRow.Type, phonesRow.Email,
                            false, false, "", "", campaignRow, campaignRow.MessagesRow, "",
                            DateTime.Now, DateTime.Now) != null)
                            count++;
                         */
                    }
                }
                return count;
            }
            finally
            {
                busy = lastBusy;
                if (lastBusy == false)
                    Validate();
            }
        }

        public int AddToCampaign(DataTable table, string campaign, List<string> keysList)
        {
            List<string> contacts = new List<string>();
            if (table == Contacts || table == Received || table == Sent)
                contacts = keysList;
            else if (table == Companies)
            {
                foreach (ContactsRow row in Contacts)
                    if (keysList.Contains(row.Company))
                        contacts.Add(row.Contact);
            }
            else if (table == Groups)
            {
                foreach (ContactsRow row in Contacts)
                    if (keysList.Contains(row.Group))
                        contacts.Add(row.Contact);
            }
            else if (table == Campaigns)
                foreach (SentRow row in Sent)
                    if (keysList.Contains(row.Campaign))
                        contacts.Add(row.Contact);
                
            return AddContactsToCampaign(campaign, contacts);
        }

        public int DeleteRows(DataTable table, List<string> keyList)
        {
            bool lastBusy = busy;

            busy = true;
            try
            {
                int count = 0;
                foreach (string key in keyList)
                {
                    DataRow row = table.Rows.Find(key);
                    if (row != null)
                    {
                        table.Rows.Remove(row);
                        count++;
                    }
                }
                return count;
            }
            finally
            {
                busy = lastBusy;
                if (lastBusy == false)
                    Validate();
            }
        }

        public bool IsClosed(string campaign)
        {
            CampaignsRow row = Campaigns.FindByCampaign(campaign);
            return row != null && row.IsClosed;
        }

        public bool IsSent(string index)
        {
            SentRow row = Sent.FindByIndex(index);
            return row != null && row.IsSent;
        }

        public string ColumnsToValues(string message)
        {
            foreach (ColumnsRow row in Columns)
            {
                message = Templater.ToValue(message, row.Column, row.Example);
                message = Templater.ToValue(message, row.Field, row.Example);
            }
            return message;

        }

        public string GetRandomToken(int letterCount)
        {
            StringBuilder str = new StringBuilder();
            Random random = new Random();
            for (int pos = 0; pos < letterCount; pos++)
            {
                str.Append(random.Next(0, 9).ToString());
            }
            return str.ToString();
        }

        public void FillColumns()
        {
            Columns.Clear();
            AddColumnListWithExample(Contacts);
            AddColumnListWithExample(Campaigns);
        }

        public void AddColumnListWithExample(DataTable sourceTable)
        {
            SortedDictionary<string, string> dict = new SortedDictionary<string, string>();
            foreach (DataColumn column in sourceTable.Columns)
            {
                string example = "";
                foreach (DataRow row in sourceTable.Rows)
                    if (row[column] != null)
                    {
                        example = row[column].ToString();
                        break;
                    }
                try
                {
                    Columns.AddColumnsRow(column.Caption, example, column.ColumnName);
                }
                catch
                {
                }
            }
        }

        public void UpdateMessages(string message, string messageText)
        {
            MessagesRow row = Messages.FindByMessage(message);
            if (row != null)
                row.Message = messageText;
            else
                row = Messages.AddMessagesRow(message, messageText);
        }
    }
}