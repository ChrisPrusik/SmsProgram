namespace SmsProgram
{
    partial class FilterBuilderForm
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
            this.FilterExpressionLabel = new System.Windows.Forms.Label();
            this.FilterExpressionTextBox = new System.Windows.Forms.TextBox();
            this.ColumnsGrid = new System.Windows.Forms.DataGridView();
            this.InformationLabel = new System.Windows.Forms.Label();
            this.ColumnsLabel = new System.Windows.Forms.Label();
            this.ExamplesFunctionsLabel = new System.Windows.Forms.LinkLabel();
            this.FilterListLabel = new System.Windows.Forms.Label();
            this.FiltersListBox = new System.Windows.Forms.ListBox();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.OpenButton = new System.Windows.Forms.Button();
            this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.ColumnsGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // OKButton
            // 
            this.OKButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKButton.Location = new System.Drawing.Point(682, 379);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 5;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            // 
            // CancelButton2
            // 
            this.CancelButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton2.Location = new System.Drawing.Point(763, 379);
            this.CancelButton2.Name = "CancelButton2";
            this.CancelButton2.Size = new System.Drawing.Size(75, 23);
            this.CancelButton2.TabIndex = 6;
            this.CancelButton2.Text = "Cancel";
            this.CancelButton2.UseVisualStyleBackColor = true;
            // 
            // FilterExpressionLabel
            // 
            this.FilterExpressionLabel.AutoSize = true;
            this.FilterExpressionLabel.Location = new System.Drawing.Point(218, 11);
            this.FilterExpressionLabel.Name = "FilterExpressionLabel";
            this.FilterExpressionLabel.Size = new System.Drawing.Size(85, 13);
            this.FilterExpressionLabel.TabIndex = 10;
            this.FilterExpressionLabel.Text = "Filter expression:";
            // 
            // FilterExpressionTextBox
            // 
            this.FilterExpressionTextBox.AllowDrop = true;
            this.FilterExpressionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.FilterExpressionTextBox.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FilterExpressionTextBox.Location = new System.Drawing.Point(221, 27);
            this.FilterExpressionTextBox.Multiline = true;
            this.FilterExpressionTextBox.Name = "FilterExpressionTextBox";
            this.FilterExpressionTextBox.Size = new System.Drawing.Size(617, 167);
            this.FilterExpressionTextBox.TabIndex = 0;
            this.FilterExpressionTextBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.TemplateMessageTextBox_DragDrop);
            this.FilterExpressionTextBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.TemplateMessageTextBox_DragEnter);
            // 
            // ColumnsGrid
            // 
            this.ColumnsGrid.AllowUserToAddRows = false;
            this.ColumnsGrid.AllowUserToDeleteRows = false;
            this.ColumnsGrid.AllowUserToResizeRows = false;
            this.ColumnsGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.ColumnsGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.ColumnsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ColumnsGrid.Location = new System.Drawing.Point(15, 27);
            this.ColumnsGrid.Name = "ColumnsGrid";
            this.ColumnsGrid.ReadOnly = true;
            this.ColumnsGrid.RowHeadersVisible = false;
            this.ColumnsGrid.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.SystemColors.Control;
            this.ColumnsGrid.Size = new System.Drawing.Size(200, 344);
            this.ColumnsGrid.TabIndex = 7;
            this.ColumnsGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ColumnsGrid_CellDoubleClick);
            this.ColumnsGrid.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ColumnsGrid_MouseDown);
            // 
            // InformationLabel
            // 
            this.InformationLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.InformationLabel.AutoSize = true;
            this.InformationLabel.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.InformationLabel.Location = new System.Drawing.Point(12, 374);
            this.InformationLabel.Name = "InformationLabel";
            this.InformationLabel.Size = new System.Drawing.Size(413, 28);
            this.InformationLabel.TabIndex = 12;
            this.InformationLabel.Text = "Arithmetic: + - * / % Comparison: < > <=  >= <> = IN LIKE\r\nExample: PhoneNumber L" +
                "IKE \'+48*\' AND LEN(PhoneNumber) = 12";
            // 
            // ColumnsLabel
            // 
            this.ColumnsLabel.AutoSize = true;
            this.ColumnsLabel.Location = new System.Drawing.Point(12, 11);
            this.ColumnsLabel.Name = "ColumnsLabel";
            this.ColumnsLabel.Size = new System.Drawing.Size(50, 13);
            this.ColumnsLabel.TabIndex = 9;
            this.ColumnsLabel.Text = "Columns:";
            // 
            // ExamplesFunctionsLabel
            // 
            this.ExamplesFunctionsLabel.AutoSize = true;
            this.ExamplesFunctionsLabel.Location = new System.Drawing.Point(787, 11);
            this.ExamplesFunctionsLabel.Name = "ExamplesFunctionsLabel";
            this.ExamplesFunctionsLabel.Size = new System.Drawing.Size(51, 13);
            this.ExamplesFunctionsLabel.TabIndex = 8;
            this.ExamplesFunctionsLabel.TabStop = true;
            this.ExamplesFunctionsLabel.Text = "examples";
            this.ExamplesFunctionsLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ExamplesFunctionsLabel_LinkClicked);
            // 
            // FilterListLabel
            // 
            this.FilterListLabel.AutoSize = true;
            this.FilterListLabel.Location = new System.Drawing.Point(221, 197);
            this.FilterListLabel.Name = "FilterListLabel";
            this.FilterListLabel.Size = new System.Drawing.Size(47, 13);
            this.FilterListLabel.TabIndex = 11;
            this.FilterListLabel.Text = "Flters list";
            // 
            // FiltersListBox
            // 
            this.FiltersListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.FiltersListBox.BackColor = System.Drawing.SystemColors.Control;
            this.FiltersListBox.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FiltersListBox.FormattingEnabled = true;
            this.FiltersListBox.ItemHeight = 14;
            this.FiltersListBox.Location = new System.Drawing.Point(221, 213);
            this.FiltersListBox.Name = "FiltersListBox";
            this.FiltersListBox.Size = new System.Drawing.Size(617, 158);
            this.FiltersListBox.TabIndex = 1;
            this.FiltersListBox.SelectedIndexChanged += new System.EventHandler(this.FiltersListBox_SelectedIndexChanged);
            this.FiltersListBox.DoubleClick += new System.EventHandler(this.FiltersListBox_DoubleClick);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DeleteButton.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.DeleteButton.Location = new System.Drawing.Point(601, 379);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(75, 23);
            this.DeleteButton.TabIndex = 4;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveButton.Location = new System.Drawing.Point(520, 379);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 3;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // OpenButton
            // 
            this.OpenButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OpenButton.Location = new System.Drawing.Point(439, 379);
            this.OpenButton.Name = "OpenButton";
            this.OpenButton.Size = new System.Drawing.Size(75, 23);
            this.OpenButton.TabIndex = 2;
            this.OpenButton.Text = "Open";
            this.OpenButton.UseVisualStyleBackColor = true;
            this.OpenButton.Click += new System.EventHandler(this.OpenButton_Click);
            // 
            // OpenFileDialog
            // 
            this.OpenFileDialog.Filter = "SMS filters|*.smsf";
            // 
            // SaveFileDialog
            // 
            this.SaveFileDialog.Filter = "SMS Filters|*.smsf";
            // 
            // FilterBuilderForm
            // 
            this.AcceptButton = this.OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelButton2;
            this.ClientSize = new System.Drawing.Size(850, 411);
            this.Controls.Add(this.ColumnsLabel);
            this.Controls.Add(this.ColumnsGrid);
            this.Controls.Add(this.ExamplesFunctionsLabel);
            this.Controls.Add(this.FilterExpressionTextBox);
            this.Controls.Add(this.FilterExpressionLabel);
            this.Controls.Add(this.FilterListLabel);
            this.Controls.Add(this.FiltersListBox);
            this.Controls.Add(this.OpenButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.InformationLabel);
            this.Controls.Add(this.CancelButton2);
            this.Controls.Add(this.OKButton);
            this.Name = "FilterBuilderForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Filter builder";
            this.Load += new System.EventHandler(this.FilterBuilderForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ColumnsGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button CancelButton2;
        public System.Windows.Forms.TextBox FilterExpressionTextBox;
        public System.Windows.Forms.DataGridView ColumnsGrid;
        public System.Windows.Forms.Label FilterExpressionLabel;
        public System.Windows.Forms.Label InformationLabel;
        private System.Windows.Forms.Label ColumnsLabel;
        private System.Windows.Forms.Label FilterListLabel;
        public System.Windows.Forms.ListBox FiltersListBox;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button OpenButton;
        public System.Windows.Forms.OpenFileDialog OpenFileDialog;
        public System.Windows.Forms.SaveFileDialog SaveFileDialog;
        private System.Windows.Forms.LinkLabel ExamplesFunctionsLabel;
    }
}