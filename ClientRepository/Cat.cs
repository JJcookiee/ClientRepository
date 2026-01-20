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

        public enum Category//which category the object represents
        {
            Software,
            Laptop_PCs,
            Games,
            Office_Tools,
            Accessories
        }

        public Cat(bool selected, Enum category)//initialises category object
        {
            cat = (Category)category;
            Selected = selected;
        }

        public Cat()//blank constructor
        {
            cat = new Category();
            Selected = false;
        }

        public static int addToDB(bool software, bool laptop_pcs, bool games, bool office_tools, bool accessories)//adds category to database and returns category id
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

        public static void updateInDB(int cat_id, bool software, bool laptop_pcs, bool games, bool office_tools, bool accessories)
        {
            string connstring = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=CRS;Integrated Security=True";

            string updatequery = "UPDATE dbo.categories SET software = @software, laptop_pcs = @laptop_pcs, games = @games, office_tools = @office_tools, accessories = @accessories WHERE cat_id = @cat_id";
            using SqlConnection connection = new(connstring);
            connection.Open();
            using (SqlCommand command = new(updatequery, connection))
            {
                command.Parameters.AddWithValue("@software", software);
                command.Parameters.AddWithValue("@laptop_pcs", laptop_pcs);
                command.Parameters.AddWithValue("@games", games);
                command.Parameters.AddWithValue("@office_tools", office_tools);
                command.Parameters.AddWithValue("@accessories", accessories);
                command.Parameters.AddWithValue("@cat_id", cat_id);
                command.ExecuteNonQuery();
            }
        }

        public static List<Cat> getFromDB(int cat_id)//retrieves category from database using category id
        {
            string connstring = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=CRS;Integrated Security=True";
            string selectquery = "SELECT software, laptop_pcs, games, office_tools, accessories FROM categories WHERE cat_id = @cat_id";
            List<Cat> categories = new List<Cat>();
            using SqlConnection connection = new(connstring);
            connection.Open();
            using (SqlCommand command = new(selectquery, connection))
            {
                command.Parameters.AddWithValue("@cat_id", cat_id);
                using SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    categories.Add(new Cat(reader.GetBoolean(0), Category.Software));
                    categories.Add(new Cat(reader.GetBoolean(1), Category.Laptop_PCs));
                    categories.Add(new Cat(reader.GetBoolean(2), Category.Games));
                    categories.Add(new Cat(reader.GetBoolean(3), Category.Office_Tools));
                    categories.Add(new Cat(reader.GetBoolean(4), Category.Accessories));
                    return categories;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
