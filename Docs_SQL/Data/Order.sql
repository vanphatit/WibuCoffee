/* CÁC CHỨC NĂNG Ở BILL HISTORY */

/*Viết hàm lọc theo mã hóa đơn hoặc ngày lập hóa đơn hoặc loại hóa đơn trong bảng bill*/

DROP FUNCTION IF EXISTS filterBill
GO

CREATE FUNCTION filterBill
(
	@billID VARCHAR(7),
	@date DATE,
	@type NVARCHAR(max)
)
RETURNS TABLE
AS
RETURN
(
	SELECT * FROM Bill
	WHERE ID = @billID OR dateTime = @date OR categoryID = @type
)
GO

/* tạo view từ bill gồm mã hóa đơn, ngày lập hóa đơn, loại hóa đơn */

DROP VIEW IF EXISTS viewBill
GO

CREATE VIEW viewBill
AS
SELECT ID, dateTime, categoryID
FROM Bill
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

/* VIẾT FUNCTION LẤY RA TỔNG TIỀN CỦA MỘT HÓA ĐƠN KHI BIẾT MÃ HÓA ĐƠN */

DROP FUNCTION IF EXISTS getTotalPrice
GO

CREATE FUNCTION getTotalPrice
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
	DECLARE @customerID VARCHAR(5)
	IF ((SELECT COUNT(*) FROM customer) < 10)
		SET @customerID = 'C' + RIGHT('000' + CAST((SELECT COUNT(*) FROM Customer) AS VARCHAR(1)), 1)
	ELSE
		SET @customerID = 'C' + RIGHT('00' + CAST((SELECT COUNT(*) FROM Customer) AS VARCHAR(2)), 2)
	IF NOT EXISTS (SELECT * FROM Customer WHERE phone = @phone)
		INSERT INTO Customer VALUES (@customerID, @name, @phone, 0)

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

/* VIẾT PROCEDURE KIỂM TRA XEM BÀN CÓ STATUS LÀ Available THÌ CẬP NHẬT SANG Occupied KHI BIẾT ID BÀN */

DROP PROCEDURE IF EXISTS updateTableStatus
GO

CREATE PROCEDURE updateTableStatus
	(@tableID VARCHAR(3))
AS
BEGIN
	IF (SELECT Status FROM TableStatusView WHERE ID = @tableID) = 'Occupied'
		UPDATE [Table] SET status = 'Available' WHERE ID = @tableID
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
	SELECT @tableID = tableID FROM inserted
	IF EXISTS (SELECT * FROM [Table] WHERE ID = @tableID AND status = 'Available')
		UPDATE [Table] SET status = 'Occupied' WHERE ID = @tableID
	ELSE
		PRINT 'TABLE IS NOT AVAILABLE'
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
	DECLARE @customerID VARCHAR(5)
	DECLARE @categoryID VARCHAR(4)
	DECLARE @empID VARCHAR(4)
	SELECT @customerID = ID FROM Customer WHERE name = @customerName
	SELECT @categoryID = ID FROM BillCategory WHERE name = @categoryName
	SELECT @empID = ID FROM Employee WHERE name = @empName
	INSERT INTO Bill(ID, dateTime, tableID, customerID, categoryID, empID, receiptMoney)
	VALUES (@ID, CAST(@dateTime  AS DATETIME), @tableID, @customerID, @categoryID, @empID, @receiptMoney)
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
	(@billID VARCHAR(7), 
	@productName NVARCHAR(max), 
	@quantity INT)
AS
BEGIN
	DECLARE @productID VARCHAR(3)
	IF NOT EXISTS (SELECT * FROM Product WHERE name = @productName)
	BEGIN
		PRINT 'PRODUCT DOES NOT EXIST'
		RETURN
	END
	SELECT @productID = ID FROM Product WHERE name = @productName
	INSERT INTO BillInfo VALUES (@billID, @productID, @quantity)
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
	DECLARE @productID VARCHAR(3)
	IF NOT EXISTS (SELECT * FROM Product WHERE name = @productName)
	BEGIN
		PRINT 'PRODUCT DOES NOT EXIST'
		RETURN
	END
	SELECT @productID = ID FROM Product WHERE name = @productName
	IF NOT EXISTS (SELECT * FROM BillInfo WHERE billID = @billID AND productID = @productID)
	BEGIN
		PRINT 'BILL INFO DOES NOT EXIST'
		RETURN
	END
	UPDATE BillInfo SET quantity = @quantity WHERE billID = @billID AND productID = @productID
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
	DECLARE @totalPrice DECIMAL(10, 2)
	DECLARE @point INT
	IF NOT EXISTS (SELECT * FROM Bill WHERE ID = @billID)
	BEGIN
		PRINT 'BILL DOES NOT EXIST'
		RETURN
	END
	SELECT @totalPrice = SUM(totalPrice) FROM BillDetailView WHERE billID = @billID
	SELECT @point = @totalPrice / 10000
	UPDATE Customer SET bonusPoint = bonusPoint + @point WHERE phone = @phone
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
WHERE Employee.jobID = Job.ID AND Employee.ID = On_Duty.empID AND On_Duty.shiftID = Shift.ID
GO

DROP PROCEDURE IF EXISTS employeeShift
GO

CREATE PROCEDURE employeeShift
AS
BEGIN
	SELECT * FROM EmployeeShiftView ORDER BY date ASC, ID ASC
END
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
GROUP BY Bill.ID, Bill.categoryID, Customer.bonusPoint, BillCategory.discount
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

/* VIẾT PROCEDURE CẬP NHẬT BILLINFO KHI BIẾT MÃ HÓA ĐƠN, MÃ SẢN PHẨM, SỐ LƯỢNG */

DROP PROCEDURE IF EXISTS updateBillInfoByID
GO

CREATE PROCEDURE updateBillInfoByID
	@billID varchar(7),
	@productID varchar(3),
	@quantity INT
AS
BEGIN
	UPDATE BillInfo
	SET quantity = @quantity
	WHERE billID = @billID AND productID = @productID
END
GO

/* VIẾT PROCEDURE XÓA BILLINFO KHI BIẾT TÊN SẢN PHẨM */

DROP PROCEDURE IF EXISTS deleteBillInfoByName
GO

CREATE PROCEDURE deleteBillInfoByName
	@billID varchar(7),
	@productName NVARCHAR(max)
AS
BEGIN
	DECLARE @productID VARCHAR(3)
	SELECT @productID = ID FROM Product WHERE name = @productName
	DELETE FROM BillInfo WHERE billID = @billID AND productID = @productID
END
GO
