
namespace ClientRepository
{
    partial class Form3
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
            LblRegistration = new Label();
            btnReg = new Button();
            TxtUsername = new TextBox();
            LblUsername = new Label();
            LblPassword = new Label();
            TxtPassword = new TextBox();
            LblConPass = new Label();
            TxtConPass = new TextBox();
            LblRule0 = new Label();
            LblRule1 = new Label();
            LblRule2 = new Label();
            LblRule3 = new Label();
            LblRule4 = new Label();
            SuspendLayout();
            // 
            // LblRegistration
            // 
            LblRegistration.AutoSize = true;
            LblRegistration.Location = new Point(62, 42);
            LblRegistration.Name = "LblRegistration";
            LblRegistration.Size = new Size(106, 25);
            LblRegistration.TabIndex = 0;
            LblRegistration.Text = "Registration";
            // 
            // btnReg
            // 
            btnReg.Location = new Point(62, 374);
            btnReg.Name = "btnReg";
            btnReg.Size = new Size(112, 34);
            btnReg.TabIndex = 1;
            btnReg.Text = "Register";
            btnReg.UseVisualStyleBackColor = true;
            btnReg.Click += btnReg_Click;
            // 
            // TxtUsername
            // 
            TxtUsername.Location = new Point(240, 96);
            TxtUsername.Name = "TxtUsername";
            TxtUsername.Size = new Size(150, 31);
            TxtUsername.TabIndex = 2;
            // 
            // LblUsername
            // 
            LblUsername.AutoSize = true;
            LblUsername.Location = new Point(62, 102);
            LblUsername.Name = "LblUsername";
            LblUsername.Size = new Size(95, 25);
            LblUsername.TabIndex = 3;
            LblUsername.Text = "Username:";
            // 
            // LblPassword
            // 
            LblPassword.AutoSize = true;
            LblPassword.Location = new Point(62, 161);
            LblPassword.Name = "LblPassword";
            LblPassword.Size = new Size(91, 25);
            LblPassword.TabIndex = 4;
            LblPassword.Text = "Password:";
            // 
            // TxtPassword
            // 
            TxtPassword.Location = new Point(240, 161);
            TxtPassword.Name = "TxtPassword";
            TxtPassword.Size = new Size(150, 31);
            TxtPassword.TabIndex = 5;
            TxtPassword.TextChanged += TxtPassword_TextChanged;
            // 
            // LblConPass
            // 
            LblConPass.AutoSize = true;
            LblConPass.Location = new Point(62, 221);
            LblConPass.Name = "LblConPass";
            LblConPass.Size = new Size(160, 25);
            LblConPass.TabIndex = 6;
            LblConPass.Text = "Confirm Password:";
            // 
            // TxtConPass
            // 
            TxtConPass.Location = new Point(240, 221);
            TxtConPass.Name = "TxtConPass";
            TxtConPass.Size = new Size(150, 31);
            TxtConPass.TabIndex = 7;
            // 
            // LblRule0
            // 
            LblRule0.AutoSize = true;
            LblRule0.Location = new Point(408, 152);
            LblRule0.Name = "LblRule0";
            LblRule0.Size = new Size(0, 25);
            LblRule0.TabIndex = 8;
            // 
            // LblRule1
            // 
            LblRule1.AutoSize = true;
            LblRule1.Location = new Point(408, 177);
            LblRule1.Name = "LblRule1";
            LblRule1.Size = new Size(0, 25);
            LblRule1.TabIndex = 9;
            // 
            // LblRule2
            // 
            LblRule2.AutoSize = true;
            LblRule2.Location = new Point(408, 202);
            LblRule2.Name = "LblRule2";
            LblRule2.Size = new Size(0, 25);
            LblRule2.TabIndex = 10;
            // 
            // LblRule3
            // 
            LblRule3.AutoSize = true;
            LblRule3.Location = new Point(408, 227);
            LblRule3.Name = "LblRule3";
            LblRule3.Size = new Size(0, 25);
            LblRule3.TabIndex = 11;
            // 
            // LblRule4
            // 
            LblRule4.AutoSize = true;
            LblRule4.Location = new Point(408, 252);
            LblRule4.Name = "LblRule4";
            LblRule4.Size = new Size(0, 25);
            LblRule4.TabIndex = 12;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(LblRule4);
            Controls.Add(LblRule3);
            Controls.Add(LblRule2);
            Controls.Add(LblRule1);
            Controls.Add(LblRule0);
            Controls.Add(TxtConPass);
            Controls.Add(LblConPass);
            Controls.Add(TxtPassword);
            Controls.Add(LblPassword);
            Controls.Add(LblUsername);
            Controls.Add(TxtUsername);
            Controls.Add(btnReg);
            Controls.Add(LblRegistration);
            Name = "Form3";
            Text = "Form3";
            ResumeLayout(false);
            PerformLayout();
        }

        private void TxtPassword_TextChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private Label LblRegistration;
        private Button btnReg;
        private TextBox TxtUsername;
        private Label LblUsername;
        private Label LblPassword;
        private TextBox TxtPassword;
        private Label LblConPass;
        private TextBox TxtConPass;
        private Label LblRule0;
        private Label LblRule1;
        private Label LblRule2;
        private Label LblRule3;
        private Label LblRule4;
    }
}