using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Text;

namespace ClientRepository
{
    public class Address
    {
        public string HouseName { get; set; }
        public string Town { get; set; }
        public string County { get; set; }
        public string PostCode { get; set; }

        public Address(string houseName, string town, string county, string postCode)//initialises address object
        {
            HouseName = houseName;
            Town = town;
            County = county;
            PostCode = postCode;
        }
        public Address()//blank constructor
        {
            HouseName = "";
            Town = "";
            County = "";
            PostCode = "";
        }

        public static string totxt(Address address)
        {
            string dbstring = (
                $"{address.HouseName}, " +
                $"{address.Town}, " +
                $"{address.County}, " +
                $"{address.PostCode}"
                );
            return dbstring;
        }
        public static Address fromtxt(string dbstring)
        {
            string[] dbstrings = dbstring.Split(", ");
            Address address = new Address(
                houseName: dbstrings[0],
                town: dbstrings[1],
                county: dbstrings[2],
                postCode: dbstrings[3]
                );
            return address;
        }


        public static int addToDB(string house_name, string town, string county, string postcode)//adds address to database and returns address id
        {
            string connstring = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=CRS;Integrated Security=True";
            string insertquery = @"
                INSERT INTO address (house_name, town, county, postcode)
                VALUES (@house_name, @town, @county, @postcode);
                SELECT CAST(SCOPE_IDENTITY() AS INT);";

            using SqlConnection connection = new(connstring);
            connection.Open();
            using SqlCommand command = new(insertquery, connection);
            command.Parameters.AddWithValue("@house_name", house_name);
            command.Parameters.AddWithValue("@town", town);
            command.Parameters.AddWithValue("@county", county);
            command.Parameters.AddWithValue("@postcode", postcode);

            object result = command.ExecuteScalar();
            return (result == null) ? 0 : Convert.ToInt32(result);
        }

        public static void updateInDB(int address_id, string house_name, string town, string county, string postcode)
        {
            string connstring = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=CRS;Integrated Security=True";
            string updatequery = "UPDATE dbo.address set house_name = @house_name, town = @town, county = @county, postcode = @postcode WHERE address_id = @address_id";
            using SqlConnection connection = new(connstring);
            connection.Open();
            using SqlCommand command = new(updatequery, connection);
            command.Parameters.AddWithValue("@house_name", house_name);
            command.Parameters.AddWithValue("@town", town);
            command.Parameters.AddWithValue("@county", county);
            command.Parameters.AddWithValue("@postcode", postcode);
            command.Parameters.AddWithValue("@address_id", address_id);
            command.ExecuteNonQuery();
        }

        public static Address getFromDB(int address_id)//retrieves address from database using address id
        {
            string connstring = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=CRS;Integrated Security=True";
            string selectquery = "SELECT house_name, town, county, postcode FROM address WHERE address_id = @address_id";
            using SqlConnection connection = new(connstring);
            connection.Open();
            using SqlCommand command = new(selectquery, connection);
            command.Parameters.AddWithValue("@address_id", address_id);
            using SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                string house_name = reader.GetString(0);
                string town = reader.GetString(1);
                string county = reader.GetString(2);
                string postcode = reader.GetString(3);
                return new Address(house_name, town, county, postcode);
            }
            else
            {
                return null;
            }
        }
    }
}
