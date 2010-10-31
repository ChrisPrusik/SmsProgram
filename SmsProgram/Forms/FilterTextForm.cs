using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SmsProgram
{
    public partial class FilterTextForm : Form
    {
        public FilterTextForm()
        {
            InitializeComponent();
        }

        private void FormatTextBox_TextChanged(object sender, EventArgs e)
        {
            string columnName = "";
            string filter = "";
            string format = FormatTextBox.Text.Trim();
            if ((format.StartsWith("*") && format.IndexOf("*", 1) > 0) ||
                (format.EndsWith("*") && format.IndexOf("*") < format.Length - 1) ||
                (format.IndexOf("*") > 0 && format.IndexOf("*") < format.Length - 1))
            {
                MessageBox.Show(Messages.ErrorFilterOneWildcard, Messages.TitleError,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
 
            try
            {
                columnName = Text.Substring(Text.IndexOf("[") + 1);
                columnName = columnName.Substring(0, columnName.IndexOf("]"));
                filter = "";
                if (format != "")
                    filter = String.Format("[{0}] LIKE '{1}' ", columnName, format);

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
