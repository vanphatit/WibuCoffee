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
WHERE Employee.jobID = Job.ID AND Employee.phone = EmployeeShiftView.phone
GROUP BY Employee.name, Job.jobDetail, Employee.ID, Job.salary
GO

--VIẾT HÀM LỌC THEO TÊN NHÂN VIÊN, CÔNG VIỆC, LƯƠNG TỪ BẢNG VIEW EMPLOYEEDETAILVIEW

DROP PROCEDURE IF EXISTS filterEmployee
GO

CREATE PROCEDURE filterEmployee
	@name NVARCHAR(max),
	@job NVARCHAR(max),
	@salary INT
AS
BEGIN
	SELECT * FROM EmployeeDetailView
	WHERE name LIKE '%' + @name + '%' AND job LIKE '%' + @job + '%' AND salary >= @salary
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

-- VIẾT HÀM CẬP NHẬT LƯƠNG HIỆN TẠI CỦA CÔNG VIỆC

DROP PROCEDURE IF EXISTS updateSalary
GO

CREATE PROCEDURE updateSalary
	@job NVARCHAR(max),
	@salary INT
AS
BEGIN
	UPDATE Job
	SET salary = @salary
	WHERE jobDetail = @job
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

DROP PROCEDURE IF EXISTS shiftDetail
GO

CREATE PROCEDURE shiftDetail
AS
BEGIN
	SELECT * FROM ShiftDetailView
	ORDER BY date ASC, ID ASC
END
GO
