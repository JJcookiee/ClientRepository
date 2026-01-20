using ClientRepository;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClientRepository
{
    internal class db
    {
        public static void remove_client(string ClientId)//removes client from database
        {
            string connstring = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=CRS;Integrated Security=True";

            string deleteQuery = "delete from clients where client_id = @client_id";
            string selectAddressIdQuery = "select address_id from clients where client_id = @client_id";
            string deleteAddressQuery = "delete from address where address_id = @address_id";
            string selectCatIdQuery = "select cat_id from clients where client_id = @client_id";
            string deleteCatQuery = "delete from categories where cat_id = @cat_id";

            SqlConnection connection = new(connstring);

            int address_id = 0;
            int cat_id = 0;

            connection.Open();
            using (SqlCommand command = new(selectAddressIdQuery, connection))//get clients address id
            {
                command.Parameters.AddWithValue("@client_id", ClientId);
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                address_id = reader.GetInt32(0);
                reader.Close();
                
            }
            using (SqlCommand command = new(selectCatIdQuery, connection))//get clients cat id
            {
                command.Parameters.AddWithValue("@client_id", ClientId);
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                cat_id = reader.GetInt32(0);
                reader.Close();
                
            }
            using (SqlCommand command = new(deleteQuery, connection))//deletes client
            {
                command.Parameters.AddWithValue("@client_id", ClientId);
                command.ExecuteNonQuery();
            }
            using (SqlCommand addressCommand = new(deleteAddressQuery, connection))//delete clients address
            {
                addressCommand.Parameters.AddWithValue("@address_id", address_id);
                addressCommand.ExecuteNonQuery();
            }
            using (SqlCommand addressCommand = new(deleteCatQuery, connection))//delete clients category list
            {
                addressCommand.Parameters.AddWithValue("@cat_id", cat_id);
                addressCommand.ExecuteNonQuery();
            }
            connection.Close();
        }

        public static List<Client> ClientList(bool ordered)//retrieves list of clients from database either ordered or not based on a bool
        {
            string connstring = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=CRS;Integrated Security=True";

            string selectCountQuery = "select count(*) from clients";
            string selectClientQuery = "select client_id, client_name, address_id, phone_number, email, cat_id from clients" + (ordered ? " order by client_name asc" : "");//ordered or not

            SqlConnection connection = new(connstring);
            SqlDataReader reader;

            int count = 0;
            List<Client> ClientList = new List<Client>();

            connection.Open();
            using (SqlCommand command = new(selectCountQuery, connection))//get number of clients
            {
                reader = command.ExecuteReader();
                reader.Read();
                count = reader.GetInt32(0);
                reader.Close();
            }

            for (int i = 0; i < count; i++)//loops thorught all clients
            {
                Client client = new Client();
                using (SqlCommand command = new(selectClientQuery, connection))//creates client object from database info
                {
                    reader = command.ExecuteReader();
                    reader.Read();
                    client.ClientID = reader.GetInt32(0);
                    client.Name = reader.GetString(1);
                    int address_id = reader.GetInt32(2);
                    client.Address = get_address(address_id);
                    client.PhoneNumber = reader.GetString(3);
                    client.Email = reader.GetString(4);
                    int cat_id = reader.GetInt32(5);
                    client.Categories = get_categories(cat_id);
                    reader.Close();
                    ClientList.Add(client);
                }
            }
            connection.Close();
            return ClientList;
        }

        public static Address get_address(int address_id)//creates address object from database info from address id
        {
            string connstring = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=CRS;Integrated Security=True";

            string selectAddressQuery = "select house_name, town, county, postcode from address where address_id = @address_id";
            SqlConnection connection = new(connstring);
            SqlDataReader reader;
            Address address = new Address();
            connection.Open();
            using (SqlCommand command = new(selectAddressQuery, connection))
            {
                command.Parameters.AddWithValue("@address_id", address_id);
                reader = command.ExecuteReader();
                reader.Read();
                address.HouseName = reader.GetString(0);
                address.Town = reader.GetString(1);
                address.County = reader.GetString(2);
                address.PostCode = reader.GetString(3);
                reader.Close();
            }
            connection.Close();
            return address;
        }
        public static List<Cat> get_categories(int cat_id)//creates list of category objects from database info from category id
        {
            string connstring = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=CRS;Integrated Security=True";

            string selectCatQuery = "select software, laptop_pcs, games, office_tools, accessories from categories where cat_id = @cat_id";
            SqlConnection connection = new(connstring);
            SqlDataReader reader;
            List<Cat> cats = new List<Cat>();
            connection.Open();
            using (SqlCommand command = new(selectCatQuery, connection))
            {
                command.Parameters.AddWithValue("@cat_id", cat_id);
                reader = command.ExecuteReader();
                reader.Read();
                for (int i = 0; i < 5; i++)
                {
                    Cat cat = new Cat();
                    switch (i)//sets category enum and selection based on index
                    {
                        case 0:
                            cat.cat = Cat.Category.Software;
                            cat.Selected = reader.GetBoolean(0);
                            break;
                        case 1:
                            cat.cat = Cat.Category.Laptop_PCs;
                            cat.Selected = reader.GetBoolean(1);
                            break;
                        case 2:
                            cat.cat = Cat.Category.Games;
                            cat.Selected = reader.GetBoolean(2);
                            break;
                        case 3:
                            cat.cat = Cat.Category.Office_Tools;
                            cat.Selected = reader.GetBoolean(3);
                            break;
                        case 4:
                            cat.cat = Cat.Category.Accessories;
                            cat.Selected = reader.GetBoolean(4);
                            break;
                    }
                    cats.Add(cat);
                }
                reader.Close();
            }
            connection.Close();
            return cats;
        }
    }
}
