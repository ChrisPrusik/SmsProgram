using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SmsProgram.Model;

namespace SmsProgram
{
    public partial class TemplateEditForm : Form
    {
        public TemplateEditForm()
        {
            InitializeComponent();
        }

        public DataTable ColumnsTable
        {
            get { return (DataTable)(ColumnsGrid.DataSource); }
        }

        private void MessageText_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ExampleText.Text = SmsProject.ColumnsToValues(MessageText.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.TitleError, 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ColumnsGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            MessageText.SelectedText = "[" + ColumnsGrid.CurrentRow.Cells[0].Value.ToString() + "] ";
            MessageText.Focus();
        }

        private string dragColumn = "";

        private void MessageText_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
            dragColumn = ColumnsGrid.CurrentRow.Cells[0].Value.ToString();
        }

        private void MessageText_DragDrop(object sender, DragEventArgs e)
        {
            MessageText.SelectedText = "[" + dragColumn + "] ";
            MessageText.Focus();
        }

        private void ColumnsGrid_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                dragColumn = (String)ColumnsGrid.CurrentCell.Value;
                if (dragColumn != null)
                    ColumnsGrid.DoDragDrop(dragColumn, DragDropEffects.Copy);
            }
        }

        private void ExamplesLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (TemplateExamplesForm form = new TemplateExamplesForm())
            {
                form.SmsProject = SmsProject;
                if (form.ShowDialog() == DialogResult.OK)
                    MessageText.Text = form.MessageText.Text;
            }
        }

        private void ExampleText_TextChanged(object sender, EventArgs e)
        {
            if (ExampleText.Text.IndexOf("[") >= 0 && ExampleText.Text.IndexOf("]") >= 0)
                MessageBox.Show(Messages.WarningCheckColumns, Messages.TitleWarning,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void TemplateEditForm_Shown(object sender, EventArgs e)
        {
            foreach (SmsProject.MessagesRow row in SmsProject.Messages)
                TemplateCombo.Items.Add(row.Message);
        }

        private void TemplateCombo_TextChanged(object sender, EventArgs e)
        {
            SmsProject.MessagesRow row = SmsProject.Messages.FindByMessage(TemplateCombo.Text);
            if (row != null)
                MessageText.Text = row.MessageText;
        }

        private void NewButton_Click(object sender, EventArgs e)
        {
            TemplateCombo.Text = "";
            TemplateCombo.Select();
        }
    }
}
