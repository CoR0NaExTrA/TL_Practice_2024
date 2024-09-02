IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Rooms')
	CREATE TABLE dbo.Rooms(
		room_id INT IDENTITY(1,1) NOT NULL,

		room_number NVARCHAR(50) NOT NULL,
		room_type NVARCHAR(50) NOT NULL,
		price_per_night NVARCHAR(50) NOT NULL,
		availability BIT NOT NULL,

		CONSTRAINT PK_rooms_room_id PRIMARY KEY (room_id)
	)

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Customers')
	CREATE TABLE dbo.Customers(
		customer_id INT IDENTITY(1,1) NOT NULL,

		first_name NVARCHAR(50) NOT NULL,
		last_name NVARCHAR(50) NOT NULL,
		email NVARCHAR(50) NOT NULL,
		phone_number NVARCHAR(50) NOT NULL,

		CONSTRAINT PK_customers_customer_id PRIMARY KEY (customer_id)
	)

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Bookings')
	CREATE TABLE dbo.Bookings(
		booking_id INT IDENTITY(1,1) NOT NULL,

		customer_id INT NOT NULL,
		room_id INT NOT NULL,
		check_in_date NVARCHAR(50) NOT NULL,
		check_out_date NVARCHAR(50) NOT NULL,
		CONSTRAINT PK_bookings_booking_id PRIMARY KEY (booking_id),

		CONSTRAINT FK_bookings_customer_id
			FOREIGN KEY (customer_id) REFERENCES dbo.Customers (customer_id),

		CONSTRAINT FK_bookings_room_id
			FOREIGN KEY (room_id) REFERENCES dbo.Rooms (room_id)
	)

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Facilities')
	CREATE TABLE dbo.Facilities(
		facility_id INT IDENTITY(1,1) NOT NULL,

		facility_name NVARCHAR(50) NOT NULL,

		CONSTRAINT PK_facilities_facility_id PRIMARY KEY (facility_id)
	)

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='RoomsToFacilities')
	CREATE TABLE dbo.RoomsToFacilities(
        id INT IDENTITY(1,1) NOT NULL,

		room_id INT NOT NULL,
		facility_id INT NOT NULL,
        CONSTRAINT PK_roomstofacilities_facility_id PRIMARY KEY (id),

		CONSTRAINT FK_roomstofacilities_room_id 
			FOREIGN KEY (room_id) REFERENCES dbo.Rooms (room_id),

		CONSTRAINT FK_roomstofacilities_facility_id
			FOREIGN KEY (facility_id) REFERENCES dbo.Facilities (facility_id)
	)

INSERT INTO dbo.Rooms (room_number, room_type, price_per_night, availability)
VALUES 
	('707', 'single room', '50$', 'true'),
	('404', 'double room', '100$', 'false'),
	('505', 'single room', '70$', 'true'),
	('606', 'double room', '150$', 'false'),
	('909', 'single room', '90$', 'false'),
	('101', 'double room', '180$', 'true');

INSERT INTO dbo.Customers (first_name, last_name, email, phone_number)
VALUES 
	('Ivan', 'Sidorov', 'ivaiva@example.com', ''),
	('Daniel', 'Cobb', 'cobbrra@example.com', ''),
	('Daniil', 'Panov', 'PanDan@example.com', ''),
	('Max', 'Davydov', 'maxdavydov@example.com', ''),
	('Edna', 'Elliott', 'ednall@example.com', ''),
	('Mary', 'Clark', 'marlark@example.com', '');

INSERT INTO dbo.Bookings (customer_id, room_id, check_in_date, check_out_date)
VALUES 
	('2', '2', '06/09/2024', '20/09/2024'),
	('3', '3', '07/01/2025', '14/01/2025'),
	('5', '5', '14/02/2025', '14/03/2025');
INSERT INTO dbo.Facilities (facility_name)
VALUES 
	('Wi-Fi'),
	('Personal safe'),
	('Bathroom'),
	('Conditioner'),
	('Balcony'),
	('TV');

INSERT INTO dbo.RoomsToFacilities (room_id, facility_id)
VALUES 
	('1', '1'), ('1', '3'), ('1', '4'),
	('2', '1'), ('2', '2'), ('2', '3'), ('2', '4'), ('2', '6'),
	('3', '1'), ('3', '3'), ('3', '4'), ('3', '6'),
	('4', '1'), ('4', '2'), ('4', '3'), ('4', '4'), ('4', '5'), ('4', '6'),
	('5', '1'), ('5', '2'), ('5', '3'), ('5', '4'), ('5', '6'),
	('6', '1'), ('6', '2'), ('6', '3'), ('6', '4'), ('6', '5'), ('6', '6');