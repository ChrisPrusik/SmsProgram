using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using SmsProgram.Properties;
using SmsProgram.Model;

namespace SmsProgram
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            Icon = new Icon("SmsProgram.ico");
        }

        private void ShowError(string message, Exception ex)
        {
            message = message + " " + ex.Message;
            message = Templater.ToCaptions(CurrentTable.Columns, message);
            MessageLabel.Text = message.Replace("\r", "").Replace("\n", "");
            MessageBox.Show(message, Messages.TitleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void Open(string fileName)
        {
            try
            {
                SmsProject.ReadXml(fileName);
                OpenFileDialog.FileName = SmsProject.FileName;
                OpenFileDialog.DefaultExt = Path.GetExtension(SmsProject.FileName);
                SaveFileDialog.FileName = SmsProject.FileName;
                SaveFileDialog.DefaultExt = Path.GetExtension(SmsProject.FileName);
                MessageLabel.Text = String.Format(Messages.StatusFileOpened, Path.GetFileName(fileName));
                FileLabel.Text = Path.GetFileName(fileName);
                Settings.Default.FileName = fileName;
                Settings.Default.Save();
            }
            catch (Exception ex)
            {
                ShowError(Messages.ErrorFileOpen, ex);
            }
        }

        public void Save(string fileName)
        {
            try
            {
                SmsProject.WriteXml(fileName);
                OpenFileDialog.FileName = SmsProject.FileName;
                OpenFileDialog.DefaultExt = Path.GetExtension(SmsProject.FileName);
                SaveFileDialog.FileName = SmsProject.FileName;
                OpenFileDialog.DefaultExt = Path.GetExtension(SmsProject.FileName);
                Settings.Default.FileName = SmsProject.FileName;
                Settings.Default.Save();
                MessageLabel.Text = String.Format(Messages.StatusFileSaved, Path.GetFileName(fileName));
                FileLabel.Text = Path.GetFileName(fileName);
            }
            catch (Exception ex)
            {
                ShowError(Messages.ErrorFileSave, ex);
            }
        }

        private void FileOpenMenu_Click(object sender, EventArgs e)
        {
            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
                Open(OpenFileDialog.FileName);
        }

        public void Import(string fileName)
        {
            try
            {
                SmsProject importProject = (SmsProject)SmsProject.Clone();
                importProject.Clear();
                importProject.ReadXml(fileName);
                using (ImportForm form = new ImportForm())
                {
                    form.InfoLabel.Text = Templater.ToValues(importProject.Properties[0], Messages.LabelFileInfo);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        SmsProject.Import(fileName,
                            form.OnlyNewerCheckBox.Checked,
                            form.ReplaceAllCheckBox.Checked);
                        MessageLabel.Text = String.Format(Messages.StatusFileImported,
                            Path.GetFileName(fileName));
                    }
                }
            }
            catch (Exception ex)
            {
                ShowError(Messages.ErrorFileImport, ex);
            }
        }

        private void FileImportMenu_Click(object sender, EventArgs e)
        {
            // TODO: Import .csv i z Excela 97 i 2007 (xls i xlsx)
            // TODO: Import VCF (VCARD)
            // TODO: Import do wyboru (File,  Web url, Phone device) 
            if (ImportFileDialog.ShowDialog() == DialogResult.OK)
                Import(ImportFileDialog.FileName);
        }

        private void FileSaveMenu_Click(object sender, EventArgs e)
        {
            if (SmsProject.FileName != "")
                Save(SmsProject.FileName);
            else
                FileSaveAsMenu_Click(sender, e);
        }

        private void FileSaveAsMenu_Click(object sender, EventArgs e)
        {
            if (SmsProject.FileName == "" &&
                SmsProject.Properties.Count > 0 &&
                SmsProject.Properties[0].Title != "")
                SaveFileDialog.FileName = SmsProject.Properties[0].Title;
            if (SaveFileDialog.ShowDialog() == DialogResult.OK)
                Save(SaveFileDialog.FileName);
        }

        private void FileNewMenu_Click(object sender, EventArgs e)
        {
            if (SmsProject.Properties.Count < 1 ||
                MessageBox.Show(Messages.ConfirmNewFile, Messages.TitleConfirm,
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                SmsProject.Clear();
                Application.DoEvents();
                using (PropertiesForm form = new PropertiesForm())
                {
                    if (form.ShowDialog() == DialogResult.OK)
                        try
                        {
                            SmsProject.Properties.Update(
                                form.TitleTextBox.Text,
                                form.AuthorTextBox.Text,
                                form.DescriptionTextBox.Text);
                            MessageLabel.Text = Messages.StatusNewFileCreated;
                            FileLabel.Text = "";
                        }
                        catch (Exception ex)
                        {
                            ShowError(Messages.ErrorBadData, ex);
                        }
                }
            }
        }

        private void FilePropertiesMenu_Click(object sender, EventArgs e)
        {
            if (SmsProject.Properties.Count < 1)
                FileNewMenu_Click(sender, e);
            else
                using (PropertiesForm form = new PropertiesForm())
                {
                    form.ProjectLabel.Text = SmsProject.Properties.TitleColumn.Caption;
                    form.AuthorLabel.Text = SmsProject.Properties.AuthorColumn.Caption;
                    form.DescriptionLabel.Text = SmsProject.Properties.DescriptionColumn.Caption;

                    form.TitleTextBox.Text = SmsProject.Properties[0].Title;
                    form.AuthorTextBox.Text = SmsProject.Properties[0].Author;
                    form.DescriptionTextBox.Text = SmsProject.Properties[0].Description;

                    form.AdditionalLabel.Text = Templater.ToValues(SmsProject.Properties[0],
                        Messages.LabelAdditionalProperties);

                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        SmsProject.Properties[0].Title = form.TitleTextBox.Text;
                        SmsProject.Properties[0].Author = form.AuthorTextBox.Text;
                        SmsProject.Properties[0].Description = form.DescriptionTextBox.Text;
                        SmsProject.Properties.AcceptChanges();

                        MessageLabel.Text = Messages.StatusPropertiesChanged;
                    }
                }
        }

        private void FileMenuExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void EditCutMenu_Click(object sender, EventArgs e)
        {
            EditCopyMenu_Click(sender, e);
            EditDeleteMenu_Click(sender, e);
        }

        private void EditCopyMenu_Click(object sender, EventArgs e)
        {
            if (ActiveControl is SplitContainer &&
                (ActiveControl as SplitContainer).ActiveControl is TextBox)
            {
                string text = ((ActiveControl as SplitContainer).ActiveControl as TextBox).SelectedText;
                if (text != "")
                    Clipboard.SetText(text, TextDataFormat.UnicodeText);
            }
            else
            {
                if (CurrentGrid.SelectedCells.Count > 0)
                    try
                    {
                        Clipboard.SetDataObject(CurrentGrid.GetClipboardContent());
                    }
                    catch (Exception ex)
                    {
                        ShowError("", ex);
                    }
            }
        }

        private void EditPasteMenu_Click(object sender, EventArgs e)
        {
            if (ActiveControl is SplitContainer &&
                (ActiveControl as SplitContainer).ActiveControl is TextBox)
            {
                ((ActiveControl as SplitContainer).ActiveControl as TextBox).SelectedText =
                    Clipboard.GetText(TextDataFormat.UnicodeText);
            }
            else
            {
                if (CurrentGrid.SelectedCells.Count > 0)
                    try
                    {
                        string text = Clipboard.GetText(TextDataFormat.UnicodeText);
                        string[] rows = text.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

                        int topRowIndex = int.MaxValue;
                        int leftCellIndex = int.MaxValue;
                        foreach (DataGridViewCell cell in CurrentGrid.SelectedCells)
                        {
                            topRowIndex = Math.Min(topRowIndex, cell.RowIndex);
                            leftCellIndex = Math.Min(leftCellIndex, cell.ColumnIndex);
                        }

                        // TODO: Dodawanie rekordów wklejanych ze schowka
                        if (CurrentGrid.Rows.Count < topRowIndex + rows.Length)
                            CurrentGrid.Rows.Add(topRowIndex + rows.Length - CurrentGrid.Rows.Count);

                        int rowIndex = 0;
                        while (rowIndex < rows.Length)
                        {
                            string[] cells = rows[rowIndex].Split('\t');
                            int iCol = 0;
                            while (iCol < cells.Length)
                            {
                                if (CurrentGrid.ColumnCount - 1 >= leftCellIndex + iCol)
                                {
                                    DataGridViewCell cell = CurrentGrid.Rows[topRowIndex + rowIndex].Cells[leftCellIndex + iCol];
                                    if (cell.OwningColumn.ReadOnly == false)
                                        cell.Value = cells[iCol];
                                }
                                iCol++;
                            }
                            rowIndex++;
                        }
                    }
                    catch (Exception ex)
                    {
                        ShowError(Messages.ErrorClipboard, ex);
                    }
            }
        }

        public bool SearchField(string text, object value, bool inField, bool ignoreLetterCase, bool useRegex)
        {
            if (value == null)
                return false;
            else if (inField == false && ignoreLetterCase == false && useRegex == false)
                return value.ToString() == text;
            else if (inField == false && ignoreLetterCase == false && useRegex)
                return Regex.IsMatch(value.ToString(), text);
            else if (inField == false && ignoreLetterCase && useRegex == false)
                return value.ToString().ToLower() == text.ToLower();
            else if (inField == false && ignoreLetterCase && useRegex)
                return Regex.IsMatch(value.ToString(), text, RegexOptions.IgnoreCase);
            else if (inField && ignoreLetterCase == false && useRegex == false)
                return value.ToString().IndexOf(text) >= 0;
            else if (inField && ignoreLetterCase == false && useRegex)
                return Regex.IsMatch(value.ToString(), text);
            else if (inField && ignoreLetterCase && useRegex == false)
                return value.ToString().ToLower().IndexOf(text.ToLower()) >= 0;
            else if (inField && ignoreLetterCase && useRegex)
                return Regex.IsMatch(value.ToString(), text, RegexOptions.IgnoreCase);
            else
                throw new Exception(Messages.ErrorInternal);
        }

        public bool SearchColumn(string text, DataGridView grid, int columnIndex, bool allColumn,
            bool inField, bool ignoreLetterCase, bool useRegex, bool backward)
        {
            if (grid.CurrentCell != null)
            {
                if (backward == false)
                {
                    for (int rowIndex = grid.CurrentCell.RowIndex + 1; rowIndex < grid.Rows.Count; rowIndex++)
                    {
                        DataGridViewCell cell = grid.Rows[rowIndex].Cells[columnIndex];
                        if (SearchField(text, cell.FormattedValue, inField, ignoreLetterCase, useRegex))
                        {
                            grid.CurrentCell = cell;
                            return true;
                        }
                    }
                    if (allColumn)
                        for (int rowIndex = 0; rowIndex <= grid.CurrentCell.RowIndex; rowIndex++)
                        {
                            DataGridViewCell cell = grid.Rows[rowIndex].Cells[columnIndex];
                            if (SearchField(text, cell.FormattedValue, inField, ignoreLetterCase, useRegex))
                            {
                                grid.CurrentCell = cell;
                                return true;
                            }
                        }
                }
                else
                {
                    for (int rowIndex = grid.CurrentCell.RowIndex - 1; rowIndex > 0; rowIndex--)
                    {
                        DataGridViewCell cell = grid.Rows[rowIndex].Cells[columnIndex];
                        if (SearchField(text, cell.FormattedValue, inField, ignoreLetterCase, useRegex))
                        {
                            grid.CurrentCell = cell;
                            return true;
                        }
                    }
                    if (allColumn)
                    {
                        for (int rowIndex = grid.RowCount - 1; rowIndex > grid.CurrentCell.RowIndex; rowIndex--)
                        {
                            DataGridViewCell cell = grid.Rows[rowIndex].Cells[columnIndex];
                            if (SearchField(text, cell.FormattedValue, inField, ignoreLetterCase, useRegex))
                            {
                                grid.CurrentCell = cell;
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        public bool SearchGrid(string text, DataGridView grid, bool inField, 
            bool ignoreLetterCase, bool useRegex, bool backward)
        {
            for (int columnIndex = 0; columnIndex < grid.ColumnCount; columnIndex++)
                if (SearchColumn(text, grid, columnIndex, true, inField, ignoreLetterCase, useRegex, backward))
                {
                    if (CurrentGrid != grid)
                    {
                        foreach(TabPage tab in TabControl.TabPages)
                            if (GetGrid(tab) == grid)
                            {
                                TabControl.SelectedTab = tab;
                                ActiveControl = grid;
                            }
                    }
                    return true;
                }
            return false;
        }

        public bool SearchEverywhere(string text, 
            bool inField, bool ignoreLetterCase, bool useRegex, bool backward)
        {
            if (SearchGrid(text, CurrentGrid, inField, ignoreLetterCase, useRegex, backward))
                return true;
            else
            {
                foreach(TabPage tab in TabControl.TabPages)
                    if (GetGrid(tab) != CurrentGrid)
                    {
                        TabControl.SelectedTab = tab;
                        if (SearchGrid(text, GetGrid(tab), inField, ignoreLetterCase, useRegex, backward))
                            return true;
                    }
                return false;
            }
        }

        public bool Search(string text, bool allColumns, bool everywhere, bool inField,
            bool ignoreLetterCase, bool useRegex, bool backward)
        {
            // UNDONE: W końcu porządny Search
            /*
            bool found = CurrentGrid.CurrentCell != null &&
                SearchColumn(text, CurrentGrid, CurrentGrid.CurrentCell.ColumnIndex, allColumns || everywhere,
                    searchInField, ignoreLetterCase, useRegex, backward);

            if (found == false && (allColumns || everywhere))
                found = SearchGrid(text, CurrentGrid, searchInField, ignoreLetterCase, useRegex, backward);
            
            if (found == false && everywhere)
                found = SearchEverywhere(text, searchInField, ignoreLetterCase, useRegex, backward);
            */
            bool found = false;
            if (everywhere)
                found = SearchEverywhere(text, inField, ignoreLetterCase, useRegex, backward);
            else if (allColumns)
                found = SearchGrid(text, CurrentGrid, inField, ignoreLetterCase, useRegex, backward);
            else
                found = SearchColumn(text, CurrentGrid, CurrentGrid.CurrentCell.ColumnIndex,
                    false, inField, ignoreLetterCase, useRegex, backward);

            if (found)
                MessageLabel.Text = String.Format(Messages.StatusTextFound, text);
            else
                MessageLabel.Text = String.Format(Messages.StatusTextNotFound, text);

            return found;
        }

        private string searchText = "";
        private bool searchAllColumns = false;
        private bool searchEverywhere = false;
        private bool searchInField = false;
        private bool searchIgnoreCase = true;
        private bool searchRegex = false;
        private bool searchBackward = false;

        private void SearchNextMenu_Click(object sender, EventArgs e)
        {
            Search(searchText, searchAllColumns, searchEverywhere,
                searchInField, searchIgnoreCase, searchRegex, false);
        }

        private void SearchPreviousMenu_Click(object sender, EventArgs e)
        {
            Search(searchText, searchAllColumns, searchEverywhere,
                searchInField, searchIgnoreCase, searchRegex, true);
        }

        private void SearchNewMenu_Click(object sender, EventArgs e)
        {
            using (SearchForm form = new SearchForm())
            {
                for (int rowIndex = 0; rowIndex < CurrentGrid.RowCount; rowIndex++)
                    if (CurrentGrid.CurrentCell != null &&
                        form.SearchTextBox.AutoCompleteCustomSource.Contains(
                        CurrentGrid.Rows[rowIndex].Cells[
                            CurrentGrid.CurrentCell.ColumnIndex].FormattedValue.ToString()) == false)
                        form.SearchTextBox.AutoCompleteCustomSource.Add(
                            CurrentGrid.Rows[rowIndex].Cells[
                                CurrentGrid.CurrentCell.ColumnIndex].FormattedValue.ToString());
                if (form.SearchTextBox.AutoCompleteCustomSource.Count > 0)
                {
                    form.SearchTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    form.SearchTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                }

                if (form.ShowDialog() == DialogResult.OK)
                {
                    searchText = form.SearchTextBox.Text;
                    searchAllColumns = form.SearchAllColumnsCheck.Checked;
                    searchEverywhere = form.SearchEverywhereCheck.Checked;
                    searchInField = form.SearchInFieldCheck.Checked;
                    searchIgnoreCase = form.SearchIgnoreCaseCheck.Checked;
                    searchRegex = form.SearchRegexCheck.Checked;
                    searchBackward = form.BackwardSearchCheck.Checked;

                    bool found = Search(searchText, searchAllColumns, searchEverywhere,
                        searchInField, searchIgnoreCase, searchRegex, searchBackward);

                    if (found == false &&
                        searchEverywhere == false)
                    {
                        if (MessageBox.Show(String.Format(Messages.QuestionSearchEverywhere, searchText),
                            Messages.TitleQuestion,
                            MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                            if (Search(searchText, true, true,
                                searchInField, searchIgnoreCase, searchRegex, searchBackward) == false)
                                MessageBox.Show(String.Format(Messages.StatusTextNotFound, searchText),
                                    Messages.TitleInformation, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (found == false)
                        MessageBox.Show(String.Format(Messages.StatusTextNotFound, searchText),
                            Messages.TitleInformation, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void FilterShowAllMenu_Click(object sender, EventArgs e)
        {
            SelectFilter("");
        }

        private void CampaignStartMenu_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Messages.ConfirmStartSending, Messages.TitleConfirm,
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Timer.Enabled = true;
                Timer.Interval = 60 * 60 * 1000 / Settings.Default.SendMessagesPerHour;
                Progress.Minimum = 0;
                Progress.Maximum = CurrentSendingSource.Count;
                MessageLabel.Text = String.Format(Messages.StatusSendStarted, CurrentSendingSource.Count);
            }
        }

        public bool SendSms(string index, string phoneNumber, string message)
        {
            try
            {
            }
            catch (Exception ex)
            {
                AddToSendLog(String.Format(Messages.LogSendSmsErrorInfo, phoneNumber), index, ex);
            }
            return true;
        }

        public bool SendEmail(string index, string email, string message)
        {
            try
            {
            }
            catch (Exception ex)
            {
                AddToSendLog(String.Format(Messages.LogSendEmailErrorInfo, email), index, ex);
            }
            return true;
        }

        public void AddToSendLog(string message, string index, Exception ex)
        {
            try
            {
                if (Settings.Default.LogFileName == "" || File.Exists(Settings.Default.LogFileName))
                {
                    Settings.Default.LogFileName = Path.Combine(Application.LocalUserAppDataPath, "Sending.log");
                    Settings.Default.Save();
                }
                File.AppendAllText(Settings.Default.LogFileName, 
                    String.Format(Messages.LogSendError, DateTime.Now, index, message, ex.Message));

            }
            catch
            {
            }
            // TODO: Wyświetlanie tego loga w na formularzu - opcjach konfiguracyjnych linkiem
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (CurrentSendingSource.Count > 0)
            {
                Progress.Increment(1);
                string index = "";
                try
                {
                    index = ((DataRowView)CurrentSendingSource.Current)[
                        SmsProject.Sent.IndexColumn.ColumnName].ToString();
                    SmsProject.SentRow row = SmsProject.Sent.FindByIndex(index);
                    switch (SmsConverter.ToDeliveryTypes(row.Type))
                    {
                        case DeliveryTypes.Email:
                            row.IsError = SendEmail(index, row.ToAddress, row.Message) == false;
                            break;
                        case DeliveryTypes.Sms:
                            row.IsError = SendSms(index, row.ToAddress, row.Message) == false;
                            break;
                        default:
                            throw new Exception(String.Format(Messages.ErrorUnknownDeliveryType, row.Type));
                    }
                    row.SendDate = DateTime.Now;
                    row.IsSent = true;
                    row.AcceptChanges();
                }
                catch (Exception ex)
                {
                    AddToSendLog(Messages.ErrorInternal, index, ex);
                }
            }
            else
            {
                Progress.Value = 0;
                MessageLabel.Text = Messages.StatusSendFinished;
                Timer.Enabled = false;
            }
        }

        private void CampaignPauseMenu_Click(object sender, EventArgs e)
        {
            Timer.Enabled = false;
            MessageLabel.Text = String.Format(Messages.StatusSendPaused, CurrentSendingSource.Count);
        }

        private void CampaignNewMenu_Click(object sender, EventArgs e)
        {
            using (CampaignEditForm form = new CampaignEditForm())
            {
                form.ShowDialog();
            }
        }

        private void CampaignMessageMenu_Click(object sender, EventArgs e)
        {
            try
            {
                using (TemplateEditForm form = new TemplateEditForm())
                {
                    DataGridViewCell templateCell = null;
                    DataGridViewCell messageCell = null;
                    SmsProject.FillColumns();
                    form.ColumnsGrid.DataSource = SmsProject.Columns;
                    templateCell = Grid.GetCell(CurrentGrid.CurrentRow, SmsProject.Messages.MessageColumn);
                    messageCell = Grid.GetCell(CurrentGrid.CurrentRow, SmsProject.Messages.MessageTextColumn);
                    form.SmsProject = SmsProject;
                    form.TemplateCombo.Text = Grid.GetStringValue(templateCell);
                    form.MessageText.Text = Grid.GetStringValue(messageCell);
                    if (CurrentGrid == CampaignsGrid)
                    {
                        if (CurrentGrid.CurrentCell == templateCell)
                            form.MessageText.ReadOnly = true;
                        else if (CurrentGrid.CurrentCell == messageCell)
                            form.TemplateCombo.Enabled = false;
                    }
                    else if (CurrentGrid == SentGrid)
                    {
                    }
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        SmsProject.UpdateMessages(
                            form.TemplateCombo.Text,
                            form.MessageText.Text);

                        if (CurrentGrid != MessagesGrid)
                        {
                            templateCell.Value = form.TemplateCombo.Text;
                            messageCell.Value = form.MessageText.Text;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ShowError(Messages.ErrorSaveMessage, ex);
            }
        }

        private void ToolsSettingsMenu_Click(object sender, EventArgs e)
        {

        }

        private void ToolsPromoSmsMenu_Click(object sender, EventArgs e)
        {

        }

        private void HelpAboutMenu_Click(object sender, EventArgs e)
        {

        }

        private void HelpHomePageMenu_Click(object sender, EventArgs e)
        {

        }

        private void HelpBuyProgramMenu_Click(object sender, EventArgs e)
        {

        }

        private void HelpAutoUpdateMenu_Click(object sender, EventArgs e)
        {

        }

        private void HelpSupportMenu_Click(object sender, EventArgs e)
        {

        }

        private void HelpSuggestionMenu_Click(object sender, EventArgs e)
        {

        }

        private void HelpRegisterMenu_Click(object sender, EventArgs e)
        {

        }

        private void ToolsAutoUpdateMenu_Click(object sender, EventArgs e)
        {

        }

        private void ToolsTestSystemMenu_Click(object sender, EventArgs e)
        {

        }

        public TextBox GetDescriptionTextBox(TabPage page)
        {
            TextBox textBox = (TextBox)GetSplit(page).Panel2.Controls[0];
            return textBox;
        }

        public TextBox CurrentDescriptionTextBox
        {
            get { return GetDescriptionTextBox(TabControl.SelectedTab); }
        }

        public SplitContainer CurrentSplit
        {
            get { return GetSplit(TabControl.SelectedTab); }
        }

        public SplitContainer GetSplit(TabPage page)
        {
            foreach (Control control in page.Controls)
                if (control is SplitContainer)
                    return (SplitContainer)control;
            return null;
        }

        public DataGridView GetGrid(TabPage page)
        {
            foreach (Control control in GetSplit(page).Panel1.Controls)
                if (control is DataGridView)
                    return (DataGridView)control;
            return null;
        }

        public DataGridView CurrentGrid
        {
            get { return GetGrid(TabControl.SelectedTab); }
        }

        public BindingSource GetSource(DataGridView grid)
        {
            if (grid != null)
                return (BindingSource)grid.DataSource;
            else
                return null;
        }

        public BindingSource CurrentSource
        {
            get { return GetSource(CurrentGrid); }
        }

        public DataTable GetTable(DataGridView grid)
        {
            if (grid != null)
                return SmsProject.Tables[GetSource(grid).DataMember];
            else
                return null;
        }

        public DataTable CurrentTable
        {
            get { return GetTable(CurrentGrid); }
        }

        public void DeleteFilter(string filterExpression)
        {
            if (Filter.DecodeFullName(filterExpression) != "")
            {
                if (MessageBox.Show(
                    String.Format(Messages.ConfirmDeleteFilter, filterExpression), Messages.TitleConfirm, 
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Settings.Default.Filters = Filter.Delete(filterExpression, Settings.Default.Filters);
                    MessageLabel.Text = String.Format(Messages.StatusFilterDeleted, filterExpression);
                }
            }
            else
                MessageLabel.Text = String.Format(Messages.StatusFilterHasEmptyName, filterExpression);
        }

        public string AddFilter(string sourceFilter, string filterExpression, bool or)
        {
            string filter = Filter.DecodeExpression(FilterTextBox.Text);
            try
            {
                if (or)
                {
                    if (filter != "")
                        filter = String.Format("({0}) OR ({1})", filter,
                            Filter.DecodeExpression(filterExpression));
                    else
                        filter = Filter.DecodeExpression(filterExpression);
                }
                else
                {
                    if (filter != "")
                        filter = String.Format("{0} AND {1}", filter, Filter.DecodeExpression(filter));
                    else
                        filter = Filter.DecodeExpression(filter);
                }
                return filter;
            }
            catch (Exception ex)
            {
                ShowError(String.Format(Messages.ErrorBadFilter, filter), ex);
                return FilterTextBox.Text;
            }
        }

        public void SelectFilter(string filterExpression)
        {
            try
            {
                if (filterExpression == "")
                {
                    CurrentSource.Filter = "";
                    FilterTextBox.Text = "";
                    MessageLabel.Text = String.Format(Messages.StatusFilterCleared, CurrentGrid.RowCount);
                }
                else
                {
                    filterExpression = Filter.InsertTable(filterExpression, CurrentTable.TableName);
                    filterExpression = Templater.ToNames(CurrentTable.Columns, filterExpression);

                    // <TableName.FilterName> FilterExpression w prawdziwych nazwach kolumn
                    string fullName = Filter.DecodeFullName(filterExpression);
                    if (fullName != "" && filterExpression != "")
                        Settings.Default.Filters = Filter.Update(filterExpression, Settings.Default.Filters);

                    if (fullName != "" && filterExpression == "")
                        filterExpression = Filter.Get(filterExpression, Settings.Default.Filters);

                    FilterTextBox.Text = Templater.ToCaptions(CurrentTable.Columns, Filter.RemoveTable(filterExpression));

                    CurrentSource.Filter = Filter.DecodeExpression(filterExpression);
                    MessageLabel.Text = String.Format(Messages.StatusFilterChanged,
                        FilterTextBox.Text, CurrentGrid.RowCount);
                }

                Filter.ToAutoComplete(Settings.Default.Filters, CurrentTable, 
                    FilterTextBox.AutoCompleteCustomSource);
            }
            catch (Exception ex)
            {
                ShowError(String.Format(Messages.ErrorBadFilter, Templater.ToCaptions(CurrentTable.Columns, 
                    Filter.DecodeExpression(filterExpression))), ex);
            }
        }

        private void FilterButton_Click(object sender, EventArgs e)
        {
            SelectFilter(FilterTextBox.Text);
        }

        private void FilterTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                FilterButton_Click(sender, e);

            // HACK: "Ręczna" obsługą schowka
            if (e.Control)
                switch (e.KeyCode)
                {
                    case Keys.X:
                        Clipboard.SetText(((TextBox)sender).SelectedText, TextDataFormat.UnicodeText);
                        ((TextBox)sender).SelectedText = "";
                        break;
                    case Keys.C:
                        Clipboard.SetText(((TextBox)sender).SelectedText, TextDataFormat.UnicodeText);
                        break;
                    case Keys.V:
                        if (Clipboard.GetText(TextDataFormat.UnicodeText) != "")
                            ((TextBox)sender).SelectedText = Clipboard.GetText(TextDataFormat.UnicodeText);
                        break;
                }

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        public bool IsInt(Type type)
        {
            return type == typeof(byte) || type == typeof(sbyte) ||
                type == typeof(short) || type == typeof(short) ||
                type == typeof(int) || type == typeof(uint) ||
                type == typeof(long) || type == typeof(ulong);
        }

        public bool IsFloat(Type type)
        {
            return type == typeof(float) || type == typeof(double) || type == typeof(decimal);
        }

        public void GridInit(DataGridView grid)
        {
                DataTable table = GetTable(grid);
            foreach (DataGridViewColumn column in grid.Columns)
            {
                string fieldName = column.DataPropertyName;
                if (IsInt(column.ValueType) || IsFloat(column.ValueType) ||
                    column.ValueType == typeof(DateTime) || 
                    fieldName == SmsProject.Campaigns.TypeColumn.ColumnName ||
                    fieldName == SmsProject.Campaigns.CreateDateColumn.ColumnName ||
                    fieldName == SmsProject.Campaigns.ModifyDateColumn.ColumnName)
                    column.CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                if (column.ReadOnly)
                    column.CellTemplate.Style.BackColor = Settings.Default.ColorReadOnly;
                else if (table.PrimaryKey[0].ColumnName == fieldName)
                    column.CellTemplate.Style.BackColor = Settings.Default.ColorPrimaryKey;
                else if (SmsProject.GetParentLookupTable(CurrentTable, fieldName) != null)
                    column.CellTemplate.Style.BackColor = Settings.Default.ColorForeignKey;
                else if (SmsProject.CustomFields.FindByCustomTableCustomField(GetTable(grid).TableName, fieldName) != null)
                    column.CellTemplate.Style.BackColor = Settings.Default.ColorCustomField;

                if (table.Columns[fieldName] != null)
                    column.HeaderText = table.Columns[fieldName].Caption;
            }
        }

        public void GridInit()
        {
            for (int tabIndex = 0; tabIndex < TabControl.TabCount; tabIndex++)
                GridInit(GetGrid(TabControl.TabPages[tabIndex]));
        }

        private void Grid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            ShowError(Messages.ErrorBadData, e.Exception);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (SmsProject.Modified && 
                e.CloseReason == CloseReason.UserClosing)
                switch(MessageBox.Show(Messages.ConfirmSaveFile, Messages.TitleConfirm,
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                {
                    case DialogResult.Yes:
                        if (SmsProject.FileName != "")
                        {
                            SaveFileDialog.FileName = SmsProject.FileName;
                            FileSaveMenu_Click(sender, e);
                        }
                        else
                            FileSaveAsMenu_Click(sender, e);
                        break;
                    case DialogResult.No:
                        break;
                    case DialogResult.Cancel:
                        e.Cancel = true;
                        break;
                }

            if (e.Cancel == false)
            {
                Settings.Default.FileName = SmsProject.FileName;
                Settings.Default.Save();
            }
        }

        private void EditInsertLookupMenu_Click(object sender, EventArgs e)
        {
            if (CurrentGrid.CurrentCell != null)
            {
                try
                {
                    CurrentGrid.EndEdit();
                    string fieldName = CurrentGrid.CurrentCell.OwningColumn.DataPropertyName;
                    DataTable table = SmsProject.GetLookupTable(CurrentTable, fieldName);
                    if (table != null && CurrentTable.PrimaryKey[0].ColumnName != fieldName)
                    {
                        if (table.Rows.Count == 0)
                            MessageBox.Show(
                                String.Format(Messages.InfoColumnHasNoData, CurrentTable.Columns[fieldName].Caption),
                                Messages.TitleInformation, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            using (InsertLookupForm form = new InsertLookupForm())
                            {
                                form.LookupTextBox.Text = CurrentGrid.CurrentCell.Value.ToString();
                                form.DataGridView.DataSource = table;
                                foreach (DataGridViewColumn column in form.DataGridView.Columns)
                                    column.HeaderText = table.Columns[column.DataPropertyName].Caption;
                                if (form.ShowDialog() == DialogResult.OK)
                                {
                                    foreach (DataGridViewCell cell in CurrentGrid.SelectedCells)
                                        if (cell.ColumnIndex == CurrentGrid.CurrentCell.ColumnIndex)
                                            cell.Value = form.LookupTextBox.Text;
                                }
                            }
                    }
                }
                catch
                {
                }
            }
        }

        public List<string> GetSelectedPrimaryKeys(DataGridView grid)
        {
            List<string> primaryKeys = new List<string>();
            foreach (DataGridViewCell cell in grid.SelectedCells)
                if (cell.ColumnIndex == 0 && primaryKeys.Contains(cell.Value.ToString()) == false)
                    primaryKeys.Add(cell.Value.ToString());
            return primaryKeys;
        }

        private void EditDeleteMenu_Click(object sender, EventArgs e)
        {
            if (ActiveControl is SplitContainer &&
                (ActiveControl as SplitContainer).ActiveControl is TextBox)
            {
                ((ActiveControl as SplitContainer).ActiveControl as TextBox).SelectedText = "";
            }
            else
            {
                List<string> primaryKeys = GetSelectedPrimaryKeys(CurrentGrid);
                if (primaryKeys.Count > 0 &&
                    MessageBox.Show(String.Format(Messages.ConfirmDeleteData, primaryKeys.Count), 
                        Messages.TitleConfirm, 
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                    return;

                if (primaryKeys.Count == 0)
                    foreach (DataGridViewCell cell in CurrentGrid.SelectedCells)
                    {
                        if (cell.OwningColumn.DataPropertyName != CurrentTable.PrimaryKey[0].ColumnName &&
                            cell.OwningColumn.ReadOnly == false)
                            cell.Value = null;
                    }
                else
                {
                    int count = SmsProject.DeleteRows(CurrentTable, primaryKeys);
                    MessageLabel.Text = String.Format(Messages.StatusRowsDeleted, count);
                }

            }
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            SmsProject.InitDelegates();
            GridInit();
            if (Settings.Default.FileName != "" &&
                File.Exists(Settings.Default.FileName))
                Open(Settings.Default.FileName);
            TabControl.SelectedTab = ContactsTab;
            ActiveControl = ContactsGrid;
        }

        private void Grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (CurrentGrid.CurrentCell != null)
            {
                string fieldName = CurrentGrid.CurrentCell.OwningColumn.DataPropertyName;
                if (CurrentGrid == MessagesGrid ||
                    fieldName == SmsProject.Messages.MessageTextColumn.ColumnName)
                    CampaignMessageMenu_Click(sender, e);
                else if (fieldName == SmsProject.Contacts.DescriptionColumn.ColumnName)
                    CurrentDescriptionTextBox.Focus();
                else if (fieldName == CurrentTable.PrimaryKey[0].ColumnName)
                    CurrentGrid.BeginEdit(false);
                else if (CurrentGrid.CurrentCell.OwningColumn.ReadOnly == false)
                    EditInsertLookupMenu_Click(sender, e);
            }
        }

        private void Grid_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            GridLookupMenu.Enabled = CurrentGrid.CurrentCell != null && 
                CurrentGrid.CurrentCell.OwningColumn.ReadOnly == false;
            EditLookupMenu.Enabled = GridLookupMenu.Enabled;
            InsertLookupButton.Enabled = GridLookupMenu.Enabled;

            GridSearchNextMenu.Enabled = searchText != "";
            EditSearchNextMenu.Enabled = GridSearchNextMenu.Enabled;

            GridAddTextFilterMenu.Enabled = CurrentGrid.CurrentCell != null &&
                CurrentGrid.CurrentCell.Value != null &&
                CurrentGrid.CurrentCell.ValueType == typeof(string);
            FilterAddTextMenu.Enabled = GridAddTextFilterMenu.Enabled;

            GridMessageMenu.Enabled =
                (CurrentTable == SmsProject.Messages ||
                CurrentTable == SmsProject.Campaigns ||
                CurrentTable == SmsProject.Sent);
            CampaignMessageMenu.Enabled = GridMessageMenu.Enabled;

            EditUndoMenu.Enabled = (SmsProject.FileName != "" && SmsProject.Modified);
        }

        private void Grid_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
        }

        private void Grid_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            // TODO: Zmiana kluczy wymaga zmian odwołań w bazie danych!
            if (CurrentGrid == CampaignsGrid &&
                CurrentGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningColumn.DataPropertyName == 
                SmsProject.Campaigns.IsClosedColumn.ColumnName &&
                e.RowIndex != CurrentGrid.NewRowIndex)
            {
                try
                {
                    object value = CurrentGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                    LockGridRow(CurrentGrid.Rows[e.RowIndex], value != null && (bool)value);
                    Refresh();
                }
                catch (Exception ex)
                {
                    ShowError(Messages.ErrorBadData, ex);
                }
            }
        }

        private void Grid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (CurrentGrid == CampaignsGrid && e.RowIndex >= 0 && e.ColumnIndex == 0 && e.Value != null)
                LockGridRow(CurrentGrid.Rows[e.RowIndex], SmsProject.IsClosed(e.Value.ToString()));
        }

        private void Grid_Paint(object sender, PaintEventArgs e)
        {
            if (CurrentGrid == CampaignsGrid)
                foreach (DataGridViewRow row in CurrentGrid.Rows)
                    LockGridRow(row, SmsProject.IsClosed(Grid.GetStringValue(Grid.GetCell(row, 
                        SmsProject.Campaigns.CampaignColumn))));
            else if (CurrentGrid == SentGrid)
                foreach (DataGridViewRow row in CurrentGrid.Rows)
                    LockGridRow(row, SmsProject.IsSent(Grid.GetStringValue(Grid.GetCell(row, 
                        SmsProject.Sent.IndexColumn))));
        }

        public void LockGridRow(DataGridViewRow row, bool readOnly)
        {
            // UNDONE: Wyrzuciłem LockGridRow
            /*foreach (DataGridViewCell cell in row.Cells)
                if (cell.ReadOnly != readOnly &&
                    ((cell.DataGridView == CampaignsGrid &&
                        GridHelper.IsDataPropertyName(cell, SmsProject.Campaigns.DescriptionColumn) == false &&
                        GridHelper.IsDataPropertyName(cell, SmsProject.Campaigns.IsClosedColumn) == false) ||
                    (cell.DataGridView == SentGrid &&
                        GridHelper.IsDataPropertyName(cell, SmsProject.Sent.DescriptionColumn) == false) ||
                    (cell.DataGridView == ReceivedGrid &&
                        GridHelper.IsDataPropertyName(cell, SmsProject.Received.DescriptionColumn) == false &&
                        GridHelper.IsDataPropertyName(cell, SmsProject.Received.CampaignColumn) == false)))
                {
                    cell.ReadOnly = readOnly;
                    if (readOnly)
                    {
                        cell.Style = new DataGridViewCellStyle(cell.OwningColumn.CellTemplate.Style);
                        cell.Style.BackColor = Settings.Default.ColorClosed;
                    }
                    else
                        cell.Style = cell.OwningColumn.CellTemplate.Style;
                }*/
        }

        private void FilterBuilderMenu_Click(object sender, EventArgs e)
        {
            using (FilterBuilderForm form = new FilterBuilderForm())
            {
                SmsProject.FillColumns();
                form.ColumnsGrid.DataSource = SmsProject.Columns; ;
                form.FilterExpressionTextBox.Text = FilterTextBox.Text;
                Filter.ToListBox(Settings.Default.Filters, CurrentTable, form.FiltersListBox.Items);

                DialogResult result = form.ShowDialog();
                if (result == DialogResult.OK && form.FilterExpressionTextBox.Text != "")
                    SelectFilter(form.FilterExpressionTextBox.Text);
                else if (result == DialogResult.Abort)
                    DeleteFilter(form.FilterExpressionTextBox.Text);
            }
        }

        private void FilterAddRangeMenu_Click(object sender, EventArgs e)
        {
            if (CurrentGrid.CurrentCell != null)
                try
                {
                    if (CurrentGrid.CurrentCell.ValueType == typeof(DateTime))
                    {
                        using (FilterDatesForm form = new FilterDatesForm())
                        {
                            form.Text += " [" + CurrentGrid.CurrentCell.OwningColumn.HeaderText + "]";
                            if (CurrentGrid.CurrentCell.Value != null)
                            {
                                form.FromDatePicker.Value = (DateTime)CurrentGrid.CurrentCell.Value;
                                form.FromTimePicker.Value = (DateTime)CurrentGrid.CurrentCell.Value;
                                form.ToDatePicker.Value = (DateTime)CurrentGrid.CurrentCell.Value;
                                form.ToTimePicker.Value = (DateTime)CurrentGrid.CurrentCell.Value;
                            }
                            if (form.ShowDialog() == DialogResult.OK)
                                if (form.ReplaceFilterCheckBox.Checked)
                                    SelectFilter(form.FilterTextBox.Text);
                                else
                                    SelectFilter(Filter.Add(FilterTextBox.Text,
                                        form.FilterTextBox.Text, form.OrFilterCheckBox.Checked));
                        }
                    }
                    else
                    {
                        using (FilterRangeForm form = new FilterRangeForm())
                        {
                            form.Text += " [" + CurrentGrid.CurrentCell.OwningColumn.HeaderText + "]";
                            if (CurrentGrid.CurrentCell.Value != null)
                            {
                                form.FromTextBox.Text = CurrentGrid.CurrentCell.Value.ToString();
                                form.ToTextBox.Text = CurrentGrid.CurrentCell.Value.ToString();
                            }
                            if (form.ShowDialog() == DialogResult.OK)
                                if (form.ReplaceFilterCheckBox.Checked)
                                    SelectFilter(form.FilterTextBox.Text);
                                else
                                    SelectFilter(Filter.Add(FilterTextBox.Text,
                                        form.FilterTextBox.Text, form.OrFilterCheckBox.Checked));
                        }
                    }
                }
                catch (Exception ex)
                {
                    ShowError(Messages.ErrorAddRangeFilter, ex); 
                }
        }

        private void FilterAddTextMenu_Click(object sender, EventArgs e)
        {
            if (CurrentGrid.CurrentCell != null)
                try
                {
                    using (FilterTextForm form = new FilterTextForm())
                    {
                        form.Text += " [" + CurrentGrid.CurrentCell.OwningColumn.HeaderText + "]";
                        if (CurrentGrid.CurrentCell.Value != null)
                            form.FormatTextBox.Text = CurrentGrid.CurrentCell.Value.ToString();
                        if (form.ShowDialog() == DialogResult.OK)
                            if (form.ReplaceFilterCheckBox.Checked)
                                SelectFilter(form.FilterTextBox.Text);
                            else
                                SelectFilter(Filter.Add(FilterTextBox.Text,
                                    form.FilterTextBox.Text, form.OrFilterCheckBox.Checked));
                    }
                }
                catch (Exception ex)
                {
                    ShowError(Messages.ErrorAddTextFilter, ex);
                }
        }

        private void DescriptionTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
                switch (e.KeyCode)
                {
                    case Keys.X:
                        Clipboard.SetText(((TextBox)sender).SelectedText, TextDataFormat.UnicodeText);
                        ((TextBox)sender).SelectedText = "";
                        break;
                    case Keys.C:
                        Clipboard.SetText(((TextBox)sender).SelectedText, TextDataFormat.UnicodeText);
                        break;
                    case Keys.V:
                        if (Clipboard.GetText(TextDataFormat.UnicodeText) != "")
                            ((TextBox)sender).SelectedText = Clipboard.GetText(TextDataFormat.UnicodeText);
                        break;
                }
        }

        private void ToolsCustomFieldsMenu_Click(object sender, EventArgs e)
        {
            // TODO: Formularz CustomFieldsForm i również pola wyliczalne
            // TODO: Dodawanie kampanii do telefonów aby można było oglądać wyniki
        }

        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridInit(CurrentGrid);
            SelectFilter("");
        }

        public List<string> GetListToCampaignAdd(DataGridView grid)
        {
            List<string> list = new List<string>();
            if (CurrentTable == SmsProject.Contacts)
                foreach(DataGridViewCell cell in CurrentGrid.SelectedCells)
                {
                    DataGridViewCell phoneCell = Grid.GetCell(cell.OwningRow, SmsProject.Contacts.ContactColumn);
                    if (list.Contains(phoneCell.Value.ToString()) == false)
                        list.Add(phoneCell.Value.ToString());
                }
            else if (CurrentTable == SmsProject.Groups)
                foreach (DataGridViewCell cell in CurrentGrid.SelectedCells)
                {
                    DataGridViewCell groupCell = Grid.GetCell(cell.OwningRow, SmsProject.Groups.GroupColumn);
                    if (list.Contains(groupCell.Value.ToString()) == false)
                        list.Add(groupCell.Value.ToString());
                }
            else if (CurrentTable == SmsProject.Companies)
                foreach (DataGridViewCell cell in CurrentGrid.SelectedCells)
                {
                    DataGridViewCell companyCell = Grid.GetCell(cell.OwningRow, SmsProject.Companies.CompanyColumn);
                    if (list.Contains(companyCell.Value.ToString()) == false)
                        list.Add(companyCell.Value.ToString());
                }
            else if (CurrentTable == SmsProject.Campaigns)
                foreach (DataGridViewCell cell in CurrentGrid.SelectedCells)
                {
                    DataGridViewCell campaignCell = Grid.GetCell(cell.OwningRow, SmsProject.Campaigns.CampaignColumn);
                    if (list.Contains(campaignCell.Value.ToString()) == false)
                        list.Add(campaignCell.Value.ToString());
                }
            return list;
        }

        public string GetCampaignLabelInfo(DataTable table, int count)
        {
            if (table == SmsProject.Contacts ||
                table == SmsProject.Sent ||
                table == SmsProject.Received)
                return String.Format(Messages.LabelCampaignContactsAdd, count);
            else if (table == SmsProject.Groups)
                return String.Format(Messages.LabelCampaignGroupsAdd, count);
            else if (table == SmsProject.Companies)
                return String.Format(Messages.LabelCampaignCompaniesAdd, count);
            else if (table == SmsProject.Campaigns)
                return String.Format(Messages.LabelCampaignCampaignsAdd, count);
            else
                return "";
        }

        private void CampaignEditMenu_Click(object sender, EventArgs e)
        {
            if (CurrentTable != SmsProject.Messages)
                try
                {
                    using (CampaignAddForm form = new CampaignAddForm())
                    {
                        List<string> list = GetListToCampaignAdd(CurrentGrid);
                        BindingSource source = new BindingSource(SmsProject.Campaigns,"");
                        form.DataGridView.DataSource = source;
                        source.Filter = String.Format("NOT [{0}]", SmsProject.Campaigns.IsClosedColumn.ColumnName);
                        foreach (DataGridViewColumn column in form.DataGridView.Columns)
                            column.HeaderText = SmsProject.Campaigns.Columns[column.DataPropertyName].Caption;
                        form.InfoLabel.Text = GetCampaignLabelInfo(CurrentTable, list.Count);
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            string campaignKey = form.DataGridView.CurrentRow.Cells[0].Value.ToString();
                            int count = SmsProject.AddToCampaign(CurrentTable, campaignKey, list);
                            MessageLabel.Text = String.Format(Messages.StatusCampaignAdded, count, campaignKey);
                        }
                    }
                }
                catch (Exception ex)
                {
                    ShowError(Messages.ErrorCampaignAdd, ex);
                }
        }

        private void EditPasteSpecialMenu_Click(object sender, EventArgs e)
        {
            // TODO: Dodawanie razem z nazwami kolumn
            // TODO: PKSoft.Localizer.Translate przed każdym wyświetleniem formularza (FormShown)
            // TODO: Posprawdzać końcówki w formularzach przed przetłumaczeniem za pomocą Localizera, np. Grid
            // TODO: formularz Filtra dla i listy wyboru
            // TODO: Nokia SMS - MAM SDK!!!! :D
        }

        private void EditUndoMenu_Click(object sender, EventArgs e)
        {
            if (SmsProject.FileName != "")
                try
                {
                    SmsProject.ReadXml(SmsProject.FileName);
                    MessageLabel.Text = Messages.StatusUndo;
                }
                catch (Exception ex)
                {
                    ShowError(Messages.ErrorUndo, ex);
                }
        }

        private void EditAddNewMenu_Click(object sender, EventArgs e)
        {
            if (CurrentGrid.CurrentCell != null)
            {
                if (CurrentGrid.CurrentCell.RowIndex < CurrentGrid.NewRowIndex)
                {
                    if (CurrentGrid == SentGrid || CurrentGrid == ReceivedGrid)
                        CurrentGrid.CurrentCell = CurrentGrid.Rows[CurrentGrid.NewRowIndex].Cells[1];
                    else
                        CurrentGrid.CurrentCell = CurrentGrid.Rows[CurrentGrid.NewRowIndex].Cells[0];
                    CurrentGrid.BeginEdit(false);
                }
            }
        }

        private void EditSelectAllMenu_Click(object sender, EventArgs e)
        {
            CurrentGrid.SelectAll();
        }

        private void CampaignSendOneSmsMenu_Click(object sender, EventArgs e)
        {

        }
    }
}