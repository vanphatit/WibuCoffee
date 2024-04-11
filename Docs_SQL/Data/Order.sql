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

SELECT * FROM BillDetailView

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

SELECT * FROM dbo.getBillDetail('B000001')

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
	IF EXISTS (SELECT * FROM TableAvailableView WHERE ID = @tableID)
		UPDATE [Table] SET status = 'Occupied' WHERE ID = @tableID
	ELSE
		PRINT 'TABLE IS NOT AVAILABLE'
	EXEC sp_refreshview TableAvailableView
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
	IF EXISTS (SELECT * FROM [Table] WHERE ID = @tableID AND status = 'Occupied')
		UPDATE [Table] SET status = 'Available' WHERE ID = @tableID
	ELSE
		PRINT 'TABLE IS NOT AVAILABLE'
	EXEC sp_refreshview TableAvailableView
END
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

SELECT * FROM dbo.BillTotalPriceView


EXEC insertBillInfo 'B000001', 'P03', 3
