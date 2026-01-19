using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace ClientRepository
{
    internal class Client
    {
        public int ClientID { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public List<Cat> Categories { get; set; }

        public Client(int? clientid, string name, Address address, string phonenumber, string email, List<Cat> categories)//initialises client object, sets client id to null if not passed
        {
            if (clientid != null) { ClientID = (int)clientid; }
            Name = name;
            Address = address;
            PhoneNumber = phonenumber;
            Email = email;
            Categories = categories;
        }

        public Client()//blank constructor
        {
            ClientID = 0;
            Name = "";
            Address = new Address();
            PhoneNumber = "";
            Email = "";
            Categories = new List<Cat>();
        }

        public static void addToDB(int address_id, int cat_id, string client_name, string phone_number, string email)//adds client to database
        {
            string connstring = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=CRS;Integrated Security=True";
            string insertquery = "INSERT INTO clients (client_name, address_id, phone_number, email, cat_id) VALUES (@client_name, @address_id, @phone_number, @email, @cat_id)";

            using SqlConnection connection = new(connstring);
            connection.Open();
            using SqlCommand command = new(insertquery, connection);
            command.Parameters.AddWithValue("@client_name", client_name);
            command.Parameters.AddWithValue("@address_id", address_id);
            command.Parameters.AddWithValue("@cat_id", cat_id);
            command.Parameters.Add("@phone_number", System.Data.SqlDbType.VarChar, 20).Value = phone_number;
            command.Parameters.AddWithValue("@email", email);

            command.ExecuteNonQuery();
        }
        public static void updateInDB(int client_id, int address_id, int cat_id, string client_name, string phone_number, string email)
        {

        }
    }
}

