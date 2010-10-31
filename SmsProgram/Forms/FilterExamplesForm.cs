using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SmsProgram
{
    public partial class FilterExamplesForm : Form
    {
        public string PhoneNumberColumn = "PhoneNumber";
        public string FirstNameColumn = "FirstName";
        public string LastNameColumn = "LastName";
        public string CompanyColumn = "Company";
        public string SentCountColumn = "SentCount";
        public string ReceivedCountColumn = "ReceivedCount";
        public string CreateDateColumn = "ModifyDate";
        public string ModifyDateColumn = "CreateDate";
        public string FilterColumn = "Filter";
        public DataTable ExampleTable = new DataTable();

        public FilterExamplesForm()
        {
            InitializeComponent();
        }

        private void FilterFunctionsForm_Shown(object sender, EventArgs e)
        {
            ExampleTable.Columns.Add(PhoneNumberColumn, typeof(string));
            ExampleTable.Columns.Add(FirstNameColumn, typeof(string));
            ExampleTable.Columns.Add(LastNameColumn, typeof(string));
            ExampleTable.Columns.Add(CompanyColumn, typeof(string));
            ExampleTable.Columns.Add(SentCountColumn, typeof(int));
            ExampleTable.Columns.Add(ReceivedCountColumn, typeof(int));
            ExampleTable.Columns.Add(CreateDateColumn, typeof(DateTime));
            ExampleTable.Columns.Add(ModifyDateColumn, typeof(DateTime));
            ExampleTable.Columns.Add(FilterColumn, typeof(string));
            ExampleTable.Rows.Add("+48500234156", "Lara", "Croft", "Tomb raider",
                10, 0, DateTime.Now.AddDays(-10), DateTime.Now);
            ExampleGrid.DataSource = ExampleTable;
            ExampleGrid.Columns[FilterColumn].Visible = false;
        }

        private void FilterExpressionTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ExampleTable.Columns[FilterColumn].Expression = FilterExpressionTextBox.Text;
                FilterResultTextBox.Text = ExampleTable.Rows[
                    ExampleGrid.CurrentRow.Index][FilterColumn].ToString();
            }
            catch(Exception ex)
            {
                FilterResultTextBox.Text = String.Format(Messages.ErrorBadFilter,
                    FilterExpressionTextBox.Text).Replace("\r", "").Replace("\n", "") + 
                    ": " + ex.Message;
            }
        }

        private void FiltersListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (FiltersListBox.SelectedIndex >= 0)
                FilterExpressionTextBox.Text = Filter.DecodeExpression(
                    FiltersListBox.Items[FiltersListBox.SelectedIndex].ToString());
        }

        private void ExampleGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            FilterExpressionTextBox_TextChanged(sender, e);
        }

        private void ExampleGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show(Messages.ErrorBadData + " " + e.Exception.Message, Messages.TitleError, 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
