CREATE DATABASE LimitlessTyres;

GO
USE LimitlessTyres;

CREATE TABLE Supplier
(
	SupplierID INT NOT NULL,
	SupplierContactNo VARCHAR(11) NOT NULL CHECK([SupplierContactNo] like replicate('[0-9]',(11))),
	SupplierName VARCHAR(40) NOT NULL CHECK(LEN(SupplierName)>1),
	SupplierStreet VARCHAR(40) NOT NULL CHECK(LEN(SupplierStreet)>1),
	SupplierTown VARCHAR(40) NOT NULL CHECK(LEN(SupplierTown)>1),
	SupplierCounty VARCHAR(11) NOT NULL CHECK(LEN(SupplierCounty)>1),
	SupplierPostcode VARCHAR(8) NOT NULL CHECK([SupplierPostcode] like '[A-Z][A-Z][0-9][0-9] [0-9][A-Z][A-Z]'),

	CONSTRAINT pkSupplier PRIMARY KEY(SupplierID)
);

CREATE TABLE TyreType
(
	TyreTypeCode VARCHAR(5) NOT NULL,
	TyreTypeDesc VARCHAR(40) NOT NULL CHECK(LEN(TyreTypeDesc)>1),

	CONSTRAINT pkTyreType PRIMARY KEY(TyreTypeCode)
);

CREATE TABLE Tyre
(
	TyreID VARCHAR(14) NOT NULL ,
	TyreTypeCode VARCHAR(5) NOT NULL,
	SupplierID INT NOT NULL,
	TyreDesc VARCHAR(40) NOT NULL, CHECK(LEN(TyreDesc)>1), 
	TyrePrice MONEY NOT NULL CHECK(TyrePrice>0), 
	QtyInStock INT NOT NULL CHECK(QtyInStock>=0),

	CONSTRAINT pkTyre PRIMARY KEY(TyreID),
	CONSTRAINT fkTyreTyreType FOREIGN KEY(TyreTypeCode) REFERENCES TyreType(TyreTypeCode),
	CONSTRAINT fkTyreSupplier FOREIGN KEY(SupplierID) REFERENCES Supplier(SupplierID)
);

CREATE TABLE CustomerType
(
	CustomerTypeID VARCHAR(1) NOT NULL,
	CustomerTypeDesc VARCHAR(7) NOT NULL CHECK(LEN(CustomerTypeDesc)>1),
	DiscountPercentage DECIMAL(3,2) NOT NULL,
	
	CONSTRAINT pkCustomerType PRIMARY KEY(CustomerTypeID)
);

CREATE TABLE Customer
(
	CustomerID INT NOT NULL,
	CustomerTypeID VARCHAR(1) NOT NULL,
	CompanyName VARCHAR(40) CHECK(LEN(CompanyName)>1),
	CustomerSurname VARCHAR(40) NOT NULL,
	CustomerForename VARCHAR(40) NOT NULL,
	CustomerContactNo VARCHAR(11) NOT NULL CHECK([CustomerContactNo] like replicate('[0-9]',(11))),
	CustomerStreet VARCHAR(40) NOT NULL CHECK(LEN(CustomerStreet)>1),
	CustomerTown VARCHAR(40) NOT NULL CHECK(LEN(CustomerTown)>1),
	CustomerCounty VARCHAR(11) NOT NULL CHECK(LEN(CustomerCounty)>1),
	CustomerPostcode VARCHAR(8) NOT NULL CHECK([CustomerPostcode] like '[A-Z][A-Z][0-9][0-9] [0-9][A-Z][A-Z]'),

	CONSTRAINT pkCustomer PRIMARY KEY(CustomerID),
	CONSTRAINT fkCustomerCustomerType FOREIGN KEY(CustomerTypeID) REFERENCES CustomerType(CustomerTypeID)
);


CREATE TABLE [Order]
(
	OrderID INT NOT NULL,
	CustomerID INT NOT NULL,
	OrderDate DATETIME NOT NULL,

	CONSTRAINT pkOrder PRIMARY KEY(OrderID),
	CONSTRAINT fkOrderCustomer FOREIGN KEY(CustomerID) REFERENCES Customer(CustomerID)
);

CREATE TABLE OrderDetail
(
	OrderID INT NOT NULL,
	TyreID VARCHAR(14) NOT NULL,
	Quantity INT NOT NULL,

	CONSTRAINT pkOrderDetails PRIMARY KEY(OrderID, TyreID),
	CONSTRAINT fkOrderDetailsToOrder FOREIGN KEY(OrderID) REFERENCES [Order] (OrderID),
	CONSTRAINT fkOrderDetailsToTyre FOREIGN KEY(TyreID) REFERENCES Tyre(TyreID)
);

CREATE TABLE ServiceItem
(
	ServiceItemID			int					NOT NULL,
	ServiceItemDescription	VARCHAR(20)			NOT NULL,
	ServicePrice			money				NOT NULL,

	CONSTRAINT pkServiceItemID PRIMARY KEY(ServiceItemID)
);

CREATE TABLE ServiceTable
(
	ServiceID				int					NOT NULL,
	CustomerID				int					NOT NULL,
	DateBooked				DateTime			NOT NULL,
	ServiceDate				DateTime			NOT NULL,
	StartTime				Time				NOT NULL,
	NoOfSlots				VARCHAR(1)			NOT NULL,

	CONSTRAINT pkServiceID PRIMARY KEY(ServiceID),
	CONSTRAINT fkCustomerID FOREIGN KEY(CustomerID) REFERENCES Customer(CustomerID)
);

CREATE TABLE ServiceDetails
(
	ServiceID				int					NOT NULL,
	ServiceItemID			int					NOT NULL,
	Quantity                int					NOT NULL,

	CONSTRAINT pkIDs PRIMARY KEY(ServiceID, ServiceItemID),
	CONSTRAINT fkServiceItemID FOREIGN KEY(ServiceItemID) REFERENCES ServiceItem(ServiceItemID),
	CONSTRAINT fkServiceID FOREIGN KEY(ServiceID) REFERENCES ServiceTable(ServiceID)
);

INSERT INTO Supplier
(SupplierID, SupplierContactNo, SupplierName, SupplierStreet, SupplierTown, SupplierCounty, SupplierPostcode)
VALUES(1000, '07632960122', 'Great Wheels', '154 Main Street', 'Eglinton', 'Derry', 'BT49 5DN'), 
(1001, '02871387592', 'Super Tyres', '53 Limavady Road', 'Derry', 'Derry', 'BT47 4TB'),
( 1002, '07774698325', 'Amazing Tyres', '34 Rosewood Avenue', 'Derry', 'Derry', 'BT47 5HF'),
(1003, '07892579432', 'Golden Tyres', '342 Rallagh Road', 'Dungiven', 'Derry', 'BT58 3HB');

INSERT INTO TyreType
(TyreTypeCode, TyreTypeDesc)
VALUES('CR', 'Regular car'),
('VN', 'Van'),
('4X4', '4x4 vehicle');

INSERT INTO Tyre
(TyreID, TyreTypeCode, SupplierID, TyreDesc, TyrePrice, QtyInStock)
VALUES('225/70R15 R', 'VN', 1000, 'ContiVanContact 100', 109.99, 550),
('225/65R17 T', '4X4', 1000, '4x4Contact', 99.99, 310),
('165/65R15 T', 'CR', 1000, 'Conti.eContact', 59.99, 280),
('185/65R14 H', 'CR', 1001, 'CrossClimate', 69.99, 170),
('195/65R15 H', 'CR', 1001, 'Primacy 4', 599.99, 231),
('235/65R17 V', '4X4', 1001, 'CrossClimate SUV', 139.99, 420),
('225/60R16 H', 'VN', 1002, 'Agilis 51', 129.99, 507),
('225/45R17 W', 'CR', 1002, 'ECO605+', 49.99, 230),
('205/55R16 H', 'CR', 1002, 'Touring S1', 39.99, 270),
('225/65R16 R', 'VN', 1003, 'AV12', 99.99, 220),
('225/60R17 H', 'CR', 1003, 'Grip 4000', 99.99, 260),
('225/75R16 S', '4X4', 1003, 'All Terrain T/A KO2', 139.99, 520),
('195/65R15 W', 'VN', 1000, 'Proxes CF2', 49.99, 230),
('165/70R14 T', 'CR', 1000, 'Kinergy Eco 2 K435', 39.99, 210),
('235/45R17 W', 'CR', 1000, 'E51A', 89.99, 210),
('185/65R15 T', 'CR', 1001, 'ZT7', 59.99, 200),
('215/75R14 T', 'CR', 1001, 'B381 KZ', 79.99, 170),
('205/45R16 W', 'CR', 1001, 'PremiumContact 6 ', 109.99, 264),
('195/55R15 H', 'CR', 1002, 'EfficientGrip', 79.99, 230),
('175/60R14 H', 'CR', 1002, 'Polaris 16', 39.99, 260);

INSERT INTO CustomerType
(CustomerTypeID, CustomerTypeDesc, DiscountPercentage)
VALUES('T', 'Trade', 0.1),
('G', 'General', 0);

INSERT INTO Customer
(CustomerID, CustomerTypeID, CustomerSurname, CustomerForename, CustomerContactNo, CustomerStreet, CustomerTown, CustomerCounty, CustomerPostcode)
VALUES(1000, 'G', 'Young', 'Amanda', '07547859473', '34 Strand Road', 'Derry', 'Derry', 'BT47 8JG'),
(1002, 'G', 'Jones', 'Jack', '07547858724', '70 Rosewood Avenue', 'Derry', 'Derry', 'BT47 3JF'),
(1004, 'G', 'Cook', 'Nicole', '07547883528', '100 Main Road', 'Derry', 'Derry', 'BT47 3MF'),
(1007, 'G', 'Connors', 'Mike', '07356322678', '1001  Modoc Alley', 'Derry', 'Derry', 'BT48 3JE'),
(1008, 'G', 'Smith', 'Serena', '07777777777', '4107  Robinson Lane', 'Derry', 'Derry', 'BT48 7IY'),
(1009, 'G', 'Johnson', 'George', '07989896556', '2004  Poplar Avenue', 'Derry', 'Derry', 'BT48 0OO'),
(1010, 'G', 'Williams', 'Sara', '07123123123', '3944  Alexander Avenue', 'Derry', 'Derry', 'BT48 1QQ'),
(1011, 'G', 'Brown', 'Luke', '07987654321', '1912  Kimberly Way', 'Derry', 'Derry', 'BT48 7HG');

INSERT INTO Customer
(CustomerID, CustomerTypeID, CompanyName, CustomerSurname, CustomerForename, CustomerContactNo, CustomerStreet, CustomerTown, CustomerCounty, CustomerPostcode)
VALUES(1001, 'T', 'Car Company', 'Brown', 'Chloe', '07583574384', '102 Main Road', 'Derry', 'Derry', 'BT47 4MF'),
(1003, 'T', 'Car Zone', 'Williams', 'Henry', '07583568391', '584 Duncrun Road', 'Limavady', 'Derry', 'BT47 3MF'),
(1005, 'T', 'Car Deals', 'Evans', 'Amanda', '07583568148', '43 Hollyfoot Hill', 'Ballykelly', 'Derry', 'BT47 4FB'),
(1006, 'T', 'Car Rentals', 'Matthews', 'Hanna', '07583368416', '21 Spencer Road', 'Waterside', 'Derry', 'BT47 7ME'),
(1013, 'T', 'Car Place', 'Rodriguez', 'Margret', '07656362154', '20 Jubilee Terrace', 'Northampton', 'Derry', 'RH74 1LE'),
(1014, 'T', 'Broom Broom', 'Lopes', 'Daniel', '07999999999', '33 Wasdale Avenue', 'Dinas Powys', 'Derry', 'DN34 5JW'),
(1015, 'T', 'Terrys Tires', 'Wilson', 'George', '07123333333', '33 Vicars Road', 'Chawleigh', 'Derry', 'AL81 4RA'),
(1016, 'T', 'Karls Cars', 'Martinez', 'Sasha', '07001028467', '6 Scotney Close', 'Blackburn', 'Derry', 'BB21 1XD'),
(1017, 'T', 'Hot Shots', 'Anderson', 'Peter', '07826536652', '10 Ffordd Merrett', 'Newark', 'Derry', 'MD31 9JB');

INSERT INTO [Order]
(OrderID, CustomerID, OrderDate)
VALUES(1000, 1001, '2020-12-24'),
(1001, 1004, '2020-11-01'),
(1002, 1000, '2020-11-04'),
(1003, 1000, '2020-11-06'),
(1004, 1002, '2020-11-08'),
(1005, 1003, '2020-11-10'),
(1006, 1001, '2020-11-13'),
(1007, 1004, '2020-11-15'),
(1008, 1002, '2020-11-17'),
(1009, 1003, '2020-11-18'),
(1010, 1005, '2020-11-18'),
(1011, 1005, '2020-11-21'),
(1012, 1006, '2020-11-24'),
(1013, 1006, '2020-11-27'),
(1014, 1002, '2020-11-27'),
(1015, 1004, '2020-11-28'),
(1016, 1000, '2020-11-30'),
(1017, 1001, '2020-12-01'),
(1018, 1005, '2020-12-02'),
(1019, 1003, '2020-12-03'),
(1020, 1006, '2020-12-04'),
(1021, 1017, '2020-12-04'),
(1022, 1017, '2020-12-05'),
(1023, 1017, '2020-12-06'),
(1024, 1014, '2020-12-06'),
(1025, 1014, '2020-12-06'),
(1026, 1014, '2020-12-07'),
(1027, 1016, '2020-12-07'),
(1028, 1016, '2020-12-08'),
(1029, 1016, '2020-12-09'),
(1030, 1013, '2020-12-10'),
(1031, 1013, '2020-12-11'),
(1032, 1013, '2020-12-12'),
(1033, 1015, '2020-12-12'),
(1034, 1015, '2020-12-13'),
(1035, 1015, '2020-12-14'),
(1036, 1011, '2020-12-14'),
(1037, 1011, '2020-12-15'),
(1038, 1011, '2020-12-15'),
(1039, 1007, '2020-12-15'),
(1040, 1007, '2020-12-16'),
(1041, 1007, '2020-12-17'),
(1042, 1009, '2020-12-17'),
(1043, 1009, '2020-12-18'),
(1044, 1009, '2020-12-19'),
(1045, 1008, '2020-12-19'),
(1046, 1008, '2020-12-20'),
(1047, 1008, '2020-12-21'),
(1048, 1010, '2020-12-21'),
(1049, 1008, '2020-12-22'),
(1050, 1010, '2020-12-22'),
(1051, 1010, '2020-12-23');

INSERT INTO OrderDetail
(OrderID, TyreID, Quantity)
VALUES
(1000, '225/65R17 T', 4),
(1000, '225/75R16 S', 4),
(1001, '185/65R14 H', 4),
(1002, '195/65R15 W', 2),
(1003, '225/65R16 R', 8),
(1004, '225/65R17 T', 4),
(1005, '225/75R16 S', 20),
(1006, '195/65R15 W', 4),
(1006, '225/60R16 H', 4),
(1006, '225/65R16 R', 4),
(1006, '225/70R15 R', 4),
(1007, '225/45R17 W', 4),
(1008, '235/65R17 V', 4),
(1009, '165/65R15 T', 16),
(1009, '195/65R15 W', 10),
(1009, '225/75R16 S', 4),
(1010, '225/65R17 T', 20),
(1010, '225/75R16 S', 4),
(1010, '235/65R17 V', 4),
(1011, '165/65R15 T', 40),
(1012, '205/55R16 H', 4),
(1012, '225/65R16 R', 10),
(1012, '235/45R17 W', 20),
(1013, '205/55R16 H', 20),
(1013, '225/75R16 S', 60),
(1014, '165/65R15 T', 2),
(1015, '225/65R16 R', 4),
(1016, '195/65R15 W', 4),
(1017, '205/55R16 H', 80),
(1018, '165/65R15 T', 40),
(1018, '205/55R16 H', 20),
(1018, '225/65R17 T', 16),
(1019, '165/65R15 T', 20),
(1019, '225/65R16 R', 80),
(1019, '225/75R16 S', 24),
(1020, '165/65R15 T', 14),
(1020, '225/60R16 H', 40),
(1020, '225/65R16 R', 20),
(1020, '225/70R15 R', 80),
(1021, '225/70R15 R', 24),
(1021, '165/70R14 T', 24),
(1021, '225/75R16 S', 24),
(1022, '175/60R14 H', 24),
(1022, '195/65R15 W', 24),
(1023, '165/65R15 T', 24),
(1023, '195/65R15 W', 24),
(1024, '225/75R16 S', 24),
(1025, '225/65R16 R', 24),
(1026, '185/65R14 H', 24),
(1026, '225/75R16 S', 24),
(1027, '225/75R16 S', 24),
(1028, '205/45R16 W', 24),
(1028, '225/75R16 S', 24),
(1029, '225/75R16 S', 24),
(1030, '225/75R16 S', 24),
(1031, '225/75R16 S', 24),
(1032, '225/65R17 T', 24),
(1032, '235/65R17 V', 24),
(1032, '225/75R16 S', 24),
(1033, '225/75R16 S', 24),
(1033, '235/65R17 V', 24),
(1034, '225/75R16 S', 24),
(1034, '205/45R16 W', 24),
(1035, '225/75R16 S', 24),
(1036, '225/75R16 S', 24),
(1037, '225/75R16 S', 24),
(1038, '225/75R16 S', 24),
(1039, '225/75R16 S', 24),
(1040, '225/75R16 S', 24),
(1041, '225/75R16 S', 24),
(1042, '225/75R16 S', 24),
(1043, '225/75R16 S', 24),
(1044, '225/75R16 S', 24),
(1045, '225/75R16 S', 24),
(1046, '225/75R16 S', 24),
(1047, '225/75R16 S', 24),
(1048, '225/75R16 S', 24),
(1049, '225/75R16 S', 24),
(1050, '225/75R16 S', 24),
(1051, '225/75R16 S', 24);

INSERT INTO ServiceItem
(ServiceItemID, ServiceItemDescription, ServicePrice)
VALUES(1000, 'Change Tyres', '£45'),
(1001, 'Tyre Check', '£15'),
(1002, 'Steering Check', '£10'),
(1003, 'Suspension Check', '£10'),
(1004, 'Change Oil', '£30'),
(1005, 'Air Filter Change', '£40'),
(1006, 'Fuel Filter Change', '£50');

INSERT INTO ServiceTable
(ServiceID, CustomerID, DateBooked, ServiceDate, StartTime, NoOfSlots)
VALUES(1000, 1000, '2020-10-01', '2020-10-02', '2020-10-02 09:00:00', '1'),
(1001, 1000, '2020-10-01', '2020-10-02', '2020-10-02 09:15:00', '1'),
(1002, 1002, '2020-10-01', '2020-10-02', '2020-10-02 09:30:00', '1'),
(1003, 1002, '2020-10-01', '2020-10-02', '2020-10-02 09:45:00', '1'),
(1004, 1004, '2020-10-01', '2020-10-02', '2020-10-02 10:00:00', '2'),
(1005, 1004, '2020-10-01', '2020-10-02', '2020-10-02 10:30:00', '2'),
(1006, 1007, '2020-10-01', '2020-10-02', '2020-10-02 11:00:00', '2'),
(1007, 1007, '2020-10-01', '2020-10-02', '2020-10-02 11:30:00', '2'),
(1008, 1008, '2020-10-02', '2020-10-03', '2020-10-03 09:00:00', '1'),
(1009, 1008, '2020-10-02', '2020-10-03', '2020-10-03 09:15:00', '1'),
(1010, 1009, '2020-10-02', '2020-10-03', '2020-10-03 09:30:00', '1'),
(1011, 1009, '2020-10-03', '2020-10-04', '2020-10-04 09:00:00', '2'),
(1012, 1010, '2020-10-03', '2020-10-04', '2020-10-04 09:30:00', '2'),
(1013, 1010, '2020-10-03', '2020-10-04', '2020-10-04 10:00:00', '2'),
(1014, 1011, '2020-10-03', '2020-10-04', '2020-10-04 10:30:00', '4'),
(1015, 1011, '2020-10-03', '2020-10-04', '2020-10-04 11:30:00', '1');

INSERT INTO ServiceDetails
(ServiceID, ServiceItemID, Quantity)
VALUES(1000, 1000, 1),
(1001, 1001, 1),
(1002, 1002, 1),
(1003, 1003, 1),
(1004, 1004, 1),
(1005, 1005, 1),
(1006, 1006, 1),
(1007, 1000, 2),
(1008, 1001, 1),
(1009, 1002, 1),
(1010, 1003, 1),
(1011, 1004, 1),
(1012, 1005, 1),
(1013, 1006, 1),
(1014, 1000, 4),
(1015, 1001, 1);
