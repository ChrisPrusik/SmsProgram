namespace SmsProgram
{
    partial class TemplateExamplesForm
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
            this.Cancel2Button = new System.Windows.Forms.Button();
            this.ExamplesGrid = new System.Windows.Forms.DataGridView();
            this.categoryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.messageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SmsExamples = new SmsProgram.Model.TemplateExamples();
            this.ExamplesLabel = new System.Windows.Forms.Label();
            this.WriteButton = new System.Windows.Forms.Button();
            this.ReadButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.MessageText = new System.Windows.Forms.TextBox();
            this.ExampleText = new System.Windows.Forms.TextBox();
            this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.SmsProject = new SmsProgram.Model.SmsProject();
            ((System.ComponentModel.ISupportInitialize)(this.ExamplesGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SmsExamples)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SmsProject)).BeginInit();
            this.SuspendLayout();
            // 
            // OKButton
            // 
            this.OKButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKButton.Location = new System.Drawing.Point(557, 322);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 0;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            // 
            // Cancel2Button
            // 
            this.Cancel2Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Cancel2Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel2Button.Location = new System.Drawing.Point(638, 322);
            this.Cancel2Button.Name = "Cancel2Button";
            this.Cancel2Button.Size = new System.Drawing.Size(75, 23);
            this.Cancel2Button.TabIndex = 1;
            this.Cancel2Button.Text = "Cancel";
            this.Cancel2Button.UseVisualStyleBackColor = true;
            // 
            // ExamplesGrid
            // 
            this.ExamplesGrid.AllowUserToAddRows = false;
            this.ExamplesGrid.AllowUserToDeleteRows = false;
            this.ExamplesGrid.AllowUserToOrderColumns = true;
            this.ExamplesGrid.AllowUserToResizeRows = false;
            this.ExamplesGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ExamplesGrid.AutoGenerateColumns = false;
            this.ExamplesGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.ExamplesGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ExamplesGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.categoryDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.messageDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn});
            this.ExamplesGrid.DataMember = "Examples";
            this.ExamplesGrid.DataSource = this.SmsExamples;
            this.ExamplesGrid.Location = new System.Drawing.Point(12, 25);
            this.ExamplesGrid.MultiSelect = false;
            this.ExamplesGrid.Name = "ExamplesGrid";
            this.ExamplesGrid.ReadOnly = true;
            this.ExamplesGrid.RowHeadersVisible = false;
            this.ExamplesGrid.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.SystemColors.Control;
            this.ExamplesGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ExamplesGrid.Size = new System.Drawing.Size(293, 291);
            this.ExamplesGrid.StandardTab = true;
            this.ExamplesGrid.TabIndex = 2;
            this.ExamplesGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ExamplesGrid_CellDoubleClick);
            this.ExamplesGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ExamplesGrid_KeyDown);
            // 
            // categoryDataGridViewTextBoxColumn
            // 
            this.categoryDataGridViewTextBoxColumn.DataPropertyName = "Category";
            this.categoryDataGridViewTextBoxColumn.HeaderText = "Category";
            this.categoryDataGridViewTextBoxColumn.Name = "categoryDataGridViewTextBoxColumn";
            this.categoryDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // messageDataGridViewTextBoxColumn
            // 
            this.messageDataGridViewTextBoxColumn.DataPropertyName = "Message";
            this.messageDataGridViewTextBoxColumn.HeaderText = "Message";
            this.messageDataGridViewTextBoxColumn.Name = "messageDataGridViewTextBoxColumn";
            this.messageDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            this.descriptionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // SmsExamples
            // 
            this.SmsExamples.DataSetName = "TemplateExamples";
            this.SmsExamples.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ExamplesLabel
            // 
            this.ExamplesLabel.AutoSize = true;
            this.ExamplesLabel.Location = new System.Drawing.Point(12, 9);
            this.ExamplesLabel.Name = "ExamplesLabel";
            this.ExamplesLabel.Size = new System.Drawing.Size(52, 13);
            this.ExamplesLabel.TabIndex = 3;
            this.ExamplesLabel.Text = "Examples";
            // 
            // WriteButton
            // 
            this.WriteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.WriteButton.Location = new System.Drawing.Point(476, 322);
            this.WriteButton.Name = "WriteButton";
            this.WriteButton.Size = new System.Drawing.Size(75, 23);
            this.WriteButton.TabIndex = 4;
            this.WriteButton.Text = "Write";
            this.WriteButton.UseVisualStyleBackColor = true;
            this.WriteButton.Click += new System.EventHandler(this.WriteButton_Click);
            // 
            // ReadButton
            // 
            this.ReadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ReadButton.Location = new System.Drawing.Point(395, 322);
            this.ReadButton.Name = "ReadButton";
            this.ReadButton.Size = new System.Drawing.Size(75, 23);
            this.ReadButton.TabIndex = 5;
            this.ReadButton.Text = "Read";
            this.ReadButton.UseVisualStyleBackColor = true;
            this.ReadButton.Click += new System.EventHandler(this.ReadButton_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(308, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Message";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(308, 164);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Example";
            // 
            // MessageText
            // 
            this.MessageText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MessageText.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.SmsExamples, "Examples.Message", true));
            this.MessageText.Location = new System.Drawing.Point(311, 25);
            this.MessageText.Multiline = true;
            this.MessageText.Name = "MessageText";
            this.MessageText.ReadOnly = true;
            this.MessageText.Size = new System.Drawing.Size(402, 136);
            this.MessageText.TabIndex = 8;
            this.MessageText.TextChanged += new System.EventHandler(this.MessageText_TextChanged);
            // 
            // ExampleText
            // 
            this.ExampleText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ExampleText.Location = new System.Drawing.Point(311, 180);
            this.ExampleText.Multiline = true;
            this.ExampleText.Name = "ExampleText";
            this.ExampleText.ReadOnly = true;
            this.ExampleText.Size = new System.Drawing.Size(402, 136);
            this.ExampleText.TabIndex = 9;
            // 
            // OpenFileDialog
            // 
            this.OpenFileDialog.Filter = "SMS Templates|*.smst";
            // 
            // SaveFileDialog
            // 
            this.SaveFileDialog.Filter = "SMS Templates|*.smst";
            // 
            // SmsProject
            // 
            this.SmsProject.DataSetName = "SmsProject";
            this.SmsProject.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // TemplateExamplesForm
            // 
            this.AcceptButton = this.OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancel2Button;
            this.ClientSize = new System.Drawing.Size(725, 354);
            this.Controls.Add(this.ExampleText);
            this.Controls.Add(this.MessageText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ReadButton);
            this.Controls.Add(this.WriteButton);
            this.Controls.Add(this.ExamplesLabel);
            this.Controls.Add(this.ExamplesGrid);
            this.Controls.Add(this.Cancel2Button);
            this.Controls.Add(this.OKButton);
            this.Name = "TemplateExamplesForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Message examples";
            this.Shown += new System.EventHandler(this.TemplateExamplesForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.ExamplesGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SmsExamples)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SmsProject)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button OKButton;
        public System.Windows.Forms.Button Cancel2Button;
        public System.Windows.Forms.DataGridView ExamplesGrid;
        public System.Windows.Forms.Label ExamplesLabel;
        public System.Windows.Forms.Button WriteButton;
        public System.Windows.Forms.Button ReadButton;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox MessageText;
        public System.Windows.Forms.TextBox ExampleText;
        public System.Windows.Forms.OpenFileDialog OpenFileDialog;
        public System.Windows.Forms.SaveFileDialog SaveFileDialog;
        private SmsProgram.Model.TemplateExamples SmsExamples;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn messageDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        public SmsProgram.Model.SmsProject SmsProject;
    }
}