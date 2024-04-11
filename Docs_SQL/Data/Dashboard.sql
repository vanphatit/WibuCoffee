USE WibuCoffee
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
WITH NumberSeries AS (
    SELECT 0 AS Number
    UNION ALL SELECT 1
    UNION ALL SELECT 2
    UNION ALL SELECT 3
    UNION ALL SELECT 4
    UNION ALL SELECT 5
    UNION ALL SELECT 6
),
DateSeries AS (
    SELECT CAST(DATEADD(DAY, -Number, GETDATE()) AS DATE) AS DateValue
    FROM NumberSeries
)
SELECT
    ds.DateValue AS [Date],
    (SELECT ISNULL(SUM(totalPrice), 0) FROM BillTotalPriceView WHERE CAST(dateTime AS DATE) = ds.DateValue) AS BillCount,
    (SELECT ISNULL(SUM(price),0) FROM ExpenseBill WHERE CAST(date AS DATE) = ds.DateValue) AS ExpenseCount
FROM
    DateSeries ds;
GO


SELECT * FROM BillExpenseCount7DaysAgo

-- create function to get total revenue for 1 month ago
DROP FUNCTION IF EXISTS getTotalRevenue1MonthAgo
GO

CREATE FUNCTION getTotalRevenue1MonthAgo()
RETURNS DECIMAL(10,0)
AS
BEGIN
	DECLARE @total DECIMAL(10,0);

	SELECT @total = SUM(totalPrice) 
	FROM BillTotalPriceView
	WHERE CAST(dateTime AS date) >= CAST(DATEADD(MONTH, -1, GETDATE()) AS date);

	RETURN ISNULL(@total, 0);
END;
GO

SELECT dbo.getTotalRevenue1MonthAgo()

