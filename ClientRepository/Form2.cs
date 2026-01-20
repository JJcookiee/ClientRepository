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
        public bool ordered = true;
        public Form2()
        {
            InitializeComponent();
            ordered = orderedBox.Checked;
        }

        private void Form2_Load(object sender, EventArgs e)//Method to get clients details from the client database and fill the data grid view
        {
            LoadClients();
        }
        private void LoadClients()
        {
            string connstring = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=CRS;Integrated Security=True";
            string selectquery = @"SELECT c.client_id, c.client_name, c.phone_number, c.email, a.house_name, a.town, a.county, a.postcode, cat.software, cat.laptop_pcs, cat.games, cat.office_tools, cat.accessories FROM clients c INNER JOIN address a ON c.address_id = a.address_id INNER JOIN categories cat ON c.cat_id = cat.cat_id";
            if (ordered) selectquery += " order by client_name asc";
            SqlConnection connection = new SqlConnection(connstring);
            connection.Open();
            SqlCommand command = new SqlCommand(selectquery, connection);
            SqlDataReader reader = command.ExecuteReader();
            clientDataTable.Clear();
            clientDataTable.Load(reader);
            dataGridViewClientData.DataSource = clientDataTable;

            List<Client> ClientList = db.ClientList(ordered);//lowkey not needed anymore :/
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
            string client_name = dataGridViewClientData.Rows[selectRow].Cells["client_name"].Value.ToString();
            string house = dataGridViewClientData.Rows[selectRow].Cells["house_name"].Value.ToString();
            string town = dataGridViewClientData.Rows[selectRow].Cells["town"].Value.ToString();
            string county = dataGridViewClientData.Rows[selectRow].Cells["county"].Value.ToString();
            string postcode = dataGridViewClientData.Rows[selectRow].Cells["postcode"].Value.ToString();
            string phone_number = dataGridViewClientData.Rows[selectRow].Cells["phone_number"].Value.ToString();
            string email = dataGridViewClientData.Rows[selectRow].Cells["email"].Value.ToString();
            bool[] cats = [
                bool.Parse(dataGridViewClientData.Rows[selectRow].Cells["software"].Value.ToString()),
                bool.Parse(dataGridViewClientData.Rows[selectRow].Cells["laptop_pcs"].Value.ToString()),
                bool.Parse(dataGridViewClientData.Rows[selectRow].Cells["games"].Value.ToString()),
                bool.Parse(dataGridViewClientData.Rows[selectRow].Cells["office_tools"].Value.ToString()),
                bool.Parse(dataGridViewClientData.Rows[selectRow].Cells["accessories"].Value.ToString())
                ];

            //Address address = Address.getFromDB(address_id);
            //List<Cat> categories = Cat.getFromDB(cat_id);

            Form1 form1 = new Form1(client_id, client_name, house, town, county, postcode, phone_number, email, cats[0], cats[1], cats[2], cats[3], cats[4]);
            form1.Show();
            //close form1
            this.Close();
        }

        private void orderedBox_CheckedChanged(object sender, EventArgs e)
        {
            if (orderedBox.Checked)
            {
                ordered = true;
                changeChecked();
                LoadClients();
            }
        }

        private void unorderedBox_CheckedChanged(object sender, EventArgs e)
        {
            if (unorderedBox.Checked)
            {
                ordered = false;
                changeChecked();
                LoadClients();
            }
        }

        private void changeChecked()
        {
            if (ordered)
            {
                orderedBox.Checked = true;
                unorderedBox.Checked = false;
            }
            else
            {
                orderedBox.Checked = false;
                unorderedBox.Checked = true;
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            //add code to check admin
            int? client_id = Convert.ToInt16(dataGridViewClientData.SelectedRows[0].Cells["client_id"].Value);
            if (client_id == null || client_id == 0) { return; }
            else { db.remove_client(client_id.ToString()); }
            dataGridViewClientData.Rows.RemoveAt(dataGridViewClientData.SelectedRows[0].Index);
        }
    }
}
