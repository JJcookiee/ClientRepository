namespace ClientRepository
{
    partial class Form2
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
            dataGridViewClientData = new DataGridView();
            NametextBox = new TextBox();
            EmailtextBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            deleteButton = new Button();
            orderedBox = new CheckBox();
            unorderedBox = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)dataGridViewClientData).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewClientData
            // 
            dataGridViewClientData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewClientData.Location = new Point(12, 80);
            dataGridViewClientData.Name = "dataGridViewClientData";
            dataGridViewClientData.RowHeadersWidth = 51;
            dataGridViewClientData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewClientData.Size = new Size(776, 358);
            dataGridViewClientData.TabIndex = 1;
            dataGridViewClientData.CellDoubleClick += dataGridViewClientData_CellDoubleClick;
            // 
            // NametextBox
            // 
            NametextBox.Location = new Point(12, 31);
            NametextBox.Name = "NametextBox";
            NametextBox.Size = new Size(248, 27);
            NametextBox.TabIndex = 2;
            NametextBox.TextChanged += NametextBox_TextChanged;
            // 
            // EmailtextBox
            // 
            EmailtextBox.Location = new Point(275, 31);
            EmailtextBox.Name = "EmailtextBox";
            EmailtextBox.Size = new Size(253, 27);
            EmailtextBox.TabIndex = 3;
            EmailtextBox.TextChanged += EmailtextBox_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 8);
            label1.Name = "label1";
            label1.Size = new Size(182, 20);
            label1.TabIndex = 4;
            label1.Text = "Search client name below:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(275, 8);
            label2.Name = "label2";
            label2.Size = new Size(188, 20);
            label2.TabIndex = 5;
            label2.Text = "Search Client Email below: ";
            // 
            // deleteButton
            // 
            deleteButton.Location = new Point(12, 444);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(182, 29);
            deleteButton.TabIndex = 6;
            deleteButton.Text = "Delete selected client";
            deleteButton.UseVisualStyleBackColor = true;
            deleteButton.Click += deleteButton_Click;
            // 
            // orderedBox
            // 
            orderedBox.AutoSize = true;
            orderedBox.Checked = true;
            orderedBox.CheckState = CheckState.Checked;
            orderedBox.Location = new Point(560, 12);
            orderedBox.Name = "orderedBox";
            orderedBox.Size = new Size(132, 24);
            orderedBox.TabIndex = 7;
            orderedBox.Text = "Order client list";
            orderedBox.UseVisualStyleBackColor = true;
            orderedBox.CheckedChanged += orderedBox_CheckedChanged;
            // 
            // unorderedBox
            // 
            unorderedBox.AutoSize = true;
            unorderedBox.Location = new Point(560, 42);
            unorderedBox.Name = "unorderedBox";
            unorderedBox.Size = new Size(165, 24);
            unorderedBox.TabIndex = 8;
            unorderedBox.Text = "Unordered client list";
            unorderedBox.UseVisualStyleBackColor = true;
            unorderedBox.CheckedChanged += unorderedBox_CheckedChanged;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 497);
            Controls.Add(unorderedBox);
            Controls.Add(orderedBox);
            Controls.Add(deleteButton);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(EmailtextBox);
            Controls.Add(NametextBox);
            Controls.Add(dataGridViewClientData);
            Name = "Form2";
            Text = "Form2";
            Load += Form2_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewClientData).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dataGridViewClientData;
        private TextBox NametextBox;
        private TextBox EmailtextBox;
        private Label label1;
        private Label label2;
        private Button deleteButton;
        private CheckBox orderedBox;
        private CheckBox unorderedBox;
    }
}