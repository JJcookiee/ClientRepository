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
                END