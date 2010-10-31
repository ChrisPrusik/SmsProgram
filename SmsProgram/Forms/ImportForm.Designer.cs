namespace SmsProgram
{
    partial class ImportForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.OKButton = new System.Windows.Forms.Button();
            this.CancelButton2 = new System.Windows.Forms.Button();
            this.InfoLabel = new System.Windows.Forms.Label();
            this.ReplaceAllCheckBox = new System.Windows.Forms.CheckBox();
            this.OnlyNewerCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // OKButton
            // 
            this.OKButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKButton.Location = new System.Drawing.Point(116, 183);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 0;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            // 
            // CancelButton2
            // 
            this.CancelButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton2.Location = new System.Drawing.Point(197, 183);
            this.CancelButton2.Name = "CancelButton2";
            this.CancelButton2.Size = new System.Drawing.Size(75, 23);
            this.CancelButton2.TabIndex = 1;
            this.CancelButton2.Text = "Cancel";
            this.CancelButton2.UseVisualStyleBackColor = true;
            // 
            // InfoLabel
            // 
            this.InfoLabel.AutoSize = true;
            this.InfoLabel.Location = new System.Drawing.Point(9, 9);
            this.InfoLabel.Name = "InfoLabel";
            this.InfoLabel.Size = new System.Drawing.Size(113, 65);
            this.InfoLabel.TabIndex = 2;
            this.InfoLabel.Text = "Filename -\r\nProjectName - Author\r\nCreated CreatedDate \r\nModified ModifiedDate\r\nBy" +
                " Login on Computer";
            // 
            // ReplaceAllCheckBox
            // 
            this.ReplaceAllCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ReplaceAllCheckBox.AutoSize = true;
            this.ReplaceAllCheckBox.Location = new System.Drawing.Point(12, 124);
            this.ReplaceAllCheckBox.Name = "ReplaceAllCheckBox";
            this.ReplaceAllCheckBox.Size = new System.Drawing.Size(128, 17);
            this.ReplaceAllCheckBox.TabIndex = 3;
            this.ReplaceAllCheckBox.Text = "Replace existing data";
            this.ReplaceAllCheckBox.UseVisualStyleBackColor = true;
            // 
            // OnlyNewerCheckBox
            // 
            this.OnlyNewerCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.OnlyNewerCheckBox.AutoSize = true;
            this.OnlyNewerCheckBox.Checked = true;
            this.OnlyNewerCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.OnlyNewerCheckBox.Location = new System.Drawing.Point(12, 147);
            this.OnlyNewerCheckBox.Name = "OnlyNewerCheckBox";
            this.OnlyNewerCheckBox.Size = new System.Drawing.Size(166, 17);
            this.OnlyNewerCheckBox.TabIndex = 4;
            this.OnlyNewerCheckBox.Text = "Replace existing only if newer";
            this.OnlyNewerCheckBox.UseVisualStyleBackColor = true;
            // 
            // ImportForm
            // 
            this.AcceptButton = this.OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelButton2;
            this.ClientSize = new System.Drawing.Size(284, 218);
            this.Controls.Add(this.OnlyNewerCheckBox);
            this.Controls.Add(this.ReplaceAllCheckBox);
            this.Controls.Add(this.InfoLabel);
            this.Controls.Add(this.CancelButton2);
            this.Controls.Add(this.OKButton);
            this.Name = "ImportForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Import";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button CancelButton2;
        public System.Windows.Forms.Label InfoLabel;
        public System.Windows.Forms.CheckBox ReplaceAllCheckBox;
        public System.Windows.Forms.CheckBox OnlyNewerCheckBox;
    }
}