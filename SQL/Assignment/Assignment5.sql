create database Assignment5

use Assignment5

create or alter procedure sp_Payslip 
    @EmpID int
as
begin
    declare @Salary decimal(10, 2)
    declare @HRA decimal(10, 2)
    declare @DA decimal(10, 2)
    declare @PF decimal(10, 2)
    declare @IT decimal(10, 2)
    declare @Deductions decimal(10, 2)
    declare @GrossSalary decimal(10, 2)
    declare @NetSalary decimal(10, 2)
 
    select @Salary = Sal from Emp where Empno = @EmpID
 
   
    set @HRA = @Salary * 0.10      -- HRA = 10% of Salary
    set @DA = @Salary * 0.20       -- DA = 20% of Salary
    set @PF = @Salary * 0.08       -- PF = 8% of Salary
    set @IT = @Salary * 0.05       -- IT = 5% of Salary
    set @Deductions = @PF + @IT
    set @GrossSalary = @Salary + @HRA + @DA
    set @NetSalary = @GrossSalary - @Deductions
    print '-----------------------------------'
    print '           Payslip Details          '
    print '-----------------------------------'
    print 'Employee ID: ' + cast(@EmpID as varchar(10))
    print 'Salary: ' + cast(@Salary as varchar(10))
    print '-----------------------------------'
    print 'HRA (10%): ' + cast(@HRA as varchar(10))
    print 'DA (20%): ' + cast(@DA as varchar(10))
    print 'PF (8%): ' + cast(@PF as varchar(10))
    print 'IT (5%): ' + cast(@IT as varchar(10))
    print '-----------------------------------'
    print 'Deductions (PF + IT): ' + CAST(@Deductions as varchar(10))
    print 'Gross Salary: ' + CAST(@GrossSalary as varchar(10))
    print 'Net Salary: ' + CAST(@NetSalary as varchar(10))
    print '-----------------------------------'
end
exec sp_Payslip @EmpID = 7369

--2

CREATE TABLE Holiday (
    holiday_date DATE PRIMARY KEY,
    holiday_name VARCHAR(100)
)
truncate table Holiday;
INSERT INTO Holiday (holiday_date, holiday_name)
VALUES 
    ('2024-08-15', 'Independence Day'),
    ('2024-01-26', 'Republic Holiday'),
    ('2024-12-25', 'Christmas'),
    ('2025-01-01', 'New Year')

 
select * from Holiday;
 
create or alter trigger RestrictDMLonHolidays on EMP
Instead of insert , update, delete as 
begin
	declare @isHoliday bit;
	declare @HolidayName varchar(100);
 
	select top 1 @HolidayName = holiday_name from Holiday where holiday_date = CONVERT(DATE, GETDATE());
	if @HolidayName is not null 
	begin
		--RAISERROR('Due to %s, you cannot perform manipulation to data.',16,1,@HolidayName);
		RAISERROR('Due to %s, you cannot perform manipulation to data.', 16, 1, @HolidayName);
 
	end
	else
    begin
        PRINT 'Data manipulation is allowed on non-holiday dates.';
        UPDATE EMP SET Mgr_id = 0000 WHERE Ename = 'SMITH';
    end
end;
 
select * from EMP;
DELETE FROM EMP WHERE EmpNo = 7369;

