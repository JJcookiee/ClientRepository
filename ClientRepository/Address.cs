using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClientRepository
{
    internal class Address
    {
        public string HouseName { get; set; }
        public string Town { get; set; }
        public string County { get; set; }
        public string PostCode { get; set; }

        public Address(string houseName, string town, string county, string postCode)
        {
            HouseName = houseName;
            Town = town;
            County = county;
            PostCode = postCode;
        }
        public Address()
        {
            HouseName = "";
            Town = "";
            County = "";
            PostCode = "";
        }

        public static string todb(Address address)
        {
            string dbstring = (
                $"{address.HouseName}, " +
                $"{address.Town}, " +
                $"{address.County}, " +
                $"{address.PostCode}"
                );
            return dbstring;
        }
        public static Address fromdb(string dbstring)
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


        public static int addToDB(string house_name, string town, string county, string postcode)
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
    }
}
