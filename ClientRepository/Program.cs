using System;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace ClientRepository
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Form4());

            using var login = new Form4();
            DialogResult result = login.ShowDialog();
            if (result != DialogResult.OK)
            {
                return;
            }

            Application.Run(new Form1());

            try
            {
                CreateDB.CreateDatabase();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "Database initialization failed:\n" + ex.Message +
                    "\n\nCheck that SQL Server LocalDB is installed and matches application bitness.",
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                // Option: return; // uncomment to stop the app after showing the error
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error during startup:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Application.Run(new Form1());
        }
    }
}