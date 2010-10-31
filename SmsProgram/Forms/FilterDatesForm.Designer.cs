namespace SmsProgram
{
    partial class FilterDatesForm
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
            this.FromDatePicker = new System.Windows.Forms.DateTimePicker();
            this.ToDatePicker = new System.Windows.Forms.DateTimePicker();
            this.FromTimePicker = new System.Windows.Forms.DateTimePicker();
            this.ToTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.FilterTextBox = new System.Windows.Forms.TextBox();
            this.OrFilterCheckBox = new System.Windows.Forms.CheckBox();
            this.ReplaceFilterCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // OKButton
            // 
            this.OKButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKButton.Location = new System.Drawing.Point(174, 106);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(87, 23);
            this.OKButton.TabIndex = 7;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            // 
            // CancelButton2
            // 
            this.CancelButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton2.Location = new System.Drawing.Point(267, 106);
            this.CancelButton2.Name = "CancelButton2";
            this.CancelButton2.Size = new System.Drawing.Size(87, 23);
            this.CancelButton2.TabIndex = 8;
            this.CancelButton2.Text = "Cancel";
            this.CancelButton2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "From date";
            // 
            // FromDatePicker
            // 
            this.FromDatePicker.Location = new System.Drawing.Point(75, 9);
            this.FromDatePicker.Name = "FromDatePicker";
            this.FromDatePicker.ShowCheckBox = true;
            this.FromDatePicker.Size = new System.Drawing.Size(152, 20);
            this.FromDatePicker.TabIndex = 0;
            this.FromDatePicker.ValueChanged += new System.EventHandler(this.DateTimePicker_ValueChanged);
            // 
            // ToDatePicker
            // 
            this.ToDatePicker.Location = new System.Drawing.Point(75, 35);
            this.ToDatePicker.Name = "ToDatePicker";
            this.ToDatePicker.ShowCheckBox = true;
            this.ToDatePicker.Size = new System.Drawing.Size(152, 20);
            this.ToDatePicker.TabIndex = 2;
            this.ToDatePicker.ValueChanged += new System.EventHandler(this.DateTimePicker_ValueChanged);
            // 
            // FromTimePicker
            // 
            this.FromTimePicker.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.FromTimePicker.Checked = false;
            this.FromTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.FromTimePicker.Location = new System.Drawing.Point(233, 9);
            this.FromTimePicker.Name = "FromTimePicker";
            this.FromTimePicker.ShowCheckBox = true;
            this.FromTimePicker.ShowUpDown = true;
            this.FromTimePicker.Size = new System.Drawing.Size(121, 20);
            this.FromTimePicker.TabIndex = 1;
            this.FromTimePicker.ValueChanged += new System.EventHandler(this.DateTimePicker_ValueChanged);
            // 
            // ToTimePicker
            // 
            this.ToTimePicker.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ToTimePicker.Checked = false;
            this.ToTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.ToTimePicker.Location = new System.Drawing.Point(233, 35);
            this.ToTimePicker.Name = "ToTimePicker";
            this.ToTimePicker.ShowCheckBox = true;
            this.ToTimePicker.ShowUpDown = true;
            this.ToTimePicker.Size = new System.Drawing.Size(121, 20);
            this.ToTimePicker.TabIndex = 3;
            this.ToTimePicker.ValueChanged += new System.EventHandler(this.DateTimePicker_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "To date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Filter";
            // 
            // FilterTextBox
            // 
            this.FilterTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.FilterTextBox.Location = new System.Drawing.Point(75, 62);
            this.FilterTextBox.Name = "FilterTextBox";
            this.FilterTextBox.Size = new System.Drawing.Size(279, 20);
            this.FilterTextBox.TabIndex = 4;
            // 
            // OrFilterCheckBox
            // 
            this.OrFilterCheckBox.AutoSize = true;
            this.OrFilterCheckBox.Checked = global::SmsProgram.Properties.Settings.Default.FilterAddOR;
            this.OrFilterCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::SmsProgram.Properties.Settings.Default, "FilterDateOR", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.OrFilterCheckBox.Location = new System.Drawing.Point(75, 83);
            this.OrFilterCheckBox.Name = "OrFilterCheckBox";
            this.OrFilterCheckBox.Size = new System.Drawing.Size(64, 17);
            this.OrFilterCheckBox.TabIndex = 5;
            this.OrFilterCheckBox.Text = "OR filter";
            this.OrFilterCheckBox.UseVisualStyleBackColor = true;
            // 
            // ReplaceFilterCheckBox
            // 
            this.ReplaceFilterCheckBox.AutoSize = true;
            this.ReplaceFilterCheckBox.Checked = global::SmsProgram.Properties.Settings.Default.FilterAddReplace;
            this.ReplaceFilterCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::SmsProgram.Properties.Settings.Default, "FilterDateReplace", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ReplaceFilterCheckBox.Location = new System.Drawing.Point(145, 83);
            this.ReplaceFilterCheckBox.Name = "ReplaceFilterCheckBox";
            this.ReplaceFilterCheckBox.Size = new System.Drawing.Size(88, 17);
            this.ReplaceFilterCheckBox.TabIndex = 6;
            this.ReplaceFilterCheckBox.Text = "Replace filter";
            this.ReplaceFilterCheckBox.UseVisualStyleBackColor = true;
            // 
            // FilterDatesForm
            // 
            this.AcceptButton = this.OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelButton2;
            this.ClientSize = new System.Drawing.Size(366, 141);
            this.Controls.Add(this.ReplaceFilterCheckBox);
            this.Controls.Add(this.OrFilterCheckBox);
            this.Controls.Add(this.FilterTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ToTimePicker);
            this.Controls.Add(this.FromTimePicker);
            this.Controls.Add(this.ToDatePicker);
            this.Controls.Add(this.FromDatePicker);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CancelButton2);
            this.Controls.Add(this.OKButton);
            this.Name = "FilterDatesForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add filter";
            this.Shown += new System.EventHandler(this.FilterDatesForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button CancelButton2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.DateTimePicker FromDatePicker;
        public System.Windows.Forms.DateTimePicker ToDatePicker;
        public System.Windows.Forms.DateTimePicker FromTimePicker;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.DateTimePicker ToTimePicker;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox FilterTextBox;
        public System.Windows.Forms.CheckBox OrFilterCheckBox;
        public System.Windows.Forms.CheckBox ReplaceFilterCheckBox;
    }
}