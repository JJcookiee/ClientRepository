using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ClientRepository
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        private Dictionary<string, string> clients = new Dictionary<string, string>();
        private Dictionary<string, string> admins = new Dictionary<string, string>();
        private Dictionary<string, string> Staff = new Dictionary<string, string>();
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string username = TxtUsername.Text;
            string password = TxtPassword.Text;

            if (AuthenticateStaff(username, password))
            {
                MessageBox.Show("Login successful!");
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }
        private bool AuthenticateStaff(string username, string password)
        {
            return Staff.ContainsKey(username) && Staff[username] == password;
        }
    }
}
