namespace ClientRepository
{
    partial class Form4
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
            LblLogin = new Label();
            LblUsername = new Label();
            TxtUsername = new TextBox();
            LblPassword = new Label();
            TxtPassword = new TextBox();
            BtnLogin = new Button();
            SuspendLayout();
            // 
            // LblLogin
            // 
            LblLogin.AutoSize = true;
            LblLogin.Location = new Point(64, 52);
            LblLogin.Name = "LblLogin";
            LblLogin.Size = new Size(56, 25);
            LblLogin.TabIndex = 0;
            LblLogin.Text = "Login";
            // 
            // LblUsername
            // 
            LblUsername.AutoSize = true;
            LblUsername.Location = new Point(61, 107);
            LblUsername.Name = "LblUsername";
            LblUsername.Size = new Size(95, 25);
            LblUsername.TabIndex = 1;
            LblUsername.Text = "Username:";
            // 
            // TxtUsername
            // 
            TxtUsername.Location = new Point(197, 107);
            TxtUsername.Name = "TxtUsername";
            TxtUsername.Size = new Size(150, 31);
            TxtUsername.TabIndex = 2;
            // 
            // LblPassword
            // 
            LblPassword.AutoSize = true;
            LblPassword.Location = new Point(61, 171);
            LblPassword.Name = "LblPassword";
            LblPassword.Size = new Size(91, 25);
            LblPassword.TabIndex = 3;
            LblPassword.Text = "Password:";
            // 
            // TxtPassword
            // 
            TxtPassword.Location = new Point(197, 171);
            TxtPassword.Name = "TxtPassword";
            TxtPassword.Size = new Size(150, 31);
            TxtPassword.TabIndex = 4;
            // 
            // BtnLogin
            // 
            BtnLogin.Location = new Point(61, 357);
            BtnLogin.Name = "BtnLogin";
            BtnLogin.Size = new Size(112, 34);
            BtnLogin.TabIndex = 5;
            BtnLogin.Text = "Login";
            BtnLogin.UseVisualStyleBackColor = true;
            BtnLogin.Click += BtnLogin_Click;
            // 
            // Form4
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(BtnLogin);
            Controls.Add(TxtPassword);
            Controls.Add(LblPassword);
            Controls.Add(TxtUsername);
            Controls.Add(LblUsername);
            Controls.Add(LblLogin);
            Name = "Form4";
            Text = "Form4";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LblLogin;
        private Label LblUsername;
        private TextBox TxtUsername;
        private Label LblPassword;
        private TextBox TxtPassword;
        private Button BtnLogin;
    }
}