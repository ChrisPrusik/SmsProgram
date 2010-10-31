namespace SmsProgram
{
    partial class SearchForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.BackwardSearchCheck = new System.Windows.Forms.CheckBox();
            this.SearchRegexCheck = new System.Windows.Forms.CheckBox();
            this.SearchIgnoreCaseCheck = new System.Windows.Forms.CheckBox();
            this.SearchInFieldCheck = new System.Windows.Forms.CheckBox();
            this.SearchEverywhereCheck = new System.Windows.Forms.CheckBox();
            this.SearchAllColumnsCheck = new System.Windows.Forms.CheckBox();
            this.SearchTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // OKButton
            // 
            this.OKButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKButton.Location = new System.Drawing.Point(230, 131);
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
            this.CancelButton2.Location = new System.Drawing.Point(311, 131);
            this.CancelButton2.Name = "CancelButton2";
            this.CancelButton2.Size = new System.Drawing.Size(75, 23);
            this.CancelButton2.TabIndex = 1;
            this.CancelButton2.Text = "Cancel";
            this.CancelButton2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Enter text to search";
            // 
            // BackwardSearchCheck
            // 
            this.BackwardSearchCheck.AutoSize = true;
            this.BackwardSearchCheck.Checked = global::SmsProgram.Properties.Settings.Default.SearchBackward;
            this.BackwardSearchCheck.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::SmsProgram.Properties.Settings.Default, "SearchBackward", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.BackwardSearchCheck.Location = new System.Drawing.Point(230, 97);
            this.BackwardSearchCheck.Name = "BackwardSearchCheck";
            this.BackwardSearchCheck.Size = new System.Drawing.Size(109, 17);
            this.BackwardSearchCheck.TabIndex = 9;
            this.BackwardSearchCheck.Text = "Backward search";
            this.BackwardSearchCheck.UseVisualStyleBackColor = true;
            // 
            // SearchRegexCheck
            // 
            this.SearchRegexCheck.AutoSize = true;
            this.SearchRegexCheck.Checked = global::SmsProgram.Properties.Settings.Default.SearchRegex;
            this.SearchRegexCheck.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::SmsProgram.Properties.Settings.Default, "SearchRegex", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.SearchRegexCheck.Location = new System.Drawing.Point(230, 74);
            this.SearchRegexCheck.Name = "SearchRegexCheck";
            this.SearchRegexCheck.Size = new System.Drawing.Size(123, 17);
            this.SearchRegexCheck.TabIndex = 8;
            this.SearchRegexCheck.Text = "Regullar expressions";
            this.SearchRegexCheck.UseVisualStyleBackColor = true;
            // 
            // SearchIgnoreCaseCheck
            // 
            this.SearchIgnoreCaseCheck.AutoSize = true;
            this.SearchIgnoreCaseCheck.Checked = global::SmsProgram.Properties.Settings.Default.SearchIgnoreLetterCase;
            this.SearchIgnoreCaseCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SearchIgnoreCaseCheck.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::SmsProgram.Properties.Settings.Default, "SearchIgnoreLetterCase", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.SearchIgnoreCaseCheck.Location = new System.Drawing.Point(230, 51);
            this.SearchIgnoreCaseCheck.Name = "SearchIgnoreCaseCheck";
            this.SearchIgnoreCaseCheck.Size = new System.Drawing.Size(108, 17);
            this.SearchIgnoreCaseCheck.TabIndex = 7;
            this.SearchIgnoreCaseCheck.Text = "Ignore letter case";
            this.SearchIgnoreCaseCheck.UseVisualStyleBackColor = true;
            // 
            // SearchInFieldCheck
            // 
            this.SearchInFieldCheck.AutoSize = true;
            this.SearchInFieldCheck.Checked = global::SmsProgram.Properties.Settings.Default.SearchInField;
            this.SearchInFieldCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SearchInFieldCheck.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::SmsProgram.Properties.Settings.Default, "SearchInField", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.SearchInFieldCheck.Location = new System.Drawing.Point(15, 97);
            this.SearchInFieldCheck.Name = "SearchInFieldCheck";
            this.SearchInFieldCheck.Size = new System.Drawing.Size(93, 17);
            this.SearchInFieldCheck.TabIndex = 6;
            this.SearchInFieldCheck.Text = "Search in field";
            this.SearchInFieldCheck.UseVisualStyleBackColor = true;
            // 
            // SearchEverywhereCheck
            // 
            this.SearchEverywhereCheck.AutoSize = true;
            this.SearchEverywhereCheck.Checked = global::SmsProgram.Properties.Settings.Default.SearchEverywhere;
            this.SearchEverywhereCheck.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::SmsProgram.Properties.Settings.Default, "SearchEverywhere", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.SearchEverywhereCheck.Location = new System.Drawing.Point(15, 74);
            this.SearchEverywhereCheck.Name = "SearchEverywhereCheck";
            this.SearchEverywhereCheck.Size = new System.Drawing.Size(120, 17);
            this.SearchEverywhereCheck.TabIndex = 5;
            this.SearchEverywhereCheck.Text = "Search ewerywhere";
            this.SearchEverywhereCheck.UseVisualStyleBackColor = true;
            this.SearchEverywhereCheck.CheckedChanged += new System.EventHandler(this.SearchEverywhereCheckBox_CheckedChanged);
            this.SearchEverywhereCheck.CheckStateChanged += new System.EventHandler(this.SearchEverywhereCheckBox_CheckStateChanged);
            // 
            // SearchAllColumnsCheck
            // 
            this.SearchAllColumnsCheck.AutoSize = true;
            this.SearchAllColumnsCheck.Checked = global::SmsProgram.Properties.Settings.Default.SearchAllColumns;
            this.SearchAllColumnsCheck.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::SmsProgram.Properties.Settings.Default, "SearchAllColumns", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.SearchAllColumnsCheck.Location = new System.Drawing.Point(15, 51);
            this.SearchAllColumnsCheck.Name = "SearchAllColumnsCheck";
            this.SearchAllColumnsCheck.Size = new System.Drawing.Size(126, 17);
            this.SearchAllColumnsCheck.TabIndex = 4;
            this.SearchAllColumnsCheck.Text = "Search in all columns";
            this.SearchAllColumnsCheck.UseVisualStyleBackColor = true;
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::SmsProgram.Properties.Settings.Default, "SearchText", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.SearchTextBox.Location = new System.Drawing.Point(15, 25);
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(371, 20);
            this.SearchTextBox.TabIndex = 3;
            this.SearchTextBox.Text = global::SmsProgram.Properties.Settings.Default.SearchText;
            // 
            // SearchForm
            // 
            this.AcceptButton = this.OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelButton2;
            this.ClientSize = new System.Drawing.Size(398, 166);
            this.Controls.Add(this.BackwardSearchCheck);
            this.Controls.Add(this.SearchRegexCheck);
            this.Controls.Add(this.SearchIgnoreCaseCheck);
            this.Controls.Add(this.SearchInFieldCheck);
            this.Controls.Add(this.SearchEverywhereCheck);
            this.Controls.Add(this.SearchAllColumnsCheck);
            this.Controls.Add(this.SearchTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CancelButton2);
            this.Controls.Add(this.OKButton);
            this.Name = "SearchForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search";
            this.Load += new System.EventHandler(this.SearchForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button CancelButton2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox SearchTextBox;
        public System.Windows.Forms.CheckBox SearchAllColumnsCheck;
        public System.Windows.Forms.CheckBox SearchEverywhereCheck;
        public System.Windows.Forms.CheckBox SearchInFieldCheck;
        public System.Windows.Forms.CheckBox SearchIgnoreCaseCheck;
        public System.Windows.Forms.CheckBox SearchRegexCheck;
        public System.Windows.Forms.CheckBox BackwardSearchCheck;
    }
}