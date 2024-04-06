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
    ('E01', N'Nguyễn Trung Hiếu', '2004-4-5', N'Sài Gòn', '0987654321', '2022-03-13', 'J03', 0, 3, 16),
	('E02', N'Phan Phúc Hảo', '2004-3-2', N'Bắc Ninh', '0982874321', '2022-03-13', 'J02', 2, 3, 15),
	('E03', N'Lê Văn Phát', '2004-6-7', N'Thanh Hóa', '0367654321', '2022-02-2', 'J01', 1, 2, 10),
	('E04', N'Huỳnh Thanh Duy', '2004-10-10', N'Hải Phòng', '0987698721', '2021-12-12', 'J03', 0, 0, 8),
	('E05', N'Lưu Tuấn Thành', '2004-3-7', N'Đắk Lắk', '0987608221', '2022-04-4', 'J03', 3, 1, 11),
	('E06', N'Lê Hoàng Bảo Phúc', '2004-1-5', N'Bắc Giang', '0980214321', '2022-05-13', 'J03', 0, 2, 8),
	('E07', N'Lê Duy Phương', '2004-04-06', N'Bình Định', '0772192320', '2023-06-02', 'J02', 0, 3, 16);
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
	('E01', 'ShF01', '2024-03-26'),
	('E01', 'ShF01', '2024-03-27'),
	('E01', 'ShF01', '2024-03-28'),
	('E07', 'ShF02', '2024-03-26'),
	('E07', 'ShF02', '2024-03-27'),
	('E07', 'ShF02', '2024-03-28'),
	('E03', 'ShF03', '2024-03-26'),
	('E03', 'ShF03', '2024-03-27'),
	('E03', 'ShF03', '2024-03-28'),
	('E02', 'ShP03', '2024-03-26'),
	('E02', 'ShP03', '2024-03-27'),
	('E02', 'ShP03', '2024-03-28'),
	('E04', 'ShP02', '2024-03-26'),
	('E04', 'ShP03', '2024-03-27'),
	('E04', 'ShP04', '2024-03-28'),
	('E05', 'ShP02', '2024-03-26'),
	('E05', 'ShP02', '2024-03-27'),
	('E05', 'ShP03', '2024-03-28'),
	('E06', 'ShP04', '2024-03-26'),
	('E06', 'ShP04', '2024-03-27'),
	('E06', 'ShP01', '2024-03-28');
GO	

INSERT INTO Supplier (ID, name, address, phone)
VALUES
    ('SP01', 'Buon Me Coffe ', N'Buôn Mê Thuột', '0140314321'),
    ('SP02', N'Tạp Hóa Vui Vẻ', N'Sài Gòn', '0987612721'),
    ('SP03', 'Coopmart', 'Đồng Nai', '0994612721');
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
	('BC01', 'Drink', 0),
	('BC02', 'Snack', 0),
	('BC03', 'Souvenir', 5);
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
	('P01', 'Espresso', 'PC01', 3.50, 'Available'),
	('P02', 'Cappuccino', 'PC01', 4.00, 'Available'),
	('P03', 'Green Tea', 'PC02', 2.50, 'Available'),
	('P04', 'Cola', 'PC07', 2.00, 'Available'),
	('P05', 'Chocolate Cake', 'PC04', 5.50, 'Available'),
	('P06', 'Club Sandwich', 'PC05', 7.00, 'Available'),
	('P07', 'Caesar Salad', 'PC06', 6.00, 'Available'),
	('P08', 'Orange Juice', 'PC03', 8.50, 'Available'),
	('P09', 'Lemon Juice', 'PC03', 9.00, 'Available'),
	('P10', 'Sting', 'PC07', 8.00, 'Available');
GO



INSERT INTO Bill (ID, dateTime, tableID, customerID, categoryID, empID, receiptMoney)
VALUES
	('B000001', '2024-03-14 08:30:00', 'T01', 'C0001', 'BC01', 'E01', 25.00),
	('B000002', '2024-03-14 12:45:00', 'T02', 'C0002', 'BC02', 'E02', 30.00),
	('B000003', '2024-03-14 18:20:00', 'T03', 'C0003', 'BC02', 'E03', 40.00),
	('B000004', '2024-03-15 09:10:00', 'T04', 'C0004', 'BC03', 'E01', 50.00),
	('B000005', '2024-03-15 13:55:00', 'T05', 'C0005', 'BC01', 'E03', 55.00),
	('B000006', '2024-03-15 17:30:00', 'T06', 'C0006', 'BC02', 'E02', 45.00),
	('B000007', '2024-03-16 08:40:00', 'T07', 'C0007', 'BC01', 'E01', 60.00),
	('B000008', '2024-03-16 12:15:00', 'T08', 'C0008','BC03', 'E03', 35.00),
	('B000009', '2024-03-16 16:50:00', 'T09', 'C0009', 'BC03', 'E01', 48.00),
	('B000010', '2024-03-17 10:25:00', 'T10', 'C0010', 'BC03','E02', 22.00);
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
	('B000010', 'P10', 1);
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
	('P04', 'M10', 1),
	('P05', 'M04', 1),
	('P06', 'M05', 1),
	('P07', 'M07', 1),
	('P08', 'M09', 1),
	('P09', 'M10', 1),
	('P10', 'M10', 1);
GO



INSERT INTO ReceiptNote (ID, date, price, supplierID, empID)
VALUES
	('RN00001', '2024-03-10', 500.00, 'SP01', 'E01'),
	('RN00002', '2024-03-11', 350.00, 'SP02', 'E02'),
	('RN00003', '2024-03-12', 200.00, 'SP03', 'E03'),
	('RN00004', '2024-03-13', 450.00, 'SP02', 'E01'),
	('RN00005', '2024-03-14', 300.00, 'SP03', 'E05'),
	('RN00006', '2024-03-15', 400.00, 'SP01', 'E04'),
	('RN00007', '2024-03-16', 550.00, 'SP03', 'E01'),
	('RN00008', '2024-03-17', 600.00, 'SP02', 'E04'),
	('RN00009', '2024-03-18', 250.00, 'SP02', 'E03'),
	('RN00010', '2024-03-19', 700.00, 'SP01', 'E02');
GO




INSERT INTO ReceiptNoteDetail (rNoteID, materialID, quantity, unitPrice)
VALUES
	('RN00001', 'M01', 10, 10.00),
	('RN00002', 'M02', 5, 5.00),
	('RN00003', 'M03', 20, 2.00),
	('RN00004', 'M04', 15, 8.00),
	('RN00005', 'M05', 10, 4.00),
	('RN00006', 'M06', 5, 6.00),
	('RN00007', 'M07', 10, 3.00),
	('RN00008', 'M08', 10, 1.50),
	('RN00009', 'M09', 8, 7.00),
	('RN00010', 'M10', 5, 6.00);
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
	(1, 'Cleaning Supplies for the month', 120.00, '2024-03-10'),
	(2, 'Bakery Ingredients for the week', 200.00, '2024-03-12'),
	(3, 'Produce for the week', 180.00, '2024-03-14'),
	(4, 'Meat for the week', 250.00, '2024-03-16'),
	(5, 'Dairy Products for the week', 180.00, '2024-03-18');
GO


INSERT INTO [Shift] (ID,  startTime, endTime)
VALUES
    (1, '08:00:00', '12:00:00'),
    (2,'12:00:00', '16:00:00'),
    (3,  '16:00:00', '20:00:00'),
    (4,  '08:00:00', '12:00:00'),
    (5,  '12:00:00', '16:00:00'),
    (6,  '16:00:00', '20:00:00'),
    (7,  '08:00:00', '12:00:00'),
    (8,  '12:00:00', '16:00:00'),
    (9,  '16:00:00', '20:00:00'),
    (10,  '08:00:00', '12:00:00');

INSERT INTO On_Duty (empID, shiftID,date)
VALUES
('E01', 'SHF01','2024-03-14'),
('E05', 'SHF01','2024-03-14'),
('E03', 'SHF02','2024-03-14'),
('E04', 'SHF02','2024-03-14'),
('E01', 'SHF03','2024-03-14'),
('E05', 'SHF03','2024-03-14'),
('E06', 'SHF03','2024-03-14'),
('E02', 'SHF04','2024-03-15'),
('E04', 'SHF04','2024-03-15'),
('E06', 'SHF05','2024-03-14');

INSERT INTO Account(userName, pass, userRole)
VALUES
('sa','sa',0), -- Admin --
('emp', 'emp', 1);
