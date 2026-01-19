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
        private DataTable clientDataTable = new DataTable();
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


            clientDataTable.Load(reader);

            dataGridViewClientData.DataSource = clientDataTable;
        }


        //Name search of the data grid view with if statement to show if no results are found
        private void NametextBox_TextChanged(object sender, EventArgs e)
        {
            DataView dataGridViewClientData = clientDataTable.DefaultView;
            dataGridViewClientData.RowFilter = $"client_name LIKE '%{NametextBox.Text}%'";

        }

        //Email search of the data grid view with if statement to show if no results are found
        private void EmailtextBox_TextChanged(object sender, EventArgs e)
        {
            DataView dataGridViewClientData = clientDataTable.DefaultView;
            dataGridViewClientData.RowFilter = $"client_name LIKE '%{EmailtextBox.Text}%'";

        }

        private void dataGridViewClientData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectRow = dataGridViewClientData.Rows.GetFirstRow(DataGridViewElementStates.Selected);
            int client_id = Convert.ToInt16(dataGridViewClientData.Rows[selectRow].Cells["client_id"].Value);
                
        }
    }
}
