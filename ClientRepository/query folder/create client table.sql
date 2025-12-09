use CRS

create table clients(
	client_id int primary key identity(1,1),
	client_name varchar(20),
	address varchar(500),
	phone_number varchar(50),
	email varchar(50)
);