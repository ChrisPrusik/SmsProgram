using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SmsProgram
{
    public partial class FilterDatesForm : Form
    {
        public FilterDatesForm()
        {
            InitializeComponent();
        }

        private void DateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            string columnName = "";
            string filter = "";
            try
            {
                columnName = Text.Substring(Text.IndexOf("[") + 1);
                columnName = columnName.Substring(0, columnName.IndexOf("]"));
                filter = "";

                if (FromDatePicker.Checked == false)
                    FromTimePicker.Checked = false;
                if (ToDatePicker.Checked == false)
                    ToTimePicker.Checked = false;

                if (FromDatePicker.Checked == false && FromTimePicker.Checked == false)
                    filter += "";
                else if (FromDatePicker.Checked && FromTimePicker.Checked == false)
                    filter += String.Format("[{0}] >= '{1}' ",columnName, 
                        FromDatePicker.Value.ToShortDateString());
                else if (FromDatePicker.Checked && FromTimePicker.Checked)
                    filter += String.Format("[{0}] >= '{1} {2}' ",columnName, 
                        FromDatePicker.Value.ToShortDateString(), 
                        FromTimePicker.Value.ToShortTimeString());

                if (ToDatePicker.Checked == false && ToTimePicker.Checked == false)
                    filter += "";
                else if (ToDatePicker.Checked && ToTimePicker.Checked == false)
                    filter += String.Format("AND [{0}] < '{1}' ", columnName,
                        ToDatePicker.Value.AddDays(1).ToShortDateString());
                else if (ToDatePicker.Checked && FromTimePicker.Checked)
                    filter += String.Format("AND [{0}] < '{1} {2}' ", columnName,
                        ToDatePicker.Value.ToShortDateString(),
                        ToTimePicker.Value.AddSeconds(1).ToShortTimeString());

                filter = filter.Trim();

                if (filter.StartsWith("AND"))
                    filter = filter.Remove(0, 3);

                FilterTextBox.Text = filter;
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format(Messages.ErrorBadFilter, filter) + " " +
                    ex.Message, Messages.TitleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FilterDatesForm_Shown(object sender, EventArgs e)
        {
            ActiveControl = FromDatePicker;
        }
    }
}
