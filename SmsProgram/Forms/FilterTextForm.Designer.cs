namespace SmsProgram
{
    partial class FilterTextForm
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
            this.CancelButton2 = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.FormatTextBox = new System.Windows.Forms.TextBox();
            this.FormatLabel = new System.Windows.Forms.Label();
            this.ReplaceFilterCheckBox = new System.Windows.Forms.CheckBox();
            this.OrFilterCheckBox = new System.Windows.Forms.CheckBox();
            this.FilterTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.InfoLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CancelButton2
            // 
            this.CancelButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton2.Location = new System.Drawing.Point(387, 96);
            this.CancelButton2.Name = "CancelButton2";
            this.CancelButton2.Size = new System.Drawing.Size(75, 23);
            this.CancelButton2.TabIndex = 5;
            this.CancelButton2.Text = "Cancel";
            this.CancelButton2.UseVisualStyleBackColor = true;
            // 
            // OKButton
            // 
            this.OKButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKButton.Location = new System.Drawing.Point(306, 96);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 4;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            // 
            // FormatTextBox
            // 
            this.FormatTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.FormatTextBox.Location = new System.Drawing.Point(57, 27);
            this.FormatTextBox.Name = "FormatTextBox";
            this.FormatTextBox.Size = new System.Drawing.Size(405, 20);
            this.FormatTextBox.TabIndex = 0;
            this.FormatTextBox.TextChanged += new System.EventHandler(this.FormatTextBox_TextChanged);
            // 
            // FormatLabel
            // 
            this.FormatLabel.AutoSize = true;
            this.FormatLabel.Location = new System.Drawing.Point(12, 27);
            this.FormatLabel.Name = "FormatLabel";
            this.FormatLabel.Size = new System.Drawing.Size(39, 13);
            this.FormatLabel.TabIndex = 7;
            this.FormatLabel.Text = "Format";
            // 
            // ReplaceFilterCheckBox
            // 
            this.ReplaceFilterCheckBox.AutoSize = true;
            this.ReplaceFilterCheckBox.Checked = global::SmsProgram.Properties.Settings.Default.FilterAddReplace;
            this.ReplaceFilterCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::SmsProgram.Properties.Settings.Default, "FilterDateReplace", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ReplaceFilterCheckBox.Location = new System.Drawing.Point(127, 89);
            this.ReplaceFilterCheckBox.Name = "ReplaceFilterCheckBox";
            this.ReplaceFilterCheckBox.Size = new System.Drawing.Size(88, 17);
            this.ReplaceFilterCheckBox.TabIndex = 3;
            this.ReplaceFilterCheckBox.Text = "Replace filter";
            this.ReplaceFilterCheckBox.UseVisualStyleBackColor = true;
            // 
            // OrFilterCheckBox
            // 
            this.OrFilterCheckBox.AutoSize = true;
            this.OrFilterCheckBox.Checked = global::SmsProgram.Properties.Settings.Default.FilterAddOR;
            this.OrFilterCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::SmsProgram.Properties.Settings.Default, "FilterDateOR", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.OrFilterCheckBox.Location = new System.Drawing.Point(57, 89);
            this.OrFilterCheckBox.Name = "OrFilterCheckBox";
            this.OrFilterCheckBox.Size = new System.Drawing.Size(64, 17);
            this.OrFilterCheckBox.TabIndex = 2;
            this.OrFilterCheckBox.Text = "OR filter";
            this.OrFilterCheckBox.UseVisualStyleBackColor = true;
            // 
            // FilterTextBox
            // 
            this.FilterTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.FilterTextBox.Location = new System.Drawing.Point(57, 63);
            this.FilterTextBox.Name = "FilterTextBox";
            this.FilterTextBox.Size = new System.Drawing.Size(405, 20);
            this.FilterTextBox.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Filter";
            // 
            // InfoLabel
            // 
            this.InfoLabel.AutoSize = true;
            this.InfoLabel.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.InfoLabel.Location = new System.Drawing.Point(54, 10);
            this.InfoLabel.Name = "InfoLabel";
            this.InfoLabel.Size = new System.Drawing.Size(399, 14);
            this.InfoLabel.TabIndex = 6;
            this.InfoLabel.Text = "Use * as any chars (ex. \'*y\' - any words with postfix y)";
            // 
            // FilterTextForm
            // 
            this.AcceptButton = this.OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelButton2;
            this.ClientSize = new System.Drawing.Size(474, 131);
            this.Controls.Add(this.InfoLabel);
            this.Controls.Add(this.ReplaceFilterCheckBox);
            this.Controls.Add(this.OrFilterCheckBox);
            this.Controls.Add(this.FilterTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.FormatLabel);
            this.Controls.Add(this.FormatTextBox);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.CancelButton2);
            this.Name = "FilterTextForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add text filter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.CheckBox ReplaceFilterCheckBox;
        public System.Windows.Forms.CheckBox OrFilterCheckBox;
        public System.Windows.Forms.TextBox FilterTextBox;
        private System.Windows.Forms.Label InfoLabel;
        public System.Windows.Forms.Button CancelButton2;
        public System.Windows.Forms.Button OKButton;
        public System.Windows.Forms.TextBox FormatTextBox;
        public System.Windows.Forms.Label FormatLabel;
        public System.Windows.Forms.Label label3;
    }
}