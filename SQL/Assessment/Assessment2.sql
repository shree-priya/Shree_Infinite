create database Assessment2

use Assessment2

create table Emp(Empno int primary key,
Ename varchar(20) not null,
Job varchar(20),
MGR_Id int,
HireDate Date, 
Sal float,
Comm int,
Deptno  int )
 
create  table Dept(Deptno int,
Dname varchar(40),
loc varchar(40))
 
 
insert into Emp values(7369,'SMITH','CLERK',7902,'17-Dec-80',800,null,20),
(7499,'ALLEN','SALESMAN',7698,'20-FEB-81',1600,300,30),
(7521,'WARD','SALESMAN',7698,'22-FEB-81',1250,500,30),
(7566,'JONES','MANAGER',7839,'02-APR-81',2975,null,20),
(7654,'MARTIN','SALESMAN',7698,'28-SEP-81',1250,1400,30),
(7698,'BLAKE','MANAGER',7839,'01-MAY-81',2850,null,30),
(7782,'CLARK','MANAGER',7839,'09-JUN-81',2450,null,10),
(7788,'SCOTT','ANALYST',7566,'19-APR-87',3000,null,20),
(7839,'KING','PRESIDENT',null,'17-NOV-81',5000,null,10),
(7844,'TURNER','SALESMAN',7698,'08-SEP-81',1500,0,30),
(7876,'ADAMS','CLERK',7788,'23-MAY-87',1100,null,20),
(7900,'JAMES','CLERK',7698,'03-DEC-81',950,null,30),
(7902,'FORD','ANALYST',7566,'03-DEC-81',3000,null,20),
(7934,'MILLER','CLERK',7782,'23-JAN-82',1300,null,10)
 
select * from Emp

UPDATE Emp SET HireDate = '2019-12-10' WHERE Empno = 7369;  
UPDATE Emp SET HireDate = '2020-12-15' WHERE Empno = 7499;  
UPDATE Emp SET HireDate = '2021-12-05' WHERE Empno = 7521;  
UPDATE Emp SET HireDate = '2022-12-25' WHERE Empno = 7566;
UPDATE Emp SET HireDate = '2018-12-01' WHERE Empno = 7698;  
UPDATE Emp SET HireDate = '2020-12-10' WHERE Empno = 7782; 
 
insert into Dept values(10,'Accounting','New York'),
(20,'Research','Dallas'),
(30,'Sales','Chicago'),
(40,'Operations','Boston')
 
select*from Dept

---Write a query to display your birthday( day of week)

SELECT DATENAME(WEEKDAY, '2002-12-25') AS BDAY_DAY_WEEK;

--Write a query to display your age in days

SELECT DATEDIFF(DAY, '2002-12-25', GETDATE()) AS Age_in_days;

--Write a query to display all employees information those who joined before 5 years in the current month

SELECT * FROM Emp 
WHERE HireDate <= DATEADD(YEAR, -5, GETDATE()) AND MONTH(HireDate) = MONTH(GETDATE())     

--Create a procedure to update the salary of employee by 500 whose dept name is Sales and current salary is below 1500 (use emp table)

CREATE PROCEDURE Update_Salary
AS
BEGIN
    UPDATE Emp
    SET Sal = Sal + 500
    WHERE Deptno = (SELECT Deptno FROM Dept WHERE Dname = 'Sales')
    AND Sal < 1500;
END;

EXEC Update_Salary;
SELECT * FROM EMP;

--4


BEGIN TRANSACTION;
CREATE TABLE Employee (empno INT PRIMARY KEY,ename VARCHAR(20),sal FLOAT,
doj DATE);

INSERT INTO Employee (empno, ename, sal, doj) VALUES (1, 'Priya', 1670, '2020-08-01');
INSERT INTO Employee (empno, ename, sal, doj) VALUES (2, 'Ram', 1500, '2021-07-20');
INSERT INTO Employee (empno, ename, sal, doj) VALUES (3, 'Rahul', 1000, '2022-08-15');


UPDATE Employee 
SET sal = sal * 1.15 
WHERE empno = 2;


DELETE FROM Employee WHERE empno = 1;
COMMIT;

INSERT INTO Employee (empno, ename, sal, doj) VALUES (1, 'Priya', 1670, '2020-08-01');

SELECT * FROM Employee;

--5
CREATE FUNCTION calculateBonus (@Deptno INT)
RETURNS FLOAT
AS
BEGIN
    DECLARE @bonus_rate FLOAT;
    
    IF @Deptno = 10
        SET @bonus_rate = 0.15;
    ELSE IF @Deptno = 20
        SET @bonus_rate = 0.20;
    ELSE
        SET @bonus_rate = 0.05;

    RETURN @bonus_rate;
END;

SELECT empno, ename, sal, dbo.calculateBonus(Deptno) * sal AS bonus FROM Emp;









 