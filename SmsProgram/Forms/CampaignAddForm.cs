using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SmsProgram
{
    public partial class CampaignAddForm : Form
    {
        public BindingSource GridSource
        {
            get
            {
                if (DataGridView != null)
                    return (BindingSource)DataGridView.DataSource;
                else
                    return null;
            }
        }

        public DataTable GridTable
        {
            get
            {
                if (GridSource != null)
                    return (DataTable)GridSource.DataSource;
                else
                    return null;
            }
        }

        public string FieldName
        {
            get
            {
                if (GridTable != null)
                    return GridTable.PrimaryKey[0].ColumnName;
                else
                    return "";
            }
        }

        public CampaignAddForm()
        {
            InitializeComponent();
        }

        private void LookupTextBox_TextChanged(object sender, EventArgs e)
        {
            if (GridTable != null)
                foreach (DataRow row in GridTable.Rows)
                    if ((row[FieldName].ToString()).ToLower().StartsWith(LookupTextBox.Text.ToLower()))
                    {
                        DataGridView.Rows[GridTable.Rows.IndexOf(row)].Selected = true;
                        return;
                    }
        }

        private void DataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            LookupTextBox.Text = GridTable.Rows[DataGridView.CurrentRow.Index][FieldName].ToString();
            DialogResult = DialogResult.OK;
        }

        private void DataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LookupTextBox.Text = GridTable.Rows[DataGridView.CurrentRow.Index][FieldName].ToString();
                DialogResult = DialogResult.OK;
            }
            else if (e.KeyCode == Keys.Back)
                LookupTextBox.Text = LookupTextBox.Text.Substring(0, LookupTextBox.Text.Length - 1);
        }

        private void LookupForm_Load(object sender, EventArgs e)
        {
            ActiveControl = DataGridView;
        }

        private void DataGridView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= ' ')
                LookupTextBox.Text += e.KeyChar.ToString();
        }
    }
}
