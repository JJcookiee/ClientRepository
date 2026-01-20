using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;

namespace ClientRepository
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();

            // Defensive wiring: attach handlers to the runtime controls (designer names must match)
            // This avoids silent failures if the designer didn't wire events or names differ.
            if (BtnReg2 != null)
            {
                BtnReg2.Click -= BtnReg2_Click_1;
                BtnReg2.Click += BtnReg2_Click_1;
            }

            if (BtnLogin != null)
            {
                BtnLogin.Click -= BtnLogin_Click;
                BtnLogin.Click += BtnLogin_Click;
            }

            // Ensure Load handler will populate the staff dictionary for login
            this.Load -= Form4_Load;
            this.Load += Form4_Load;
        }

        private Dictionary<string, string> clients = new Dictionary<string, string>();
        private Dictionary<string, string> admins = new Dictionary<string, string>();
        private Dictionary<string, string> Staff = new Dictionary<string, string>();

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string username = TxtUsername?.Text ?? string.Empty;
            string password = TxtPassword?.Text ?? string.Empty;

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

        private async void Form4_Load(object? sender, EventArgs e)
        {
            // Load staff credentials async so UI stays responsive and login can work
            await LoadStaffCredentialsAsync();
        }

        private async Task LoadStaffCredentialsAsync()
        {
            try
            {
                await Task.Run(() =>
                {
                    string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=CRS;Integrated Security=True";
                    string selectStaffQuery = "SELECT username, password FROM dbo.staff";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand(selectStaffQuery, connection))
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string username = reader.GetString(0);
                                string password = reader.GetString(1);
                                this.Invoke((Action)(() => Staff[username] = password));
                            }
                        }
                    }
                });
            }
            catch (Exception ex)
            {
                // Do not block UI — surface the problem and allow the app to continue
                this.Invoke((Action)(() =>
                {
                    MessageBox.Show("Could not load staff credentials: " + ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }));
            }
        }

        private void BtnReg2_Click_1(object sender, EventArgs e)
        {
            // Diagnostic to confirm the click handler is being invoked
            MessageBox.Show("Register clicked (handler entered).", "Diagnostic", MessageBoxButtons.OK, MessageBoxIcon.Information);

            try
            {
                // Construct Form3 and show it. Form3's DB work now runs in its Load handler asynchronously.
                var form3 = new Form3(this);
                form3.FormClosed += (s, args) => this.Show();
                this.Hide();
                form3.Show();
            }
            catch (Exception ex)
            {
                // Surface any constructor exception (should be rare now that DB work is deferred)
                MessageBox.Show("Failed to open registration form:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Show();
            }
        }
    }
}
