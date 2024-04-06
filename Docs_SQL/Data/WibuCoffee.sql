USE master
GO

DROP DATABASE IF EXISTS WibuCoffee
GO

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
    ID VARCHAR(3) PRIMARY KEY, -- E01, E02, ...
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
    name NVARCHAR(max),
    address NVARCHAR(max),
    phone VARCHAR(10) CHECK (LEN(phone) = 10)
);

-- Tạo bảng On_Duty
CREATE TABLE On_Duty (
    empID VARCHAR(3),
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
    empID VARCHAR(3) NOT NULL,
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
    status NVARCHAR(max),
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
    status NVARCHAR(max) NOT NULL
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
    empID VARCHAR(3) NOT NULL,
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