SELECT room_number FROM dbo.Rooms
WHERE availability = 'free';

SELECT last_name, first_name FROM dbo.Customers
WHERE last_name LIKE 'S%';

SELECT C.first_name, C.last_name, R.room_number, B.check_in_date, B.check_out_date
FROM dbo.Bookings AS B
JOIN dbo.Customers AS C
ON B.customer_id = C.customer_id
JOIN dbo.Rooms AS R
ON B.room_id = R.room_id
WHERE first_name = 'Edna' OR email = 'ednall@example.com';

SELECT R.room_number, C.first_name, C.last_name, B.check_in_date, B.check_out_date
FROM dbo.Bookings AS B
JOIN dbo.Customers AS C
ON B.customer_id = C.customer_id
JOIN dbo.Rooms AS R
ON B.room_id = R.room_id
WHERE room_number = '505';

SELECT R.room_number
FROM dbo.Bookings AS B
RIGHT JOIN dbo.Rooms AS R
ON B.room_id = R.room_id
WHERE check_in_date != '06/09/2024' OR availability = 'free';
