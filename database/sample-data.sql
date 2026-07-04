USE SalesOrderManagementDb;

INSERT INTO Clients (CustomerName, Address, City, PostCode)
VALUES
('Kamal Perera', 'No 12, Main Street', 'Colombo', '00100'),
('Nimal Silva', 'No 45, Lake Road', 'Kandy', '20000'),
('Sunil Traders', 'No 88, Market Road', 'Galle', '80000');

INSERT INTO Items (ItemCode, Description, Price)
VALUES
('ITM001', 'Laptop', 250000.00),
('ITM002', 'Wireless Mouse', 3500.00),
('ITM003', 'Keyboard', 6500.00),
('ITM004', 'Monitor', 75000.00);