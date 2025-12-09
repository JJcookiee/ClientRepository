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
                    ON (NAME = CRS, FILENAME = '|DataDictionary|\CRS.mdf'); 
                END";
            string createClientTableQuery = @"
                IF OBJECT_ID('clients', 'U') IS NULL
                BEGIN
                    CREATE TABLE clients (
                        client_id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
                        client_name NVARCHAR(100) NOT NULL,
                        address NVARCHAR(255) NOT NULL,
                        phone_number NVARCHAR(15) NOT NULL,
                        email NVARCHAR(100) NOT NULL
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
            connstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDictionary|\CRS.mdf;Integrated Security=True";
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
                connection.Close();
            }
        }
    }
}
