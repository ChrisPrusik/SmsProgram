using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SmsProgram
{
    public partial class SearchForm : Form
    {
        public SearchForm()
        {
            InitializeComponent();
        }

        private void SearchForm_Load(object sender, EventArgs e)
        {
            if (SearchEverywhereCheck.Checked)
            {
                SearchAllColumnsCheck.Checked = true;
                SearchAllColumnsCheck.Enabled = false;
            }
            ActiveControl = SearchTextBox;
        }

        private void SearchEverywhereCheckBox_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void SearchEverywhereCheckBox_CheckStateChanged(object sender, EventArgs e)
        {
            if (SearchEverywhereCheck.Checked)
            {
                SearchAllColumnsCheck.Checked = true;
                SearchAllColumnsCheck.Enabled = false;
                SearchEverywhereCheck.Checked = true;
            }
            else
                SearchAllColumnsCheck.Enabled = true;

        }
    }
}
