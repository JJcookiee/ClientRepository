using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Text;

namespace ClientRepository
{
    internal class Registration
    {
        private Dictionary<string, string> clients = new Dictionary<string, string>();
        private Dictionary<string, string> admins = new Dictionary<string, string>();
        private Dictionary<string, string> Staff = new Dictionary<string, string>();
        private bool IsUsernameTaken(string username)
        {
            return clients.ContainsKey(username) || admins.ContainsKey(username) || Staff.ContainsKey(username);
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
        private bool AuthenticateClient(string username, string password)
        {
            return clients.ContainsKey(username) && clients[username] == password;
        }
        private bool AuthenticateAdmin(string username, string password)
        {
            return admins.ContainsKey(username) && admins[username] == password;
        }
        private bool AuthenticateStaff(string username, string password)
        {
            return Staff.ContainsKey(username) && Staff[username] == password;
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
        private bool SaveAdminCredentials(string username, string password)
        {
            if (!admins.ContainsKey(username))
            {
                admins.Add(username, password);
                return true;
            }
            return false;
        }
        private bool SaveClientCredentials(string username, string password)
        {
            if (!clients.ContainsKey(username))
            {
                clients.Add(username, password);
                return true;
            }
            return false;
        }
        private void RegisterClient()
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

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

            if (!IsStrongPassword(password))
            {
                MessageBox.Show("Password is not strong enough.");
                return;
            }

            if (IsUsernameTaken(username))
            {
                MessageBox.Show("Username is already taken.");
                return;
            }

            if (SaveClientCredentials(username, password))
            {
                MessageBox.Show("Registration successful!");
            }
            else
            {
                MessageBox.Show("Registration failed. Please try again.");
            }
        }
        private void RegistrationAdmin()
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

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

            if (SaveAdminCredentials(username, password))
            {
                MessageBox.Show("Registration successful!");
            }
            else
            {
                MessageBox.Show("Registration failed. Please try again.");
            }
        }
        private void RegistrationStaff()
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

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

            if (SaveStaffCredentials(username, password))
            {
                MessageBox.Show("Registration successful!");
            }
            else
            {
                MessageBox.Show("Registration failed. Please try again.");
            }
        }
        private void LoginClient()
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            if (AuthenticateClient(username, password))
            {
                MessageBox.Show("Login successful!");
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }
        private void LoginAdmin()
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            if (AuthenticateAdmin(username, password))
            {
                MessageBox.Show("Login successful!");
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }
        private (Func<string, bool> Rule, string Message)[] rules = new (Func<string, bool> Rule, string Message)[]
            {
                (pwd => pwd.Length >= 8, "At least 8 characters"),
                (pwd => System.Text.RegularExpressions.Regex.IsMatch(pwd, @"[A-Z]"), "At least one uppercase letter"),
                (pwd => System.Text.RegularExpressions.Regex.IsMatch(pwd, @"[a-z]"), "At least one lowercase letter"),
                (pwd => System.Text.RegularExpressions.Regex.IsMatch(pwd, @"[0-9]"), "At least one digit"),
                (pwd => System.Text.RegularExpressions.Regex.IsMatch(pwd, @"[\W_]"), "At least one special character")
            };

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            string password = txtPassword.Text;
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
            btnRegister.Enabled = allPassed && txtPassword.Text == txtConfirmPassword.Text;
        }

        private void MarkRuleAsPassed(int index)
        {
            Label lbl = this.Controls.Find("lblRule" + index, true).FirstOrDefault() as Label;
            if (lbl != null)
            {
                lbl.Text = "✔ " + rules[index].Message;
                lbl.ForeColor = Color.Green;
            }
        }

        private void MarkRuleAsFailed(int index)
        {
            Label lbl = this.Controls.Find("lblRule" + index, true).FirstOrDefault() as Label;
            if (lbl != null)
            {
                lbl.Text = "✘ " + rules[index].Message;
                lbl.ForeColor = Color.Red;
            }
        }
    }
}
