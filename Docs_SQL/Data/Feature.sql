USE WibuCoffee
GO

/* INSERT */

CREATE PROCEDURE insertEmployee
	@ID VARCHAR(3) ,
    @name NVARCHAR(max),
    @birthDate DATE,
    @address NVARCHAR(max),
    @phone VARCHAR(10),
    @recruitmentDate DATE ,
    @jobID VARCHAR(3),
    @penaltyPoint INT,
    @bonusPoint INT,
    @numberOfShift INT
AS
BEGIN
	INSERT INTO Employee (ID, name, birthDate, address, phone, recruitmentDate, jobID, penaltyPoint, bonusPoint, numberOfShift)
	VALUES (@ID, @name, @birthDate, @address, @phone, @recruitmentDate, @jobID, @penaltyPoint, @bonusPoint, @numberOfShift)
END
GO

CREATE PROCEDURE insertJob
	@ID VARCHAR(3),
    @jobDetail NVARCHAR(max),
    @salary DECIMAL(10, 2)
AS
BEGIN
	INSERT INTO Job (ID, jobDetail, salary)
	VALUES (@ID, @jobDetail, @salary)
END
GO

CREATE PROCEDURE insertOnDuty
	@empID varchar(3),
	@shiftID varchar(3),
	@date DATE
AS
BEGIN
	INSERT INTO On_Duty(empID, shiftID, date)
	VALUES (@empID, @shiftID, @date)
END
GO

CREATE PROCEDURE insertTable
	@ID varchar(3),
	@name nvarchar(max),
	@status nvarchar(max)
AS
BEGIN
	INSERT INTO [Table] (ID, name, status)
	VALUES (@ID, @name, @status)
END
GO

CREATE PROCEDURE insertCustomer
	@ID varchar(5),
	@name nvarchar(max),
	@phone varchar(10),
	@bonusPoint INT
AS
BEGIN
	INSERT INTO Customer(ID, name, phone, bonusPoint)
	VALUES (@ID, @name, @phone, @bonusPoint)
END
GO

CREATE PROCEDURE insertBillCategory
	@ID varchar(4),
	@name nvarchar(max),
	@discount DECIMAL(5,2)
AS
BEGIN
	INSERT INTO BillCategory(ID, name, discount)
	VALUES (@ID, @name, @discount)
END
GO

CREATE PROCEDURE insertBill
	@ID varchar(7),
	@dateTime DATETIME,
	@tableID varchar(3),
	@customerID varchar(5),
	@categoryID varchar(4),
	@empID varchar(3),
	@receiptMoney DECIMAL(10,2)
AS
BEGIN
	INSERT INTO Bill(ID, dateTime, tableID, customerID, categoryID, empID, receiptMoney)
	VALUES (@ID, @dateTime, @tableID, @customerID, @categoryID, @empID, @receiptMoney)
END
GO

CREATE PROCEDURE insertProductCategory
	@ID varchar(4),
	@name nvarchar(max)
AS
BEGIN
	INSERT INTO ProductCategory(ID, name)
	VALUES (@ID, @name)
END
GO

CREATE PROCEDURE insertProduct
	@ID varchar(3),
	@name nvarchar(max),
	@categoryID varchar(4),
	@price DECIMAL(10,2),
	@status nvarchar(max)
AS
BEGIN
	INSERT INTO Product(ID, name, categoryID, price, status)
	VALUES (@ID, @name, @categoryID, @price, @status)
END
GO

CREATE PROCEDURE insertBillInfo
	@billID varchar(7),
	@productID varchar(3),
	@quantity INT
AS
BEGIN
	INSERT INTO BillInfo(billID, productID, quantity)
	VALUES (@billID, @productID, @quantity)
END
GO

CREATE PROCEDURE insertMaterial
	@ID varchar(3),
	@name nvarchar(max),
	@status nvarchar(max)
AS
BEGIN
	INSERT INTO Material(ID, name, status)
	VALUES (@ID, @name, @status)
END
GO

CREATE PROCEDURE insertProductMaterial
	@productID varchar(3),
	@materialID varchar(3),
	@quantity INT
AS
BEGIN
	INSERT INTO Product_Material(productID, materialID, quantity)
	VALUES (@productID, @materialID, @quantity)
END
GO

CREATE PROCEDURE insertSupplier
	@ID varchar(4),
	@name nvarchar(max),
	@address nvarchar(max),
	@phone varchar(10)
AS
BEGIN
	INSERT INTO Supplier(ID, name, address, phone)
	VALUES (@ID, @name, @address, @phone)
END
GO

CREATE PROCEDURE insertReceiptNote
	@ID varchar(7),
	@date DATE,
	@price DECIMAL(10,2),
	@supplierID varchar(4),
	@empID varchar(3)
AS
BEGIN
	INSERT INTO ReceiptNote(ID, date, price, supplierID, empID)
	VALUES (@ID, @date, @price, @supplierID, @empID)
END
GO

CREATE PROCEDURE insertReceiptNoteDetail
	@rNoteID varchar(7),
	@materialID varchar(3),
	@quantity INT,
	@unitPrice DECIMAL(10,2)
AS
BEGIN
	INSERT INTO ReceiptNoteDetail(rNoteID, materialID, quantity, unitPrice)
	VALUES (@rNoteID, @materialID, @quantity, @unitPrice)
END
GO

CREATE PROCEDURE insertDelivery
	@materialID varchar(3),
	@supplierID varchar(4)
AS
BEGIN
	INSERT INTO Delivery(materialID, supplierID)
	VALUES (@materialID, @supplierID)
END
GO

CREATE PROCEDURE insertExpenseBill
	@ID varchar(7),
	@detail nvarchar(max),
	@price DECIMAL(18,2),
	@date DATE
AS
BEGIN
	INSERT INTO ExpenseBill(ID, detail, price, date)
	VALUES (@ID, @detail, @price, @date)
END
GO

CREATE PROCEDURE insertAccount
	@userName VARCHAR(10),
	@pass VARCHAR(max),
	@userRole INT
AS
BEGIN
	INSERT INTO Account(userName, pass, userRole)
	VALUES (@userName, @pass, @userRole)
END
GO

/* DELETE BY ID */

CREATE PROCEDURE deleteEmployeeByID
	@ID VARCHAR(3)
AS
BEGIN
	DELETE FROM Employee WHERE ID = @ID
END
GO

CREATE PROCEDURE deleteJobByID
	@ID VARCHAR(3)
AS
BEGIN
	DELETE FROM Job WHERE ID = @ID
END
GO

CREATE PROCEDURE deleteShiftByID
	@ID VARCHAR(5)
AS
BEGIN
	DELETE FROM [Shift] WHERE ID = @ID
END
GO

CREATE PROCEDURE deleteOnDutyByID
	@empID VARCHAR(3),
	@shiftID VARCHAR(5),
	@date DATE
AS
BEGIN
	DELETE FROM On_Duty WHERE empID = @empID AND shiftID = @shiftID AND date = @date
END
GO

CREATE PROCEDURE deleteTableByID
	@ID VARCHAR(3)
AS
BEGIN
	DELETE FROM [Table] WHERE ID = @ID
END
GO

CREATE PROCEDURE deleteCustomerByID
	@ID VARCHAR(5)
AS
BEGIN
	DELETE FROM Customer WHERE ID = @ID
END
GO

CREATE PROCEDURE deleteBillCategoryByID
	@ID VARCHAR(4)
AS
BEGIN
	DELETE FROM BillCategory WHERE ID = @ID
END
GO

CREATE PROCEDURE deleteBillByID
	@ID VARCHAR(7)
AS
BEGIN
	DELETE FROM Bill WHERE ID = @ID
END
GO

CREATE PROCEDURE deleteProductCategoryByID
	@ID VARCHAR(4)
AS
BEGIN
	DELETE FROM ProductCategory WHERE ID = @ID
END
GO

CREATE PROCEDURE deleteProductByID
	@ID VARCHAR(3)
AS
BEGIN
	DELETE FROM Product WHERE ID = @ID
END
GO

CREATE PROCEDURE deleteBillInfoByID
	@billID VARCHAR(7),
	@productID VARCHAR(3)
AS
BEGIN
	DELETE FROM BillInfo WHERE billID = @billID AND productID = @productID
END
GO

CREATE PROCEDURE deleteMaterialByID
	@ID VARCHAR(3)
AS
BEGIN
	DELETE FROM Material WHERE ID = @ID
END
GO

CREATE PROCEDURE deleteProductMaterialByID
	@productID VARCHAR(3),
	@materialID VARCHAR(3)
AS
BEGIN
	DELETE FROM Product_Material WHERE productID = @productID AND materialID = @materialID
END
GO

CREATE PROCEDURE deleteSupplierByID
	@ID VARCHAR(4)
AS
BEGIN
	DELETE FROM Supplier WHERE ID = @ID
END
GO

CREATE PROCEDURE deleteReceiptNoteByID
	@ID VARCHAR(7)
AS
BEGIN
	DELETE FROM ReceiptNote WHERE ID = @ID
END
GO

CREATE PROCEDURE deleteReceiptNoteDetailByID
	@rNoteID VARCHAR(7),
	@materialID VARCHAR(3)
AS
BEGIN
	DELETE FROM ReceiptNoteDetail WHERE rNoteID = @rNoteID AND materialID = @materialID
END
GO

CREATE PROCEDURE deleteDeliveryByID
	@materialID VARCHAR(3),
	@supplierID VARCHAR(4)
AS
BEGIN
	DELETE FROM Delivery WHERE materialID = @materialID AND supplierID = @supplierID
END
GO

CREATE PROCEDURE deleteExpenseBillByID
	@ID VARCHAR(7)
AS
BEGIN
	DELETE FROM ExpenseBill WHERE ID = @ID
END
GO

CREATE PROCEDURE deleteAccountByID
	@userName VARCHAR(10)
AS
BEGIN
	DELETE FROM Account WHERE userName = @userName
END
GO

/* UPDATE BY ID */

CREATE PROCEDURE updateEmployeeByID
	@ID VARCHAR(3) ,
	@name NVARCHAR(max),
	@birthDate DATE,
	@address NVARCHAR(max),
	@phone VARCHAR(10),
	@recruitmentDate DATE ,
	@jobID VARCHAR(3),
	@penaltyPoint INT,
	@bonusPoint INT,
	@numberOfShift INT
AS
BEGIN
	UPDATE Employee
	SET name = @name, birthDate = @birthDate, address = @address, phone = @phone, recruitmentDate = @recruitmentDate, jobID = @jobID, penaltyPoint = @penaltyPoint, bonusPoint = @bonusPoint, numberOfShift = @numberOfShift
	WHERE ID = @ID
END
GO

CREATE PROCEDURE updateJobByID
	@ID VARCHAR(3),
	@jobDetail NVARCHAR(max),
	@salary DECIMAL(10, 2)
AS
BEGIN
	UPDATE Job
	SET jobDetail = @jobDetail, salary = @salary
	WHERE ID = @ID
END
GO

CREATE PROCEDURE updateShiftByID
	@ID VARCHAR(5),
	@startTime TIME,
	@endTime TIME
AS
BEGIN
	UPDATE [Shift]
	SET startTime = @startTime, endTime = @endTime
	WHERE ID = @ID
END
GO

CREATE PROCEDURE updateOnDutyByID
	@empID varchar(3),
	@shiftID varchar(3),
	@date DATE
AS
BEGIN
	UPDATE On_Duty
	SET empID = @empID, shiftID = @shiftID
	WHERE empID = @empID AND shiftID = @shiftID AND date = @date
END
GO

CREATE PROCEDURE updateTableByID
	@ID varchar(3),
	@name nvarchar(max),
	@status nvarchar(max)
AS
BEGIN
	UPDATE [Table]
	SET name = @name, status = @status
	WHERE ID = @ID
END
GO

CREATE PROCEDURE updateCustomerByID
	@ID varchar(5),
	@name nvarchar(max),
	@phone varchar(10),
	@bonusPoint INT
AS
BEGIN
	UPDATE Customer
	SET name = @name, phone = @phone, bonusPoint = @bonusPoint
	WHERE ID = @ID
END
GO

CREATE PROCEDURE updateBillCategoryByID
	@ID varchar(4),
	@name nvarchar(max),
	@discount DECIMAL(5,2)
AS
BEGIN
	UPDATE BillCategory
	SET name = @name, discount = @discount
	WHERE ID = @ID
END
GO

CREATE PROCEDURE updateBillByID
	@ID varchar(7),
	@dateTime DATETIME,
	@tableID varchar(3),
	@customerID varchar(5),
	@categoryID varchar(4),
	@empID varchar(3),
	@receiptMoney DECIMAL(10,2)
AS
BEGIN
	UPDATE Bill
	SET dateTime = @dateTime, tableID = @tableID, customerID = @customerID, categoryID = @categoryID, empID = @empID, receiptMoney = @receiptMoney
	WHERE ID = @ID
END
GO

CREATE PROCEDURE updateProductCategoryByID
	@ID varchar(4),
	@name nvarchar(max)
AS
BEGIN
	UPDATE ProductCategory
	SET name = @name
	WHERE ID = @ID
END
GO

CREATE PROCEDURE updateProductByID
	@ID varchar(3),
	@name nvarchar(max),
	@categoryID varchar(4),
	@price DECIMAL(10,2),
	@status nvarchar(max)
AS
BEGIN
	UPDATE Product
	SET name = @name, categoryID = @categoryID, price = @price, status = @status
	WHERE ID = @ID
END
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

CREATE PROCEDURE updateMaterialByID
	@ID varchar(3),
	@name nvarchar(max),
	@status nvarchar(max)
AS
BEGIN
	UPDATE Material
	SET name = @name, status = @status
	WHERE ID = @ID
END
GO

CREATE PROCEDURE updateProductMaterialByID
	@productID varchar(3),
	@materialID varchar(3),
	@quantity INT
AS
BEGIN
	UPDATE Product_Material
	SET quantity = @quantity
	WHERE productID = @productID AND materialID = @materialID
END
GO

CREATE PROCEDURE updateSupplierByID
	@ID varchar(4),
	@name nvarchar(max),
	@address nvarchar(max),
	@phone varchar(10)
AS
BEGIN
	UPDATE Supplier
	SET name = @name, address = @address, phone = @phone
	WHERE ID = @ID
END
GO

CREATE PROCEDURE updateReceiptNoteByID
	@ID varchar(7),
	@date DATE,
	@price DECIMAL(10,2),
	@supplierID varchar(4),
	@empID varchar(3)
AS
BEGIN
	UPDATE ReceiptNote
	SET date = @date, price = @price, supplierID = @supplierID, empID = @empID
	WHERE ID = @ID
END
GO

CREATE PROCEDURE updateReceiptNoteDetailByID
	@rNoteID varchar(7),
	@materialID varchar(3),
	@quantity INT,
	@unitPrice DECIMAL(10,2)
AS
BEGIN
	UPDATE ReceiptNoteDetail
	SET quantity = @quantity, unitPrice = @unitPrice
	WHERE rNoteID = @rNoteID AND materialID = @materialID
END
GO

CREATE PROCEDURE updateDeliveryByID
	@materialID varchar(3),
	@supplierID varchar(4)
AS
BEGIN
	UPDATE Delivery
	SET materialID = @materialID, supplierID = @supplierID
	WHERE materialID = @materialID AND supplierID = @supplierID
END
GO

CREATE PROCEDURE updateExpenseBillByID
	@ID varchar(7),
	@detail nvarchar(max),
	@price DECIMAL(18,2),
	@date DATE
AS
BEGIN
	UPDATE ExpenseBill
	SET detail = @detail, price = @price, date = @date
	WHERE ID = @ID
END
GO

CREATE PROCEDURE updateAccountByID
	@userName VARCHAR(10),
	@pass VARCHAR(max)
AS
BEGIN
	UPDATE Account
	SET pass = @pass
	WHERE userName = @userName
END
GO

/* SELECT ALL */

CREATE PROCEDURE selectAllEmployee
AS
BEGIN
	SELECT * FROM Employee
END
GO

CREATE PROCEDURE selectAllJob
AS
BEGIN
	SELECT * FROM Job
END
GO

CREATE PROCEDURE selectAllShift
AS
BEGIN
	SELECT * FROM [Shift]
END
GO

CREATE PROCEDURE selectAllOnDuty
AS
BEGIN
	SELECT * FROM On_Duty
END
GO

CREATE PROCEDURE selectAllTable
AS
BEGIN
	SELECT * FROM [Table]
END
GO

CREATE PROCEDURE selectAllCustomer
AS
BEGIN
	SELECT * FROM Customer
END
GO

CREATE PROCEDURE selectAllBillCategory
AS
BEGIN
	SELECT * FROM BillCategory
END
GO

CREATE PROCEDURE selectAllBill
AS
BEGIN
	SELECT * FROM Bill
END	
GO

CREATE PROCEDURE selectAllProductCategory
AS
BEGIN
	SELECT * FROM ProductCategory
END
GO

CREATE PROCEDURE selectAllProduct
AS
BEGIN
	SELECT * FROM Product
END
GO

CREATE PROCEDURE selectAllBillInfo
AS
BEGIN
	SELECT * FROM BillInfo
END
GO

CREATE PROCEDURE selectAllMaterial
AS
BEGIN
	SELECT * FROM Material
END
GO

CREATE PROCEDURE selectAllProductMaterial
AS
BEGIN
	SELECT * FROM Product_Material
END
GO

CREATE PROCEDURE selectAllSupplier
AS
BEGIN
	SELECT * FROM Supplier
END
GO

CREATE PROCEDURE selectAllReceiptNote
AS
BEGIN
	SELECT * FROM ReceiptNote
END
GO

CREATE PROCEDURE selectAllReceiptNoteDetail
AS
BEGIN
	SELECT * FROM ReceiptNoteDetail
END
GO

CREATE PROCEDURE selectAllDelivery
AS
BEGIN
	SELECT * FROM Delivery
END
GO

CREATE PROCEDURE selectAllExpenseBill
AS
BEGIN
	SELECT * FROM ExpenseBill
END
GO

CREATE PROCEDURE selectAllAccount
AS
BEGIN
	SELECT * FROM Account
END
GO

/* SELECT BY ID */

CREATE PROCEDURE selectEmployeeByID
	@ID VARCHAR(3)
AS
BEGIN
	SELECT * FROM Employee WHERE ID = @ID
END
GO

CREATE PROCEDURE selectJobByID
	@ID VARCHAR(3)
AS
BEGIN
	SELECT * FROM Job WHERE ID = @ID
END
GO

CREATE PROCEDURE selectShiftByID
	@ID VARCHAR(5)
AS
BEGIN
	SELECT * FROM [Shift] WHERE ID = @ID
END
GO

CREATE PROCEDURE selectOnDutyByID
	@empID VARCHAR(3),
	@shiftID VARCHAR(5),
	@date DATE
AS
BEGIN
	SELECT * FROM On_Duty WHERE empID = @empID AND shiftID = @shiftID AND date = @date
END
GO

CREATE PROCEDURE selectTableByID
	@ID VARCHAR(3)
AS
BEGIN
	SELECT * FROM [Table] WHERE ID = @ID
END
GO

CREATE PROCEDURE selectCustomerByID
	@ID VARCHAR(5)
AS
BEGIN
	SELECT * FROM Customer WHERE ID = @ID
END
GO

CREATE PROCEDURE selectBillCategoryByID
	@ID VARCHAR(4)
AS
BEGIN
	SELECT * FROM BillCategory WHERE ID = @ID
END
GO

CREATE PROCEDURE selectBillByID
	@ID VARCHAR(7)
AS
BEGIN
	SELECT * FROM Bill WHERE ID = @ID
END
GO

CREATE PROCEDURE selectProductCategoryByID
	@ID VARCHAR(4)
AS
BEGIN
	SELECT * FROM ProductCategory WHERE ID = @ID
END
GO

CREATE PROCEDURE selectProductByID
	@ID VARCHAR(3)
AS
BEGIN
	SELECT * FROM Product WHERE ID = @ID
END
GO

CREATE PROCEDURE selectBillInfoByID
	@billID VARCHAR(7),
	@productID VARCHAR(3)
AS
BEGIN
	SELECT * FROM BillInfo WHERE billID = @billID AND productID = @productID
END
GO

CREATE PROCEDURE selectMaterialByID
	@ID VARCHAR(3)
AS
BEGIN
	SELECT * FROM Material WHERE ID = @ID
END
GO

CREATE PROCEDURE selectProductMaterialByID
	@productID VARCHAR(3),
	@materialID VARCHAR(3)
AS
BEGIN
	SELECT * FROM Product_Material WHERE productID = @productID AND materialID = @materialID
END
GO

CREATE PROCEDURE selectSupplierByID
	@ID VARCHAR(4)
AS
BEGIN
	SELECT * FROM Supplier WHERE ID = @ID
END
GO

CREATE PROCEDURE selectReceiptNoteByID
	@ID VARCHAR(7)
AS
BEGIN
	SELECT * FROM ReceiptNote WHERE ID = @ID
END
GO

CREATE PROCEDURE selectReceiptNoteDetailByID
	@rNoteID VARCHAR(7),
	@materialID VARCHAR(3)
AS
BEGIN
	SELECT * FROM ReceiptNoteDetail WHERE rNoteID = @rNoteID AND materialID = @materialID
END
GO

CREATE PROCEDURE selectDeliveryByID
	@materialID VARCHAR(3),
	@supplierID VARCHAR(4)
AS
BEGIN
	SELECT * FROM Delivery WHERE materialID = @materialID AND supplierID = @supplierID
END
GO

CREATE PROCEDURE selectExpenseBillByID
	@ID VARCHAR(7)
AS
BEGIN
	SELECT * FROM ExpenseBill WHERE ID = @ID
END
GO

CREATE PROCEDURE selectAccountByID
	@userName VARCHAR(10)
AS
BEGIN
	SELECT * FROM Account WHERE userName = @userName
END
GO

/* CHECK ROLE */
CREATE PROCEDURE checkRole
	@userName VARCHAR(10)
AS
BEGIN
	SELECT userRole FROM Account WHERE userName = @userName
END
GO

/* FUNCTION */

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

/* VIẾT HÀM KIỂM TRA XEM CÓ TỒN TẠI KHÁCH HÀNG CÓ SỐ ĐIỆN THOẠI ĐÓ KHÔNG, NẾU CÓ THÌ TRẢ VỀ CUSTOMER KHÔNG THÌ IN RA MÀN HÌNH KHÔNG CÓ KHÁCH HÀNG */

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

/* VIẾT LẤY TÊN NHÂN VIÊN KHI CÓ NGÀY VÀ CA TRỰC */

CREATE FUNCTION getEmployeeName
	(@date DATE, @shiftID VARCHAR(3), @job NVARCHAR(MAX))
	RETURNS NVARCHAR(MAX)
AS
BEGIN
	DECLARE @result NVARCHAR(MAX)
	SET @result = (SELECT Employee.ID
	FROM Employee, On_Duty, Job
	WHERE Employee.ID = On_Duty.empID
	AND On_Duty.date = @date
	AND On_Duty.shiftID = @shiftID
	AND Employee.jobID = (SELECT ID FROM Job WHERE jobDetail = @job))
	RETURN @result
END
GO