USE WibuCoffee
GO

INSERT INTO Job (ID, jobDetail, salary)
VALUES
    ('J01', 'Waiter', 23000.00),
    ('J02', 'Batender', 24000.00),
    ('J03', 'Order', 25000.00);
GO

INSERT INTO Employee (ID, name, birthDate, address, phone, recruitmentDate, jobID, penaltyPoint, bonusPoint, numberOfShift)
VALUES
    ('EF01', N'Nguyễn Trung Hiếu', '2004-4-5', N'Sài Gòn', '0987654321', '2022-03-13', 'J03', 0, 3, 2),
	('EP02', N'Phan Phúc Hảo', '2004-3-2', N'Bắc Ninh', '0982874321', '2022-03-13', 'J02', 2, 3, 3),
	('EF03', N'Lê Văn Phát', '2004-6-7', N'Thanh Hóa', '0367654321', '2022-02-2', 'J01', 1, 2, 3),
	('EP04', N'Huỳnh Thanh Duy', '2004-10-10', N'Hải Phòng', '0987698721', '2021-12-12', 'J03', 0, 0, 2),
	('EP05', N'Lưu Tuấn Thành', '2004-3-7', N'Đắk Lắk', '0987608221', '2022-04-4', 'J03', 3, 1, 3),
	('EP06', N'Lê Hoàng Bảo Phúc', '2004-1-5', N'Bắc Giang', '0980214321', '2022-05-13', 'J03', 0, 2, 2),
	('EF07', N'Lê Duy Phương', '2004-04-06', N'Bình Định', '0772192320', '2023-06-02', 'J02', 0, 3, 2);
GO


-- On duty, Shift chưa làm--
-- Giờ làm nè -.- --
INSERT INTO Shift (ID, startTime, endTime)
VALUES
	('ShF01', '06:30:00', '14:30:00'),
	('ShF02', '14:30:00', '22:30:00'),
	('ShF03', '08:00:00', '17:00:00'),
	('ShP01', '08:00:00', '12:00:00'),
	('ShP02', '13:00:00', '17:00:00'),
	('ShP03', '17:00:00', '22:00:00'),
	('ShP04', '10:00:00', '14:00:00');
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
	('T01', 'Table 1', 'Available'),
	('T02', 'Table 2', 'Available'),
	('T03', 'Table 3', 'Occupied'),
	('T04', 'Table 4', 'Occupied'),
	('T05', 'Table 5', 'Available'),
	('T06', 'Table 6', 'Available'),
	('T07', 'Table 7', 'Occupied'),
	('T08', 'Table 8', 'Occupied'),
	('T09', 'Table 9', 'Available'),
	('T10', 'Table 10', 'Available');
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
	('C0010', 'Jack Harris', '0173154751', 18);
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
	('B000001', '2024-03-14 08:30:00', 'T01', 'C0001', 'BC01', 'EF01', 25000.00),
	('B000002', '2024-03-14 12:45:00', 'T02', 'C0002', 'BC02', 'EP04', 30000.00),
	('B000003', '2024-03-14 18:20:00', 'T03', 'C0003', 'BC02', 'EP05', 40000.00),
	('B000004', '2024-03-15 09:10:00', 'T04', 'C0004', 'BC03', 'EF01', 50000.00),
	('B000005', '2024-03-15 13:55:00', 'T05', 'C0005', 'BC01', 'EP06', 55000.00),
	('B000006', '2024-03-15 17:30:00', 'T06', 'C0006', 'BC02', 'EP04', 45000.00),
	('B000007', '2024-03-16 08:40:00', 'T07', 'C0007', 'BC01', 'EF01', 60000.00),
	('B000008', '2024-03-16 12:15:00', 'T08', 'C0008','BC03', 'EP05', 35000.00),
	('B000009', '2024-03-16 16:50:00', 'T09', 'C0009', 'BC03', 'EF01', 48000.00),
	('B000010', '2024-03-17 10:25:00', 'T10', 'C0010', 'BC03','EP06', 22000.00),
	('B000011', '2024-04-11 08:30:00', 'T01', 'C0001', 'BC01', 'EF01', 25000.00),
    ('B000012', '2024-04-10 12:45:00', 'T02', 'C0002', 'BC02', 'EP04', 30000.00),
    ('B000013', '2024-04-09 18:20:00', 'T03', 'C0003', 'BC02', 'EP05', 40000.00),
    ('B000014', '2024-04-08 09:10:00', 'T04', 'C0004', 'BC03', 'EF01', 50000.00),
    ('B000015', '2024-04-07 13:55:00', 'T05', 'C0005', 'BC01', 'EP06', 55000.00),
    ('B000016', '2024-04-06 17:30:00', 'T06', 'C0006', 'BC02', 'EP04', 45000.00),
    ('B000017', '2024-04-05 08:40:00', 'T07', 'C0007', 'BC01', 'EF01', 60000.00),
    ('B000018', '2024-04-04 12:15:00', 'T08', 'C0008','BC03', 'EP05', 35000.00),
    ('B000019', '2024-04-05 16:50:00', 'T09', 'C0009', 'BC03', 'EF01', 48000.00),
    ('B000020', '2024-04-06 10:25:00', 'T10', 'C0010', 'BC03','EP06', 22000.00);
GO


INSERT INTO ProductCategory (ID, name)
VALUES
	('PC01', 'Coffee'),
	('PC02', 'Tea'),
	('PC03', 'Juice'),
	('PC04', 'Cake'),
	('PC05', 'Sandwich'),
	('PC06', 'Salad'),
	('PC07', 'Soft Drink');
GO



INSERT INTO Product (ID, name, categoryID, price, status)
VALUES
	('P01', 'Espresso', 'PC01', 30000.00, 'Available'),
	('P02', 'Cappuccino', 'PC01', 40000.00, 'Available'),
	('P03', 'Green Tea', 'PC02', 25000.00, 'Available'),
	('P04', 'Cola', 'PC07', 20000.00, 'Available'),
	('P05', 'Chocolate Cake', 'PC04', 55000.00, 'Available'),
	('P06', 'Club Sandwich', 'PC05', 70000.00, 'Available'),
	('P07', 'Caesar Salad', 'PC06', 60000.00, 'Available'),
	('P08', 'Orange Juice', 'PC03', 50000.00, 'Available'),
	('P09', 'Lemon Juice', 'PC03', 39000.00, 'Available'),
	('P10', 'Sting', 'PC07', 45000.00, 'Available');
GO



INSERT INTO BillInfo (billID, productID, quantity)
VALUES
	('B000001', 'P01', 2),
	('B000002', 'P02', 1),
	('B000003', 'P03', 1),
	('B000004', 'P04', 2),
	('B000005', 'P05', 1),
	('B000006', 'P06', 3),
	('B000007', 'P07', 1),
	('B000008', 'P08', 2),
	('B000009', 'P09', 1),
	('B000010', 'P10', 1),
	('B000011', 'P01', 2),
    ('B000012', 'P02', 1),
    ('B000013', 'P03', 1),
    ('B000014', 'P04', 2),
    ('B000015', 'P05', 1),
    ('B000016', 'P06', 3),
    ('B000017', 'P07', 1),
    ('B000018', 'P08', 2),
    ('B000019', 'P09', 1),
    ('B000020', 'P10', 1);
GO



INSERT INTO Material (ID, name, status)
VALUES
	('M01', 'Coffee Beans', 'Available'),
	('M02', 'Tea Leaves', 'Available'),
	('M03', 'Sugar', 'Available'),
	('M04', 'Flour', 'Available'),
	('M05', 'Butter', 'Available'),
	('M06', 'Chocolate', 'Available'),
	('M07', 'Lettuce', 'Available'),
	('M08', 'Tomato', 'Available'),
	('M09', 'Orange', 'Available'),
	('M10', 'Lemon', 'Available');
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
	('RN00001', '2024-03-10', 5000000.00, 'SP01', 'EF01'),
	('RN00002', '2024-03-11', 3500000.00, 'SP02', 'EP02'),
	('RN00003', '2024-03-12', 2000000.00, 'SP03', 'EF03'),
	('RN00004', '2024-03-13', 4500000.00, 'SP02', 'EF01'),
	('RN00005', '2024-03-14', 3000000.00, 'SP03', 'EP05'),
	('RN00006', '2024-03-15', 4000000.00, 'SP01', 'EP04'),
	('RN00007', '2024-03-16', 5500000.00, 'SP03', 'EF01'),
	('RN00008', '2024-03-17', 6000000.00, 'SP02', 'EP04'),
	('RN00009', '2024-03-18', 2500000.00, 'SP02', 'EF03'),
	('RN00010', '2024-03-19', 7000000.00, 'SP01', 'EP02');
GO



INSERT INTO ReceiptNoteDetail (rNoteID, materialID, quantity, unitPrice)
VALUES
	('RN00001', 'M01', 50, 100000.00),
	('RN00002', 'M02', 70, 50000.00),
	('RN00003', 'M03', 100, 20000.00),
	('RN00004', 'M04', 150, 30000.00),
	('RN00005', 'M05', 100, 30000.00),
	('RN00006', 'M06', 50, 80000.00),
	('RN00007', 'M07', 110, 50000.00),
	('RN00008', 'M08', 100, 60000.00),
	('RN00009', 'M09', 100, 25000.00),
	('RN00010', 'M10', 200, 35000.00);
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
	('EX00001', 'Cleaning Supplies for the month', 5000000.00, '2024-03-10'),
	('EX00002', 'Bakery Ingredients for the week', 600000.00, '2024-03-12'),
	('EX00003', 'Produce for the week', 1800000.00, '2024-03-14'),
	('EX00004', 'Dairy Products for the week', 1800000.00, '2024-03-18'),
	('EX00005', 'Cleaning Supplies for the month', 5000000.00, '2024-04-11'),
    ('EX00006', 'Bakery Ingredients for the week', 600000.00, '2024-04-10'),
    ('EX00007', 'Produce for the week', 1800000.00, '2024-04-09'),
    ('EX00008', 'Dairy Products for the week', 1800000.00, '2024-04-08'),
    ('EX00009', 'Cleaning Supplies for the month', 5000000.00, '2024-04-07'),
    ('EX00010', 'Bakery Ingredients for the week', 600000.00, '2024-04-06'),
    ('EX00011', 'Produce for the week', 1800000.00, '2024-04-05'),
    ('EX00012', 'Dairy Products for the week', 1800000.00, '2024-04-04'),
    ('EX00013', 'Cleaning Supplies for the month', 5000000.00, '2024-04-04'),
    ('EX00014', 'Bakery Ingredients for the week', 600000.00, '2024-04-05'),
    ('EX00015', 'Produce for the week', 1800000.00, '2024-04-06'),
    ('EX00016', 'Dairy Products for the week', 1800000.00, '2024-04-07');
GO


INSERT INTO Account(userName, pass, userRole)
VALUES
('sa','sa',0), -- Admin --
('emp', 'emp', 1);




