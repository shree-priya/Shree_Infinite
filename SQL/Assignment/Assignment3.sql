create database Assignment3

use Assignment3

create  table Dept(Deptno int Primary key,
Dname varchar(40),
loc varchar(40))
 
create table Emp(Empno int primary key,
Ename varchar(20) not null,
Job varchar(20),
MGR_Id int,
HireDate Date, 
Sal float,
Comm int,
Deptno  int foreign key references Dept(Deptno))
 
 
insert into Dept values(10,'Accounting','New York'),
(20,'Research','Dallas'),
(30,'Sales','Chicago'),
(40,'Operations','Boston')
 
 
insert into Emp values
(7369,'SMITH','CLERK',7902,'17-Dec-80',800,null,20),
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
 
 

-- 1. Retrieve a list of MANAGERS.
SELECT Ename FROM Emp WHERE Job = 'MANAGER';

-- 2. Find out the names and salaries of all employees earning more than 1000 per month.
SELECT Ename, Sal FROM Emp WHERE Sal > 1000;

-- 3. Display the names and salaries of all employees except JAMES.
SELECT Ename, Sal FROM Emp WHERE Ename != 'JAMES';

-- 4. Find out the details of employees whose names begin with ‘S’.
SELECT * FROM Emp WHERE Ename LIKE 'S%';

-- 5. Find out the names of all employees that have ‘A’ anywhere in their name.
SELECT Ename FROM Emp WHERE Ename LIKE '%A%';

-- 6. Find out the names of all employees that have ‘L’ as their third character in their name.
SELECT Ename FROM Emp WHERE Ename LIKE '__L%';

-- 7. Compute daily salary of JONES.
SELECT Ename, Sal / 30 AS DailySalary FROM Emp WHERE Ename = 'JONES';

-- 8. Calculate the total monthly salary of all employees.
SELECT SUM(Sal) AS TotalMonthlySalary FROM Emp;

-- 9. Print the average annual salary.
SELECT AVG(Sal * 12) AS AverageAnnualSalary FROM Emp;

-- 10. Select the name, job, salary, department number of all employees except SALESMAN from department number 30.
SELECT Ename, Job, Sal, Deptno FROM Emp WHERE Deptno = 30 AND Job != 'SALESMAN';

-- 11. List unique departments of the EMP table.
SELECT DISTINCT Deptno FROM Emp;

-- 12. List the name and salary of employees who earn more than 1500 and are in department 10 or 30. Label the columns Employee and Monthly Salary respectively.
SELECT Ename AS Employee, Sal AS "Monthly Salary" FROM Emp WHERE Sal > 1500 AND Deptno IN (10, 30);

-- 13. Display the name, job, and salary of all the employees whose job is MANAGER or ANALYST and their salary is not equal to 1000, 3000, or 5000.
SELECT Ename, Job, Sal FROM Emp WHERE (Job = 'MANAGER' OR Job = 'ANALYST') AND Sal NOT IN (1000, 3000, 5000);

-- 14. Display the name, salary and commission for all employees whose commission amount is greater than their salary increased by 10%.
SELECT Ename, Sal, Comm FROM Emp WHERE Comm > (Sal * 1.10);

-- 15. Display the name of all employees who have two Ls in their name and are in department 30 or their manager is 7782.
SELECT Ename FROM Emp WHERE Ename LIKE '%L%L%' AND (Deptno = 30 OR MGR_Id = 7782);

-- 16. Display the names of employees with experience of over 30 years and under 40 years. Count the total number of employees.
SELECT Ename FROM Emp WHERE DATEDIFF(YEAR, HireDate, GETDATE()) BETWEEN 30 AND 40;

-- 17. Retrieve the names of departments in ascending order and their employees in descending order.
SELECT D.Dname, E.Ename, E.HireDate FROM Dept D JOIN Emp E ON D.Deptno = E.Deptno ORDER BY D.Dname ASC, E.HireDate DESC;


-- 18. Find out experience of MILLER.
SELECT DATEDIFF(YEAR, HireDate, GETDATE()) AS Experience FROM Emp WHERE Ename = 'MILLER';
