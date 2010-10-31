using System;
using System.Collections.Generic;
using System.Text;

namespace SmsProgram
{
    public static class Messages
    {
        public static string TitleError = "Error";
        public static string TitleWarning = "Warning";
        public static string TitleConfirm = "Confirmation";
        public static string TitleInformation = "Information";
        public static string TitleQuestion = "Question";

        public static string StatusFileOpened = "OK, file '{0}' opened.";
        public static string StatusFileSaved = "OK, file '{0}' saved.";
        public static string StatusFileImported = "OK, file '{0}' imported into existing.";
        public static string StatusNewFileCreated = "OK, new file created. Please enter data and save.";
        public static string StatusPropertiesChanged = "OK, file properties changed.";
        public static string StatusRowsDeleted = "OK, {0} row(s) deleted.";
        public static string StatusFilterDeleted = "OK, filter '{0}' deleted.";
        public static string StatusFilterHasEmptyName = "filter '{0}' has empty name.";
        public static string StatusFilterCleared = "OK, filter cleared, found: {0}.";
        public static string StatusFilterChanged = "OK, filter changed to '{0}', found: {1}.";
        public static string StatusTextFound = "OK, '{0}' - found.";
        public static string StatusTextNotFound = "Ups... '{0}' not found.";
        public static string StatusCampaignAdded = "OK, {0} contacts added to campaign {1}.";
        public static string StatusSendStarted = "OK, sending/receiving started ({0} messages in queue).";
        public static string StatusSendPaused = "OK, sending/receiving paused ({0} messages in queue).";
        public static string StatusSendFinished = "OK, sending/receiving finished.";
        public static string StatusUndo = "OK, operations from last save was canceled.";

        public static string LogSendError = "{0}: Send error at row index {1} [{2}] - {3}.";
        public static string LogSendSmsErrorInfo = "Phone number = '{0}'";
        public static string LogSendEmailErrorInfo = "Email = '{0}'";

        public static string ErrorExamplesRead = "Can't read examples.";
        public static string ErrorExamplesWrite = "Can't write examples.";
        public static string ErrorAtLine = "Error at line {0}.";
        public static string ErrorFileOpen = "Can't open file.";
        public static string ErrorFileImport = "Can't import file.";
        public static string ErrorFileSave = "Can't save file.";
        public static string ErrorBadData = "Please enter correct data.";
        public static string ErrorUnknownFileType = "Unknown file type {0} for {1}.";
        public static string ErrorClipboard = "Bad data in clipboard.";
        public static string ErrorInternal = "Internal program error.";
        public static string ErrorBadFilter = "Bad filter: {0}.";
        public static string ErrorAddRangeFilter = "Unnable to add range filter.";
        public static string ErrorAddTextFilter = "Unnable to add text filter.";
        public static string ErrorSaveMessage = "Unnable to save message.";
        public static string ErrorFilterOneWildcard = "A wildcard is allowed at the start or end of word.";
        public static string ErrorCampaignAdd = "Unnable to add contacts into campaign.";
        public static string ErrorUndo = "Unnable to undo last operation.";
        public static string ErrorCampaignIsClosed = "Current campaign is closed and can't be changed";

        public static string ConfirmStartSending = "Are You sure to send all data in Sending queue?";
        public static string ConfirmNewFile = "Are You sure to create new file?";
        public static string ConfirmSaveFile = "Save active file?";
        public static string ConfirmDeleteData = "Are You sure to delete {0} row(s) data?";
        public static string ConfirmDeleteFilter = "Are You sure to delete filter {0}?";

        public static string WarningCheckColumns = "Please check column names [] in Your message.";

        public static string QuestionSearchEverywhere = "{0} - not found. Search everywhere?";

        public static string InfoUnknownFileExtension = "Please select file .smsx or .xml.";
        public static string InfoColumnHasNoData = "Column [{0}] has no data.";

        public static string LabelAdditionalProperties = "Created [CreateDate] modified [ModifyDate]\r\nby [Login] on [Computer] (Revision [Revision])";
        public static string LabelFileInfo = "Filename: [FileName]\r\nTitle: [Title]\r\nAuthor: [Author]\r\n\r\nCreated [CreateDate]\r\nModified [ModifyDate]\r\nBy [Login] on [Computer] (Revision: [Revision])";
        public static string LabelCampaignContactsAdd = "You have selected {0} contacts to add into campaign";
        public static string LabelCampaignGroupsAdd = "You have selected {0} groups to add into campaign";
        public static string LabelCampaignCompaniesAdd = "You have selected {0} companies to add into campaign";
        public static string LabelCampaignCampaignsAdd = "You have selected {0} campaigns to add into campaign";

        public static string ToolTipCustomField = "This is custom field";

        // Not important
        public static string ErrorDefineCustomField = "Please define custom field {0} name and title (found in phone {1}).";
        public static string ErrorBadKeyInInternalData = "Bad key {0}:{1}/{2} in internal database.";
        public static string ErrorUnknownDeliveryType = "Unknown delivery type {0}.";
        public static string ErrorUnknownDeliveryProvider = "Unknown delivery provider {0}.";
        public static string ErrorProviderDoesntExists = "Provider {0} for type {1} doesn't exists.";
        public static string ErrorBadProviderValues = "Bad provider values, expected {0} items.";
        public static string ErrorExpectedProviderColumn = "Expected column {0} in provider.";
    }
}
