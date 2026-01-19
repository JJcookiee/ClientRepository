using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;




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
            string? client_name = dataGridViewClientData.Rows[selectRow].Cells["client_name"].Value.ToString();
            int address_id = Convert.ToInt16(dataGridViewClientData.Rows[selectRow].Cells["address_id"].Value);
            string? phone_number = dataGridViewClientData.Rows[selectRow].Cells["phone_number"].Value.ToString();
            string? email = dataGridViewClientData.Rows[selectRow].Cells["email"].Value.ToString();
            int cat_id = Convert.ToInt16(dataGridViewClientData.Rows[selectRow].Cells["cat_id"].Value);

            Address address = Address.getFromDB(address_id);
            List<Cat> categories = Cat.getFromDB(cat_id);

            Form1 form1 = new Form1(client_id, client_name, address.HouseName, address.Town, address.County, address.PostCode, phone_number, email, categories[0].Selected, categories[1].Selected, categories[2].Selected, categories[3].Selected, categories[4].Selected);
            form1.Show();
            //close form1
            this.Close();
        }
    }
}
