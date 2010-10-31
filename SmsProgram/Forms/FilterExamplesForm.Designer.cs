namespace SmsProgram
{
    partial class FilterExamplesForm
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
            this.FiltersListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.FilterExpressionTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.FilterResultTextBox = new System.Windows.Forms.TextBox();
            this.ExamplesLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ExampleGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.ExampleGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // CancelButton2
            // 
            this.CancelButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton2.Location = new System.Drawing.Point(754, 369);
            this.CancelButton2.Name = "CancelButton2";
            this.CancelButton2.Size = new System.Drawing.Size(75, 23);
            this.CancelButton2.TabIndex = 4;
            this.CancelButton2.Text = "Cancel";
            this.CancelButton2.UseVisualStyleBackColor = true;
            // 
            // OKButton
            // 
            this.OKButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OKButton.Location = new System.Drawing.Point(673, 369);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 3;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            // 
            // FiltersListBox
            // 
            this.FiltersListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.FiltersListBox.BackColor = System.Drawing.SystemColors.Control;
            this.FiltersListBox.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.FiltersListBox.FormattingEnabled = true;
            this.FiltersListBox.ItemHeight = 14;
            this.FiltersListBox.Items.AddRange(new object[] {
            "Higher than    | [CreateDate] > [ModifyDate]",
            "Equal          | [CreateDate] = [ModifyDate]",
            "Higher or equal| [ReceivedCount] >= [SentCount]",
            "Math operators | [SentCount] / ([ReceivedCount] + 1)",
            "String wildcard| [PhoneNumber] LIKE \'+48*\'",
            "String exactly | [PhoneNumber] LIKE \'+48500234156\'",
            "String length  | LEN([PhoneNumber]) > 9",
            "Check is null  | ISNULL([Company], \'No company\') = \'No company\'",
            "If then        | IIF([ReceivedCount] > 0, \'received!\', \'no received\') = \'received" +
                "\'",
            "Trim spaces    | TRIM(\'   ala    \') = \'ala\'",
            "Substring      | SUBSTRING(\'Alibaba\', 1, 3) = \'Ali\'"});
            this.FiltersListBox.Location = new System.Drawing.Point(12, 24);
            this.FiltersListBox.Name = "FiltersListBox";
            this.FiltersListBox.Size = new System.Drawing.Size(817, 172);
            this.FiltersListBox.TabIndex = 1;
            this.FiltersListBox.SelectedIndexChanged += new System.EventHandler(this.FiltersListBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 285);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Filter expression";
            // 
            // FilterExpressionTextBox
            // 
            this.FilterExpressionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.FilterExpressionTextBox.Location = new System.Drawing.Point(14, 301);
            this.FilterExpressionTextBox.Name = "FilterExpressionTextBox";
            this.FilterExpressionTextBox.Size = new System.Drawing.Size(817, 20);
            this.FilterExpressionTextBox.TabIndex = 0;
            this.FilterExpressionTextBox.TextChanged += new System.EventHandler(this.FilterExpressionTextBox_TextChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 324);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Result";
            // 
            // FilterResultTextBox
            // 
            this.FilterResultTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.FilterResultTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.FilterResultTextBox.Location = new System.Drawing.Point(14, 340);
            this.FilterResultTextBox.Name = "FilterResultTextBox";
            this.FilterResultTextBox.ReadOnly = true;
            this.FilterResultTextBox.Size = new System.Drawing.Size(817, 20);
            this.FilterResultTextBox.TabIndex = 9;
            // 
            // ExamplesLabel
            // 
            this.ExamplesLabel.AutoSize = true;
            this.ExamplesLabel.Location = new System.Drawing.Point(12, 8);
            this.ExamplesLabel.Name = "ExamplesLabel";
            this.ExamplesLabel.Size = new System.Drawing.Size(52, 13);
            this.ExamplesLabel.TabIndex = 5;
            this.ExamplesLabel.Text = "Examples";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 199);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(233, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Example table (You can edit data to check filter)";
            // 
            // ExampleGrid
            // 
            this.ExampleGrid.AllowUserToResizeColumns = false;
            this.ExampleGrid.AllowUserToResizeRows = false;
            this.ExampleGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ExampleGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.ExampleGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ExampleGrid.Location = new System.Drawing.Point(12, 215);
            this.ExampleGrid.Name = "ExampleGrid";
            this.ExampleGrid.RowHeadersVisible = false;
            this.ExampleGrid.Size = new System.Drawing.Size(817, 67);
            this.ExampleGrid.TabIndex = 2;
            this.ExampleGrid.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.ExampleGrid_CellValueChanged);
            this.ExampleGrid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.ExampleGrid_CellValueChanged);
            this.ExampleGrid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.ExampleGrid_DataError);
            // 
            // FilterFunctionsForm
            // 
            this.AcceptButton = this.OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelButton2;
            this.ClientSize = new System.Drawing.Size(841, 404);
            this.Controls.Add(this.ExampleGrid);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ExamplesLabel);
            this.Controls.Add(this.FilterResultTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.FilterExpressionTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FiltersListBox);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.CancelButton2);
            this.Name = "FilterFunctionsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Filter functions";
            this.Shown += new System.EventHandler(this.FilterFunctionsForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.ExampleGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CancelButton2;
        private System.Windows.Forms.Button OKButton;
        public System.Windows.Forms.ListBox FiltersListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox FilterExpressionTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox FilterResultTextBox;
        private System.Windows.Forms.Label ExamplesLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView ExampleGrid;
    }
}