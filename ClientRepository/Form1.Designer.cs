namespace ClientRepository
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            CheckedListBoxCategories = new CheckedListBox();
            getName = new TextBox();
            getHouse = new TextBox();
            label1 = new Label();
            getPostcode = new TextBox();
            getCounty = new TextBox();
            getTown = new TextBox();
            getEmail = new TextBox();
            getphone = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            SearchBar = new TextBox();
            label9 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(428, 409);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 0;
            button1.Text = "Enter";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // CheckedListBoxCategories
            // 
            CheckedListBoxCategories.FormattingEnabled = true;
            CheckedListBoxCategories.Items.AddRange(new object[] { "Software", "Laptop_PCs", "Games", "Office_Tools", "Accessories" });
            CheckedListBoxCategories.Location = new Point(485, 289);
            CheckedListBoxCategories.Name = "CheckedListBoxCategories";
            CheckedListBoxCategories.Size = new Size(231, 114);
            CheckedListBoxCategories.TabIndex = 1;
            CheckedListBoxCategories.SelectedIndexChanged += checkedListBox1_SelectedIndexChanged;
            // 
            // getName
            // 
            getName.Location = new Point(12, 150);
            getName.Name = "getName";
            getName.Size = new Size(334, 27);
            getName.TabIndex = 2;
            getName.TextChanged += getName_TextChanged;
            // 
            // getHouse
            // 
            getHouse.Location = new Point(12, 203);
            getHouse.Name = "getHouse";
            getHouse.Size = new Size(334, 27);
            getHouse.TabIndex = 3;
            getHouse.TextChanged += getHouse_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(117, 127);
            label1.Name = "label1";
            label1.Size = new Size(52, 20);
            label1.TabIndex = 4;
            label1.Text = "Name:";
            // 
            // getPostcode
            // 
            getPostcode.Location = new Point(12, 362);
            getPostcode.Name = "getPostcode";
            getPostcode.Size = new Size(334, 27);
            getPostcode.TabIndex = 5;
            getPostcode.TextChanged += getPostcode_TextChanged;
            // 
            // getCounty
            // 
            getCounty.Location = new Point(12, 309);
            getCounty.Name = "getCounty";
            getCounty.Size = new Size(334, 27);
            getCounty.TabIndex = 6;
            getCounty.TextChanged += getCounty_TextChanged;
            // 
            // getTown
            // 
            getTown.Location = new Point(12, 256);
            getTown.Name = "getTown";
            getTown.Size = new Size(334, 27);
            getTown.TabIndex = 7;
            getTown.TextChanged += getTown_TextChanged;
            // 
            // getEmail
            // 
            getEmail.Location = new Point(442, 160);
            getEmail.Name = "getEmail";
            getEmail.Size = new Size(334, 27);
            getEmail.TabIndex = 8;
            getEmail.TextChanged += getEmail_TextChanged;
            // 
            // getphone
            // 
            getphone.Location = new Point(443, 213);
            getphone.Name = "getphone";
            getphone.Size = new Size(333, 27);
            getphone.TabIndex = 9;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(117, 180);
            label2.Name = "label2";
            label2.Size = new Size(98, 20);
            label2.TabIndex = 11;
            label2.Text = "House Name:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(120, 233);
            label3.Name = "label3";
            label3.Size = new Size(47, 20);
            label3.TabIndex = 12;
            label3.Text = "Town:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(117, 286);
            label4.Name = "label4";
            label4.Size = new Size(58, 20);
            label4.TabIndex = 13;
            label4.Text = "County:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(117, 339);
            label5.Name = "label5";
            label5.Size = new Size(72, 20);
            label5.TabIndex = 14;
            label5.Text = "Postcode:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(570, 137);
            label6.Name = "label6";
            label6.Size = new Size(55, 20);
            label6.TabIndex = 15;
            label6.Text = "E-mail:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(570, 190);
            label7.Name = "label7";
            label7.Size = new Size(53, 20);
            label7.TabIndex = 16;
            label7.Text = "Phone:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(543, 256);
            label8.Name = "label8";
            label8.Size = new Size(114, 20);
            label8.TabIndex = 17;
            label8.Text = "Select category:";
            // 
            // SearchBar
            // 
            SearchBar.Location = new Point(200, 26);
            SearchBar.Name = "SearchBar";
            SearchBar.Size = new Size(398, 27);
            SearchBar.TabIndex = 18;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(286, 3);
            label9.Name = "label9";
            label9.Size = new Size(224, 20);
            label9.TabIndex = 19;
            label9.Text = "Search for Client Name or Email:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label9);
            Controls.Add(SearchBar);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(getphone);
            Controls.Add(getEmail);
            Controls.Add(getTown);
            Controls.Add(getCounty);
            Controls.Add(getPostcode);
            Controls.Add(label1);
            Controls.Add(getHouse);
            Controls.Add(getName);
            Controls.Add(CheckedListBoxCategories);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private CheckedListBox CheckedListBoxCategories;
        private TextBox getName;
        private TextBox getHouse;
        private Label label1;
        private TextBox getPostcode;
        private TextBox getCounty;
        private TextBox getTown;
        private TextBox getEmail;
        private TextBox getphone;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private TextBox SearchBar;
        private Label label9;
    }
}
