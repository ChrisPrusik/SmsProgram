namespace SmsProgram
{
    partial class FilterRangeForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.FilterTextBox = new System.Windows.Forms.TextBox();
            this.FromTextBox = new System.Windows.Forms.TextBox();
            this.ToTextBox = new System.Windows.Forms.TextBox();
            this.ReplaceFilterCheckBox = new System.Windows.Forms.CheckBox();
            this.OrFilterCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // CancelButton2
            // 
            this.CancelButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton2.Location = new System.Drawing.Point(243, 136);
            this.CancelButton2.Name = "CancelButton2";
            this.CancelButton2.Size = new System.Drawing.Size(75, 23);
            this.CancelButton2.TabIndex = 6;
            this.CancelButton2.Text = "Cancel";
            this.CancelButton2.UseVisualStyleBackColor = true;
            // 
            // OKButton
            // 
            this.OKButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKButton.Location = new System.Drawing.Point(162, 136);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 5;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "From";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "To";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Filter";
            // 
            // FilterTextBox
            // 
            this.FilterTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.FilterTextBox.Location = new System.Drawing.Point(53, 83);
            this.FilterTextBox.Name = "FilterTextBox";
            this.FilterTextBox.Size = new System.Drawing.Size(265, 20);
            this.FilterTextBox.TabIndex = 2;
            // 
            // FromTextBox
            // 
            this.FromTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.FromTextBox.Location = new System.Drawing.Point(53, 12);
            this.FromTextBox.Name = "FromTextBox";
            this.FromTextBox.Size = new System.Drawing.Size(265, 20);
            this.FromTextBox.TabIndex = 0;
            this.FromTextBox.TextChanged += new System.EventHandler(this.FromTextBox_TextChanged);
            // 
            // ToTextBox
            // 
            this.ToTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ToTextBox.Location = new System.Drawing.Point(53, 47);
            this.ToTextBox.Name = "ToTextBox";
            this.ToTextBox.Size = new System.Drawing.Size(265, 20);
            this.ToTextBox.TabIndex = 1;
            this.ToTextBox.TextChanged += new System.EventHandler(this.FromTextBox_TextChanged);
            // 
            // ReplaceFilterCheckBox
            // 
            this.ReplaceFilterCheckBox.AutoSize = true;
            this.ReplaceFilterCheckBox.Checked = global::SmsProgram.Properties.Settings.Default.FilterAddReplace;
            this.ReplaceFilterCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::SmsProgram.Properties.Settings.Default, "FilterDateReplace", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ReplaceFilterCheckBox.Location = new System.Drawing.Point(123, 109);
            this.ReplaceFilterCheckBox.Name = "ReplaceFilterCheckBox";
            this.ReplaceFilterCheckBox.Size = new System.Drawing.Size(88, 17);
            this.ReplaceFilterCheckBox.TabIndex = 4;
            this.ReplaceFilterCheckBox.Text = "Replace filter";
            this.ReplaceFilterCheckBox.UseVisualStyleBackColor = true;
            // 
            // OrFilterCheckBox
            // 
            this.OrFilterCheckBox.AutoSize = true;
            this.OrFilterCheckBox.Checked = global::SmsProgram.Properties.Settings.Default.FilterAddOR;
            this.OrFilterCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::SmsProgram.Properties.Settings.Default, "FilterDateOR", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.OrFilterCheckBox.Location = new System.Drawing.Point(53, 109);
            this.OrFilterCheckBox.Name = "OrFilterCheckBox";
            this.OrFilterCheckBox.Size = new System.Drawing.Size(64, 17);
            this.OrFilterCheckBox.TabIndex = 3;
            this.OrFilterCheckBox.Text = "OR filter";
            this.OrFilterCheckBox.UseVisualStyleBackColor = true;
            // 
            // FilterRangeForm
            // 
            this.AcceptButton = this.OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelButton2;
            this.ClientSize = new System.Drawing.Size(330, 171);
            this.Controls.Add(this.ReplaceFilterCheckBox);
            this.Controls.Add(this.OrFilterCheckBox);
            this.Controls.Add(this.ToTextBox);
            this.Controls.Add(this.FromTextBox);
            this.Controls.Add(this.FilterTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.CancelButton2);
            this.Name = "FilterRangeForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add range filter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CancelButton2;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.CheckBox ReplaceFilterCheckBox;
        public System.Windows.Forms.CheckBox OrFilterCheckBox;
        public System.Windows.Forms.TextBox FilterTextBox;
        public System.Windows.Forms.TextBox FromTextBox;
        public System.Windows.Forms.TextBox ToTextBox;
    }
}