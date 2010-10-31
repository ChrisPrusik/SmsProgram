using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using SmsProgram.Properties;

namespace SmsProgram
{
    public partial class FilterBuilderForm : Form
    {
        public FilterBuilderForm()
        {
            InitializeComponent();
        }

        private void ColumnsGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FilterExpressionTextBox.SelectedText = "[" + ColumnsGrid.CurrentRow.Cells[0].Value.ToString() + "] ";
            FilterExpressionTextBox.Focus();
        }

        private void FilterBuilderForm_Load(object sender, EventArgs e)
        {
            ActiveControl = FilterExpressionTextBox;
        }

        private void FiltersListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FiltersListBox.SelectedIndex >= 0)
                FilterExpressionTextBox.Text = FiltersListBox.Items[FiltersListBox.SelectedIndex].ToString();
        }

        private void FiltersListBox_DoubleClick(object sender, EventArgs e)
        {
            if (FiltersListBox.SelectedIndex >= 0)
            {
                FilterExpressionTextBox.Text = FiltersListBox.Items[FiltersListBox.SelectedIndex].ToString();
                DialogResult = DialogResult.OK;
            }
        }

        private void OpenButton_Click(object sender, EventArgs e)
        {
            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
                Settings.Default.Filters = File.ReadAllText(OpenFileDialog.FileName);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (SaveFileDialog.ShowDialog() == DialogResult.OK)
                File.WriteAllText(SaveFileDialog.FileName, Settings.Default.Filters);
        }

        private void ExamplesFunctionsLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (FilterExamplesForm form = new FilterExamplesForm())
            {
                form.ShowDialog();
            }
        }

        private string dragColumn = "";

        private void TemplateMessageTextBox_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
            dragColumn = ColumnsGrid.CurrentRow.Cells[0].Value.ToString();
        }

        private void TemplateMessageTextBox_DragDrop(object sender, DragEventArgs e)
        {
            FilterExpressionTextBox.SelectedText = "[" + dragColumn + "] ";
            FilterExpressionTextBox.Focus();
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

    }
}
