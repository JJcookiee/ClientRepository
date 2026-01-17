using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClientRepository
{
    internal class Cat
    {
        public bool Selected { get; set; }

        public Category cat { get; set; }

        public enum Category
        {
            Software,
            Laptop_PCs,
            Games,
            Office_Tools,
            Accessories
        }

        public Cat(bool selected, Enum category)
        {
            cat = (Category)category;
            Selected = selected;
        }

        public Cat()
        {
            cat = new Category();
            Selected = false;
        }

        public static int addToDB(bool software, bool laptop_pcs, bool games, bool office_tools, bool accessories)
        {
            string connstring = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=CRS;Integrated Security=True";
            string insertquery = @"
                INSERT INTO categories (software, laptop_pcs, games, office_tools, accessories)
                VALUES (@software, @laptop_pcs, @games, @office_tools, @accessories);
                SELECT CAST(SCOPE_IDENTITY() AS INT);";

            using SqlConnection connection = new(connstring);
            connection.Open();
            using (SqlCommand command = new(insertquery, connection))
            {
                command.Parameters.AddWithValue("@software", software);
                command.Parameters.AddWithValue("@laptop_pcs", laptop_pcs);
                command.Parameters.AddWithValue("@games", games);
                command.Parameters.AddWithValue("@office_tools", office_tools);
                command.Parameters.AddWithValue("@accessories", accessories);

                object result = command.ExecuteScalar();
                return (result == null) ? 0 : Convert.ToInt32(result);
            }
        }
    }
}
