
USE master;
DROP DATABASE IF EXISTS WibuCoffee;

CREATE DATABASE WibuCoffee
GO

USE WibuCoffee
GO

-- Tạo bảng Job
CREATE TABLE Job (
    ID VARCHAR(3) PRIMARY KEY, -- J01, J02, ...
    jobDetail NVARCHAR(max),
    salary DECIMAL(10, 2) NOT NULL CHECK (salary > 0)
);

CREATE TABLE Employee (
    ID VARCHAR(4) PRIMARY KEY, -- E01, E02, ...
    name NVARCHAR(max) NOT NULL,
    birthDate DATE,
    address NVARCHAR(max),
    phone VARCHAR(10) NOT NULL CHECK (LEN(phone) = 10),
    recruitmentDate DATE ,
    jobID VARCHAR(3) NOT NULL,
    penaltyPoint INT,
    bonusPoint INT,
    numberOfShift INT NOT NULL,
    FOREIGN KEY (jobID) REFERENCES Job(ID)
		ON UPDATE CASCADE
);


-- Tạo bảng Shift
CREATE TABLE [Shift] (
    ID VARCHAR(5) PRIMARY KEY, -- S0001, S0002, ...
    startTime TIME NOT NULL,
    endTime TIME NOT NULL
);

-- Tạo bảng Supplier
CREATE TABLE Supplier (
    ID VARCHAR(4) PRIMARY KEY, -- SP01, SP02, ...
    name NVARCHAR(max) NOT NULL,
    address NVARCHAR(max) NOT NULL,
    phone VARCHAR(10) CHECK (LEN(phone) = 10) NOT NULL
);

-- Tạo bảng On_Duty
CREATE TABLE On_Duty (
    empID VARCHAR(4),
    shiftID VARCHAR(5),
    date DATE,
    FOREIGN KEY (empID) REFERENCES Employee(ID)
		ON UPDATE CASCADE,
    FOREIGN KEY (shiftID) REFERENCES [Shift](ID)
		ON UPDATE CASCADE,
    PRIMARY KEY (empID, shiftID, date)

);

-- Tạo bảng Table
CREATE TABLE [Table] (
    ID VARCHAR(3) PRIMARY KEY, -- T01, T02, ...
    name NVARCHAR(max) NOT NULL,
    status NVARCHAR(max) NOT NULL
);

-- Tạo bảng Customer
CREATE TABLE Customer (
    ID VARCHAR(5) PRIMARY KEY, -- C0001, C0002, ...
    name NVARCHAR(max) NOT NULL,
    phone VARCHAR(10) NOT NULL CHECK (LEN(phone) = 10),
    bonusPoint INT
);

-- Tạo bảng BillCategory
CREATE TABLE BillCategory (
    ID VARCHAR(4) PRIMARY KEY, -- BC01, ...
    name NVARCHAR(max) NOT NULL,
    discount DECIMAL(5, 2)
);

-- Tạo bảng Bill
CREATE TABLE Bill (
    ID VARCHAR(7) PRIMARY KEY, -- B000001
    dateTime DATETIME NOT NULL,
    tableID VARCHAR(3),
    customerID VARCHAR(5) NOT NULL,
    categoryID VARCHAR(4) NOT NULL,
    empID VARCHAR(4) NOT NULL,
    receiptMoney DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (tableID) REFERENCES [Table](ID)
		ON UPDATE CASCADE,
    FOREIGN KEY (customerID) REFERENCES Customer(ID)
		ON UPDATE CASCADE,
    FOREIGN KEY (categoryID) REFERENCES BillCategory(ID)
		ON UPDATE CASCADE,
    FOREIGN KEY (empID) REFERENCES Employee(ID)
		ON UPDATE CASCADE
);

-- Tạo bảng ProductCategory
CREATE TABLE ProductCategory (
    ID VARCHAR(4) PRIMARY KEY, -- PC01, PC02, ...
    name VARCHAR(max) NOT NULL
);

-- Tạo bảng Product
CREATE TABLE Product (
    ID VARCHAR(3) PRIMARY KEY, -- P01, P02, ...
    name NVARCHAR(max) NOT NULL,
    categoryID VARCHAR(4) NOT NULL,
    price DECIMAL(10, 2) NOT NULL,
    status INT NOT NULL,
    FOREIGN KEY (categoryID) REFERENCES ProductCategory(ID)
		ON UPDATE CASCADE
);

-- Tạo bảng BillInfo
CREATE TABLE BillInfo (
    billID VARCHAR(7),
    productID VARCHAR(3),
    quantity INT NOT NULL,
    FOREIGN KEY (billID) REFERENCES Bill(ID)
		ON UPDATE CASCADE,
    FOREIGN KEY (productID) REFERENCES Product(ID)
		ON UPDATE CASCADE,
    PRIMARY KEY (billID, productID)
);

-- Tạo bảng Material
CREATE TABLE Material (
    ID VARCHAR(3) PRIMARY KEY, -- M01, M02, ...
    name NVARCHAR(max) NOT NULL,
    status DECIMAL(10,2) NOT NULL
);

-- Tạo bảng Product_Material
CREATE TABLE Product_Material (
    productID VARCHAR(3) NOT NULL,
    materialID VARCHAR(3) NOT NULL,
    quantity INT NOT NULL,
    FOREIGN KEY (productID) REFERENCES Product(ID)
		ON UPDATE CASCADE,
    FOREIGN KEY (materialID) REFERENCES Material(ID)
		ON UPDATE CASCADE,
    PRIMARY KEY (productID, materialID)
);

-- Tạo bảng ReceiptNote
CREATE TABLE ReceiptNote (
    ID VARCHAR(7) PRIMARY KEY,
    date DATE NOT NULL,
    price DECIMAL(10, 2),
    supplierID VARCHAR(4) NOT NULL,
    empID VARCHAR(4) NOT NULL,
    FOREIGN KEY (supplierID) REFERENCES Supplier(ID)
		ON UPDATE CASCADE,
    FOREIGN KEY (empID) REFERENCES Employee(ID)
		ON UPDATE CASCADE,
);

-- Tạo bảng ReceiptNoteDetail
CREATE TABLE ReceiptNoteDetail (
    rNoteID VARCHAR(7),
    materialID VARCHAR(3),
    quantity INT NOT NULL,
    unitPrice DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (rNoteID) REFERENCES ReceiptNote(ID)
		ON UPDATE CASCADE,
    FOREIGN KEY (materialID) REFERENCES Material(ID)
		ON UPDATE CASCADE,
    PRIMARY KEY (rNoteID, materialID)
);

CREATE TABLE Delivery (
	materialID VARCHAR(3),
	supplierID VARCHAR(4),
	FOREIGN KEY (materialID) REFERENCES Material(ID)
		ON UPDATE CASCADE,
    FOREIGN KEY (supplierID) REFERENCES Supplier(ID)
		ON UPDATE CASCADE,
	PRIMARY KEY (materialID, supplierID)
);

-- Tạo bảng ExpenseBill
CREATE TABLE ExpenseBill (
    ID VARCHAR(7) PRIMARY KEY, -- EX00001, EX00002
    detail NVARCHAR(max) NOT NULL,
    price DECIMAL(18, 2) NOT NULL,
    date DATE NOT NULL
);

CREATE TABLE Account (
	userName VARCHAR(10) PRIMARY KEY,
	pass VARCHAR(max) NOT NULL, 
	userRole INT NOT NULL CHECK (userRole >= 0 AND userRole <= 1)
)
GO

USE WibuCoffee
GO

INSERT INTO Job (ID, jobDetail, salary)
VALUES
	('NA', N'Nghỉ việc', 0.01),
    ('J01', 'Waiter', 23000.00),
    ('J02', 'Batender', 24000.00),
    ('J03', 'Order', 25000.00);
GO

INSERT INTO Employee (ID, name, birthDate, address, phone, recruitmentDate, jobID, penaltyPoint, bonusPoint, numberOfShift)
VALUES
	('NA' , 'NA', '0001-01-01', '', '0000000000', '0001-01-01', 'NA', 0, 0, 0),
    ('EF01', N'Nguyễn Trung Hiếu', '2004-4-5', N'Sài Gòn', '0987654321', '2022-03-13', 'J03', 0, 3, 2),
	('EP02', N'Phan Phúc Hảo', '2004-3-2', N'Bắc Ninh', '0982874321', '2022-03-13', 'J02', 2, 3, 3),
	('EF03', N'Lê Văn Phát', '2004-6-7', N'Thanh Hóa', '0367654321', '2022-02-2', 'J01', 1, 2, 3),
	('EP04', N'Huỳnh Thanh Duy', '2004-10-10', N'Hải Phòng', '0987698721', '2021-12-12', 'J03', 0, 0, 2),
	('EP05', N'Lưu Tuấn Thành', '2004-3-7', N'Đắk Lắk', '0987608221', '2022-04-4', 'J03', 3, 1, 3),
	('EP06', N'Lê Hoàng Bảo Phúc', '2004-1-5', N'Bắc Giang', '0980214321', '2022-05-13', 'J03', 0, 2, 2),
	('EF07', N'Lê Duy Phương', '2004-04-06', N'Bình Định', '0772192320', '2023-06-02', 'J02', 0, 3, 2),
	('EF08', N'Trần Thị Linh', '2000-10-25', N'Hà Nội', '0967123456', '2023-05-20', 'J01', 0, 1, 2),
    ('EF09', N'Lê Thị Hương', '2001-08-15', N'Hải Phòng', '0978123456', '2023-06-10', 'J01', 0, 3, 1),
    ('EP07', N'Nguyễn Văn Long', '2002-07-20', N'Đà Nẵng', '0988234567', '2023-04-15', 'J02', 0, 4, 2),
    ('EP08', N'Phạm Thị Lan', '2003-05-18', N'Hồ Chí Minh', '0987234567', '2023-07-05', 'J02', 0, 5, 1),
    ('EP10', N'Vũ Văn Dũng', '2001-12-12', N'Cần Thơ', '0968123456', '2023-05-30', 'J03', 0, 4, 3),
    ('EF11', N'Nguyễn Thị Huệ', '2000-03-28', N'Hà Tĩnh', '0989123456', '2023-07-20', 'J03', 0, 2, 1);
GO


-- On duty, Shift --
INSERT INTO Shift (ID, startTime, endTime)
VALUES
	('ShF01', '06:30:00', '14:30:00'),
	('ShF02', '14:30:00', '22:30:00'),
	('ShF03', '08:00:00', '17:00:00'),
	('ShF04', '17:00:00', '23:59:00'),
	('ShF05', '00:00:00', '07:00:00'),
	('ShP01', '08:00:00', '12:00:00'),
	('ShP02', '13:00:00', '17:00:00'),
	('ShP03', '17:00:00', '22:00:00'),
	('ShP04', '10:00:00', '14:00:00'),
	('ShP05', '22:00:00', '23:59:00'),
	('ShP06', '00:00:00', '07:00:00');
GO

INSERT INTO On_Duty (empID, shiftID, date)
VALUES
	('EF01', 'ShF01', '2024-03-26'),
	('EF01', 'ShF01', '2024-03-27'),
	('EF01', 'ShF01', '2024-03-28'),
	('EF07', 'ShF02', '2024-03-26'),
	('EF07', 'ShF02', '2024-03-27'),
	('EF07', 'ShF02', '2024-03-28'),
	('EF03', 'ShF03', '2024-03-26'),
	('EF03', 'ShF03', '2024-03-27'),
	('EF03', 'ShF03', '2024-03-28'),
	('EP02', 'ShP03', '2024-03-26'),
	('EP02', 'ShP03', '2024-03-27'),
	('EP02', 'ShP03', '2024-03-28'),
	('EP04', 'ShP02', '2024-03-26'),
	('EP04', 'ShP03', '2024-03-27'),
	('EP04', 'ShP04', '2024-03-28'),
	('EP05', 'ShP02', '2024-03-26'),
	('EP05', 'ShP02', '2024-03-27'),
	('EP05', 'ShP03', '2024-03-28'),
	('EP06', 'ShP04', '2024-03-26'),
	('EP06', 'ShP04', '2024-03-27'),
	('EP06', 'ShP01', '2024-03-28');
GO	





-- Dữ liệu cho bảng [Table]
INSERT INTO [Table] (ID, name, status)
VALUES
	('NA', 'NA', 'NA'),
	('T01', 'Table 1', 'Available'),
	('T02', 'Table 2', 'Available'),
	('T03', 'Table 3', 'Occupied'),
	('T04', 'Table 4', 'Occupied'),
	('T05', 'Table 5', 'Available'),
	('T06', 'Table 6', 'Available'),
	('T07', 'Table 7', 'Occupied'),
	('T08', 'Table 8', 'Occupied'),
	('T09', 'Table 9', 'Available'),
	('T10', 'Table 10', 'Available'),
	('T11', 'Table 11', 'Available'),
	('T12', 'Table 12', 'Available'),
	('T13', 'Table 13', 'Occupied'),
	('T14', 'Table 14', 'Occupied'),
	('T15', 'Table 15', 'Available'),
	('T16', 'Table 16', 'Available'),
	('T17', 'Table 17', 'Occupied'),
	('T18', 'Table 18', 'Occupied'),
	('T19', 'Table 19', 'Available'),
	('T20', 'Table 20', 'Available');

GO


INSERT INTO Customer (ID, name, phone, bonusPoint)
VALUES
	('C0001', 'Nguyễn Thanh Sang', '0381294752', 20),
	('C0002', 'Phạm Duy Vũ', '0381164752', 15),
	('C0003', 'Lê Thành Đạt','0382154752', 10),
	('C0004', 'Trần Trung Tiến', '0363154752', 5),
	('C0005', 'Nguyễn Yến Thanh', '0143154752', 0),
	('C0006', 'Phạm Thành Quách', '0143191752', 25),
	('C0007', 'Nguyễn Tiến Thành', '0173193751', 30),
	('C0008', 'Henry Martinez', '0173151751', 8),
	('C0009', 'Ivy Clark', '0171293751', 12),
	('C0010', 'Jack Harris', '0173154751', 18),
	('C0011', N'Nguyễn Thị Hằng', '0123456781', 20),
	('C0012', N'Trần Văn Đức', '0234567892', 15),
	('C0013', N'Lê Thị Thủy', '0345678903', 10),
	('C0014', N'Phạm Văn Dũng', '0456789014', 22),
	('C0015', N'Hồ Thị Lan', '0567890125', 23),
	('C0016', N'Mai Văn Tâm', '0678901236', 24),
	('C0017', N'Đặng Thị Huệ', '0789012347', 21),
	('C0018', N'Hoàng Văn Thanh', '0890123458', 17),
	('C0019', N'Vũ Thị Ngọc', '0901234569', 19),
	('C0020', N'Lương Văn Tuấn', '0912345670', 18),
	('C0021', N'Võ Thị Thu', '0923456781', 14),
	('C0022', N'Bùi Văn Minh', '0934567892', 16),
	('C0023', N'Trịnh Thị Phương', '0945678903', 13),
	('C0024', N'Đào Văn Quân', '0956789014', 12),
	('C0025', N'Ngô Thị Hồng', '0967890125', 11),
	('C0026', N'Dương Văn Tâm', '0978901236', 8),
	('C0027', N'Lê Thị Thảo', '0989012347', 9),
	('C0028', N'Chu Văn Hùng', '0990123458', 7),
	('C0029', N'Âu Thị Mai', '0101234569', 6),
	('C0030', N'La Văn Nam', '0112345670', 5),
	('C0031', N'Nguyễn Văn Tú', '0123456789', 24),
	('C0032', N'Trần Thị Hương', '0234567898', 22),
	('C0033', N'Lê Văn Long', '0345678987', 23),
	('C0034', N'Phạm Thị Lan', '0456789876', 21),
	('C0035', N'Hồ Văn Nam', '0567898765', 20),
	('C0036', N'Mai Thị Phương', '0678987654', 19),
	('C0037', N'Đặng Văn Bình', '0789876543', 18),
	('C0038', N'Hoàng Thị Mai', '0898765432', 17),
	('C0039', N'Vũ Văn Hoàng', '0909876541', 16),
	('C0040', N'Lương Thị Hà', '0912345678', 15),
	('C0041', N'Võ Văn Tuấn', '0923456789', 14),
	('C0042', N'Bùi Thị Ngọc', '0934567890', 13),
	('C0043', N'Trịnh Văn Huy', '0945678901', 12),
	('C0044', N'Đào Thị Ngân', '0956789012', 11),
	('C0045', N'Ngô Văn Minh', '0967890123', 10),
	('C0046', N'Dương Thị Ngọc', '0978901234', 9),
	('C0047', N'Đinh Văn Phương', '0989012345', 8),
	('C0048', N'Mạc Thị Hạnh', '0990123456', 7),
	('C0049', N'Vương Văn Trung', '0911234567', 6),
	('C0050', N'Lê Thị Hà', '0922345678', 5);
GO


INSERT INTO BillCategory (ID, name, discount)
VALUES
	('BC01', 'In place', 0),
	('BC02', 'Take Away', 0),
	('BC03', 'Shopee food', 0.05),
	('BC04', 'Bee Food', 0.06),
	('BC05', 'Grab Food', 0.04);
GO

INSERT INTO Bill (ID, dateTime, tableID, customerID, categoryID, empID, receiptMoney)
VALUES
	('B000001', '2024-01-05 08:30:00', 'T01', 'C0001', 'BC01', 'EF01', 125000.00),
	('B000002', '2024-01-10 12:45:00', 'T02', 'C0002', 'BC02', 'EF11', 98000.00),
	('B000003', '2024-01-15 19:20:00', 'T03', 'C0003', 'BC03', 'EF01', 175000.00),
	('B000004', '2024-02-02 10:00:00', 'T04', 'C0004', 'BC04', 'EF01', 145000.00),
	('B000005', '2024-02-08 15:20:00', 'T05', 'C0005', 'BC05', 'EF11', 99000.00),
	('B000006', '2024-03-05 11:30:00', 'T06', 'C0006', 'BC01', 'EF01', 200000.00),
	('B000007', '2024-03-12 18:15:00', 'T07', 'C0007', 'BC02', 'EF11', 85000.00),
	('B000008', '2024-04-06 14:50:00', 'T08', 'C0008', 'BC03', 'EF01', 165000.00),
	('B000009', '2024-04-14 19:45:00', 'T09', 'C0009', 'BC04', 'EF11', 78000.00),
	('B000010', '2024-05-03 09:00:00', 'T10', 'C0010', 'BC05', 'EF01', 220000.00),
	('B000011', '2024-05-11 13:25:00', 'T11', 'C0011', 'BC01', 'EF11', 105000.00),
	('B000012', '2024-06-08 16:30:00', 'T12', 'C0012', 'BC02', 'EF01', 185000.00),
	('B000013', '2024-06-16 20:10:00', 'T13', 'C0013', 'BC03', 'EF11', 92000.00),
	('B000014', '2024-07-02 11:20:00', 'T14', 'C0014', 'BC04', 'EF01', 240000.00),
	('B000015', '2024-07-19 17:35:00', 'T15', 'C0015', 'BC05', 'EF11', 84000.00),
	('B000016', '2024-08-09 10:40:00', 'T16', 'C0016', 'BC01', 'EF01', 205000.00),
	('B000017', '2024-08-21 14:55:00', 'T17', 'C0017', 'BC02', 'EF11', 115000.00),
	('B000018', '2024-09-05 12:15:00', 'T18', 'C0018', 'BC03', 'EF01', 270000.00),
	('B000019', '2024-09-17 18:40:00', 'T19', 'C0019', 'BC04', 'EF11', 92000.00),
	('B000020', '2024-10-06 15:00:00', 'T20', 'C0020', 'BC05', 'EF01', 280000.00),
	('B000021', '2024-10-22 19:20:00', 'T01', 'C0021', 'BC01', 'EF11', 99000.00),
	('B000022', '2024-11-03 08:45:00', 'T02', 'C0022', 'BC02', 'EF01', 225000.00),
	('B000023', '2024-11-16 14:30:00', 'T03', 'C0023', 'BC03', 'EF11', 84000.00),
	('B000024', '2024-12-05 11:10:00', 'T04', 'C0024', 'BC04', 'EF01', 315000.00),
	('B000025', '2024-12-19 17:55:00', 'T05', 'C0025', 'BC05', 'EF11', 78000.00),
	('B000026', '2024-03-15 17:30:00', 'T06', 'C0006', 'BC02', 'EP04', 45000.00),
	('B000027', '2024-03-16 08:40:00', 'T07', 'C0007', 'BC01', 'EF01', 60000.00),
	('B000028', '2024-03-16 12:15:00', 'T08', 'C0008','BC03', 'EP05', 35000.00),
	('B000029', '2024-03-16 16:50:00', 'T09', 'C0009', 'BC03', 'EF01', 48000.00),
	('B000030', '2024-03-17 10:25:00', 'T10', 'C0010', 'BC03','EP06', 220000.00),
	('B000031', '2024-04-11 08:30:00', 'T01', 'C0001', 'BC01', 'EF01', 250000.00),
    ('B000032', '2024-04-10 12:45:00', 'T02', 'C0002', 'BC02', 'EP04', 90000.00),
    ('B000033', '2024-04-09 18:20:00', 'T03', 'C0003', 'BC02', 'EP05', 120000.00),
    ('B000034', '2024-04-08 09:10:00', 'T04', 'C0004', 'BC03', 'EF01', 150000.00),
    ('B000035', '2024-04-07 13:55:00', 'T05', 'C0005', 'BC01', 'EP06', 65000.00),
    ('B000036', '2024-04-06 17:30:00', 'T06', 'C0006', 'BC02', 'EP04', 45000.00),
    ('B000037', '2024-04-05 08:40:00', 'T07', 'C0007', 'BC01', 'EF01', 60000.00),
    ('B000038', '2024-04-04 12:15:00', 'T08', 'C0008','BC03', 'EP05', 150000.00),
    ('B000039', '2024-04-05 16:50:00', 'T09', 'C0009', 'BC03', 'EF01', 78000.00),
    ('B000040', '2024-04-06 10:25:00', 'T10', 'C0010', 'BC03','EP06', 202000.00),
	('B000041', '2024-03-14 08:30:00', 'T01', 'C0001', 'BC01', 'EF01', 75000.00),
	('B000042', '2024-03-14 12:45:00', 'T02', 'C0002', 'BC02', 'EP04', 60000.00),
	('B000043', '2024-03-14 18:20:00', 'T03', 'C0003', 'BC02', 'EP05', 80000.00),
	('B000044', '2024-03-15 09:10:00', 'T04', 'C0004', 'BC03', 'EF01', 120000.00),
	('B000045', '2024-03-15 13:55:00', 'T05', 'C0005', 'BC01', 'EP06', 155000.00),
	('B000046', '2024-03-14 08:30:00', 'T01', 'C0001', 'BC01', 'EF01', 125000.00),
	('B000047', '2024-03-14 12:45:00', 'T02', 'C0002', 'BC02', 'EP04', 230000.00),
	('B000048', '2024-03-14 18:20:00', 'T03', 'C0003', 'BC02', 'EP05', 140000.00),
	('B000049', '2024-03-15 09:10:00', 'T04', 'C0004', 'BC03', 'EF01', 150000.00),
	('B000050', '2024-03-15 13:55:00', 'T05', 'C0005', 'BC01', 'EP06', 255000.00),
	('B000051', '2024-01-25 08:30:00', 'T06', 'C0026', 'BC01', 'EF01', 175000.00),
	('B000052', '2024-02-05 12:45:00', 'T07', 'C0027', 'BC02', 'EF11', 98000.00),
	('B000053', '2024-03-15 19:20:00', 'T08', 'C0028', 'BC03', 'EF01', 145000.00),
	('B000054', '2024-04-20 10:00:00', 'T09', 'C0029', 'BC04', 'EF01', 165000.00),
	('B000055', '2024-05-28 15:20:00', 'T10', 'C0030', 'BC05', 'EF11', 99000.00),
	('B000056', '2024-06-08 08:30:00', 'T11', 'C0031', 'BC01', 'EF01', 200000.00),
	('B000057', '2024-07-10 12:45:00', 'T12', 'C0032', 'BC02', 'EF11', 105000.00),
	('B000058', '2024-08-15 19:20:00', 'T13', 'C0033', 'BC03', 'EF01', 185000.00),
	('B000059', '2024-09-20 10:00:00', 'T14', 'C0034', 'BC04', 'EF01', 205000.00),
	('B000060', '2024-10-28 15:20:00', 'T15', 'C0035', 'BC05', 'EF11', 115000.00),
	('B000061', '2024-11-08 08:30:00', 'T16', 'C0036', 'BC01', 'EF01', 220000.00),
	('B000062', '2024-12-10 12:45:00', 'T17', 'C0037', 'BC02', 'EF11', 125000.00),
	('B000063', '2025-01-15 19:20:00', 'T18', 'C0038', 'BC03', 'EF01', 240000.00),
	('B000064', '2025-02-20 10:00:00', 'T19', 'C0039', 'BC04', 'EF01', 260000.00),
	('B000065', '2025-03-28 15:20:00', 'T20', 'C0040', 'BC05', 'EF11', 135000.00),
	('B000066', '2025-04-08 08:30:00', 'T01', 'C0041', 'BC01', 'EF01', 250000.00),
	('B000067', '2025-05-10 12:45:00', 'T02', 'C0042', 'BC02', 'EF11', 145000.00),
	('B000068', '2025-06-15 19:20:00', 'T03', 'C0043', 'BC03', 'EF01', 280000.00),
	('B000069', '2025-07-20 10:00:00', 'T04', 'C0044', 'BC04', 'EF01', 300000.00),
	('B000070', '2025-08-28 15:20:00', 'T05', 'C0045', 'BC05', 'EF11', 155000.00),
	('B000071', '2025-09-08 08:30:00', 'T06', 'C0046', 'BC01', 'EF01', 290000.00),
	('B000072', '2025-10-10 12:45:00', 'T07', 'C0047', 'BC02', 'EF11', 165000.00),
	('B000073', '2025-11-15 19:20:00', 'T08', 'C0048', 'BC03', 'EF01', 320000.00),
	('B000074', '2025-12-20 10:00:00', 'T09', 'C0049', 'BC04', 'EF01', 340000.00),
	('B000075', '2026-01-28 15:20:00', 'T10', 'C0050', 'BC05', 'EF11', 175000.00),
	('B000076', '2026-02-08 08:30:00', 'T11', 'C0026', 'BC01', 'EF01', 175000.00),
	('B000077', '2026-03-10 12:45:00', 'T12', 'C0027', 'BC02', 'EF11', 98000.00),
	('B000078', '2026-04-15 19:20:00', 'T13', 'C0028', 'BC03', 'EF01', 145000.00),
	('B000079', '2026-05-20 10:00:00', 'T14', 'C0029', 'BC04', 'EF01', 165000.00),
	('B000080', '2026-06-28 15:20:00', 'T15', 'C0030', 'BC05', 'EF11', 99000.00),
	('B000081', '2026-07-08 08:30:00', 'T16', 'C0031', 'BC01', 'EF01', 200000.00),
	('B000082', '2026-08-10 12:45:00', 'T17', 'C0032', 'BC02', 'EF11', 105000.00),
	('B000083', '2026-09-15 19:20:00', 'T18', 'C0033', 'BC03', 'EF01', 185000.00),
	('B000084', '2026-10-20 10:00:00', 'T19', 'C0034', 'BC04', 'EF01', 205000.00),
	('B000085', '2026-11-28 15:20:00', 'T20', 'C0035', 'BC05', 'EF11', 115000.00),
	('B000086', '2026-12-08 08:30:00', 'T01', 'C0036', 'BC01', 'EF01', 220000.00),
	('B000087', '2027-01-10 12:45:00', 'T02', 'C0037', 'BC02', 'EF11', 125000.00),
	('B000088', '2027-02-15 19:20:00', 'T03', 'C0038', 'BC03', 'EF01', 240000.00),
	('B000089', '2027-03-20 10:00:00', 'T04', 'C0039', 'BC04', 'EF01', 260000.00),
	('B000090', '2027-04-28 15:20:00', 'T05', 'C0040', 'BC05', 'EF11', 135000.00),
	('B000091', '2027-05-08 08:30:00', 'T06', 'C0041', 'BC01', 'EF01', 250000.00),
	('B000092', '2027-06-10 12:45:00', 'T07', 'C0042', 'BC02', 'EF11', 145000.00),
	('B000093', '2027-07-15 19:20:00', 'T08', 'C0043', 'BC03', 'EF01', 280000.00),
	('B000094', '2027-08-20 10:00:00', 'T09', 'C0044', 'BC04', 'EF01', 300000.00),
	('B000095', '2027-09-28 15:20:00', 'T10', 'C0045', 'BC05', 'EF11', 155000.00),
	('B000096', '2027-10-08 08:30:00', 'T11', 'C0046', 'BC01', 'EF01', 290000.00),
	('B000097', '2027-11-10 12:45:00', 'T12', 'C0047', 'BC02', 'EF11', 165000.00),
	('B000098', '2027-12-15 19:20:00', 'T13', 'C0048', 'BC03', 'EF01', 320000.00),
	('B000099', '2028-01-20 10:00:00', 'T14', 'C0049', 'BC04', 'EF01', 340000.00),
	('B000100', '2028-02-28 15:20:00', 'T15', 'C0050', 'BC05', 'EF11', 175000.00);
GO


INSERT INTO ProductCategory (ID, name)
VALUES
	('PC01', 'Coffee'),
	('PC02', 'Tea'),
	('PC03', 'Juice'),
	('PC04', 'Cake'),
	('PC05', 'Sandwich'),
	('PC06', 'Salad'),
	('PC07', 'Soft Drink'),
	('PC08', 'Towel'),
	('PC09', 'Cream'),
	('PC10', 'Wibu');
GO



INSERT INTO Product (ID, name, categoryID, price, status)
VALUES
	('P01', 'Espresso', 'PC01', 30000.00, 10),
	('P02', 'Cappuccino', 'PC01', 40000.00, 20),
	('P03', 'Green Tea', 'PC02', 25000.00, 10),
	('P04', 'Cola', 'PC07', 20000.00, 20),
	('P05', 'Chocolate Cake', 'PC04', 55000.00, 15),
	('P06', 'Club Sandwich', 'PC05', 70000.00, 15),
	('P07', 'Caesar Salad', 'PC06', 60000.00, 20),
	('P08', 'Orange Juice', 'PC03', 50000.00, 20),
	('P09', 'Lemon Juice', 'PC03', 39000.00, 20),
	('P10', 'Sting', 'PC07', 45000.00, 20),
	('P11', 'Gacha Sticker' , 'PC10', 2000.00, 100),
	('P12', 'Smol Cream ', 'PC09', 3000.00, 20),
	('P13', 'Vani Smol Cream ', 'PC09', 4000.00, 20),
	('P14', 'Beag Cream ', 'PC09', 5000.00, 20),
	('P15', 'Vani Beag Cream ', 'PC09', 7000.00, 20);
GO



INSERT INTO BillInfo (billID, productID, quantity)
VALUES
	('B000001', 'P01', 4),
	('B000001', 'P11', 1),
	('B000002', 'P08', 1),
	('B000002', 'P02', 1),
	('B000002', 'P11', 4),
	('B000003', 'P07', 2),
	('B000003', 'P05', 1),
	('B000004', 'P10', 3),
	('B000004', 'P11', 5),
	('B000005', 'P10', 2),
	('B000005', 'P12', 3),
	('B000006', 'P02', 5),
	('B000007', 'P05', 1),
	('B000007', 'P01', 1),
	('B000008', 'P03', 3),
	('B000008', 'P01', 3),
	('B000009', 'P09', 2),
	('B000010', 'P08', 4),
	('B000010', 'P13', 5), -- Hết 10 bills--
	('B000011', 'P05', 1),
	('B000011', 'P08', 1),
	('B000012', 'P06', 2),
	('B000012', 'P10', 1),
	('B000013', 'P01', 3),
	('B000013', 'P11', 1),
	('B000014', 'P02', 6),
	('B000015', 'P02', 2),
	('B000015', 'P11', 2),
	('B000016', 'P08', 3),
	('B000016', 'P05', 1),
	('B000017', 'P07', 1),
	('B000017', 'P05', 1),
	('B000018', 'P06', 3),
	('B000018', 'P07', 1),
	('B000019', 'P01', 3),
	('B000019', 'P11', 1),
	('B000020', 'P06', 4),  -- Hết 10 bills
	('B000021', 'P01', 3),
	('B000021', 'P13', 1),
	('B000022', 'P03', 1),
	('B000022', 'P08', 4),
	('B000023', 'P02', 2),
	('B000023', 'P11', 2),
	('B000024', 'P05', 1),
	('B000024', 'P08', 4),
	('B000024', 'P07', 1),
	('B000025', 'P09', 2), 
	('B000026', 'P10', 1),
	('B000027', 'P01', 2),
	('B000027', 'P03', 1),
	('B000028', 'P11', 5),
	('B000029', 'P02', 1),
	('B000029', 'P11', 4),
	('B000030', 'P05', 4), -- Hết 10 bill
	('B000031', 'P08', 3),
	('B000032', 'P01', 3),
	('B000033', 'P02', 3),
	('B000033', 'P11', 2),
	('B000034', 'P01', 5),
	('B000035', 'P09', 2), 
	('B000035', 'P11', 10), 
	('B000036', 'P10', 1),
	('B000037', 'P01', 2),
	('B000038', 'P01', 5),
	('B000039', 'P02', 1),
	('B000039', 'P09', 2),
	('B000040', 'P08', 4),
	('B000040', 'P11', 1), -- Hết 10 bill
	('B000041', 'P05', 1), 
	('B000041', 'P11', 10),
	('B000042', 'P01', 2),
	('B000043', 'P02', 2),
	('B000044', 'P01', 4),
	('B000045', 'P05', 1),
	('B000045', 'P08', 2), 
	('B000046', 'P03', 1),
	('B000046', 'P08', 2),
	('B000047', 'P01', 1),
	('B000047', 'P02', 5),
	('B000048', 'P06', 2),
	('B000049', 'P08', 3),
	('B000050', 'P05', 1), 
	('B000050', 'P08', 4),  -- Hết 10 bill --
	('B000051', 'P05', 1), 
	('B000051', 'P02', 3),
	('B000052', 'P09', 2),
	('B000052', 'P11', 10),
	('B000053', 'P05', 1),
	('B000053', 'P01', 3),
	('B000054', 'P03', 1),
	('B000054', 'P06', 2),
	('B000055', 'P01', 3),
	('B000055', 'P13', 1), 
	('B000056', 'P08', 4),
	('B000057', 'P05', 1),
	('B000057', 'P08', 1),
	('B000058', 'P10', 1),
	('B000058', 'P06', 2),
	('B000059', 'P05', 1),
	('B000059', 'P08', 3),
	('B000060', 'P05', 1), 
	('B000060', 'P08', 1), -- Hết 10 bill --
	('B000061', 'P05', 4), 
	('B000062', 'P03', 1),
	('B000062', 'P08', 2),
	('B000063', 'P02', 6),
	('B000064', 'P06', 3),
	('B000064', 'P08', 1),
	('B000065', 'P03', 1),
	('B000065', 'P05', 2), 
	('B000066', 'P08', 5),
	('B000067', 'P03', 1),
	('B000067', 'P07', 2),
	('B000068', 'P06', 4),
	('B000069', 'P07', 5),
	('B000070', 'P05', 1), 
	('B000070', 'P08', 2), -- Hết 10 bill --
	('B000071', 'P06', 4), 
	('B000071', 'P11', 5),
	('B000072', 'P03', 1),
	('B000072', 'P06', 2),
	('B000073', 'P02', 8),
	('B000074', 'P02', 8),
	('B000074', 'P11', 10),
	('B000075', 'P05', 1),
	('B000075', 'P01', 4), 
	('B000076', 'P05', 1),
	('B000077', 'P02', 2),
	('B000077', 'P11', 9),
	('B000078', 'P03', 1),
	('B000078', 'P07', 2),
	('B000079', 'P03', 1),
	('B000079', 'P06', 2),
	('B000080', 'P05', 1), 
	('B000080', 'P01', 1), 
	('B000080', 'P13', 1),  -- Hết 10 bill --
	('B000081', 'P08', 4), 
	('B000082', 'P03', 1),
	('B000082', 'P02', 2),
	('B000083', 'P02', 4),
	('B000083', 'P03', 1),
	('B000084', 'P05', 1),
	('B000084', 'P08', 3),
	('B000085', 'P05', 1),
	('B000085', 'P08', 1), 
	('B000086', 'P05', 4),
	('B000087', 'P03', 1),
	('B000087', 'P08', 2),
	('B000088', 'P07', 4),
	('B000089', 'P08', 5),
	('B000089', 'P11', 5),
	('B000089', 'P03', 1),
	('B000090', 'P03', 1), 
	('B000090', 'P05', 2),  -- Hết 10 bill --
	('B000091', 'P08', 5), 
	('B000092', 'P03', 1),
	('B000092', 'P07', 2),
	('B000093', 'P06', 4),
	('B000094', 'P07', 5),
	('B000095', 'P05', 1),
	('B000095', 'P08', 2),
	('B000096', 'P06', 4),
	('B000097', 'P05', 3),
	('B000098', 'P07', 5),
	('B000098', 'P11', 10),
	('B000099', 'P07', 5),
	('B000099', 'P02', 1),
	('B000100', 'P05', 1), 
	('B000100', 'P07', 2); -- Hết 10 bill --

			

GO

INSERT INTO Material (ID, name, status)
VALUES
	('M01', 'Coffee Beans', 20),
	('M02', 'Tea Leaves', 10),
	('M03', 'Sugar', 20),
	('M04', 'Flour', 20),
	('M05', 'Butter', 15),
	('M06', 'Chocolate', 10),
	('M07', 'Lettuce', 15),
	('M08', 'Tomato', 12),
	('M09', 'Orange', 15),
	('M10', 'Lemon', 20);
GO



INSERT INTO Product_Material (productID, materialID, quantity)
VALUES
	('P01', 'M01', 2),
	('P02', 'M01', 1),
	('P03', 'M02', 1),
	('P04', 'M10', 2),
	('P05', 'M04', 1),
	('P06', 'M05', 3),
	('P07', 'M07', 1),
	('P08', 'M09', 2),
	('P09', 'M10', 1),
	('P10', 'M10', 4);
GO

INSERT INTO Supplier (ID, name, address, phone)
VALUES
    ('SP01', 'Buon Me Coffee ', N'Buôn Mê Thuột', '0140314321'),
    ('SP02', N'Tạp Hóa Vui Vẻ', N'Sài Gòn', '0987612721'),
    ('SP03', 'Coopmart', 'Đồng Nai', '0994612721');
GO

INSERT INTO ReceiptNote (ID, date, price, supplierID, empID)
VALUES
	('RN00001', '2024-01-10', 500000.00, 'SP01', 'EF01'),
	('RN00002', '2024-02-11', 350000.00, 'SP02', 'EF01'),
	('RN00003', '2024-03-12', 200000.00, 'SP03', 'EF11'),
	('RN00004', '2024-04-13', 450000.00, 'SP02', 'EF11'),
	('RN00005', '2024-05-14', 300000.00, 'SP03', 'EF01'),
	('RN00006', '2024-06-15', 400000.00, 'SP01', 'EF11'),
	('RN00007', '2024-07-16', 550000.00, 'SP03', 'EF11'),
	('RN00008', '2024-08-17', 600000.00, 'SP02', 'EF01'),
	('RN00009', '2024-09-18', 250000.00, 'SP02', 'EF01'),
	('RN00010', '2024-10-19', 700000.00, 'SP01', 'EF11'),
	('RN00011', '2024-06-15', 400000.00, 'SP01', 'EF01'),
	('RN00012', '2024-07-16', 550000.00, 'SP03', 'EF01');

GO



INSERT INTO ReceiptNoteDetail (rNoteID, materialID, quantity, unitPrice)
VALUES
	('RN00001', 'M01', 50, 10000.00),
	('RN00002', 'M02', 7, 50000.00),
	('RN00003', 'M03', 10, 20000.00),
	('RN00004', 'M04', 15, 30000.00),
	('RN00005', 'M05', 10, 30000.00),
	('RN00006', 'M06', 5, 80000.00),
	('RN00007', 'M07', 11, 50000.00),
	('RN00008', 'M08', 10, 60000.00),
	('RN00009', 'M09', 10, 25000.00),
	('RN00010', 'M10', 20, 35000.00),
	('RN00011', 'M09', 20, 20000.00),
	('RN00012', 'M10', 11, 50000.00);

GO

INSERT INTO Delivery (supplierID, materialID)
VALUES
	('SP01', 'M01'),
	('SP01', 'M02'),
	('SP01', 'M03'),
	('SP02', 'M04'),
	('SP02', 'M05'),
	('SP02', 'M06'),
	('SP03', 'M07'),
	('SP03', 'M08'),
	('SP03', 'M09'),
	('SP03', 'M10');
GO


INSERT INTO ExpenseBill (ID, detail, price, date)
VALUES
	('EX00001', 'Cleaning Supplies for the month', 100000.00, '2024-01-10'),
	('EX00002', 'Cleaning Supplies for the month', 100000.00, '2024-02-10'),
	('EX00003', 'Cleaning Supplies for the month', 100000.00, '2024-03-10'),
	('EX00004', 'Cleaning Supplies for the month', 100000.00, '2024-04-10'),
	('EX00005', 'Cleaning Supplies for the month', 100000.00, '2024-05-11'),
    ('EX00006', 'Cleaning Supplies for the month', 100000.00, '2024-06-10'),
    ('EX00007', 'Cleaning Supplies for the month', 100000.00, '2024-07-10'),
    ('EX00008', 'Cleaning Supplies for the month', 100000.00, '2024-08-10'),
    ('EX00009', 'Cleaning Supplies for the month', 100000.00, '2024-09-07'),
    ('EX00010', 'Cleaning Supplies for the month', 100000.00, '2024-10-07'),
    ('EX00011', 'Cleaning Supplies for the month', 100000.00, '2024-11-07'),
    ('EX00012', 'Cleaning Supplies for the month', 100000.00, '2024-12-07'),
    ('EX00013', 'Checking and repair machine', 150000.00, '2024-01-04'),
    ('EX00014', 'Checking and repair machine', 150000.00, '2024-04-04'),
    ('EX00015', 'Checking and repair machine', 150000.00, '2024-07-04'),
    ('EX00016', 'Checking and repair machine', 150000.00, '2024-10-04');
GO


INSERT INTO Account(userName, pass, userRole)
VALUES
('admin','admin',0), -- Admin --
('emp', 'emp', 1);
GO



----------------------------------------------------------------------------
----------------------------------------------------------------------------
------------------------------ ORDER ---------------------------------------
----------------------------------------------------------------------------
----------------------------------------------------------------------------

USE WibuCoffee
GO

/* CÁC CHỨC NĂNG Ở BILL HISTORY */

/* TẠO VIEW HIỂN THỊ DANH SÁCH HÓA ĐƠN GỒM MÃ HÓA ĐƠN, NGÀY LẬP HÓA ĐƠN, TÊN LOẠI HÓA ĐƠN. SỐ TIỀN NHẬN ĐƯỢC */

DROP VIEW IF EXISTS BillView
GO

CREATE VIEW BillView
AS
SELECT Bill.ID, Bill.dateTime, BillCategory.name, Bill.receiptMoney
FROM Bill, BillCategory
WHERE Bill.categoryID = BillCategory.ID
GO

/*VIẾT HÀM LỌC RA DANH SÁCH HÓA ĐƠN THEO MÃ HÓA ĐƠN */

DROP FUNCTION IF EXISTS filterBillByID
GO

CREATE FUNCTION filterBillByID
(
	@ID VARCHAR(7)
)
RETURNS TABLE
AS
RETURN
(
	SELECT * FROM BillView
	WHERE ID = @ID
)
GO

/*VIẾT HÀM LỌC RA DANH SÁCH HÓA ĐƠN THEO NGÀY LẬP HÓA ĐƠN */

DROP FUNCTION IF EXISTS filterBillByDate
GO

CREATE FUNCTION filterBillByDate
(
	@date DATE
)
RETURNS TABLE
AS
RETURN
(
	SELECT * FROM BillView
	WHERE CAST(dateTime AS DATE) = @date
)
GO

/*VIẾT HÀM LỌC RA DANH SÁCH HÓA ĐƠN THEO TÊN LOẠI HÓA ĐƠN */

DROP FUNCTION IF EXISTS filterBillByCategory
GO

CREATE FUNCTION filterBillByCategory
(
	@category NVARCHAR(max)
)
RETURNS TABLE
AS
RETURN
(
	SELECT * FROM BillView
	WHERE name = @category
)
GO

/* TẠO PROCEDURE LẤY RA DANH SÁCH HÓA ĐƠN */

DROP PROCEDURE IF EXISTS selectAllBillView
GO

CREATE PROCEDURE selectAllBillView
AS
BEGIN
	SELECT * FROM BillView
END
GO

/* TẠO PROCEDURE LẤY RA DANH SÁCH MÃ HÓA ĐƠN */

DROP PROCEDURE IF EXISTS selectAllBillID
GO

CREATE PROCEDURE selectAllBillID
AS
BEGIN
	DECLARE @errorMessage NVARCHAR(max)
	BEGIN TRY
		SELECT ID FROM Bill
	END TRY
	BEGIN CATCH
		SET @errorMessage = ERROR_MESSAGE()
		RAISERROR(@errorMessage, 16, 1)
	END CATCH
END
GO

/* TẠO PROCEDURE LẤY RA DANH SÁCH TÊN LOẠI HÓA ĐƠN */

DROP PROCEDURE IF EXISTS selectAllBillCategory
GO

CREATE PROCEDURE selectAllBillCategory
AS
BEGIN
	DECLARE @errorMessage NVARCHAR(max)
	BEGIN TRY
		SELECT name FROM BillCategory
	END TRY
	BEGIN CATCH
		SET @errorMessage = ERROR_MESSAGE()
		RAISERROR(@errorMessage, 16, 1)
	END CATCH
END
GO

/* VIẾT VIEW HIỂN THỊ CHI TIẾT HÓA ĐƠN GỒM TÊN SẢN PHẢM, SỐ LƯỢNG, THÀNH TIỀN = PRODEUCT.PRICE * SỐ LƯỢNG KHI BIẾT MÃ HÓA ĐƠN */

DROP VIEW IF EXISTS BillDetailView
GO

CREATE VIEW BillDetailView
AS
SELECT  BillInfo.billID,
		Product.name, 
		BillInfo.quantity, 
		Product.price * BillInfo.quantity AS totalPrice
FROM BillInfo, Product
WHERE BillInfo.productID = Product.ID
GO

/* VIẾT FUNCTION LẤY RA TẤT CẢ CHI TIẾT HÓA ĐƠN CỦA MỘT HÓA ĐƠN KHI BIẾT MÃ HÓA ĐƠN */

DROP FUNCTION IF EXISTS getBillDetail
GO

CREATE FUNCTION getBillDetail
(
	@billID VARCHAR(7)
)
RETURNS TABLE
AS
RETURN
(
	SELECT * FROM BillDetailView
	WHERE billID = @billID
)
GO

/* CÁC CHỨ NĂNG Ở ORDER */

/* VIẾT HÀM KIỂM TRA XEM CÓ TỒN TẠI KHÁCH HÀNG CÓ SỐ ĐIỆN THOẠI ĐÓ KHÔNG, NẾU CÓ THÌ TRẢ VỀ CUSTOMER KHÔNG THÌ IN RA MÀN HÌNH KHÔNG CÓ KHÁCH HÀNG */

DROP FUNCTION IF EXISTS checkCustomer
GO

CREATE FUNCTION checkCustomer
	(@phone VARCHAR(10))
	RETURNS NVARCHAR(max)
AS
BEGIN
	DECLARE @result NVARCHAR(max)
	IF NOT EXISTS (SELECT * FROM Customer WHERE phone = @phone)
		SET @result = 'CUSTOMER DOES NOT EXIST'
	ELSE 
		SET @result = (SELECT name FROM Customer WHERE phone = @phone)
	RETURN @result
END
GO

/* VIẾT PROCEDURE THÊM KHÁCH HÀNG MỚI VÀO CSDL */

DROP PROCEDURE IF EXISTS insertCustomer
GO

CREATE PROCEDURE insertCustomer
	(@name NVARCHAR(max), 
	@phone VARCHAR(10))
AS
BEGIN
	IF @name = '' OR @name = 'CUSTOMER DOES NOT EXIST'
		THROW 50000, 'Vui lòng điền tên khách hàng', 1
	ELSE IF @phone = ''
		THROW 50000, 'Vui lòng điền số điện thoại khách hàng', 1
	ELSE IF LEN(@phone) != 10
		THROW 50000, 'Số điện thoại phải có 10 chữ số', 1
	ELSE IF EXISTS (SELECT * FROM Customer WHERE phone = @phone)
		THROW 50000, 'Số điện thoại đã tồn tại', 1
	ELSE
	BEGIN TRANSACTION
		DECLARE @cusID VARCHAR(7)
		--LẤY CUSTOMERID CUỐI CÙNG
		DECLARE @lastCusID VARCHAR(7)
		SELECT @lastCusID = MAX(ID) FROM Customer
		--NẾU CHƯA CÓ CUSTOMER NÀO THÌ CUSTOMERID MỚI LÀ C00001
		IF @lastCusID IS NULL
			SET @cusID = 'C00001'
		ELSE
		--NẾU ĐÃ CÓ CUSTOMER THÌ CUSTOMERID MỚI LÀ CUSTOMERID CUỐI CÙNG + 1
		BEGIN
			DECLARE @number INT
			SET @number = CAST(RIGHT(@lastCusID, 4) AS INT) + 1
			SET @cusID = 'C' + RIGHT('0000' + CAST(@number AS VARCHAR(4)), 4)
		END
		--THÊM CUSTOMER MỚI
		DECLARE @errorMessage NVARCHAR(max)
		BEGIN TRY
			INSERT INTO Customer(ID, name, phone)
			VALUES (@cusID, @name, @phone)
			COMMIT TRANSACTION
		END TRY
			BEGIN CATCH
			ROLLBACK TRANSACTION
			SET @errorMessage = ERROR_MESSAGE()
				RAISERROR(@errorMessage, 16, 1)
		END CATCH
END
GO

/* TẠO VIEW BÀN CÓ STATUS LÀ ĐANG ĐƯỢC DÙNG */

DROP VIEW IF EXISTS TableAvailableView
GO

CREATE VIEW TableAvailableView
AS
SELECT ID, status
FROM [Table]
WHERE status = 'Available'
GO

/* VIẾT PROCEDURE KIỂM TRA XEM BÀN CÓ STATUS LÀ OCCUPIED THÌ CẬP NHẬT SANG AVAILABLE KHI BIẾT ID BÀN */

DROP PROCEDURE IF EXISTS updateTableStatus
GO

CREATE PROCEDURE updateTableStatus
	(@tableID VARCHAR(3))
AS
BEGIN
	IF (SELECT Status FROM TableStatusView WHERE ID = @tableID) = 'Occupied'
	BEGIN
		DECLARE @errorMessage NVARCHAR(max)
		BEGIN TRY
			UPDATE [Table] SET status = 'Available' WHERE ID = @tableID
		END TRY
		BEGIN CATCH
			SET @errorMessage = ERROR_MESSAGE()
			RAISERROR(@errorMessage, 16, 1)
		END CATCH
	END
	ELSE
		THROW 50000, 'Bàn đang trống', 1
		RETURN
END
GO

/* VIẾT TRIGGER KHI THÊM BILL MỚI THÌ CẬP NHẬT BÀN TỪ TRẠNG THÁI TRỐNG SANG TRẠNG THÁI ĐANG ĐƯỢC DÙNG NẾU BÀN ĐƯỢC DÙNG THÌ KHÔNG THÊM BILL VÀ IN RA MÀN HÌNH */

DROP TRIGGER IF EXISTS updateTableStatusTrigger
GO

CREATE TRIGGER updateTableStatusTrigger
ON Bill
AFTER INSERT
AS
BEGIN
	DECLARE @tableID VARCHAR(3)
	DECLARE @categoryID VARCHAR(4)
	SELECT @tableID = tableID FROM inserted
	SELECT @categoryID = categoryID FROM inserted
	IF @categoryID = 'BC01'
	BEGIN
		IF (SELECT status FROM [Table] WHERE ID = @tableID) = 'Available'
			UPDATE [Table] SET status = 'Occupied' WHERE ID = @tableID
		ELSE
			THROW 50000, 'TABLE IS OCCUPIED', 1
	END
	EXEC sp_refreshview TableAvailableView
END
GO

/* VIẾT PROCEDURE INSERT BILL */

DROP PROCEDURE IF EXISTS insertBill
GO

CREATE PROCEDURE insertBill
	@ID varchar(7),
	@dateTime varchar(max),
	@tableID varchar(3),
	@customerName nvarchar(max),
	@categoryName nvarchar(max),
	@empName nvarchar(max),
	@receiptMoney DECIMAL(10,2)
AS
BEGIN
	IF @categoryName = '' 
		THROW 50000, 'Vui lòng chọn loại hóa đơn', 1
	ELSE IF @customerName = '' 
		THROW 50000, 'Vui lòng nhập số điện thoại và khách hàng', 1
	ELSE IF @empName = '' 
		THROW 50000, 'Vui lòng chọn tên nhân viên', 1
	ELSE IF @tableID = '' 
		THROW 50000, 'Vui lòng chọn bàn', 1
	ELSE IF NOT EXISTS (SELECT * FROM TableAvailableView WHERE ID = @tableID) AND @tableID <> 'NA'
		THROW 50000, 'Bàn không tồn tại hoặc đang được sử dụng', 1
	ELSE
	BEGIN TRANSACTION
		DECLARE @customerID VARCHAR(5)
		DECLARE @categoryID VARCHAR(4)
		DECLARE @empID VARCHAR(4)
		SELECT @customerID = ID FROM Customer WHERE name = @customerName
		SELECT @categoryID = ID FROM BillCategory WHERE name = @categoryName
		SELECT @empID = ID FROM Employee WHERE name = @empName
		DECLARE @errorMessage NVARCHAR(max)
		BEGIN TRY
			INSERT INTO Bill(ID, dateTime, tableID, customerID, categoryID, empID, receiptMoney)
			VALUES (@ID, CAST(@dateTime  AS DATETIME), @tableID, @customerID, @categoryID, @empID, @receiptMoney)
			COMMIT TRANSACTION
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION
			SET @errorMessage = ERROR_MESSAGE()
			RAISERROR(@errorMessage, 16, 1)
		END CATCH
END
GO

/* VIẾT VIEW HIỂN THỊ TRẠNG THÁI BÀN */

DROP VIEW IF EXISTS TableStatusView
GO

CREATE VIEW TableStatusView
AS
SELECT ID, status
FROM [Table]
GO

/* VIẾT PROCEDURE THÊM BILLINFO KHI BIẾT MÃ HÓA ĐƠN, TÊN SẢN PHẨM, SỐ LƯỢNG */

DROP PROCEDURE IF EXISTS addBillInfo
GO

CREATE PROCEDURE addBillInfo
(
	@billID VARCHAR(7), 
	@productName NVARCHAR(max), 
	@quantity INT
)
AS
BEGIN
	IF @quantity <= 0
		THROW 50000, 'Số lượng không hợp lệ', 1
	ELSE IF NOT EXISTS (SELECT * FROM Product WHERE name = @productName)
		THROW 50000, 'Sản phẩm không tồn tại', 1
	ELSE IF NOT EXISTS (SELECT * FROM Bill WHERE ID = @billID)
		THROW 50000, 'Hóa đơn không tồn tại', 1
	ELSE
	BEGIN TRANSACTION
		DECLARE @productID VARCHAR(3)
		DECLARE @status INT
		DECLARE @quantityProductMaterial INT
		DECLARE @materialID VARCHAR(3)

		-- Lấy ID và trạng thái của sản phẩm
		SELECT @productID = ID , @status = status FROM Product WHERE name = @productName

		-- Lấy số lượng nguyên liệu cần cho sản phẩm
		SELECT @quantityProductMaterial = quantity, @materialID = materialID FROM Product_Material WHERE productID = @productID

		-- Kiểm tra số lượng tồn kho
		IF @status >= @quantity
		BEGIN
			DECLARE @errorMessage NVARCHAR(max)
			BEGIN TRY
				-- Cập nhật số lượng nguyên liệu
				UPDATE Material SET status = status - @quantityProductMaterial * @quantity WHERE ID = @materialID

				-- Thêm thông tin hóa đơn
				INSERT INTO BillInfo VALUES (@billID, @productID, @quantity)

				COMMIT TRANSACTION
			END TRY
			BEGIN CATCH
				ROLLBACK TRANSACTION
				SET @errorMessage = ERROR_MESSAGE()
				RAISERROR(@errorMessage, 16, 1)
			END CATCH
		END
		ELSE
			THROW 50000, 'Sản phẩm không đủ số lượng mà bạn yêu cầu', 1
END
GO

/* VIẾT PROCEDURE CẬP NHẬT BILL INFO KHI BIẾT MÃ HÓA ĐƠN, TÊN SẢN PHẨM, SỐ LƯỢNG */

DROP PROCEDURE IF EXISTS updateBillInfo
GO

CREATE PROCEDURE updateBillInfo
	(@billID VARCHAR(7), 
	@productName NVARCHAR(max), 
	@quantity INT)
AS
BEGIN
	IF @quantity <= 0
	THROW 50000, 'Số lượng không hợp lệ', 1
	ELSE IF NOT EXISTS (SELECT * FROM Product WHERE name = @productName)
		THROW 50000, 'Sản phẩm không tồn tại', 1
	ELSE IF NOT EXISTS (SELECT * FROM Bill WHERE ID = @billID)
		THROW 50000, 'Hóa đơn không tồn tại', 1
	ELSE
	BEGIN TRANSACTION
		DECLARE @productID VARCHAR(3)
		DECLARE @status INT
		DECLARE @quantityProductMaterial INT
		DECLARE @materialID VARCHAR(3)

		-- Lấy ID và trạng thái của sản phẩm
		SELECT @productID = ID , @status = status FROM Product WHERE name = @productName

		-- Lấy số lượng nguyên liệu cần cho sản phẩm
		SELECT @quantityProductMaterial = quantity, @materialID = materialID FROM Product_Material WHERE productID = @productID

		-- Kiểm tra số lượng tồn kho
		IF @status >= @quantity
		BEGIN
			DECLARE @errorMessage NVARCHAR(max)
			BEGIN TRY
				-- Cập nhật số lượng nguyên liệu
				UPDATE Material SET status = status - @quantityProductMaterial * @quantity WHERE ID = @materialID

				-- Cập nhật thông tin hóa đơn
				UPDATE BillInfo SET quantity = @quantity WHERE billID = @billID AND productID = @productID

				COMMIT TRANSACTION
			END TRY
			BEGIN CATCH
				ROLLBACK TRANSACTION
				SET @errorMessage = ERROR_MESSAGE()
				RAISERROR(@errorMessage, 16, 1)
			END CATCH
		END
		ELSE
			THROW 50000, 'Sản phẩm không đủ số lượng mà bạn yêu cầu', 1
END
GO

/* VIẾT FUNCTION TRẢ VỀ BẢNG HIỂN THỊ BILL INFO GỒM TÊN SẢN PHẨM, SỐ LƯỢNG, THÀNH TIỀN (PRODUCT.PRICE * QUANTITY) KHI BIẾT MÃ HÓA ĐƠN */

DROP FUNCTION IF EXISTS getBillInfo
GO

CREATE FUNCTION getBillInfo
(
	@billID VARCHAR(7)
)
RETURNS TABLE
AS
RETURN
(
	SELECT Product.name, BillInfo.quantity, Product.price * BillInfo.quantity AS totalPrice
	FROM BillInfo, Product
	WHERE BillInfo.productID = Product.ID AND BillInfo.billID = @billID
)
GO

/* VIẾT PROCEDURE CẬP NHẬT ĐIỂM THƯỞNG KHÁCH HÀNG KHI BIẾT BILL.ID VÀ SỐ ĐIỆN THOẠI. ĐIỂM THƯỞNG BẰNG TỔNG GIÁ TRỊ BILL CHIA CHO 10000, TỔNG GIÁ TRỊ BILL BẰNG TỔNG CỦA CÁC TOTAL PRICE TRONG BILLDETAILVIEW */

DROP PROCEDURE IF EXISTS updateCustomerPoint
GO

CREATE PROCEDURE updateCustomerPoint
	(@billID VARCHAR(7), 
	@phone VARCHAR(10))
AS
BEGIN
	BEGIN TRANSACTION
		DECLARE @totalPrice DECIMAL(10, 2)
		DECLARE @point INT
		IF NOT EXISTS (SELECT * FROM Bill WHERE ID = @billID)
			THROW 50000, 'BILL DOES NOT EXIST', 1
		SELECT @totalPrice = SUM(totalPrice) FROM BillDetailView WHERE billID = @billID
		SELECT @point = @totalPrice / 10000
		DECLARE @errorMessage NVARCHAR(max)
		BEGIN TRY
			UPDATE Customer SET bonusPoint = bonusPoint + @point WHERE phone = @phone
			COMMIT TRANSACTION
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION
			SET @errorMessage = ERROR_MESSAGE()
			RAISERROR(@errorMessage, 16, 1)
		END CATCH
END
GO

/* VIẾT VIEW TRẢ VỀ MẢNG DANH SÁCH TÊN CÁC NHÂN VIÊN TRONG CA TRỰC NGÀY HÔM ĐÓ GỒM TÊN NHÂN VIÊN, CHI TIẾT CÔNG VIỆC DỰA VÀO EMPLOYEE.JOBID, SỐ ĐIỆN THOẠI, ID CA TRỰC, NGÀY TRỰC VÀ SẮP XẾP THEO NGÀY TRỰC */

DROP VIEW IF EXISTS EmployeeShiftView
GO

CREATE VIEW EmployeeShiftView
AS
SELECT  Employee.name, 
		Job.jobDetail, 
		Employee.phone, 
		Shift.ID, 
		On_Duty.date
FROM Employee, Job, Shift, On_Duty
WHERE Employee.name <> 'NA' AND Employee.jobID = Job.ID AND Employee.ID = On_Duty.empID AND On_Duty.shiftID = Shift.ID
GO

/* DỰA VÀO NGÀY HIỆN TẠI TÌM RA DANH SÁCH TÊN CÁC NHÂN VIÊN ĐANG TRỰC */

DROP PROCEDURE IF EXISTS findEmployeeShift
GO

CREATE PROCEDURE findEmployeeShift
AS
BEGIN
	DECLARE @today DATE
	SET @today = GETDATE()
	SELECT * FROM EmployeeShiftView WHERE date = @today
END
GO

/* VIEETS VIEW TÍNH VÀ HIỂN THỊ TỔNG TIỀN VÀ CHIẾC KHẤU CỦA TỪNG HÓA ĐƠN. 
NẾU HÓA ĐƠN LÀ BC01 VÀ BC02 THÌ CĂN CỨ THEO ID KHÁCH HÀNG TÌM RA BONUSPOINT CỦA HỌ 
KHI BONUSPOINT BẰNG 200đ = chiết khấu 5% tổng bill
400đ = chiết khấu 10% tổng bill
500đ = chiết khấu 15% tổng bill
NẾU HÓA ĐƠN LÀ BC03 VÀ BC04 THÌ CĂN CỨ VÀO DISCOUNT TRONG BILLCATEGORY
CUỐI CÙNG LẤY DISCOUNT NHÂN VỚI TỔNG GIÁ TIỀN ĐỂ RA CHIẾC KHẤU*/

DROP VIEW IF EXISTS BillTotalPriceView
GO

CREATE VIEW BillTotalPriceView
AS
SELECT  Bill.ID, 
		Bill.categoryID,
		Bill.dateTime,
		SUM(totalPrice) AS totalPrice, 
		CASE 
			WHEN Bill.categoryID = 'BC01' OR Bill.categoryID = 'BC02' THEN 
				CASE 
					WHEN Customer.bonusPoint < 200 THEN 0
					WHEN Customer.bonusPoint >= 200 AND Customer.bonusPoint < 400 THEN SUM(totalPrice) * 0.05
					WHEN Customer.bonusPoint >= 400 AND Customer.bonusPoint < 500 THEN SUM(totalPrice) * 0.1
					WHEN Customer.bonusPoint >= 500 THEN SUM(totalPrice) * 0.15
				END
			WHEN Bill.categoryID = 'BC03' OR Bill.categoryID = 'BC04' THEN SUM(totalPrice) * BillCategory.discount
		END AS discount
FROM Bill, BillDetailView, Customer, BillCategory
WHERE Bill.ID = BillDetailView.billID 
AND Bill.customerID = Customer.ID 
AND Bill.categoryID = BillCategory.ID
GROUP BY Bill.ID, Bill.categoryID, Bill.dateTime, Customer.bonusPoint, BillCategory.discount
GO

/* VIẾT FUNCTION LẤY RA TỔNG TIỀN CỦA MỘT HÓA ĐƠN KHI BIẾT MÃ HÓA ĐƠN */

DROP FUNCTION IF EXISTS getBillTotalPrice
GO

CREATE FUNCTION getBillTotalPrice
(
	@billID VARCHAR(7)
)
RETURNS DECIMAL(10, 2)
AS
BEGIN
	DECLARE @totalPrice DECIMAL(10, 2)
	SELECT @totalPrice = totalPrice FROM BillTotalPriceView WHERE ID = @billID
	RETURN @totalPrice
END
GO

/* VIẾT FUNCTION LẤY RA DISCOUNT CỦA MỘT HÓA ĐƠN KHI BIẾT MÃ HÓA ĐƠN */

DROP FUNCTION IF EXISTS getBillDiscount
GO

CREATE FUNCTION getBillDiscount
(
	@billID VARCHAR(7)
)
RETURNS DECIMAL(10, 2)
AS
BEGIN
	DECLARE @discount DECIMAL(10, 2)
	SELECT @discount = discount FROM BillTotalPriceView WHERE ID = @billID
	RETURN @discount
END
GO

/* VIẾT PROCEDURE XÓA BILLINFO KHI BIẾT TÊN SẢN PHẨM */

DROP PROCEDURE IF EXISTS deleteBillInfoByName
GO

CREATE PROCEDURE deleteBillInfoByName
	@billID varchar(7),
	@productName NVARCHAR(max),
	@quantity INT
AS
BEGIN
	IF @quantity <= 0
		THROW 50000, 'Số lượng không hợp lệ', 1
	ELSE IF NOT EXISTS (SELECT * FROM Product WHERE name = @productName)
		THROW 50000, 'Sản phẩm không tồn tại', 1
	ELSE IF NOT EXISTS (SELECT * FROM Bill WHERE ID = @billID)
		THROW 50000, 'Hóa đơn không tồn tại', 1
	ELSE
	BEGIN TRANSACTION
		DECLARE @productID VARCHAR(3)
		DECLARE @status INT
		DECLARE @quantityProductMaterial INT
		DECLARE @materialID VARCHAR(3)

		-- Lấy ID và trạng thái của sản phẩm
		SELECT @productID = ID , @status = status FROM Product WHERE name = @productName

		-- Lấy số lượng nguyên liệu cần cho sản phẩm
		SELECT @quantityProductMaterial = quantity, @materialID = materialID FROM Product_Material WHERE productID = @productID

		DECLARE @errorMessage NVARCHAR(max)
		BEGIN TRY
			-- Cập nhật số lượng nguyên liệu
			UPDATE Material SET status = status + @quantityProductMaterial * @quantity WHERE ID = @materialID

			-- Xóa thông tin hóa đơn
			DELETE FROM BillInfo WHERE billID = @billID AND productID = @productID

			COMMIT TRANSACTION
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION
			SET @errorMessage = ERROR_MESSAGE()
			RAISERROR(@errorMessage, 16, 1)
		END CATCH
END
GO

/* VIẾT PROCEDURE CẬP NHẬT RECEIPT MONEY KHI BIẾT MÃ HÓA ĐƠN */

DROP PROCEDURE IF EXISTS updateReceiptMoney
GO

CREATE PROCEDURE updateReceiptMoney
	@billID varchar(7),
	@receiptMoney DECIMAL(10, 2)
AS
BEGIN
	IF @receiptMoney >= (SELECT totalPrice FROM BillTotalPriceView WHERE ID = @billID)
	BEGIN
		BEGIN TRANSACTION
			DECLARE @errorMessage NVARCHAR(max)
			BEGIN TRY
				UPDATE Bill
				SET receiptMoney = @receiptMoney
				WHERE ID = @billID
				COMMIT TRANSACTION
			END TRY
			BEGIN CATCH
				ROLLBACK TRANSACTION
				SET @errorMessage = ERROR_MESSAGE()
				RAISERROR(@errorMessage, 16, 1)
			END CATCH
	END
	ELSE IF @receiptMoney = 0
		THROW 50000, 'Vui lòng nhập số tiền', 1
	ELSE IF @receiptMoney < (SELECT totalPrice FROM BillTotalPriceView WHERE ID = @billID) AND @receiptMoney > 0
		THROW 50000, 'Số tiền không đủ', 1
	ELSE
		THROW 50000, 'Số tiền không hợp lệ', 1
END
GO

/* XÓA BÀN KHI BIẾT ID */

DROP PROCEDURE IF EXISTS deleteTableByID
GO

CREATE PROCEDURE deleteTableByID
	@ID VARCHAR(3)
AS
BEGIN
	--NẾU BÀN ĐANG ĐƯỢC DÙNG THÌ KHÔNG XÓA
	IF (SELECT status FROM [Table] WHERE ID = @ID) = 'Occupied'
		THROW 50000, 'TABLE IS OCCUPIED', 1
	ELSE
	BEGIN
		BEGIN TRANSACTION
			DECLARE @errorMessage NVARCHAR(max)
			BEGIN TRY
				DELETE FROM [Table] WHERE ID = @ID
				COMMIT TRANSACTION
			END TRY
			BEGIN CATCH
				ROLLBACK TRANSACTION
				SET @errorMessage = ERROR_MESSAGE()
				RAISERROR(@errorMessage, 16, 1)
			END CATCH
	END
END
GO

--VIẾT TRIGGER KHI XÓA BÀN THÌ CHUYỂN HẾT ID BÀN ĐÓ TRONG BILL SANG ID NA

DROP TRIGGER IF EXISTS deleteTableTrigger
GO

CREATE TRIGGER deleteTableTrigger
ON [Table]
INSTEAD OF DELETE
AS
BEGIN
	BEGIN TRANSACTION
		DECLARE @errorMessage NVARCHAR(max)
		DECLARE @tableID VARCHAR(3)
		SELECT @tableID = ID FROM deleted
		BEGIN TRY
			UPDATE Bill SET tableID = 'NA' WHERE tableID = @tableID
			DELETE FROM [Table] WHERE ID = @tableID
			COMMIT TRANSACTION
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION
			SET @errorMessage = ERROR_MESSAGE()
			RAISERROR(@errorMessage, 16, 1)
		END CATCH
END
GO

/* VIẾT TRIGGER KHI XÓA HÓA ĐƠN THÌ XÓA HẾT BILLINFO CỦA HÓA ĐƠN ĐÓ VÀ CẬP NHẬT TRẠNG THÁI BÀN VỀ AVAILABLE NẾU NÓ ĐANG OCCUPID 
NGHĨA LÀ TRƯỚC KHI XÓA BILL CÓ BILLID THÌ PHẢI XÓA BILLINFO LIÊN QUAN ĐẾN BILL ĐÓ*/

DROP TRIGGER IF EXISTS deleteBillTrigger
GO
	
CREATE TRIGGER deleteBillTrigger
ON Bill
INSTEAD OF DELETE
AS
BEGIN
	BEGIN TRANSACTION
		DECLARE @billID VARCHAR(7)
		DECLARE @tableID VARCHAR(3)
		DECLARE @errorMessage NVARCHAR(max)
		SELECT @billID = ID FROM deleted
		SELECT @tableID = tableID FROM deleted
		BEGIN TRY
			DELETE FROM BillInfo WHERE billID = @billID
			IF (SELECT status FROM [Table] WHERE ID = @tableID) = 'Occupied'
				UPDATE [Table] SET status = 'Available' WHERE ID = @tableID
			DELETE FROM Bill WHERE ID = @billID
			COMMIT TRANSACTION
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION
			SET @errorMessage = ERROR_MESSAGE()
			RAISERROR(@errorMessage, 16, 1)
		END CATCH
END
GO

--VIẾT FUNCTION KIỂM TRA XEM ID BILL CÓ TỒN TẠI KHÔNG

DROP FUNCTION IF EXISTS checkBillID
GO

CREATE FUNCTION checkBillID
(
	@billID VARCHAR(7)
)
RETURNS INT
AS
BEGIN
	DECLARE @result INT
	IF EXISTS (SELECT * FROM Bill WHERE ID = @billID)
		SET @result = 1
	ELSE
		SET @result = 0
	RETURN @result
END
GO

/* VIẾT PROCEDURE XÓA HÓA ĐƠN KHI BIẾT MÃ HÓA ĐƠN */

DROP PROCEDURE IF EXISTS deleteBillByID
GO

CREATE PROCEDURE deleteBillByID
	@ID VARCHAR(7)
AS
BEGIN
	BEGIN TRANSACTION
		DECLARE @errorMessage NVARCHAR(max)
		BEGIN TRY
			DELETE FROM Bill WHERE ID = @ID
			COMMIT TRANSACTION
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION
			SET @errorMessage = ERROR_MESSAGE()
			RAISERROR(@errorMessage, 16, 1)
		END CATCH
END
GO

/* VIẾT FUNCTION LẤY THÔNG TIN BILL GỒM LOẠI HÓA ĐƠN, MÃ HÓA ĐƠN, TÊN NHÂN VIÊN, NGÀY LẬP BILL, SỐ ĐIỆN THOẠI, TÊN KHÁCH HÀNG, MÃ BÀN */

DROP FUNCTION IF EXISTS getBillInfoViewByID
GO

CREATE FUNCTION getBillInfoViewByID
(
	@billID VARCHAR(7)
)
RETURNS TABLE
AS
RETURN
(
	SELECT BillCategory.name AS categoryName, 
			Bill.ID, Employee.name AS empName, Bill.dateTime, Customer.phone, Customer.name AS customerName, [Table].ID AS tableID
	FROM Bill, BillCategory, Employee, Customer, [Table]
	WHERE Bill.categoryID = BillCategory.ID AND Bill.empID = Employee.ID AND Bill.customerID = Customer.ID AND Bill.tableID = [Table].ID AND Bill.ID = @billID
)
GO

/* VIẾT HÀM TẠO VÀ TRẢ VỀ ID TỰ ĐỘNG CHO BILL, HÀM NÀY KHÔNG TRUYỀN VÀO THAM SỐ */

DROP FUNCTION IF EXISTS createBillID
GO

CREATE FUNCTION createBillID
()
RETURNS VARCHAR(7)
AS
BEGIN
	DECLARE @billID VARCHAR(7)
	--LẤY BILLID CUỐI CÙNG
	DECLARE @lastBillID VARCHAR(7)
	SELECT @lastBillID = MAX(ID) FROM Bill
	--NẾU CHƯA CÓ BILL NÀO THÌ BILLID MỚI LÀ B00001
	IF @lastBillID IS NULL
		SET @billID = 'B00001'
	ELSE
	--NẾU ĐÃ CÓ BILL THÌ BILLID MỚI LÀ BILLID CUỐI CÙNG + 1
	BEGIN
		DECLARE @number INT
		SET @number = CAST(RIGHT(@lastBillID, 6) AS INT) + 1
		SET @billID = 'B' + RIGHT('000000' + CAST(@number AS VARCHAR(6)), 6)
	END
	RETURN @billID
END
GO

/* VIẾT HÀM CHỌN TẤT CẢ CA TRỰC */

DROP PROCEDURE IF EXISTS selectAllShift
GO

CREATE PROCEDURE selectAllShift
AS
BEGIN
	DECLARE @errorMessage NVARCHAR(max)
	BEGIN TRY
	SELECT * FROM [Shift]
	END TRY
	BEGIN CATCH
		SET @errorMessage = ERROR_MESSAGE()
		RAISERROR(@errorMessage, 16, 1)
	END CATCH
END
GO

--VIẾT VIEW LẤY RA MÃ SẢN PHẨM, TÊN SẢN PHẨM, TRẠNG THÁI, GIÁ SẢN PHẨM TỪ BẢNG PRODUCT

DROP VIEW IF EXISTS ProductView
GO

CREATE VIEW ProductView
AS

SELECT ID, name, status, price
FROM Product
GO

--VIẾT PROCEDURE LẤY VIEW PRODUCTVIEW

DROP PROCEDURE IF EXISTS selectAllProduct
GO

CREATE PROCEDURE selectAllProduct
AS

BEGIN
	DECLARE @errorMessage NVARCHAR(max)
	BEGIN TRY
		SELECT * FROM ProductView
	END TRY
	BEGIN CATCH
		SET @errorMessage = ERROR_MESSAGE()
		RAISERROR(@errorMessage, 16, 1)
	END CATCH
END
GO

--VIẾT FUNCTION LẤY RA STATUS CỦA SẢN PHẨM KHI BIẾT TÊN SẢN PHẨM

DROP FUNCTION IF EXISTS getProductStatus
GO

CREATE FUNCTION getProductStatus
(
	@productName NVARCHAR(max)
)
RETURNS INT
AS
BEGIN
	DECLARE @status NVARCHAR(max)
	SELECT @status = status FROM ProductView WHERE name = @productName
	RETURN @status
END
GO

--VIẾT PROCEDURE THÊM BÀN MỚI CÓ STATUS LÀ AVAILABLE

DROP PROCEDURE IF EXISTS insertTable
GO

CREATE PROCEDURE insertTable
AS
BEGIN
	BEGIN TRANSACTION
		DECLARE @errorMessage NVARCHAR(max)
		BEGIN TRY
			INSERT INTO [Table](ID, name, status)
			VALUES ('', '', '')
			COMMIT TRANSACTION
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION
			SET @errorMessage = ERROR_MESSAGE()
			RAISERROR(@errorMessage, 16, 1)
		END CATCH
END
GO

--VIẾT TRIGGER TRƯỚC KHI THÊM BÀN MỚI THÌ TỰ TẠO ID VÀ TÊN BÀN

DROP TRIGGER IF EXISTS insertTableTrigger
GO

CREATE TRIGGER insertTableTrigger
ON [Table]
INSTEAD OF INSERT
AS
BEGIN
	BEGIN TRANSACTION
		DECLARE @ID VARCHAR(3)
		DECLARE @status NVARCHAR(max)
		DECLARE @name NVARCHAR(max)
		DECLARE @errorMessage NVARCHAR(max)
		SET @status = 'Available'
		--LẤY TABLEID CUỐI CÙNG
		DECLARE @lastTableID VARCHAR(3)
		SELECT @lastTableID = MAX(ID) FROM [Table]
		--NẾU CHƯA CÓ TABLE NÀO THÌ TABLEID MỚI LÀ T01
		IF @lastTableID IS NULL
			BEGIN
				SET @ID = 'T01'
				SET @name = 'Table 1'
			END
		ELSE
		--NẾU ĐÃ CÓ TABLE THÌ TABLEID MỚI LÀ TABLEID CUỐI CÙNG + 1
		BEGIN
			DECLARE @number INT
			SET @number = CAST(RIGHT(@lastTableID, 2) AS INT) + 1
			SET @ID = 'T' + RIGHT('00' + CAST(@number AS VARCHAR(2)), 2)
			SET @name = 'Table ' + CAST(@number AS VARCHAR(2))
		END
		BEGIN TRY
			INSERT INTO [Table](ID, name, status)
			VALUES (@ID, @name, @status)
			COMMIT TRANSACTION
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION
			SET @errorMessage = ERROR_MESSAGE()
			RAISERROR(@errorMessage, 16, 1)
		END CATCH
END
GO

----------------------------------------------------------------------------
----------------------------------------------------------------------------
------------------------------ DASHBOARD -----------------------------------
----------------------------------------------------------------------------
----------------------------------------------------------------------------

USE WibuCoffee
GO

/* Add user */

DROP PROCEDURE IF EXISTS AddAccount
GO

CREATE PROCEDURE AddAccount
    @userName VARCHAR(10),
    @pass VARCHAR(MAX),
    @userRole INT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        -- Validate user role
        IF @userRole < 0 OR @userRole > 1
            RAISERROR('Invalid user role. Must be 0 or 1.', 16, 1);
        
        -- Insert the new account
        INSERT INTO Account (userName , pass , userRole)
        VALUES (@userName , @pass , @userRole);
    END TRY
    BEGIN CATCH
        -- Error handling
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        DECLARE @ErrorSeverity INT = ERROR_SEVERITY();
        DECLARE @ErrorState INT = ERROR_STATE();

        RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
    END CATCH
END;
GO

DROP TRIGGER IF EXISTS Trigger_CreateSQLAccount
GO

CREATE TRIGGER [dbo].[Trigger_CreateSQLAccount]
ON [dbo].[Account]
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION; -- Start transaction

        DECLARE @userName NVARCHAR(10), @pass NVARCHAR(MAX), @userRole INT;
        SELECT @userName = i.userName, @pass = '' + i.pass, @userRole = i.userRole
        FROM inserted i;

        DECLARE @sqlString NVARCHAR(2000);

        -- Create SQL Server login for the new account
        SET @sqlString = 'CREATE LOGIN [' + @userName + '] WITH PASSWORD = ''' + @pass +
                         ''', DEFAULT_DATABASE=[WibuCoffee], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF';
        --print @sqlString
		EXEC (@sqlString);
		
        -- Create user for the login
        SET @sqlString = 'CREATE USER [' + @userName  + '] FOR LOGIN [' + @userName + ']';
        EXEC (@sqlString);

        -- Assign role based on userRole
        IF @userRole = 0
            SET @sqlString = 'ALTER ROLE db_owner ADD MEMBER [' + @userName + ']';
        ELSE IF @userRole = 1
            SET @sqlString = 'ALTER ROLE role_emp ADD MEMBER [' + @userName + ']';

        EXEC (@sqlString); 

        COMMIT TRANSACTION; -- Commit the transaction if no errors
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION; -- Roll back the transaction on error

        -- Capture and raise the error information
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        DECLARE @ErrorSeverity INT = ERROR_SEVERITY();
        DECLARE @ErrorState INT = ERROR_STATE();

        RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
    END CATCH
END;
GO


DROP FUNCTION IF EXISTS checkLogin
GO

/* CHECK LOGIN */
CREATE FUNCTION checkLogin
    (@userName VARCHAR(10),
     @pass VARCHAR(MAX))
RETURNS VARCHAR(MAX)
AS
BEGIN
    DECLARE @userRole VARCHAR(MAX)

    IF EXISTS (SELECT * FROM Account WHERE userName = @userName AND pass = @pass)
        SELECT @userRole = userRole FROM Account WHERE userName = @userName

    RETURN ISNULL(@userRole, 'Invalid')
END
GO

DROP FUNCTION IF EXISTS getTotalPriceBillbyDate
GO

CREATE FUNCTION getTotalPriceBillbyDate
(@date date)
RETURNS DECIMAL(10,0)
BEGIN
  DECLARE @total DECIMAL(10,0);
  SELECT @total = SUM(totalPrice) 
  FROM BillTotalPriceView
  WHERE CAST(dateTime AS date) = @date;
  RETURN ISNULL(@total, 0); -- Trả về 0 nếu không có dữ liệu
END;
GO

SELECT dbo.getTotalPriceBillbyDate ('2024-03-14')

DROP FUNCTION IF EXISTS getTotalExpensebyDate
GO

CREATE FUNCTION getTotalExpensebyDate
(@date date)
RETURNS DECIMAL(10,0)
AS
BEGIN
    DECLARE @total DECIMAL(10,0);

    SELECT @total = SUM(price)
    FROM ExpenseBill
    WHERE date = @date;
    RETURN ISNULL(@total, 0);
END;
GO

SELECT dbo.getTotalExpensebyDate ('2024-04-10')

DROP FUNCTION IF EXISTS getEmptyTableCount
GO

CREATE FUNCTION getEmptyTableCount()
RETURNS INT
AS
BEGIN
    DECLARE @avail INT;

    SELECT @avail = COUNT(*)
    FROM dbo.[Table]
    WHERE [status] = 'Available';

    RETURN ISNULL(@avail, 0);
END;
GO


SELECT dbo.getEmptyTableCount ()

--  create view to list 5 most popular products
DROP VIEW IF EXISTS MostPopularProducts
GO

CREATE VIEW MostPopularProducts
AS
SELECT TOP 5 p.ID, p.name, p.price, SUM(bi.quantity) as totalQuantity
FROM Product p
JOIN BillInfo bi
ON p.ID = bi.productID
GROUP BY p.ID, p.name, p.price
ORDER BY totalQuantity DESC;
GO

SELECT * FROM MostPopularProducts

-- create view to list count of bill and expense for 7 days

DROP VIEW IF EXISTS BillExpenseCount7DaysAgo
GO

CREATE VIEW BillExpenseCount7DaysAgo
AS
-- Định nghĩa CTE đầu tiên để tạo một dãy số từ 0 đến 6
WITH NumberSeries AS (
    SELECT 0 AS Number  -- Bắt đầu dãy số với 0
    UNION ALL SELECT 1  -- Thêm số 1 vào dãy
    UNION ALL SELECT 2  -- Thêm số 2 vào dãy
    UNION ALL SELECT 3  -- Thêm số 3 vào dãy
    UNION ALL SELECT 4  -- Thêm số 4 vào dãy
    UNION ALL SELECT 5  -- Thêm số 5 vào dãy
    UNION ALL SELECT 6  -- Thêm số 6 vào dãy, hoàn thành dãy số từ 0 đến 6
),
-- Định nghĩa CTE thứ hai để tạo chuỗi ngày từ ngày hiện tại trở về trước 6 ngày
DateSeries AS (
    SELECT CAST(DATEADD(DAY, -Number, GETDATE()) AS DATE) AS DateValue  -- Tính toán ngày bằng cách trừ số ngày (Number) từ ngày hiện tại
    FROM NumberSeries  -- Sử dụng dãy số đã tạo ở CTE trên để tính ngày
)
-- Chọn ngày và tính tổng giá trị hóa đơn và chi phí cho mỗi ngày trong khoảng 7 ngày
SELECT
    ds.DateValue AS [Date],  -- Lấy giá trị ngày từ CTE DateSeries
    -- Tính tổng giá trị hóa đơn cho mỗi ngày, nếu không có hóa đơn thì trả về 0
    (SELECT ISNULL(SUM(totalPrice), 0) FROM BillTotalPriceView WHERE CAST(dateTime AS DATE) = ds.DateValue) AS TotalBill,
    -- Tính tổng chi phí cho mỗi ngày, nếu không có chi phí thì trả về 0
    (SELECT ISNULL(SUM(price),0) FROM ExpenseBill WHERE CAST(date AS DATE) = ds.DateValue) AS TotalExpense
FROM
    DateSeries ds;  -- Sử dụng CTE DateSeries để lặp qua từng ngày
GO 

SELECT * FROM BillExpenseCount7DaysAgo

-- create function to get total revenue = total price of bill - total price of receipt note - total price of expense bill in 1 month ago
DROP FUNCTION IF EXISTS getTotalRevenue1MonthAgo
GO

CREATE FUNCTION getTotalRevenue1MonthAgo()
RETURNS DECIMAL(18,2)  -- Increased precision for financial calculations
AS
BEGIN
    DECLARE @totalRevenue DECIMAL(18,2);
    DECLARE @totalBills DECIMAL(18,2);
    DECLARE @totalExpenses DECIMAL(18,2);
    DECLARE @totalReceiptNotes DECIMAL(18,2);

    -- Calculate total price from bills in the current month
    SELECT @totalBills = ISNULL(SUM(totalPrice), 0)
    FROM BillTotalPriceView
    WHERE MONTH(dateTime) = MONTH(GETDATE())
      AND YEAR(dateTime) = YEAR(GETDATE());

    -- Calculate total price from expense bills in the current month
    SELECT @totalExpenses = ISNULL(SUM(price), 0)
    FROM ExpenseBill
    WHERE MONTH(date) = MONTH(GETDATE())
      AND YEAR(date) = YEAR(GETDATE());

    -- Calculate total price from receipt notes in the current month
    SELECT @totalReceiptNotes = ISNULL(SUM(unitPrice * quantity), 0)
    FROM ReceiptNoteDetail
    JOIN ReceiptNote ON ReceiptNoteDetail.rNoteID = ReceiptNote.ID
    WHERE MONTH(ReceiptNote.date) = MONTH(GETDATE())
      AND YEAR(ReceiptNote.date) = YEAR(GETDATE());

    -- Calculate total revenue
    SET @totalRevenue = @totalBills - @totalExpenses - @totalReceiptNotes;

    RETURN @totalRevenue;
END;
GO

SELECT dbo.getTotalRevenue1MonthAgo()

DROP VIEW IF EXISTS MonthlyTotalPriceBillView
GO

-- create view to list total price of bill for 12 month of current year, if no data, return 0
CREATE VIEW MonthlyTotalPriceBillView
AS
    -- Định nghĩa một CTE để tạo ra một dãy số từ 0 đến 11
    WITH NumberSeries AS (
        SELECT 0 AS Number -- Đại diện cho tháng đầu tiên của năm hiện tại
        UNION ALL SELECT 1
        UNION ALL SELECT 2
        UNION ALL SELECT 3
        UNION ALL SELECT 4
        UNION ALL SELECT 5
        UNION ALL SELECT 6
        UNION ALL SELECT 7
        UNION ALL SELECT 8
        UNION ALL SELECT 9
        UNION ALL SELECT 10
        UNION ALL SELECT 11 -- Đại diện cho tháng cuối cùng của năm hiện tại
    ),
    -- Định nghĩa CTE thứ hai để tạo ra một chuỗi các giá trị tháng từ số đã cho
    MonthSeries AS (
        SELECT DATEADD(MONTH, Number, DATEADD(YEAR, DATEDIFF(YEAR, 0, GETDATE()), 0)) AS MonthValue
        FROM NumberSeries -- Thêm mỗi giá trị Number vào đầu năm hiện tại để tạo ra một ngày trong từng tháng
    )
    -- Thực hiện truy vấn để lấy tổng giá trị hóa đơn cho mỗi tháng
    SELECT
        MONTH(ms.MonthValue) AS [Month], -- Lấy số tháng từ giá trị ngày
        -- Subquery để tính tổng giá trị hóa đơn cho mỗi tháng tương ứng
        (SELECT ISNULL(SUM(totalPrice), 0) 
            FROM BillTotalPriceView -- Sử dụng VIEW lưu trữ tổng giá trị của các hóa đơn
            WHERE MONTH(dateTime) = MONTH(ms.MonthValue) -- So sánh tháng của hóa đơn với tháng hiện tại của CTE
                  AND YEAR(dateTime) = YEAR(ms.MonthValue) -- So sánh năm của hóa đơn với năm của ngày trong CTE
            ) AS TotalPrice
    FROM MonthSeries ms; -- Lặp qua mỗi giá trị tháng trong MonthSeries
GO

SELECT * FROM MonthlyTotalPriceBillView

----------------------------------------------------------------------------
----------------------------------------------------------------------------
------------------------------ PRODUCT -------------------------------------
----------------------------------------------------------------------------
----------------------------------------------------------------------------

USE WibuCoffee
GO

-- VIEW --

DROP VIEW IF EXISTS ProductView
GO

CREATE VIEW ProductView AS
SELECT p.id, p.name, p.price, pc.name AS productcategory, p.status
FROM Product p, ProductCategory pc 
WHERE p.categoryID = pc.id AND p.status != -1
GO

SELECT * FROM ProductView
GO

DROP VIEW IF EXISTS ProductCategoryView
GO

CREATE VIEW ProductCategoryView AS
SELECT id, name
FROM ProductCategory
GO

SELECT * FROM ProductCategoryView
GO

------------------------------------------------------------
------------------------------------------------------------
------------------------------------------------------------
-- FUNCTION --

-- create function to get all materials when product id is given


DROP FUNCTION IF EXISTS GetMaterials
GO

CREATE FUNCTION GetMaterials(@productID VARCHAR(3))
RETURNS TABLE
AS
RETURN
(
	SELECT m.name AS materialname, pm.quantity
	FROM Material m, Product_Material pm, Product p
	WHERE pm.materialID = m.ID AND pm.productID = p.ID AND pm.productID = @productID
)
GO

SELECT * FROM GetMaterials('P02')
GO

------------------------------------------------------------
------------------------------------------------------------
------------------------------------------------------------
--- Procedure ---

DROP PROCEDURE IF EXISTS updateProductStatus
GO

CREATE PROCEDURE updateProductStatus
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION; -- Start of transaction

        -- Temporary table to store minimum product counts based on material availability
        CREATE TABLE #ProductStatusUpdate (
            ProductID VARCHAR(50),
            MaxProductCount INT
        );

        -- Insert the calculated maximum product counts into the temporary table
        INSERT INTO #ProductStatusUpdate (ProductID, MaxProductCount)
        SELECT 
            pm.ProductID,
            MIN(m.status / pm.quantity) AS MaxProductCount
        FROM 
            Product_Material pm
        INNER JOIN 
            Material m ON pm.MaterialID = m.ID
        GROUP BY 
            pm.ProductID;

        -- Update the Product table's status with the least number of products that can be made
        UPDATE 
            Product
        SET 
            status = psu.MaxProductCount
        FROM 
            Product p
        INNER JOIN 
            #ProductStatusUpdate psu ON p.ID = psu.ProductID;

		DROP TABLE #ProductStatusUpdate;

        COMMIT TRANSACTION; -- Commit the transaction if no errors

    END TRY
    BEGIN CATCH
        -- Roll back the transaction on error
        ROLLBACK TRANSACTION;

        -- Printing the error message and the severity
        DECLARE @ErrorMessage NVARCHAR(4000);
        DECLARE @ErrorSeverity INT;
        DECLARE @ErrorState INT;

        SELECT 
            @ErrorMessage = ERROR_MESSAGE(),
            @ErrorSeverity = ERROR_SEVERITY(),
            @ErrorState = ERROR_STATE();

        RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
    END CATCH
END;
GO


EXEC dbo.updateProductStatus

-- Procedure Product --
DROP PROCEDURE IF EXISTS AddProduct
GO

CREATE PROCEDURE AddProduct
    @id VARCHAR(3),
    @name NVARCHAR(MAX),
    @categoryID VARCHAR(4),
    @price DECIMAL(10, 2),
    @status INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Check for null or empty inputs for varchar/nvarchar fields
    IF @id IS NULL OR LTRIM(RTRIM(@id)) = ''
    BEGIN
        RAISERROR('Error: ID must not be null or empty.', 16, 1);
        RETURN;
    END

    IF @name IS NULL OR LTRIM(RTRIM(@name)) = ''
    BEGIN
        RAISERROR('Error: Name must not be null or empty.', 16, 1);
        RETURN;
    END

    IF @categoryID IS NULL OR LTRIM(RTRIM(@categoryID)) = ''
    BEGIN
        RAISERROR('Error: Category ID must not be null or empty.', 16, 1);
        RETURN;
    END

    -- Check for valid decimal and status values
    IF @price IS NULL OR @price <= 0 OR LTRIM(RTRIM(@categoryID)) = ''
    BEGIN
        RAISERROR('Error: Price must not be null and cannot be negative.', 16, 1);
        RETURN;
    END

    IF @status IS NULL OR @status < 0 OR LTRIM(RTRIM(@categoryID)) = ''
    BEGIN
        RAISERROR('Error: Status must be >= 0 and cannot be null.', 16, 1);
        RETURN;
    END

	DECLARE @ErrorMessage NVARCHAR(4000);
    -- If all checks pass, proceed with the insert
    BEGIN TRY
        INSERT INTO Product (id, name, categoryID, price, status)
        VALUES (@id, @name, @categoryID, @price, @status);
    END TRY
    BEGIN CATCH
        -- Catch block to handle SQL errors during the insert operation
		SET @ErrorMessage = ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH
END;
GO

DROP PROCEDURE IF EXISTS UpdateProductByID
GO

CREATE PROCEDURE UpdateProductByID
    @ID VARCHAR(3),
    @name NVARCHAR(MAX),
    @categoryID VARCHAR(4),
    @price DECIMAL(10, 2),
    @status INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Check for null or empty inputs for varchar/nvarchar fields
    IF @ID IS NULL OR LTRIM(RTRIM(@ID)) = ''
    BEGIN
        RAISERROR('Error: ID must not be null or empty.', 16, 1);
        RETURN;
    END

    IF @name IS NULL OR LTRIM(RTRIM(@name)) = ''
    BEGIN
        RAISERROR('Error: Name must not be null or empty.', 16, 1);
        RETURN;
    END

    IF @categoryID IS NULL OR LTRIM(RTRIM(@categoryID)) = ''
    BEGIN
        RAISERROR('Error: Category ID must not be null or empty.', 16, 1);
        RETURN;
    END

    -- Check for valid decimal and status values
    IF @price IS NULL OR @price <= 0
    BEGIN
        RAISERROR('Error: Price must not be null and cannot be negative.', 16, 1);
        RETURN;
    END

    IF @status IS NULL OR @status < 0 OR LTRIM(RTRIM(@categoryID)) = ''
    BEGIN
        RAISERROR('Error: Status must be >= 0 and cannot be null.', 16, 1);
        RETURN;
    END

	DECLARE @ErrorMessage NVARCHAR(4000);
    -- If all checks pass, proceed with the update
    BEGIN TRY
        UPDATE Product
        SET name = @name, categoryID = @categoryID, price = @price, status = @status
        WHERE ID = @ID;
    END TRY
    BEGIN CATCH
        -- Catch block to handle SQL errors during the update operation
        SET @ErrorMessage = ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH
END;
GO

DROP PROCEDURE IF EXISTS DeleteProductByID
GO

CREATE PROCEDURE DeleteProductByID
    @ID VARCHAR(3)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @ErrorMessage NVARCHAR(4000);
    DECLARE @ErrorSeverity INT;
    DECLARE @ErrorState INT;

    BEGIN TRY
        BEGIN TRANSACTION; -- Start the transaction

        -- First, delete associated data from Product_Material
        DELETE FROM Product_Material
        WHERE productID = @ID;

        -- Then, update the status in the Product table
        UPDATE Product
        SET status = -1
        WHERE ID = @ID;

        COMMIT TRANSACTION; -- Commit the transaction if no errors
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION; -- Roll back the transaction on error

        -- If an error occurs, catch it and throw an error message
        SET @ErrorMessage = ERROR_MESSAGE();
        SET @ErrorSeverity = ERROR_SEVERITY();
        SET @ErrorState = ERROR_STATE();
        RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState);
    END CATCH
END;
GO

-- End procedure Product --

--- Procedure product category ---
DROP PROCEDURE IF EXISTS addProductCategory
GO

CREATE PROCEDURE addProductCategory
	@ID varchar(4),
	@name nvarchar(max)
AS
BEGIN
	-- Check for null or empty inputs for varchar/nvarchar fields
    IF @id IS NULL OR LTRIM(RTRIM(@id)) = ''
    BEGIN
        RAISERROR('Error: ID must not be null or empty.', 16, 1);
        RETURN;
    END

    IF @name IS NULL OR LTRIM(RTRIM(@name)) = ''
    BEGIN
        RAISERROR('Error: Name must not be null or empty.', 16, 1);
        RETURN;
    END

	DECLARE @ErrorMessage NVARCHAR(4000);
    -- If all checks pass, proceed with the insert
    BEGIN TRY
        INSERT INTO ProductCategory(ID, name)
		VALUES (@ID, @name)
    END TRY
    BEGIN CATCH
        -- Catch block to handle SQL errors during the insert operation
		SET @ErrorMessage = ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH
END
GO

DROP PROCEDURE IF EXISTS updateProductCategoryByID
GO

CREATE PROCEDURE updateProductCategoryByID
	@ID varchar(4),
	@name nvarchar(max)
AS
BEGIN
	
	-- Check for null or empty inputs for varchar/nvarchar fields
    IF @id IS NULL OR LTRIM(RTRIM(@id)) = ''
    BEGIN
        RAISERROR('Error: ID must not be null or empty.', 16, 1);
        RETURN;
    END

    IF @name IS NULL OR LTRIM(RTRIM(@name)) = ''
    BEGIN
        RAISERROR('Error: Name must not be null or empty.', 16, 1);
        RETURN;
    END

	DECLARE @ErrorMessage NVARCHAR(4000);
    -- If all checks pass, proceed with the insert
    BEGIN TRY
        UPDATE ProductCategory
		SET name = @name
		WHERE ID = @ID
    END TRY
    BEGIN CATCH
        -- Catch block to handle SQL errors during the insert operation
		SET @ErrorMessage = ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH
END
GO

-- End procedure Product Category --

-- Procedure ProductMaterial --
DROP PROCEDURE IF EXISTS addProductMaterial
GO

CREATE PROCEDURE addProductMaterial
	@productID varchar(3),
	@materialID varchar(3),
	@quantity INT
AS
BEGIN

	-- Check for null or empty inputs for varchar/nvarchar fields
    IF @productID IS NULL OR LTRIM(RTRIM(@productID)) = ''
    BEGIN
        RAISERROR('Error: ProductID must not be null or empty.', 16, 1);
        RETURN;
    END

    IF @materialID IS NULL OR LTRIM(RTRIM(@materialID)) = ''
    BEGIN
        RAISERROR('Error: MaterialID must not be null or empty.', 16, 1);
        RETURN;
    END

	IF @quantity IS NULL OR @quantity <= 0 OR LTRIM(RTRIM(@quantity)) = ''
    BEGIN
        RAISERROR('Error: Quantity must be > 0 and cannot be null.', 16, 1);
        RETURN;
    END

	DECLARE @ErrorMessage NVARCHAR(4000);
    -- If all checks pass, proceed with the insert
    BEGIN TRY
        INSERT INTO Product_Material(productID, materialID, quantity)
		VALUES (@productID, @materialID, @quantity)
    END TRY
    BEGIN CATCH
        -- Catch block to handle SQL errors during the insert operation
		SET @ErrorMessage = ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH
END
GO

DROP PROCEDURE IF EXISTS updateProductMaterialByID
GO

CREATE PROCEDURE updateProductMaterialByID
	@productID varchar(3),
	@materialID varchar(3),
	@quantity INT
AS
BEGIN

	-- Check for null or empty inputs for varchar/nvarchar fields
    IF @productID IS NULL OR LTRIM(RTRIM(@productID)) = ''
    BEGIN
        RAISERROR('Error: ProductID must not be null or empty.', 16, 1);
        RETURN;
    END

    IF @materialID IS NULL OR LTRIM(RTRIM(@materialID)) = ''
    BEGIN
        RAISERROR('Error: MaterialID must not be null or empty.', 16, 1);
        RETURN;
    END

	IF @quantity IS NULL OR @quantity <= 0 OR LTRIM(RTRIM(@quantity)) = ''
    BEGIN
        RAISERROR('Error: Quantity must be > 0 and cannot be null.', 16, 1);
        RETURN;
    END

	DECLARE @ErrorMessage NVARCHAR(4000);
    -- If all checks pass, proceed with the insert
    BEGIN TRY
        UPDATE Product_Material
		SET quantity = @quantity
		WHERE productID = @productID AND materialID = @materialID
    END TRY
    BEGIN CATCH
        -- Catch block to handle SQL errors during the insert operation
		SET @ErrorMessage = ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH
END
GO

DROP PROCEDURE IF EXISTS deleteProductMaterialByID
GO

CREATE PROCEDURE deleteProductMaterialByID
	@productID VARCHAR(3),
	@materialID VARCHAR(3)
AS
BEGIN
	-- Check for null or empty inputs for varchar/nvarchar fields
    IF @productID IS NULL OR LTRIM(RTRIM(@productID)) = ''
    BEGIN
        RAISERROR('Error: ProductID must not be null or empty.', 16, 1);
        RETURN;
    END

    IF @materialID IS NULL OR LTRIM(RTRIM(@materialID)) = ''
    BEGIN
        RAISERROR('Error: MaterialID must not be null or empty.', 16, 1);
        RETURN;
    END

	DECLARE @ErrorMessage NVARCHAR(4000);
    -- If all checks pass, proceed with the insert
    BEGIN TRY
        DELETE FROM Product_Material 
		WHERE productID = @productID AND materialID = @materialID
    END TRY
    BEGIN CATCH
        -- Catch block to handle SQL errors during the insert operation
		SET @ErrorMessage = ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH
END
GO
-- End procedure ProductMaterial --


------------------------------------------------------------
------------------------------------------------------------
------------------------------------------------------------
--- TRIGGER ---

-- ProductMaterial --
DROP TRIGGER IF EXISTS UpdateProduct_ProductMaterialTrigger
GO

CREATE TRIGGER UpdateProduct_ProductMaterialTrigger
ON Product_Material
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    -- Prevent trigger from firing recursively
    IF TRIGGER_NESTLEVEL() > 1 RETURN;

    -- Call the procedure to update product statuses
    EXEC updateProductStatus;
END;
GO


-- Trigger sửa lại ID khi thêm product theo định dạng Pxx, dựa nào ID cuối cùng trong bảng Product
DROP TRIGGER IF EXISTS UpdateProductID
GO

CREATE TRIGGER UpdateProductID
ON Product
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION; -- Start the transaction

        DECLARE @lastID VARCHAR(3);
        SELECT TOP 1 @lastID = ID
        FROM Product
        ORDER BY ID DESC;

        DECLARE @newID VARCHAR(3);
        SET @newID = 'P' + RIGHT('00' + CAST(CAST(RIGHT(@lastID, 2) AS INT) + 1 AS VARCHAR(2)), 2);

        UPDATE Product
        SET ID = @newID
        WHERE ID IN (SELECT ID FROM inserted);

        COMMIT TRANSACTION; -- Commit the transaction if no errors
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION; -- Roll back the transaction on error

        -- Capture and raise the error information
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        DECLARE @ErrorSeverity INT = ERROR_SEVERITY();
        DECLARE @ErrorState INT = ERROR_STATE();

        RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
    END CATCH
END;
GO

-- Trigger sửa lại ID khi thêm product category theo định dạng PCxx, dựa nào ID cuối cùng trong bảng ProductCategory
DROP TRIGGER IF EXISTS UpdateProductCategoryID
GO

CREATE TRIGGER UpdateProductCategoryID
ON ProductCategory
AFTER INSERT
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION;

		DECLARE @lastID VARCHAR(4)
		SELECT TOP 1 @lastID = ID
		FROM ProductCategory
		ORDER BY ID DESC

		DECLARE @newID VARCHAR(4)
		SET @newID = 'PC' + RIGHT(CAST(CAST(RIGHT(@lastID, 2) AS INT) + 1 AS VARCHAR(2)), 2)

		UPDATE ProductCategory
		SET ID = @newID
		WHERE ID IN (SELECT ID FROM inserted)
			
		COMMIT TRANSACTION;
	END TRY
	 BEGIN CATCH
        -- Roll back the transaction on error
        ROLLBACK TRANSACTION;

        -- Printing the error message and the severity
        DECLARE @ErrorMessage NVARCHAR(4000);
        DECLARE @ErrorSeverity INT;
        DECLARE @ErrorState INT;

        SELECT 
            @ErrorMessage = ERROR_MESSAGE(),
            @ErrorSeverity = ERROR_SEVERITY(),
            @ErrorState = ERROR_STATE();

        RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
    END CATCH
END
GO

DROP TRIGGER IF EXISTS PreventDuplicateProductName
GO

CREATE TRIGGER PreventDuplicateProductName
ON Product
INSTEAD OF INSERT
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM inserted i
        JOIN Product p ON i.name = p.name AND p.status != -1
    )
    BEGIN
        RAISERROR ('Cannot insert. A product with the same name already exists.', 16, 1)
        ROLLBACK TRANSACTION
    END
    ELSE
    BEGIN
        INSERT INTO Product (ID, name, categoryID, price, status)
        SELECT ID, name, categoryID, price, status
        FROM inserted
    END
END;
GO

----------------------------------------------------------------------------
----------------------------------------------------------------------------
------------------------------ EMPLOYEE ------------------------------------
----------------------------------------------------------------------------
----------------------------------------------------------------------------

USE WibuCoffee
GO

/*	CÁC CHƯC NĂNG CỦA EMPLOYEE */

--VIẾT VIEW HIỂN THỊ CHI TIẾT NHÂN VIÊN GỒM TÊN, CÔNG VIỆC (DỰA VÀO JOBID TÌM JOBDETAIL TRONG BẢNG JOB, SỐ CA (SỐ CA ĐƯỢC TÍNH BẰNG TỔNG SỐ CA TRONG VIEW EMPLOYEESHIFT), LƯƠNG (ĐƯỢC TÍNH BẰNG SỐ CA NHÂN VỚI SỐ GIỜ LÀM VIỆC TRONG MỘT CA VỚI NHÂN VIÊN CÓ MÃ LÀ EF THÌ 1 CA DÀI 8 TIẾNG CÒN MÃ EP THÌ MỘT CA DÀI 4 TIẾNG XONG NHÂN VỚI JOBSALARY */

DROP VIEW IF EXISTS EmployeeDetailView
GO

CREATE VIEW EmployeeDetailView
AS
SELECT Employee.name, Job.jobDetail AS job, COUNT(EmployeeShiftView.phone) AS shift, 
	CASE 
		WHEN Employee.ID LIKE 'EF%' THEN COUNT(EmployeeShiftView.phone) * 8 * Job.salary
		WHEN Employee.ID LIKE 'EP%' THEN COUNT(EmployeeShiftView.phone) * 4 * Job.salary
	END AS salary
FROM Employee , Job , EmployeeShiftView 
WHERE Employee.name <> 'NA' AND Employee.jobID = Job.ID AND Employee.phone = EmployeeShiftView.phone
GROUP BY Employee.name, Job.jobDetail, Employee.ID, Job.salary
GO

--VIẾT HÀM LẤY JOB DETAIL TỪ BẢNG JOB KHI BIẾT ID CÔNG VIỆC

DROP FUNCTION IF EXISTS getJobDetail
GO

CREATE FUNCTION getJobDetail
(
	@jobID NVARCHAR(3)
)
RETURNS NVARCHAR(max)
AS
BEGIN
	DECLARE @jobDetail NVARCHAR(max)
	SELECT @jobDetail = jobDetail
	FROM Job
	WHERE ID = @jobID
	RETURN @jobDetail
END
GO

--VIẾT FUNCTION LẤY RA THÔNG TIN NHÂN VIÊN TỪ BẢNG EMPLOYEE KHI BIẾT ID NHÂN VIÊN

DROP FUNCTION IF EXISTS getEmployeeInfo
GO

CREATE FUNCTION getEmployeeInfo
(
	@name NVARCHAR(max),
	@job NVARCHAR(max)
)
RETURNS TABLE
AS
RETURN
(
	SELECT * FROM Employee
	WHERE name = @name AND jobID = (SELECT ID FROM Job WHERE jobDetail = @job)
)
GO

--VIẾT HÀM LẤY RA DANH SÁCH NHÂN VIÊN TỪ BẢNG VIEW EMPLOYEEDETAILVIEW

DROP PROCEDURE IF EXISTS getEmployee
GO

CREATE PROCEDURE getEmployee
AS
BEGIN
	DECLARE @errorMessage NVARCHAR(max)
	BEGIN TRY
		EXEC SP_REFRESHVIEW 'EmployeeDetailView'
		SELECT * FROM EmployeeDetailView
	END TRY
	BEGIN CATCH
		SET @errorMessage = ERROR_MESSAGE()
		RAISERROR(@errorMessage, 16, 1)
	END CATCH
END
GO

--VIẾT HÀM LẤY RA CHI TIẾT CÔNG VIỆC TỪ BẢNG JOB

DROP PROCEDURE IF EXISTS getJob
GO

CREATE PROCEDURE getJob
AS
BEGIN
	DECLARE @errorMessage NVARCHAR(max)
	BEGIN TRY
		SELECT jobDetail FROM Job WHERE ID <> 'NA'
	END TRY
	BEGIN CATCH
		SET @errorMessage = ERROR_MESSAGE()
		RAISERROR(@errorMessage, 16, 1)
	END CATCH
END
GO

--VIẾT HÀM LẤY RA DANH SÁCH CA TRỰC TRONG BẢNG SHIFT

DROP PROCEDURE IF EXISTS getShift
GO

CREATE PROCEDURE getShift
AS
BEGIN
	DECLARE @errorMessage NVARCHAR(max)
	BEGIN TRY
		SELECT * FROM Shift
	END TRY
	BEGIN CATCH
		SET @errorMessage = ERROR_MESSAGE()
		RAISERROR(@errorMessage, 16, 1)
	END CATCH
END
GO

--VIẾT HÀM LẤY RA DANH SÁCH NHÂN VIÊN TRONG BẢNG EMPLOYEE

DROP PROCEDURE IF EXISTS getEmployeeList
GO

CREATE PROCEDURE getEmployeeList
AS
BEGIN
	DECLARE @errorMessage NVARCHAR(max)
	BEGIN TRY
		SELECT ID, name, phone, 
		(SELECT jobDetail FROM Job WHERE ID = jobID ) AS jobDetail
		FROM Employee
	END TRY
	BEGIN CATCH
	SET @errorMessage = ERROR_MESSAGE()
		RAISERROR(@errorMessage, 16, 1)
	END CATCH
END
GO

--VIẾT HÀM LẤY RA LƯƠNG CỦA CÔNG VIỆC CỤ THỂ

DROP FUNCTION IF EXISTS getSalary
GO

CREATE FUNCTION getSalary
	(@job NVARCHAR(max))
	RETURNS INT
AS
BEGIN
	DECLARE @salary INT
	SELECT @salary = salary
	FROM Job
	WHERE jobDetail = @job
	RETURN @salary
END
GO

--VIẾT HÀM CẬP NHẬT LƯƠNG CỦA CÔNG VIỆC

DROP PROCEDURE IF EXISTS updateSalary
GO

CREATE PROCEDURE updateSalary
	(@job NVARCHAR(max), @salary DECIMAL(10,2))
AS
BEGIN
	IF @salary <= 0
		THROW 50000, 'Lương không hợp lệ', 1
	ELSE IF @job = ''
		THROW 50000, 'Công việc không được để trống', 1
	ELSE IF NOT EXISTS (SELECT * FROM Job WHERE jobDetail = @job)
		THROW 50000, 'Công việc không tồn tại', 1
	ELSE
	BEGIN TRANSACTION
		DECLARE @errorMessage NVARCHAR(max)
		BEGIN TRY
			UPDATE Job
			SET salary = @salary
			WHERE jobDetail = @job
			COMMIT TRANSACTION
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION
			SET @errorMessage = ERROR_MESSAGE()
			RAISERROR(@errorMessage, 16, 1)
		END CATCH
END
GO

--VIẾT FUCTION LẤY RA MÃ NHÂN VIÊN TỪ BẢNG EMPLOYEE KHI BIẾT KÍ TỰ ĐẦU LÀ EF HOẶC EP

DROP FUNCTION IF EXISTS getEmployeeID
GO

CREATE FUNCTION getEmployeeID
(
	@empCategory NVARCHAR(max)
)
RETURNS TABLE
AS
RETURN
(
	SELECT name FROM Employee 
	WHERE (@empCategory = 'Fulltime' AND ID LIKE 'EF%')
		OR (@empCategory <> 'Fulltime' AND ID LIKE 'EP%')
)
GO

--VIẾT HÀM LẤY RA THÔNG TIN NHÂN VIÊN TỪ VIEW EMPLOYEEDETAILVIEW KHI BIẾT DANH SÁCH TÊN NHÂN VIÊN

DROP FUNCTION IF EXISTS getEmployeeInfoByName
GO

CREATE FUNCTION getEmployeeInfoByName
(
	@name NVARCHAR(max)
)
RETURNS TABLE
AS
RETURN
(
	SELECT * FROM EmployeeDetailView
	WHERE name = @name
)
GO

--VIẾT HÀM LẤY RA THÔNG TIN NHÂN VIÊN TỪ VIEW EMPLOYEEDETAILVIEW KHI BIẾT CÔNG VIỆC

DROP FUNCTION IF EXISTS getEmployeeInfoByJob
GO

CREATE FUNCTION getEmployeeInfoByJob
(
	@job NVARCHAR(max)
)
RETURNS TABLE
AS
RETURN
(
	SELECT * FROM EmployeeDetailView
	WHERE job = @job
)
GO

--VIẾT HÀM LẤY RA TÊN NHÂN VIÊN TỪ BẢNG EMPLOYEE KHI NGÀY TUYỂN DỤNG

DROP FUNCTION IF EXISTS getEmployeeNameByRecruitmentDate
GO

CREATE FUNCTION getEmployeeNameByRecruitmentDate
(
	@recruitmentDate DATE
)
RETURNS TABLE
AS
RETURN
(
	SELECT name FROM Employee
	WHERE recruitmentDate = @recruitmentDate
)
GO

--VIẾT HÀM TẠO ID NHÂN VIÊN TỰ ĐỘNG

DROP FUNCTION IF EXISTS createID
GO

CREATE FUNCTION createID
(
	@empCategory VARCHAR(max)
)
RETURNS NVARCHAR(4)
AS
BEGIN
	DECLARE @id NVARCHAR(4)
	--LẤY ID NHÂN VIÊN CUỐI CÙNG
	DECLARE @lastID NVARCHAR(4)
	IF @empCategory = 'Fulltime'
		SELECT @lastID = MAX(ID)
		FROM Employee
		WHERE ID LIKE 'EF%'
	ELSE
		SELECT @lastID = MAX(ID)
		FROM Employee
		WHERE ID LIKE 'EP%'
	--NẾU CHƯA CÓ NHÂN VIÊN NÀO THÌ ID SẼ BẮT ĐẦU BẰNG 'EF01' HOẶC EP01
	IF @lastID IS NULL
		IF @empCategory = 'Fulltime'
			SET @id = 'EF01'
		ELSE
			SET @id = 'EP01'
	ELSE
		IF @empCategory = 'Fulltime'
			SET @id = 'EF' + RIGHT('00' + CAST(CAST(RIGHT(@lastID, 2) AS INT) + 1 AS NVARCHAR(2)), 2)
		ELSE
			SET @id = 'EP' + RIGHT('00' + CAST(CAST(RIGHT(@lastID, 2) AS INT) + 1 AS NVARCHAR(2)), 2)
	RETURN @id
END
GO

--VIẾT HÀM TẠO NHÂN VIÊN

DROP PROCEDURE IF EXISTS insertEmployee
GO

CREATE PROCEDURE insertEmployee
	@id VARCHAR(4),
	@name NVARCHAR(max),
	@birth DATETIME,
	@address NVARCHAR(max),
	@phone VARCHAR(10),
	@recruitmentDate DATETIME,
	@jobName NVARCHAR(max),
	@penatyPoint INT,
	@bonusPoint INT,
	@numberOfShift INT
AS
BEGIN
	IF @name = ''
		THROW 50000, 'Tên nhân viên không được để trống', 1
	ELSE IF @address = ''
		THROW 50000, 'Địa chỉ không được để trống', 1
	ELSE IF @phone = ''
		THROW 50000, 'Số điện thoại không được để trống', 1
	ELSE
		BEGIN TRANSACTION
			DECLARE @jobID NVARCHAR(4)
			DECLARE @empCategory NVARCHAR(max)
			--LẤY ID CỦA CÔNG VIỆC
			SELECT @jobID = ID
			FROM Job
			WHERE jobDetail = @jobName
			--THÊM NHÂN VIÊN
			DECLARE @errorMessage NVARCHAR(max)
			BEGIN TRY
				INSERT INTO Employee(ID, name, birthDate, address, phone, recruitmentDate, jobID, penaltyPoint, bonusPoint, numberOfShift)
				VALUES(@id, @name, CAST (@birth AS DATE), @address, @phone, CAST (@recruitmentDate AS DATE), @jobID, @penatyPoint, @bonusPoint, @numberOfShift)
				COMMIT TRANSACTION
			END TRY
			BEGIN CATCH
				ROLLBACK TRANSACTION
				SET @errorMessage = ERROR_MESSAGE()
				RAISERROR(@errorMessage, 16, 1)
			END CATCH
			--REFESH EmployeeDetailView
			EXEC SP_REFRESHVIEW 'EmployeeDetailView'
END
GO

--VIẾT HÀM CẬP NHẬT THÔNG TIN NHÂN VIÊN

DROP PROCEDURE IF EXISTS updateEmployee
GO

CREATE PROCEDURE updateEmployee
	@id VARCHAR(4),
	@name NVARCHAR(max),
	@birth DATETIME,
	@address NVARCHAR(max),
	@phone VARCHAR(10),
	@recruitmentDate DATETIME,
	@jobName NVARCHAR(max),
	@penatyPoint INT,
	@bonusPoint INT,
	@numberOfShift INT
AS
BEGIN
	IF @name = ''
		THROW 50000, 'Tên nhân viên không được để trống', 1
	ELSE IF @address = ''
		THROW 50000, 'Địa chỉ không được để trống', 1
	ELSE IF @phone = ''
		THROW 50000, 'Số điện thoại không được để trống', 1
	ELSE
		BEGIN TRANSACTION
			DECLARE @jobID NVARCHAR(4)
			DECLARE @empCategory NVARCHAR(max)
			--LẤY ID CỦA CÔNG VIỆC
			SELECT @jobID = ID
			FROM Job
			WHERE jobDetail = @jobName
			--CẬP NHẬT NHÂN VIÊN
			DECLARE @errorMessage NVARCHAR(max)
			BEGIN TRY
				UPDATE Employee 
				SET name = @name, birthDate = CAST (@birth AS DATE), address = @address, phone = @phone, recruitmentDate = CAST (@recruitmentDate AS DATE), jobID = @jobID, penaltyPoint = @penatyPoint, bonusPoint = @bonusPoint, numberOfShift = @numberOfShift
				WHERE ID = @id
				COMMIT TRANSACTION
			END TRY
			BEGIN CATCH
				ROLLBACK TRANSACTION
				SET @errorMessage = ERROR_MESSAGE()
				RAISERROR(@errorMessage, 16, 1)
			END CATCH
			--REFESH EmployeeDetailView
			EXEC SP_REFRESHVIEW 'EmployeeDetailView'
END
GO

--VIẾT TRIGGER TRƯỚC KHI XÓA NHÂN VIÊN THÌ SET MÃ NHÂN VIÊN TRONG CÁC BẢNG BILL, RECEIPTNOTE, ON_DUTY VỀ NHÂN VIÊN CÓ MÃ LÀ N/A

DROP TRIGGER IF EXISTS setEmployeeToNA
GO

CREATE TRIGGER setEmployeeToNA
ON Employee
INSTEAD OF DELETE
AS
BEGIN
	BEGIN TRANSACTION
		DECLARE @errorMessage NVARCHAR(max)
		BEGIN TRY
			UPDATE Bill
			SET empID = 'NA'
			WHERE empID = (SELECT ID FROM DELETED)

			UPDATE ReceiptNote
			SET empID = 'NA'
			WHERE empID = (SELECT ID FROM DELETED)

			UPDATE On_Duty
			SET empID = 'NA'
			WHERE empID = (SELECT ID FROM DELETED)

			DELETE FROM Employee
			WHERE ID = (SELECT ID FROM DELETED)

			COMMIT TRANSACTION
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION
			SET @errorMessage = ERROR_MESSAGE()
			RAISERROR(@errorMessage, 16, 1)
		END CATCH
END
GO

--VIẾT HÀM XÓA NHÂN VIÊN

DROP PROCEDURE IF EXISTS deleteEmployeeByID
GO

CREATE PROCEDURE deleteEmployeeByID
	@id VARCHAR(4)
AS
BEGIN
	BEGIN TRANSACTION
		DECLARE @errorMessage NVARCHAR(max)
		BEGIN TRY
			DELETE FROM Employee
			WHERE ID = @id
			COMMIT TRANSACTION
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION
			SET @errorMessage = ERROR_MESSAGE()
			RAISERROR(@errorMessage, 16, 1)
		END CATCH
		--REFESH EmployeeDetailView
		EXEC SP_REFRESHVIEW 'EmployeeDetailView'
END
GO

--VIẾT HÀM THÊM NHÂN VIÊN VÀO BẢNG ON DUTY

DROP PROCEDURE IF EXISTS insertEmployeeToShift
GO

CREATE PROCEDURE insertEmployeeToShift
	@phone VARCHAR(10),
	@date DATE,
	@shiftID VARCHAR(5)
AS
BEGIN
	BEGIN TRANSACTION
		--THÊM NHÂN VIÊN VÀO BẢNG ON DUTY
		DECLARE @id VARCHAR(4)
		SELECT @id = ID FROM Employee WHERE phone = @phone
		DECLARE @errorMessage NVARCHAR(max)
		BEGIN TRY
			INSERT INTO On_Duty(empID, shiftID,  date)
			VALUES(@id, @shiftID, @date)
			COMMIT TRANSACTION
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION
			SET @errorMessage = ERROR_MESSAGE()
			RAISERROR(@errorMessage, 16, 1)
		END CATCH
		--REFESH EmployeeShiftView
		EXEC SP_REFRESHVIEW 'EmployeeShiftView'
END
GO

--VIẾT HÀM UPDATE NHÂN VIÊN TRONG BẢNG ON DUTY

DROP PROCEDURE IF EXISTS updateEmployeeInShift
GO

CREATE PROCEDURE updateEmployeeInShift
	@phone VARCHAR(10),
	@date DATE,
	@shiftID VARCHAR(5)
AS
BEGIN
	BEGIN TRANSACTION
		--CẬP NHẬT NHÂN VIÊN TRONG BẢNG ON DUTY
		DECLARE @id VARCHAR(4)
		SELECT @id = ID FROM Employee WHERE phone = @phone
		DECLARE @errorMessage NVARCHAR(max)
		BEGIN TRY
			UPDATE On_Duty
			SET empID = @id
			WHERE date = @date AND shiftID = @shiftID
			COMMIT TRANSACTION
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION
			SET @errorMessage = ERROR_MESSAGE()
			RAISERROR(@errorMessage, 16, 1)
		END CATCH
		--REFESH EmployeeShiftView
		EXEC SP_REFRESHVIEW 'EmployeeShiftView'
END
GO

--VIẾT HÀM XÓA NHÂN VIÊN TRONG BẢNG ON DUTY

DROP PROCEDURE IF EXISTS deleteEmployeeInShift
GO

CREATE PROCEDURE deleteEmployeeInShift
	@phone VARCHAR(10)
AS
BEGIN
	BEGIN TRANSACTION
		--XÓA NHÂN VIÊN TRONG BẢNG ON DUTY
		DECLARE @errorMessage NVARCHAR(max)
		BEGIN TRY
			DELETE FROM On_Duty
			WHERE empID = (SELECT ID FROM Employee WHERE phone = @phone)
		END TRY
		BEGIN CATCH
			SET @errorMessage = ERROR_MESSAGE()
			RAISERROR(@errorMessage, 16, 1)
		END CATCH
		--REFESH EmployeeShiftView
		EXEC SP_REFRESHVIEW 'EmployeeShiftView'
END
GO

/* CÁC CHỨC NĂNG CỦA XẾP CA TRỰC */

-- VIẾT VIEW HIỂN THỊ CHI TIẾT CA TRỰC GỒM TÊN NHÂN VIÊN, SỐ ĐIỆN THOẠI, CA TRỰC, NGÀY TRỰC	THEO TUẦN (TỪ THỨ 2 ĐẾN CHỦ NHẬT) VÀ SẮP XẾP THEO NGÀY TRỰC CÙNG NGÀY TRỰC SẼ SẮP XẾP THEO CA TRỰC

DROP VIEW IF EXISTS ShiftDetailView
GO

CREATE VIEW ShiftDetailView
AS
SELECT Employee.name, Employee.phone, EmployeeShiftView.ID, EmployeeShiftView.date
FROM Employee, EmployeeShiftView
WHERE Employee.phone = EmployeeShiftView.phone
GO

DROP PROCEDURE IF EXISTS getShiftDetail
GO

CREATE PROCEDURE getShiftDetail
AS
BEGIN
	SELECT * FROM ShiftDetailView
	ORDER BY date ASC, ID ASC
END
GO

--VIẾT HÀM LẤY RA DANH SÁCH TỪ VIEW ShiftDetailView TRONG TUẦN CỦA NGÀY HIỆN TẠI

DROP PROCEDURE IF EXISTS getShiftDetailByWeek
GO

CREATE PROCEDURE getShiftDetailByWeek
AS
BEGIN
	DECLARE @firstDayOfWeek DATE --NGÀY ĐẦU TIÊN CỦA TUẦN
	DECLARE @lastDayOfWeek DATE --NGÀY CUỐI CÙNG CỦA TUẦN
	DECLARE @errorMessage NVARCHAR(max)
		BEGIN TRY
		SET @firstDayOfWeek = DATEADD(DAY, -(DATEPART(WEEKDAY, GETDATE()) - 2), CAST(GETDATE() AS DATE))
		SET @lastDayOfWeek = DATEADD(DAY, 6 - (DATEPART(WEEKDAY, GETDATE()) - 2), CAST(GETDATE() AS DATE))
	
		SELECT * FROM ShiftDetailView
		WHERE date BETWEEN @firstDayOfWeek AND @lastDayOfWeek
		ORDER BY date ASC, ID ASC
	END TRY
	BEGIN CATCH
		SET @errorMessage = ERROR_MESSAGE()
		RAISERROR(@errorMessage, 16, 1)
	END CATCH
END
GO

--VIẾT HÀM LẤY RA DANH SÁCH TỪ VIEW ShiftDetailView TRONG TUẦN TIẾP THEO CỦA NGÀY HIỆN TẠI

DROP PROCEDURE IF EXISTS getNextWeekShiftDetail
GO

CREATE PROCEDURE getNextWeekShiftDetail
AS
BEGIN
	DECLARE @firstDayOfWeek DATE --NGÀY ĐẦU TIÊN CỦA TUẦN
	DECLARE @lastDayOfWeek DATE --NGÀY CUỐI CÙNG CỦA TUẦN
	DECLARE @errorMessage NVARCHAR(max)

	BEGIN TRY
		SET @firstDayOfWeek = DATEADD(DAY, -(DATEPART(WEEKDAY, GETDATE()) - 2) + 7, CAST(GETDATE() AS DATE))
		SET @lastDayOfWeek = DATEADD(DAY, 6 - (DATEPART(WEEKDAY, GETDATE()) - 2) + 7, CAST(GETDATE() AS DATE))
	
		SELECT * FROM ShiftDetailView
		WHERE date BETWEEN @firstDayOfWeek AND @lastDayOfWeek
		ORDER BY date ASC, ID ASC
	END TRY
	BEGIN CATCH
		SET @errorMessage = ERROR_MESSAGE()
		RAISERROR(@errorMessage, 16, 1)
	END CATCH
END
GO

--VIẾT FUNCTION LỌC NHÂN VIÊN THEO TÊN NHÂN VIÊN TRONG SHIFTDETAILVIEW

DROP FUNCTION IF EXISTS filterEmployeeByName
GO

CREATE FUNCTION filterEmployeeByName
	(@name NVARCHAR(max))
RETURNS TABLE
AS
RETURN
(
	SELECT * FROM ShiftDetailView
	WHERE name LIKE '%' + @name + '%'
)
GO

--VIẾT FUNCTION LỌC NHÂN VIÊN THEO NGÀY TRỰC TRONG SHIFTDETAILVIEW

DROP FUNCTION IF EXISTS filterEmployeeByDate
GO

CREATE FUNCTION filterEmployeeByDate
	(@date DATE)
RETURNS TABLE
AS
RETURN
(
	SELECT * FROM ShiftDetailView
	WHERE date = @date
)
GO

----------------------------------------------------------------------------
----------------------------------------------------------------------------
------------------------------ MATERIAL ------------------------------------
----------------------------------------------------------------------------
----------------------------------------------------------------------------

USE WibuCoffee
GO

--- PROCEDURE Thêm material ---	

--- PROCEDURE ---
DROP PROCEDURE IF EXISTS AddMaterial
GO
CREATE PROCEDURE AddMaterial
    @ID VARCHAR(3),
    @name NVARCHAR(max),
    @status DECIMAL(10,2)
	
AS
BEGIN
	IF (@name = '' OR @name = NULL OR @status > 0   ) 
		THROW 50000, 'Không được để trống tên hoặc trạng thái ', 1
	ELSE
		INSERT INTO Material (ID, name, status)
		VALUES (@ID, @name, @status)
	
END;
GO

--- PROCEDURE Sửa material ---
DROP PROCEDURE IF EXISTS UpdateMaterial
GO
CREATE PROCEDURE UpdateMaterial
    @ID VARCHAR(3),
    @name NVARCHAR(max),
    @status DECIMAL(10,2)
AS
BEGIN
	IF (@name = '' OR @name = NULL OR @status > 0  ) 
		THROW 50000, 'Không được để trống tên hoặc trạng thái ', 1
	ELSE
		UPDATE Material
		SET name = @name, status = @status
		WHERE ID = @ID
END;
GO

																	
--- Procedure KIểm tra trạng thái khi thêm trạng thái ---
DROP PROCEDURE IF EXISTS updateProductStatus
GO
CREATE PROCEDURE updateProductStatus
AS
BEGIN
    SET NOCOUNT ON;

    -- Temporary table to store minimum product counts based on material availability
    CREATE TABLE #ProductStatusUpdate (
        ProductID VARCHAR(50),
        MaxProductCount INT
    );

    -- Insert the calculated maximum product counts into the temporary table
    INSERT INTO #ProductStatusUpdate (ProductID, MaxProductCount)
    SELECT 
        pm.ProductID,
        MIN(m.status / pm.quantity) AS MaxProductCount
    FROM 
        Product_Material pm
    INNER JOIN 
        Material m ON pm.MaterialID = m.ID
    GROUP BY 
        pm.ProductID;

    -- Update the Product table's status with the least number of products that can be made
    UPDATE 
        Product
    SET 
        status = psu.MaxProductCount
    FROM 
        Product p
    INNER JOIN 
        #ProductStatusUpdate psu ON p.ID = psu.ProductID;

    -- Cleanup temporary table
    DROP TABLE #ProductStatusUpdate;
END;
GO

EXEC dbo.updateProductStatus


-- TRIGGER tự động đặt ID
DROP TRIGGER IF EXISTS UpdateMaterialID
GO
CREATE TRIGGER UpdateMaterialID
ON Material
AFTER INSERT

AS
BEGIN
    DECLARE @lastID VARCHAR(3)
    SELECT TOP 1 @lastID = ID
    FROM Material
    ORDER BY ID DESC

    DECLARE @newID VARCHAR(3)
    SET @newID = 'M' + RIGHT(CAST(CAST(RIGHT(@lastID, 2) AS INT) + 1 AS VARCHAR(2)), 2)

    UPDATE Material
    SET ID = @newID
    WHERE ID IN (SELECT ID FROM inserted)
END;
GO
															---TRIGGER---

---- TRIGGER ROLL back lại khi người dùng nhập tên trùng ---
DROP TRIGGER IF EXISTS PreventDuplicateMaterialName
GO
CREATE OR ALTER TRIGGER PreventDuplicateMaterialName
ON Material
INSTEAD OF INSERT
AS
BEGIN
    DECLARE @ExistingName NVARCHAR(max);
    SELECT @ExistingName = name FROM Material WHERE name IN (SELECT name FROM inserted);

    IF @ExistingName IS NOT NULL
    BEGIN
        RAISERROR ('Cannot insert. Material with the same name already exists.', 16, 1);
        ROLLBACK TRANSACTION;
    END
    ELSE
    BEGIN
        INSERT INTO Material (ID, name, status)
        SELECT ID, name, status FROM inserted;
    END
END;
GO
																	--- FUNCTION ---
--- TẠO Function lọc ra các Material có tình trạng còn hàng ---
DROP FUNCTION IF EXISTS FilterMaterialsByStatus
GO
CREATE FUNCTION FilterMaterialsByStatus
(
    @materialStatus NVARCHAR(MAX)
)
RETURNS TABLE
AS
RETURN
(
    SELECT *
    FROM Material
    WHERE status LIKE '%' + @materialStatus + '%'
);

GO

DROP TRIGGER IF EXISTS updateProduct_MaterialTrigger
GO

CREATE TRIGGER updateProduct_MaterialTrigger
ON Material
AFTER UPDATE
AS
BEGIN
     SET NOCOUNT ON;

    -- Prevent trigger from firing recursively
    IF TRIGGER_NESTLEVEL() > 1 RETURN;
    -- Call the procedure to update product statuses
    EXEC updateProductStatus;
END;
GO 

-- Tạo funcion lọc Material theo tên
DROP FUNCTION IF EXISTS FilterMaterialsByName
GO
CREATE FUNCTION FilterMaterialsByName
(
    @materialName NVARCHAR(MAX)
)
RETURNS TABLE
AS
RETURN
(
    SELECT *
    FROM Material
    WHERE name LIKE '%' + @materialName + '%'
);
GO 


--- tạo function lọc MAterial theo ID ---
DROP FUNCTION IF EXISTS FilterMaterialsByID
GO
CREATE FUNCTION FilterMaterialsByID
(
    @materialID VARCHAR(3)
)
RETURNS TABLE
AS
RETURN
(
    SELECT *
    FROM Material
    WHERE ID = @materialID
);

GO
																	--- VIEW ---
--- Tạo view ---
DROP VIEW IF EXISTS MaterialDetailss
GO
CREATE VIEW MaterialDetailss
AS
SELECT *
FROM Material;
GO

----------------------------------------------------------------------------
----------------------------------------------------------------------------
------------------------------ SUPPLIER ------------------------------------
----------------------------------------------------------------------------
----------------------------------------------------------------------------

USE WibuCoffee
GO

-- Hàm thủ tục cho Supplier --


-- PROCEDURE thêm một nhà cung cấp --
DROP PROCEDURE IF EXISTS AddSupplier
GO
CREATE PROCEDURE AddSupplier
    @ID VARCHAR(4),
    @name NVARCHAR(max),
    @phone VARCHAR(10),
	@address NVARCHAR(max)
AS
BEGIN
	IF (@name = '' OR @name = NULL OR @phone = NULL OR @phone = '' OR @address = '' OR @address = NULL   ) 
		THROW 50000, 'Không được để trống tên hoặc số điện thoại hoặc địa chỉ ', 1
	ELSE
		INSERT INTO Supplier (ID, name, address, phone)
		VALUES (@ID, @name, @address, @phone)
END
GO

-- PROCEDURE sửa một nhà cung cấp --
DROP PROCEDURE IF EXISTS UpdateSupplier
GO
CREATE PROCEDURE UpdateSupplier
    @ID VARCHAR(4),
    @name NVARCHAR(max),
	@phone VARCHAR(10),
    @address NVARCHAR(max)
    
AS
BEGIN
	IF (@name = '' OR @name = NULL OR @phone = NULL OR @phone = '' OR @address = '' OR @address = NULL   ) 
		THROW 50000, 'Không được để trống tên hoặc số điện thoại hoặc địa chỉ ', 1
	ELSE
		UPDATE Supplier
		SET name = @name, address = @address, phone = @phone
		WHERE ID = @ID
END
GO

-- PROCEDURE xóa một nhà cung cấp 
DROP PROCEDURE IF EXISTS DeleteSupplier
GO
CREATE PROCEDURE DeleteSupplier 
@ID VARCHAR(4)

 AS
BEGIN
    UPDATE Supplier
    SET address = N'Hết hạn hợp đồng'
	WHERE ID = @ID;

END
GO
															--Trigger --
-- TRIGGER tự động đặt ID
DROP TRIGGER IF EXISTS UpdateSupplierID
GO
CREATE TRIGGER UpdateSupplierID
ON Supplier
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @lastID VARCHAR(4);
    DECLARE @newID VARCHAR(4);

    -- Find the maximum ID from the current table
    SELECT @lastID = MAX(ID) FROM Supplier;
    IF @lastID IS NOT NULL
        SET @newID = 'SP' + RIGHT('00' + CAST(CAST(SUBSTRING(@lastID, 3, 2) AS INT) + 1 AS VARCHAR(2)), 2);
    ELSE
        SET @newID = 'SP01'; -- Default starting ID if no existing data

    -- Update the newly inserted record with a new ID
    -- This assumes that only one record is inserted at a time
    UPDATE Supplier
    SET ID = @newID
    WHERE ID IN (SELECT ID FROM inserted);
END;
GO

-- Trigger kiểm tra xem có phải có người cố gắng thêm Nhà cung cấp mà trùng số điện thoại
DROP TRIGGER IF EXISTS SamePhone;
GO
CREATE TRIGGER SamePhone
ON Supplier
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @phone VARCHAR(20);
    DECLARE cur CURSOR FOR 
        SELECT phone FROM inserted;

    OPEN cur;

    FETCH NEXT FROM cur INTO @phone;

    WHILE @@FETCH_STATUS = 0
    BEGIN
        IF EXISTS (
            SELECT 1 
            FROM Supplier 
            WHERE phone = @phone
            GROUP BY phone
            HAVING COUNT(*) > 1
        )
        BEGIN
            RAISERROR ('Không thể chèn. Nhà cung cấp với cùng số điện thoại đã tồn tại.', 16, 1);
            ROLLBACK;
            RETURN;
        END

        FETCH NEXT FROM cur INTO @phone;
    END

    CLOSE cur;
    DEALLOCATE cur;
END;
GO

																	-- FUNCTION ---
-- Lọc nhà cung cấp dựa trên ID -- 
DROP FUNCTION IF EXISTS GetSupplierByID
GO 

CREATE FUNCTION GetSupplierByID
(
    @ID VARCHAR(4)
)
RETURNS TABLE
AS
RETURN
(
    SELECT *
    FROM Supplier
    WHERE ID = @ID
); 
GO


-- Lọc theo tên của nhà cung cấp --
DROP FUNCTION IF EXISTS FilterSuppliersByName
GO 
CREATE FUNCTION FilterSuppliersByName
(
    @supplierName NVARCHAR(MAX)
)
RETURNS TABLE
AS
RETURN
(
    SELECT *
    FROM Supplier
    WHERE name LIKE '%' + @supplierName + '%'
);
GO

-- Lọc theo địa chỉ của nhà cung cấp
DROP FUNCTION IF EXISTS FilterSuppliersByAddress
GO 
CREATE FUNCTION FilterSuppliersByAddress
(
    @supplierAddress NVARCHAR(MAX)
)
RETURNS TABLE
AS
RETURN
(
    SELECT *
    FROM Supplier
    WHERE address LIKE '%' + @supplierAddress + '%'
);
GO
-- Lọc nhà cung cấp dựa trên số điện thoại  --
DROP FUNCTION IF EXISTS FilterSuppliersByPhone
GO 

CREATE FUNCTION FilterSuppliersByPhone
(
    @supplierPhone VARCHAR(10)
)
RETURNS TABLE
AS
RETURN
(
    SELECT *
    FROM Supplier
    WHERE phone = @supplierPhone
);
GO

-- Tạo VIEW SupplierList Hiển thị đầy đủ toàn bộ thuộc tính -- 
DROP VIEW IF EXISTS SupplierList
GO

CREATE VIEW SupplierList AS
SELECT *
FROM Supplier
WHERE address <> N'Hết hạn hợp đồng';

GO

----------------------------------------------------------------------------
----------------------------------------------------------------------------
------------------------------ RECEIPT_NOTE --------------------------------
----------------------------------------------------------------------------
----------------------------------------------------------------------------

                                      /* CÁC CHỨC NĂNG Ở RECEIPT-NOTE */
USE WibuCoffee
GO


/* Tạo view cho bảng đơn nhập hàng - để hiển thị trên UI */
DROP VIEW IF EXISTS ReceiptNoteView
GO

CREATE VIEW ReceiptNoteView
AS
SELECT rn.ID, rn.date, s.name [Supplier Name], e.name [Employee Name], rn.price FROM ReceiptNote rn, Supplier s, Employee e
WHERE rn.empID = e.ID AND rn.supplierID = s.ID
GO

SELECT * FROM ReceiptNoteView

/* FUNCTION lọc bảng đơn nhập hàng theo ID */
DROP FUNCTION IF EXISTS filterReceiptNoteViewByID
GO

CREATE FUNCTION filterReceiptNoteViewByID
(
	@id VARCHAR(7)
)
RETURNS TABLE
AS
RETURN
	SELECT * FROM ReceiptNoteView WHERE ID = @id;
GO

/* FUNCTION lọc bảng đơn nhập hàng theo Nhà cung cấp */
DROP FUNCTION IF EXISTS filterReceiptNoteViewBySupplier
GO

CREATE FUNCTION filterReceiptNoteViewBySupplier
(
	@supName NVARCHAR(MAX)
)
RETURNS TABLE
AS
RETURN
	SELECT * FROM ReceiptNoteView WHERE [Supplier Name] = @supName;
GO

/* FUNCTION lọc bảng đơn nhập hàng theo Nhân viên nhập*/
DROP FUNCTION IF EXISTS filterReceiptNoteViewByEmployee
GO

CREATE FUNCTION filterReceiptNoteViewByEmployee
(
	@empName NVARCHAR(MAX)
)
RETURNS TABLE
AS
RETURN
	SELECT * FROM ReceiptNoteView WHERE [Employee Name] = @empName;
GO

/* FUNCTION lọc bảng đơn nhập hàng theo ngày nhập hàng */
DROP FUNCTION IF EXISTS filterReceiptNoteViewByDate
GO

CREATE FUNCTION filterReceiptNoteViewByDate
(
	@date DATE
)
RETURNS TABLE
AS
RETURN
	SELECT * FROM ReceiptNoteView WHERE date = @date;
GO

/* PROC thêm đơn mới vào table đơn nhập hàng */
DROP PROC IF EXISTS addNewReceiptNote
GO

CREATE PROC addNewReceiptNote
	@date DATE,
	@empName NVARCHAR(MAX),
	@supName NVARCHAR(MAX)
AS
BEGIN
	IF (@date > GETDATE())
		THROW 50000, N'Vui lòng không nhập ngày trong tương lai.', 255
	ELSE IF (@supName = N'')
		THROW 50000, N'Vui lòng chọn nhà cung cấp.', 255
	ELSE IF (@empName = N'')
		THROW 50000, N'Vui lòng chọn nhân viên nhập hàng.', 255

	DECLARE @supID VARCHAR(4), @empID VARCHAR(4);
	SELECT @supID = ID FROM Supplier WHERE name = @supName;
	SELECT @empID = ID FROM Employee WHERE name = @empName;
	INSERT INTO ReceiptNote(ID, date, price, supplierID, empID) VALUES('', @date, 0, @supID, @empID);
END;
GO

/* Trigger tự động thêm ID cho Receipt Note thêm vào */
--SELECT CONCAT('B', RIGHT('000000' + CAST(@max_ID + 1 AS VARCHAR), 6));
DROP TRIGGER IF EXISTS setReceiptNoteIDTrigger
GO

CREATE TRIGGER setReceiptNoteIDTrigger
ON ReceiptNote
AFTER INSERT
AS
BEGIN
    DECLARE @max_id INT;
    DECLARE @new_id VARCHAR(7);
  
    SELECT @max_id = MAX(CAST(SUBSTRING(ID, 3, LEN(ID)) AS INT)) FROM ReceiptNote WHERE ID LIKE 'RN%';
    
    -- Tạo ID mới
    IF @max_id IS NULL
        SET @new_id = 'RN00001';
    ELSE
        SET @new_id = 'RN' + RIGHT('00000' + CAST(@max_id + 1 AS VARCHAR), 5);
    
    -- Gán ID mới cho bản ghi sẽ được chèn vào
    UPDATE ReceiptNote SET ID = @new_id WHERE ID = '';
END;
GO

/* PROC sửa một đơn đã có trong table đơn nhập hàng */
DROP PROC IF EXISTS updateNewReceiptNote
GO

CREATE PROC updateNewReceiptNote
	@id VARCHAR(7),
	@date DATE,
	@empName NVARCHAR(MAX),
	@supName NVARCHAR(MAX)
AS
BEGIN
	IF (@date > GETDATE())
		THROW 50000, N'Vui lòng không nhập ngày trong tương lai.', 255

	DECLARE @supID VARCHAR(4), @empID VARCHAR(4);
	SELECT @supID = ID FROM Supplier WHERE name = @supName;
	SELECT @empID = ID FROM Employee WHERE name = @empName;
	UPDATE ReceiptNote 
	SET date = @date, supplierID = @supID, empID = @empID
	WHERE ID = @id;
END;
GO

/* PROC xóa một đơn đã có trong table đơn nhập hàng */
DROP PROC IF EXISTS deleteReceiptNote
GO

CREATE PROC deleteReceiptNote
	@id VARCHAR(7)
AS
BEGIN
	IF (@id = '')
		THROW 50000, N'Vui lòng chọn đơn nhập hàng cần xóa trong bảng dữ liệu.', 255
	DELETE ReceiptNote WHERE ID = @id;
END;

/* Trigger xóa chi tiết phiếu nhập liên quan khi xóa một phiếu nhập */
DROP TRIGGER IF EXISTS deleteReceiptNoteDetailTrigger
GO

CREATE TRIGGER deleteReceiptNoteDetailTrigger
ON ReceiptNote
INSTEAD OF DELETE
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM ReceiptNoteDetail
    WHERE rNoteID IN (SELECT deleted.ID FROM deleted);

	DELETE FROM ReceiptNote
    WHERE ID IN (SELECT ID FROM deleted);
END;
GO

/* Tạo view cho bảng danh sách đơn nhập hàng khi nhấn vào chi tiết - để hiển thị trên UI */
DROP VIEW IF EXISTS ReceiptNoteListView
GO

CREATE VIEW ReceiptNoteListView
AS
SELECT ID, date, [Employee Name], [Supplier Name] FROM ReceiptNoteView
GO

SELECT * FROM ReceiptNoteListView

/* FUNCTION lọc bảng đơn nhập hàng theo ID*/
DROP FUNCTION IF EXISTS filterReceiptNoteListViewByID
GO

CREATE FUNCTION filterReceiptNoteListViewByID
(
	@id VARCHAR(7)
)
RETURNS TABLE
AS
RETURN
	SELECT * FROM ReceiptNoteListView WHERE ID = @id;
GO

/* FUNCTION lọc bảng đơn nhập hàng theo Nhà cung cấp */
DROP FUNCTION IF EXISTS filterReceiptNoteListViewBySupplier
GO

CREATE FUNCTION filterReceiptNoteListViewBySupplier
(
	@supName NVARCHAR(MAX)
)
RETURNS TABLE
AS
RETURN
	SELECT * FROM ReceiptNoteListView WHERE [Supplier Name] = @supName;
GO

/* FUNCTION lọc bảng đơn nhập hàng theo Nhân viên nhập*/
DROP FUNCTION IF EXISTS filterReceiptNoteListViewByEmployee
GO

CREATE FUNCTION filterReceiptNoteListViewByEmployee
(
	@empName NVARCHAR(MAX)
)
RETURNS TABLE
AS
RETURN
	SELECT * FROM ReceiptNoteListView WHERE [Employee Name] = @empName;
GO


/* FUNCTION lọc bảng đơn nhập hàng theo ngày nhập hàng */
DROP FUNCTION IF EXISTS filterReceiptNoteListViewByDate
GO

CREATE FUNCTION filterReceiptNoteListViewByDate
(
	@date DATE
)
RETURNS TABLE
AS
RETURN
	SELECT * FROM ReceiptNoteListView WHERE date = @date;
GO

/* FUNCTION trả về bảng cho Thông Tin chi tiết đơn nhập hàng đã chọn */
DROP FUNCTION IF EXISTS seeReceiptNoteDetail
GO

CREATE FUNCTION seeReceiptNoteDetail
(
	@id VARCHAR(7)
)
RETURNS TABLE
AS
RETURN
(
	SELECT m.name, rnd.quantity, rnd.unitPrice, rnd.quantity*rnd.unitPrice as price FROM ReceiptNote rn, ReceiptNoteDetail rnd, Material m
	WHERE rn.ID = rnd.rNoteID AND rnd.materialID = m.ID AND rn.ID = @id
);
GO

/* PROC xóa chi tiết phiếu nhập theo rNoteID và materialID */
DROP PROC IF EXISTS deleteReceiptNoteDetail
GO

CREATE PROC deleteReceiptNoteDetail
	@rNoteID VARCHAR(7),
	@materialID VARCHAR(3)
AS
BEGIN
	IF @materialID IS NULL
		THROW 50000, N'Vui lòng chọn thông tin chi tiết cần xóa.', 255

	DELETE ReceiptNoteDetail WHERE rNoteID = @rNoteID AND materialID = @materialID;
END;
GO

/* PROC thêm chi tiết phiếu nhập */
DROP PROC IF EXISTS addReceiptNoteDetail
GO

CREATE PROC addReceiptNoteDetail
	@rNoteID VARCHAR(7),
	@materialID VARCHAR(3),
	@quantity INT,
	@unitPrice DECIMAL(10,2)
AS
BEGIN
	IF @materialID IS NULL
		THROW 50000, N'Vui lòng chọn nguyên liệu cần nhập.', 255
	ELSE IF (@quantity <= 0 )
		THROW 50000, N'Vui lòng nhập số lượng lớn hơn 0.', 255
	ELSE IF (@unitPrice <= 0)
		THROW 50000, N'Vui lòng nhập đơn giá lớn hơn 0.', 255
	ELSE IF (SELECT COUNT(*) FROM ReceiptNoteDetail WHERE rNoteID = @rNoteID AND materialID = @materialID) > 0
		THROW 50000, N'Nguyên liệu được thêm đã có trong phiếu nhập. Nếu có sự thay đổi, vui lòng chọn SỬA!', 255
	INSERT INTO ReceiptNoteDetail VALUES (@rNoteID, @materialID, @quantity, @unitPrice);
END;
GO

/* PROC sửa chi tiết phiếu nhập theo rNoteID và materialID */
DROP PROC IF EXISTS updateReceiptNoteDetail
GO

CREATE PROC updateReceiptNoteDetail
	@rNoteID VARCHAR(7),
	@materialID VARCHAR(3),
	@quantity INT,
	@unitPrice DECIMAL(10,2)
AS
BEGIN
	IF @materialID IS NULL
		THROW 50000, N'Vui lòng chọn thông tin chi tiết cần sửa.', 255
	ELSE IF (@quantity <= 0 )
		THROW 50000, N'Vui lòng nhập số lượng lớn hơn 0.', 255
	ELSE IF (@unitPrice <= 0)
		THROW 50000, N'Vui lòng nhập đơn giá lớn hơn 0.', 255

	UPDATE ReceiptNoteDetail 
	SET quantity = @quantity, unitPrice = @unitPrice
	WHERE rNoteID = @rNoteID AND materialID = @materialID;
END;
GO

-- TRIGGER sau khi thêm, sửa, xóa Chi tiết đơn nhập hàng thì cập nhật lại giá trị cho đơn
DROP TRIGGER IF EXISTS updateRNPriceTrigger
GO

CREATE TRIGGER updateRNPriceTrigger
ON ReceiptNoteDetail
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
	DECLARE @rnID VARCHAR(7)
	IF EXISTS (SELECT * FROM inserted)
    BEGIN
        SELECT @rnID = rNoteID FROM inserted;
    END
    ELSE
    BEGIN
        SELECT @rnID = rNoteID FROM deleted;
    END;

	UPDATE ReceiptNote 
    SET price = (SELECT SUM(unitPrice * quantity) FROM ReceiptNoteDetail WHERE rNoteID = @rnID)
    WHERE ID = @rnID;
END;
GO

/* FUNCTION trả về giá trị tổng của phiếu nhập */
DROP FUNCTION IF EXISTS calReceiptNotePrice
GO

CREATE FUNCTION calReceiptNotePrice
(
    @id VARCHAR(7)
)
RETURNS DECIMAL(18,2)
AS
BEGIN
	IF ((SELECT COUNT(materialID) FROM ReceiptNoteDetail WHERE rNoteID = @id) = 0)
		RETURN 0;

    DECLARE @result DECIMAL(18,2);
    SELECT @result = SUM(quantity * unitPrice)
    FROM dbo.seeReceiptNoteDetail(@id);
    RETURN @result;
END;
GO

----------------------------------------------------------------------------
----------------------------------------------------------------------------
------------------------------ EXPENSE BILL --------------------------------
----------------------------------------------------------------------------
----------------------------------------------------------------------------

                                           /* CÁC CHỨC NĂNG Ở EXPENSE-BILL */

USE WibuCoffee
GO

/* TẠO VIEW EXPENSE-BILL để bỏ vào UI */
DROP VIEW IF EXISTS ExpenseBillView
GO

CREATE VIEW dbo.ExpenseBillView
AS
SELECT ID, date, price, detail FROM ExpenseBill;
GO

SELECT * FROM ExpenseBillView;

/* PROC thêm phiếu chi mới vào CSDL */
DROP PROC IF EXISTS addNewExpenseBill
GO

CREATE PROC addNewExpenseBill
	@date DATE, @price DECIMAL(18,2), @detail NVARCHAR(MAX)
AS
BEGIN
	IF (@date > GETDATE())
		THROW 50000, N'Không được nhập vào ngày trong tương lai', 255
	ELSE IF (@price <= 0)
		THROW 50000, N'Giá trị phiếu chi phải lớn hơn 0', 255
	ELSE IF (@detail = N'')
		THROW 50000, N'Chi tiết phiếu chi không được để trống', 255
	INSERT INTO ExpenseBill VALUES ('', @detail, @price, @date);
END;
GO

--EXEC addNewExpenseBill '2024-04-14', '200000.00', N'Chi cho trang thiết bị';

/* Trigger tự động set ID cho phiếu chi khi thêm mới */
DROP TRIGGER IF EXISTS setExpenseBillIDTrigger
GO

CREATE TRIGGER setExpenseBillIDTrigger
ON ExpenseBill
AFTER INSERT
AS
BEGIN
    DECLARE @max_id INT;
    DECLARE @new_id VARCHAR(7);
  
    SELECT @max_id = MAX(CAST(SUBSTRING(ID, 3, LEN(ID)) AS INT)) FROM ExpenseBill WHERE ID LIKE 'EX%';
    
    -- Tạo ID mới
    IF @max_id IS NULL
        SET @new_id = 'EX00001';
    ELSE
        SET @new_id = 'EX' + RIGHT('00000' + CAST(@max_id + 1 AS VARCHAR), 5);
    
    -- Gán ID mới cho bản ghi sẽ được chèn vào
    UPDATE ExpenseBill SET ID = @new_id WHERE ID = '';
END;
GO



/* PROC sửa phiếu chi đã có trong CSDL */
DROP PROC IF EXISTS updateExpenseBill
GO

CREATE PROC updateExpenseBill
	@id VARCHAR(7), @date DATE, @price DECIMAL(18,2), @detail NVARCHAR(MAX)
AS
BEGIN
	IF (@date > GETDATE())
		THROW 50000, N'Không được nhập vào ngày trong tương lai', 255
	ELSE IF (@price <= 0)
		THROW 50000, N'Giá trị phiếu chi phải lớn hơn 0', 255
	ELSE IF (@detail = N'')
		THROW 50000, N'Chi tiết phiếu chi không được để trống', 255
	UPDATE ExpenseBill SET date = @date, price = @price, detail = @detail
	WHERE ID = @id
END;



/* PROC xóa phiếu chi đã có trong CSDL */
DROP PROC IF EXISTS deleteExpenseBill
GO

CREATE PROC deleteExpenseBill
	@id VARCHAR(7)
AS
BEGIN
	IF (@id = '')
		THROW 50000, N'Vui lòng chọn phiếu chi cần xóa trong bảng dữ liệu.', 255
	DELETE ExpenseBill
	WHERE ID = @id
END;



/* Viết function lọc phiếu chi theo mã expenseBill */
DROP FUNCTION IF EXISTS filterExpenseBillByID
GO

CREATE FUNCTION filterExpenseBillByID
(
	@id VARCHAR(7)
)
RETURNS TABLE
AS
RETURN
		SELECT * FROM ExpenseBillView WHERE ID = @id;
GO

/* Viết function lọc phiếu chi theo ngày expenseBill */
DROP FUNCTION IF EXISTS filterExpenseBillByDate
GO

CREATE FUNCTION filterExpenseBillByDate
(
	@date DATE
)
RETURNS TABLE
AS
RETURN
	SELECT * FROM ExpenseBillView WHERE date = @date
GO

SELECT * FROM dbo.filterExpenseBillByDate('2024-03-12')
GO

----------------------------------------------------------------------------
----------------------------------------------------------------------------
------------------------------ ROLES ---------------------------------------
----------------------------------------------------------------------------
----------------------------------------------------------------------------

--------------------- CREATE USER ADMIN WITH ROLE DB_OWNER ----------------------------
USE master
GO

CREATE LOGIN admin
	WITH PASSWORD = 'admin',
	CHECK_POLICY = OFF, CHECK_EXPIRATION = OFF,
	DEFAULT_DATABASE = WibuCoffee;

-- Create login for the user
CREATE LOGIN emp 
	WITH PASSWORD = 'emp',
	CHECK_POLICY = OFF, CHECK_EXPIRATION = OFF,
	DEFAULT_DATABASE = WibuCoffee;
GO

USE WibuCoffee
GO

CREATE USER admin
	FOR LOGIN admin
GO

-- Granting db_owner role to admin within WibuCoffee database
ALTER ROLE db_owner ADD MEMBER admin;
GO

--------------------- CREATE USER EMP WITH LIMITED ROLE ---------------------------

USE WibuCoffee
GO

-- Create user from the login
CREATE USER emp 
	FOR LOGIN emp;
GO

CREATE ROLE role_emp
GO

ALTER ROLE role_emp ADD MEMBER emp
GO

GRANT EXECUTE TO role_emp;
GO

GRANT SELECT TO role_emp;
GO

-- Granting SELECT, INSERT, UPDATE on Product_Material
GRANT SELECT, INSERT, UPDATE ON Product_Material TO role_emp;
GO

GRANT SELECT, INSERT, UPDATE ON Bill TO role_emp;
GO

-- Granting SELECT, INSERT, UPDATE, DELETE on BillInfo
GRANT SELECT, INSERT, UPDATE, DELETE ON BillInfo TO role_emp;
GO

GRANT EXECUTE ON dbo.checkLogin TO role_emp;
GO

-- Explicitly deny DELETE on all other tables
DENY DELETE ON DATABASE::WibuCoffee TO role_emp;
GO

-- Explicitly deny any access to specific tables
DENY SELECT, INSERT, UPDATE, DELETE ON Account TO role_emp;
DENY SELECT, INSERT, UPDATE, DELETE ON Employee TO role_emp;
DENY SELECT, INSERT, UPDATE, DELETE ON Shift TO role_emp;
DENY SELECT, INSERT, UPDATE, DELETE ON On_Duty TO role_emp;
DENY SELECT, INSERT, UPDATE, DELETE ON Product TO role_emp;
DENY SELECT, INSERT, UPDATE, DELETE ON Supplier TO role_emp;
DENY SELECT, INSERT, UPDATE, DELETE ON ReceiptNote TO role_emp;
DENY SELECT, INSERT, UPDATE, DELETE ON ReceiptNoteDetail TO role_emp;
GO

--------- FOR ORDER --------------
REVOKE CONTROL ON dbo.BillCategory FROM role_emp;
GO

GRANT SELECT ON dbo.BillCategory TO role_emp;
GO

REVOKE CONTROL ON dbo.insertBill FROM role_emp;
GO

GRANT EXECUTE ON dbo.insertBill TO role_emp;
GO

GRANT SELECT ON dbo.TableStatusView TO role_emp;
GO

DENY EXECUTE ON dbo.insertTable TO role_emp;
DENY EXECUTE ON dbo.deleteTableByID TO role_emp;
DENY EXECUTE ON dbo.deleteBillByID TO role_emp;
GO

------- FOR EMPLOYEE -----------
DENY SELECT ON dbo.EmployeeDetailView TO role_emp;
DENY SELECT ON dbo.ShiftDetailView to role_emp;

DENY EXECUTE ON dbo.getJobDetail TO role_emp;
DENY SELECT ON dbo.getEmployeeInfo TO role_emp;
DENY SELECT ON dbo.filterEmployeeByName TO role_emp;
DENY SELECT ON dbo.filterEmployeeByDate TO role_emp;
DENY EXECUTE ON dbo.getSalary TO role_emp;
DENY SELECT ON dbo.getEmployeeID TO role_emp;
DENY SELECT ON dbo.getEmployeeInfoByName TO role_emp;
DENY SELECT ON dbo.getEmployeeInfoByJob TO role_emp;
DENY SELECT ON dbo.getEmployeeNameByRecruitmentDate TO role_emp;
DENY EXECUTE ON dbo.createID TO role_emp;
GO

DENY EXECUTE ON dbo.getEmployee TO role_emp;
DENY EXECUTE ON dbo.getJob TO role_emp;
DENY EXECUTE ON dbo.getShift TO role_emp;
DENY EXECUTE ON dbo.getEmployeeList TO role_emp;
DENY EXECUTE ON dbo.updateSalary TO role_emp;
DENY EXECUTE ON dbo.insertEmployee TO role_emp;
DENY EXECUTE ON dbo.updateEmployee TO role_emp;
DENY EXECUTE ON dbo.deleteEmployeeByID TO role_emp;
DENY EXECUTE ON dbo.insertEmployeeToShift TO role_emp;
DENY EXECUTE ON dbo.updateEmployeeInShift TO role_emp;
DENY EXECUTE ON dbo.deleteEmployeeInShift TO role_emp;
DENY EXECUTE ON dbo.getShiftDetail TO role_emp;
DENY EXECUTE ON dbo.getShiftDetailByWeek TO role_emp;
DENY EXECUTE ON dbo.getNextWeekShiftDetail TO role_emp;
GO

------- FOR PRODUCT -----------
DENY SELECT ON dbo.ProductView TO role_emp;
DENY SELECT ON dbo.ProductCategoryView TO role_emp;
GO

DENY SELECT ON dbo.GetMaterials TO role_emp;
GO

DENY EXECUTE ON dbo.AddProduct TO role_emp;
DENY EXECUTE ON dbo.UpdateProductByID TO role_emp;
DENY EXECUTE ON dbo.DeleteProductByID TO role_emp;
DENY EXECUTE ON dbo.addProductCategory TO role_emp;
DENY EXECUTE ON dbo.updateProductCategoryByID TO role_emp;
DENY EXECUTE ON dbo.addProductMaterial TO role_emp;
DENY EXECUTE ON dbo.updateProductMaterialByID TO role_emp;
DENY EXECUTE ON dbo.deleteProductMaterialByID TO role_emp;
GO

------- FOR SUPPLIER -----------
DENY SELECT ON dbo.SupplierList TO role_emp
GO

DENY EXECUTE ON dbo.AddSupplier TO role_emp;
DENY EXECUTE ON dbo.UpdateSupplier TO role_emp;
DENY EXECUTE ON dbo.DeleteSupplier TO role_emp;
GO

------- FOR RECEIPT NOTE -----------
DENY SELECT ON dbo.ReceiptNoteView TO role_emp;
DENY SELECT ON dbo.ReceiptNoteListView TO role_emp;
GO

DENY SELECT ON dbo.filterReceiptNoteViewByID TO role_emp;
DENY SELECT ON dbo.filterReceiptNoteViewBySupplier TO role_emp;
DENY SELECT ON dbo.filterReceiptNoteViewByEmployee TO role_emp;
DENY SELECT ON dbo.filterReceiptNoteViewByDate TO role_emp;
DENY SELECT ON dbo.filterReceiptNoteListViewByID TO role_emp;
DENY SELECT ON dbo.filterReceiptNoteListViewBySupplier TO role_emp;
DENY SELECT ON dbo.filterReceiptNoteListViewByEmployee TO role_emp;
DENY SELECT ON dbo.filterReceiptNoteListViewByDate TO role_emp;
DENY SELECT ON dbo.seeReceiptNoteDetail TO role_emp;
DENY EXECUTE ON dbo.calReceiptNotePrice TO role_emp;
GO

DENY EXECUTE ON dbo.addNewReceiptNote TO role_emp;
DENY EXECUTE ON dbo.updateNewReceiptNote TO role_emp;
DENY EXECUTE ON dbo.deleteReceiptNote TO role_emp;
DENY EXECUTE ON dbo.deleteReceiptNoteDetail TO role_emp;
DENY EXECUTE ON dbo.addReceiptNoteDetail TO role_emp;
DENY EXECUTE ON dbo.updateReceiptNoteDetail TO role_emp;
GO