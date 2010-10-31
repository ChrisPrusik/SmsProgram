namespace SmsProgram
{
    partial class TemplateEditForm
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
            this.ColumnsGrid = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.MessageText = new System.Windows.Forms.TextBox();
            this.SmsProject = new SmsProgram.Model.SmsProject();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ExampleText = new System.Windows.Forms.TextBox();
            this.CancelButton2 = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.TemplateCombo = new System.Windows.Forms.ComboBox();
            this.ExamplesLink = new System.Windows.Forms.LinkLabel();
            this.AdditionalLabel = new System.Windows.Forms.Label();
            this.NewButton = new System.Windows.Forms.Button();
            this.RefreshButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ColumnsGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SmsProject)).BeginInit();
            this.SuspendLayout();
            // 
            // ColumnsGrid
            // 
            this.ColumnsGrid.AllowDrop = true;
            this.ColumnsGrid.AllowUserToAddRows = false;
            this.ColumnsGrid.AllowUserToDeleteRows = false;
            this.ColumnsGrid.AllowUserToResizeRows = false;
            this.ColumnsGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ColumnsGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.ColumnsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ColumnsGrid.Location = new System.Drawing.Point(12, 28);
            this.ColumnsGrid.Name = "ColumnsGrid";
            this.ColumnsGrid.ReadOnly = true;
            this.ColumnsGrid.RowHeadersVisible = false;
            this.ColumnsGrid.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.SystemColors.Control;
            this.ColumnsGrid.Size = new System.Drawing.Size(200, 328);
            this.ColumnsGrid.TabIndex = 0;
            this.ColumnsGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ColumnsGrid_CellDoubleClick);
            this.ColumnsGrid.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ColumnsGrid_MouseDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Columns (drag and drop on message)";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(218, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Template";
            // 
            // MessageText
            // 
            this.MessageText.AllowDrop = true;
            this.MessageText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.MessageText.Location = new System.Drawing.Point(218, 67);
            this.MessageText.Multiline = true;
            this.MessageText.Name = "MessageText";
            this.MessageText.Size = new System.Drawing.Size(402, 136);
            this.MessageText.TabIndex = 4;
            this.MessageText.TextChanged += new System.EventHandler(this.MessageText_TextChanged);
            this.MessageText.DragDrop += new System.Windows.Forms.DragEventHandler(this.MessageText_DragDrop);
            this.MessageText.DragEnter += new System.Windows.Forms.DragEventHandler(this.MessageText_DragEnter);
            // 
            // SmsProject
            // 
            this.SmsProject.DataSetName = "SmsProject";
            this.SmsProject.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(218, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Message";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(215, 206);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Example";
            // 
            // ExampleText
            // 
            this.ExampleText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ExampleText.Location = new System.Drawing.Point(218, 222);
            this.ExampleText.Multiline = true;
            this.ExampleText.Name = "ExampleText";
            this.ExampleText.ReadOnly = true;
            this.ExampleText.Size = new System.Drawing.Size(402, 134);
            this.ExampleText.TabIndex = 7;
            this.ExampleText.TextChanged += new System.EventHandler(this.ExampleText_TextChanged);
            // 
            // CancelButton2
            // 
            this.CancelButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton2.Location = new System.Drawing.Point(545, 362);
            this.CancelButton2.Name = "CancelButton2";
            this.CancelButton2.Size = new System.Drawing.Size(75, 23);
            this.CancelButton2.TabIndex = 8;
            this.CancelButton2.Text = "Cancel";
            this.CancelButton2.UseVisualStyleBackColor = true;
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.SaveButton.Location = new System.Drawing.Point(464, 362);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 9;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            // 
            // TemplateCombo
            // 
            this.TemplateCombo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TemplateCombo.FormattingEnabled = true;
            this.TemplateCombo.Location = new System.Drawing.Point(221, 28);
            this.TemplateCombo.Name = "TemplateCombo";
            this.TemplateCombo.Size = new System.Drawing.Size(399, 21);
            this.TemplateCombo.TabIndex = 10;
            this.TemplateCombo.TextChanged += new System.EventHandler(this.TemplateCombo_TextChanged);
            // 
            // ExamplesLink
            // 
            this.ExamplesLink.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ExamplesLink.AutoSize = true;
            this.ExamplesLink.Location = new System.Drawing.Point(568, 51);
            this.ExamplesLink.Name = "ExamplesLink";
            this.ExamplesLink.Size = new System.Drawing.Size(51, 13);
            this.ExamplesLink.TabIndex = 11;
            this.ExamplesLink.TabStop = true;
            this.ExamplesLink.Text = "examples";
            this.ExamplesLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ExamplesLink_LinkClicked);
            // 
            // AdditionalLabel
            // 
            this.AdditionalLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AdditionalLabel.AutoSize = true;
            this.AdditionalLabel.Location = new System.Drawing.Point(12, 362);
            this.AdditionalLabel.Name = "AdditionalLabel";
            this.AdditionalLabel.Size = new System.Drawing.Size(197, 13);
            this.AdditionalLabel.TabIndex = 12;
            this.AdditionalLabel.Text = "At email, first line of message mean topic";
            // 
            // NewButton
            // 
            this.NewButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.NewButton.Location = new System.Drawing.Point(383, 362);
            this.NewButton.Name = "NewButton";
            this.NewButton.Size = new System.Drawing.Size(75, 23);
            this.NewButton.TabIndex = 13;
            this.NewButton.Text = "New";
            this.NewButton.UseVisualStyleBackColor = true;
            this.NewButton.Click += new System.EventHandler(this.NewButton_Click);
            // 
            // RefreshButton
            // 
            this.RefreshButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.RefreshButton.Location = new System.Drawing.Point(302, 362);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(75, 23);
            this.RefreshButton.TabIndex = 14;
            this.RefreshButton.Text = "Refresh";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.TemplateCombo_TextChanged);
            // 
            // TemplateEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelButton2;
            this.ClientSize = new System.Drawing.Size(632, 395);
            this.Controls.Add(this.RefreshButton);
            this.Controls.Add(this.NewButton);
            this.Controls.Add(this.AdditionalLabel);
            this.Controls.Add(this.ExamplesLink);
            this.Controls.Add(this.TemplateCombo);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.CancelButton2);
            this.Controls.Add(this.ExampleText);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.MessageText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ColumnsGrid);
            this.Name = "TemplateEditForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit template";
            this.Shown += new System.EventHandler(this.TemplateEditForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.ColumnsGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SmsProject)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView ColumnsGrid;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox MessageText;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox ExampleText;
        public System.Windows.Forms.Button CancelButton2;
        public System.Windows.Forms.Button SaveButton;
        public System.Windows.Forms.ComboBox TemplateCombo;
        public System.Windows.Forms.LinkLabel ExamplesLink;
        private System.Windows.Forms.Label AdditionalLabel;
        public System.Windows.Forms.Button NewButton;
        public SmsProgram.Model.SmsProject SmsProject;
        private System.Windows.Forms.Button RefreshButton;

    }
}