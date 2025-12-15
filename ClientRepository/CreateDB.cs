using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;

namespace ClientRepository
{
    internal class CreateDB
    {
        public static void CreateDatabase()// checks for db, creates if not exists, same for tables, probs will only be used once each
        {
            string connstring = @"Data Source=(LocalDB)\MSSQLLocalDB;Integrated Security=True";
            string createDBQuery = @"
                IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'CRS') 
                BEGIN
                    CREATE DATABASE CRS
                END";
            string createClientTableQuery = @"
                IF OBJECT_ID('clients', 'U') IS NULL
                BEGIN
                    CREATE TABLE clients (
                        client_id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
                        client_name NVARCHAR(100) NOT NULL,
                        address_id INT NOT NULL,
                        phone_number NVARCHAR(15) NOT NULL,
                        email NVARCHAR(100) NOT NULL,
                        cat_id INT NOT NULL,
                        FOREIGN KEY (address_id) REFERENCES address(address_id),
                        FOREIGN KEY (cat_id) REFERENCES categories(cat_id)
                    );
                END";
            string createAddressTableQuery = @"
                IF OBJECT_ID('address', 'U') IS NULL
                BEGIN
                    CREATE TABLE address (
                        address_id INT PRIMARY KEY IDENTITY (1, 1) NOT NULL,
                        house_name VARCHAR (50) NOT NULL,
                        town VARCHAR (50) NOT NULL,
                        county VARCHAR (50) NOT NULL,
                        postcode VARCHAR (10) NOT NULL,
                    );
                END";
            string createCatTableQuery = @"
                IF OBJECT_ID('categories', 'U') IS NULL
                BEGIN
                    CREATE TABLE categories (
                        cat_id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
                        software bit default(0) not null,
                        laptop_pcs bit default(0) not null,
                        games bit default(0) not null,
                        office_tools bit default(0) not null,
                        accessories bit default(0) not null
                    );
                END";
            using (SqlConnection connection = new SqlConnection(connstring))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(createDBQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
            // Connect to the newly created database to create the table
            connstring = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=CRS;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connstring))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(createClientTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
                using (SqlCommand command = new SqlCommand(createAddressTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
                using (SqlCommand command = new SqlCommand(createCatTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
    }
}
