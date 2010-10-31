using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SmsProgram
{
    public partial class FilterRangeForm : Form
    {
        public FilterRangeForm()
        {
            InitializeComponent();
        }

        private void FromTextBox_TextChanged(object sender, EventArgs e)
        {
            string columnName = "";
            string filter = "";
            try
            {
                columnName = Text.Substring(Text.IndexOf("[") + 1);
                columnName = columnName.Substring(0, columnName.IndexOf("]"));
                filter = "";

                if (FromTextBox.Text != "")
                    filter += String.Format("[{0}] >= '{1}' ", columnName, FromTextBox.Text);
                if (ToTextBox.Text != "")
                    filter += String.Format("AND [{0}] <= '{1}' ", columnName, ToTextBox.Text);
                filter = filter.Trim();
                if (filter.StartsWith("AND"))
                    filter = filter.Remove(0, 3);

                FilterTextBox.Text = filter;
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format(Messages.ErrorBadFilter, filter) +
                    " " + ex.Message, Messages.TitleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
