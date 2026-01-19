namespace ClientRepository
{
    partial class addupdateForm
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
            button1 = new Button();
            ClientID = new TextBox();
            ChangeName = new TextBox();
            ChangeHouseName = new TextBox();
            ChangeTownName = new TextBox();
            ChangePostcode = new TextBox();
            ChangeCounty = new TextBox();
            ChangeEmail = new TextBox();
            ChangePhone = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(300, 409);
            button1.Name = "button1";
            button1.Size = new Size(122, 29);
            button1.TabIndex = 0;
            button1.Text = "Enter changes:";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // ClientID
            // 
            ClientID.Location = new Point(12, 140);
            ClientID.Name = "ClientID";
            ClientID.Size = new Size(288, 27);
            ClientID.TabIndex = 1;
            // 
            // ChangeName
            // 
            ChangeName.Location = new Point(12, 213);
            ChangeName.Name = "ChangeName";
            ChangeName.Size = new Size(288, 27);
            ChangeName.TabIndex = 2;
            // 
            // ChangeHouseName
            // 
            ChangeHouseName.Location = new Point(12, 295);
            ChangeHouseName.Name = "ChangeHouseName";
            ChangeHouseName.Size = new Size(288, 27);
            ChangeHouseName.TabIndex = 3;
            // 
            // ChangeTownName
            // 
            ChangeTownName.Location = new Point(12, 369);
            ChangeTownName.Name = "ChangeTownName";
            ChangeTownName.Size = new Size(288, 27);
            ChangeTownName.TabIndex = 4;
            // 
            // ChangePostcode
            // 
            ChangePostcode.Location = new Point(426, 140);
            ChangePostcode.Name = "ChangePostcode";
            ChangePostcode.Size = new Size(336, 27);
            ChangePostcode.TabIndex = 5;
            // 
            // ChangeCounty
            // 
            ChangeCounty.Location = new Point(426, 213);
            ChangeCounty.Name = "ChangeCounty";
            ChangeCounty.Size = new Size(336, 27);
            ChangeCounty.TabIndex = 6;
            // 
            // ChangeEmail
            // 
            ChangeEmail.Location = new Point(426, 295);
            ChangeEmail.Name = "ChangeEmail";
            ChangeEmail.Size = new Size(336, 27);
            ChangeEmail.TabIndex = 7;
            // 
            // ChangePhone
            // 
            ChangePhone.Location = new Point(426, 369);
            ChangePhone.Name = "ChangePhone";
            ChangePhone.Size = new Size(336, 27);
            ChangePhone.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 101);
            label1.Name = "label1";
            label1.Size = new Size(65, 20);
            label1.TabIndex = 9;
            label1.Text = "ClientID:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(23, 181);
            label2.Name = "label2";
            label2.Size = new Size(106, 20);
            label2.TabIndex = 10;
            label2.Text = "Change Name:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(28, 262);
            label3.Name = "label3";
            label3.Size = new Size(152, 20);
            label3.TabIndex = 11;
            label3.Text = "Change House Name:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(34, 339);
            label4.Name = "label4";
            label4.Size = new Size(0, 20);
            label4.TabIndex = 12;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(430, 107);
            label5.Name = "label5";
            label5.Size = new Size(126, 20);
            label5.TabIndex = 13;
            label5.Text = "Change Postcode:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(431, 183);
            label6.Name = "label6";
            label6.Size = new Size(108, 20);
            label6.TabIndex = 14;
            label6.Text = "ChangeCounty:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(434, 262);
            label7.Name = "label7";
            label7.Size = new Size(103, 20);
            label7.TabIndex = 15;
            label7.Text = "Change Email:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(435, 340);
            label8.Name = "label8";
            label8.Size = new Size(107, 20);
            label8.TabIndex = 16;
            label8.Text = "Change Phone:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(23, 339);
            label9.Name = "label9";
            label9.Size = new Size(149, 20);
            label9.TabIndex = 17;
            label9.Text = "Change  Town Name:";
            // 
            // addupdateForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(ChangePhone);
            Controls.Add(ChangeEmail);
            Controls.Add(ChangeCounty);
            Controls.Add(ChangePostcode);
            Controls.Add(ChangeTownName);
            Controls.Add(ChangeHouseName);
            Controls.Add(ChangeName);
            Controls.Add(ClientID);
            Controls.Add(button1);
            Name = "addupdateForm";
            Text = "addupdateForm";
            Load += addupdateForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox ClientID;
        private TextBox ChangeName;
        private TextBox ChangeHouseName;
        private TextBox ChangeTownName;
        private TextBox ChangePostcode;
        private TextBox ChangeCounty;
        private TextBox ChangeEmail;
        private TextBox ChangePhone;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
    }
}