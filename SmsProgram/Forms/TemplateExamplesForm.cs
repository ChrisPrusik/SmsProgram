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
    public partial class TemplateExamplesForm : Form
    {
        public TemplateExamplesForm()
        {
            InitializeComponent();
        }

        private void ReadButton_Click(object sender, EventArgs e)
        {
            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
                try
                {
                    SmsExamples.Read(OpenFileDialog.FileName);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(Messages.ErrorExamplesRead + " " + ex.Message);
                }
        }

        private void WriteButton_Click(object sender, EventArgs e)
        {
            if (SaveFileDialog.ShowDialog() == DialogResult.OK)
                try
                {
                    SmsExamples.Write(OpenFileDialog.FileName);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(Messages.ErrorExamplesWrite + " " + ex.Message);
                }
        }

        private void TemplateExamplesForm_Shown(object sender, EventArgs e)
        {
            // TODO: PKSoft.Localizer powinien wybrać wersję narodową pliku
            try
            {
                SmsExamples.Read("SmsProgram.smst");
                ExamplesGrid.Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Messages.ErrorExamplesRead + " " + ex.Message);
            }
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

        private void ExamplesGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void ExamplesGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                DialogResult = DialogResult.OK;
        }
    }
}