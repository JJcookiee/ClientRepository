using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


    

namespace ClientRepository
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        

        //Method to get clients details from the client database and fill the data grid view

            string connstring = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=CRS;Integrated Security=True";
            string selectquery = @"SELECT client_id, client_name, address_id, phone_number, email, cat_id FROM dbo.clients";

            SqlConnection connection = new SqlConnection(connstring);
            connection.Open();
            SqlCommand command = new SqlCommand(selectquery, connection);
            SqlDataReader reader = command.ExecuteReader();
            DataTable dataTable = new DataTable();

            dataTable.Load(reader);

            dataGridViewClientData.DataSource = dataTable;
        }
        

        //Name search of the data grid view with if statement to show if no results are found
        private void NametextBox_TextChanged(object sender, EventArgs e)
        {
            if (dataGridViewClientData.DataSource != null)
            {
                DataTable dt = dataGridViewClientData.DataSource as DataTable;
                if (dt != null)
                {
                    DataView dvclients = dt.DefaultView;
                    dvclients.RowFilter = $"client_name LIKE '%{NametextBox.Text}%'";
                    dataGridViewClientData.DataSource = dvclients.ToTable();
                }
            }

        }

        //Email search of the data grid view with if statement to show if no results are found
        private void EmailtextBox_TextChanged(object sender, EventArgs e)
        {
            if (dataGridViewClientData.DataSource != null)
            {
                DataTable dt = dataGridViewClientData.DataSource as DataTable;
                if (dt != null)
                {
                    DataView dvclients = dt.DefaultView;
                    dvclients.RowFilter = $"client_email LIKE '%{EmailtextBox.Text}%'";
                    dataGridViewClientData.DataSource = dvclients.ToTable();
                }
            }
        }
    }
}
