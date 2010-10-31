using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SmsProgram
{
    public partial class CampaignEditForm : Form
    {
        public CampaignEditForm()
        {
            InitializeComponent();
        }

        private void TemplateLink_Click(object sender, EventArgs e)
        {
            using (TemplateEditForm form = new TemplateEditForm())
            {
                form.ShowDialog();
            }
        }
    }
}
