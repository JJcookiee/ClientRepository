using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace ClientRepository
{
    public partial class Form3 : Form
    {
        private Dictionary<string, string> clients = new Dictionary<string, string>();
        private Dictionary<string, string> admins = new Dictionary<string, string>();
        private Dictionary<string, string> Staff = new Dictionary<string, string>();
        private Form _previousForm;

        public Form3(Form previousForm)
        {
            InitializeComponent();
            _previousForm = previousForm;

            // Proper event wiring for closing
            this.FormClosed += Form3_FormClosed;
            this.FormClosing += Form3_FormClosing;

            // keep register disabled until checks pass
            btnReg.Enabled = false;

            // Ensure both password and confirm-password re-evaluate rules
            TxtPassword.TextChanged += TxtPassword_TextChanged;
            TxtConPass.TextChanged += TxtPassword_TextChanged;

            // Defer DB load to avoid constructor throwing; start async load and handle errors gracefully.
            LoadStaffCredentialsAsync();
        }

        private void Form3_FormClosing(object? sender, FormClosingEventArgs e)
        {
            throw new NotImplementedException();
        }

        private async void LoadStaffCredentialsAsync()
        {
            try
            {
                await System.Threading.Tasks.Task.Run(() =>
                {
                    string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=CRS;Integrated Security=True";
                    string selectStaffQuery = "SELECT username, password FROM dbo.staff";

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
                                    // marshal to UI-safe update
                                    this.Invoke((Action)(() => Staff[username] = password));
                                }
                            }
                        }
                    }
                });
            }
            catch (Exception ex)
            {
                // Do not throw from constructor — surface to user and allow registration UI to open
                this.Invoke((Action)(() =>
                {
                }));
            }
        }

        private void Form3_FormClosed(object? sender, FormClosedEventArgs e)
        {
            _previousForm?.Show();
        }

        // ... rest of the class unchanged (btnReg_Click, validation, helpers, etc.)
    }
}