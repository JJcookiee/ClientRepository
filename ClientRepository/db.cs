using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Programming03Project 
{
    internal class db
    {
        public static void remove_details(string ClientId)
        {
            string connstring = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\jacob\\source\\repos\\Programming03Project\\Programming03Project\\CRS.mdf;Integrated Security=True";
            string deleteQuery = "delete from clients where client_id = @client_id";

            SqlConnection connection = new(connstring);

            connection.Open();
            using (SqlCommand command = new(deleteQuery, connection))
            {
                command.Parameters.AddWithValue("@client_id", ClientId);
                command.ExecuteNonQuery();
            }
            connection.Close();
        }
        public static List<Client> ClientList(bool ordered)
        {
            string orderBy = "";

            if (ordered)
            {
                orderBy = " order by client_name asc";
            }

            string connstring = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\jacob\\source\\repos\\Programming03Project\\Programming03Project\\CRS.mdf;Integrated Security=True";
            string selectQuery = "select count(*) from graph";
            string selectQuery2 = "select client_name, address, phone_number, email from clients" + orderBy;

            SqlConnection connection = new(connstring);
            SqlDataReader reader;

            int count = 0;
            List<Client> ClientList = new List<Client>();

            connection.Open();
            using (SqlCommand command = new(selectQuery, connection))
            {
                reader = command.ExecuteReader();
                reader.Read();
                count = reader.GetInt32(0);
                reader.Close();
            }

            for (int i = 0; i < count; i++)
            {
                Client client = new Client();
                using (SqlCommand command = new(selectQuery2, connection))
                {
                    reader = command.ExecuteReader();
                    reader.Read();
                    client.Name = reader.GetString(0);
                    client.Address = Address.fromdb(reader.GetString(1));
                    client.PhoneNumber = reader.GetInt32(2);
                    client.Email = reader.GetString(3);
                    reader.Close();
                    ClientList.Add(client);
                }
            }
            connection.Close();

            return ClientList;
        }
    }
}
