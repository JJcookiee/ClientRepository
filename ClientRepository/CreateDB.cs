using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;

namespace ClientRepository
{
    internal class CreateDB
    {
        public static void CreateDatabase()// checks for db, creates if not exists, same for tables
        {
            string connstring = @"Data Source=(LocalDB)\MSSQLLocalDB;Integrated Security=True";
            string createDBQuery = @"
                IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'CRS') 
                BEGIN
                    CREATE DATABASE CRS;
                END";

            string createAddressTableQuery = @"
                IF OBJECT_ID('dbo.address', 'U') IS NULL
                BEGIN
                    CREATE TABLE dbo.address (
                        address_id INT PRIMARY KEY IDENTITY (1, 1) NOT NULL,
                        house_name VARCHAR(50) NOT NULL,
                        town VARCHAR(50) NOT NULL,
                        county VARCHAR(50) NOT NULL,
                        postcode VARCHAR(10) NOT NULL
                    );
                END";

            string createCatTableQuery = @"
                IF OBJECT_ID('dbo.categories', 'U') IS NULL
                BEGIN
                    CREATE TABLE dbo.categories (
                        cat_id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
                        software BIT DEFAULT(0) NOT NULL,
                        laptop_pcs BIT DEFAULT(0) NOT NULL,
                        games BIT DEFAULT(0) NOT NULL,
                        office_tools BIT DEFAULT(0) NOT NULL,
                        accessories BIT DEFAULT(0) NOT NULL
                    );
                END";

            string createClientTableQuery = @"
                IF OBJECT_ID('dbo.clients', 'U') IS NULL
                BEGIN
                    CREATE TABLE dbo.clients (
                        client_id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
                        client_name NVARCHAR(100) NOT NULL,
                        address_id INT NOT NULL,
                        phone_number NVARCHAR(15) NOT NULL,
                        email NVARCHAR(100) NOT NULL,
                        cat_id INT NOT NULL,
                        FOREIGN KEY (address_id) REFERENCES dbo.address(address_id),
                        FOREIGN KEY (cat_id) REFERENCES dbo.categories(cat_id)
                    );
                END";
            using (SqlConnection connection = new SqlConnection(connstring))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(createDBQuery, connection))//create database if it doesn't exist
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
                
                using (SqlCommand command = new SqlCommand(createAddressTableQuery, connection))//create address table if it doesn't exists
                {
                    command.ExecuteNonQuery();
                }
                using (SqlCommand command = new SqlCommand(createCatTableQuery, connection))//create categories table if it doesn't exist
                {
                    command.ExecuteNonQuery();
                }
                using (SqlCommand command = new SqlCommand(createClientTableQuery, connection))//create clients table if it doesn't exist
                {
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
    }
}
