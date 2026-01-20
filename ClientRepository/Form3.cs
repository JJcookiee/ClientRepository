using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace ClientRepository
{
    public partial class Form3 : Form
    {
        private Dictionary<string, string> clients = new Dictionary<string, string>();
        private Dictionary<string, string> admins = new Dictionary<string, string>();
        private Dictionary<string, string> Staff = new Dictionary<string, string>();
        public Form3()
        {
            InitializeComponent();
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=CRS;Integrated Security=True";  //gets staff from db and puts in dictionary
            string selectStaffQuery = "SELECT username, password FROM Staff";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(selectStaffQuery, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string username = reader.GetString(0);
                            string password = reader.GetString(1);
                            Staff[username] = password;
                        }
                    }
                }
                connection.Close();
            }
        }
        
        private void btnReg_Click(object sender, EventArgs e)
        {
            string username = TxtUsername.Text;
            string password = TxtPassword.Text;
            string confirmPassword = TxtConPass.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show("Username and password cannot be empty.");
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.");
                return;
            }

            if (IsUsernameTaken(username))
            {
                MessageBox.Show("Username is already taken.");
                return;
            }

            if(!IsStrongPassword(password))
            {
                MessageBox.Show("Password does not meet the required criteria.");
                return;
            }

            if (SaveStaffCredentials(username, password))
            {
                MessageBox.Show("Registration successful!");
            }
            else
            {
                MessageBox.Show("Registration failed. Please try again.");
            }
        }

        private bool IsUsernameTaken(string username)
        {
            return clients.ContainsKey(username) || admins.ContainsKey(username) || Staff.ContainsKey(username);
        }

        private bool SaveStaffCredentials(string username, string password)
        {
            if (!Staff.ContainsKey(username))
            {
                Staff.Add(username, password);
                return true;
            }
            return false;
        }

        private void TxtPassword_TextChanged(object sender, EventArgs e)
        {
            string password = TxtPassword.Text;
            bool allPassed = true;

            for (int i = 0; i < rules.Length; i++)
            {

                if (rules[i].Rule(password))
                {
                    MarkRuleAsPassed(i);
                }
                else
                {
                    MarkRuleAsFailed(i);
                    allPassed = false;
                }
            }
            btnReg.Enabled = allPassed && TxtPassword.Text == TxtConPass.Text;
        }

        private (Func<string, bool> Rule, string Message)[] rules = new (Func<string, bool> Rule, string Message)[]
        {
            (pwd => pwd.Length >= 8, "At least 8 characters"),
            (pwd => System.Text.RegularExpressions.Regex.IsMatch(pwd, @"[A-Z]"), "At least one uppercase letter"),
            (pwd => System.Text.RegularExpressions.Regex.IsMatch(pwd, @"[a-z]"), "At least one lowercase letter"),
            (pwd => System.Text.RegularExpressions.Regex.IsMatch(pwd, @"[0-9]"), "At least one digit"),
            (pwd => System.Text.RegularExpressions.Regex.IsMatch(pwd, @"[\W_]"), "At least one special character")
        };
        private void TxtPassword_TextChanged(object sender, EventArgs e)
        {
            string password = TxtPassword.Text;
            bool allPassed = true;

            for (int i = 0; i < rules.Length; i++)
            {

                if (rules[i].Rule(password))
                {
                    MarkRuleAsPassed(i);
                }
                else
                {
                    MarkRuleAsFailed(i);
                    allPassed = false;
                }
            }
            btnReg.Enabled = allPassed && TxtPassword.Text == TxtConPass.Text;
        private void MarkRuleAsPassed(int index)
        {
            Label lbl = this.Controls.Find("LblRule" + index, true).FirstOrDefault() as Label;
            if (lbl != null)
            {
                lbl.Text = "✔ " + rules[index].Message;
                lbl.ForeColor = Color.Green;
            }
        }

        private void MarkRuleAsFailed(int index)
        {
            Label lbl = this.Controls.Find("LblRule" + index, true).FirstOrDefault() as Label;
            if (lbl != null)
            {
                lbl.Text = "✘ " + rules[index].Message;
                lbl.ForeColor = Color.Red;
            }
        }
        private bool IsStrongPassword(string password)
        {
            foreach (var rule in rules)
            {
                if (!rule.Rule(password))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
