create  database Assignment2

use Assignment2
 
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
 
insert into Dept values(10,'Accounting','New York'),
(20,'Research','Dallas'),
(30,'Sales','Chicago'),
(40,'Operations','Boston')
 
select*from Dept
 
 
--1)All employees whose name begins with 'A'
 
select * from Emp where Ename like 'A%'
 
--2)Employees Who don't have Manager
select*from Emp where MGR_Id is null
 
--3)Employee who earn between 1200 to 1400
select Ename,Comm,Sal from Emp where Sal between 1200 and 1400
 
--4)10% rise for research dept
--update Emp set Sal=Sal*0.10 where exists(select Deptno from Dept where Dname='Research')
update Emp   set Sal=Sal+Sal*0.10 where Deptno in (select Deptno from Dept where Dname ='research')
 
 
 
--5)Number of clerks
select Count(Job)as'No of Clerks'from Emp where Job='clerk'
 
--6)Avg salary and no of People in each job
 
select job,count(Job) as 'No of People', AVG(Sal)as 'Average salary'  from Emp 
group by Job
 
 
--7)Employee with Lowest and Highest salary
 
select max(Sal) as 'Highest salary',min(Sal) as 'Lowest salary' from Emp
 
--8)details of departments that don't have any employees
select deptno, Dname,loc from Dept 
   where not exists(select * from Emp where Emp.Deptno = Dept.DeptNo)
 
 
--9)Salaries of all analysts earning more than 1200 based on department 2.name in ascending order 
SELECT Ename, Sal FROM Emp WHERE Deptno = 20 AND Job = 'Analyst' AND Sal > 1200 ORDER BY Ename ASC
 
 
--10)department and total salary paid to that department
select d.Dname, d.Deptno, SUM(e.Sal) AS Salary FROM Dept d JOIN Emp e ON d.Deptno = e.Deptno GROUP BY d.Dname, d.Deptno ORDER BY d.Deptno
 
 
--11)Salray of both Miller and Smith
Select Ename,Sal from Emp where Ename in ('Miller','Smith')
 
--12)Names of the Employee Whose Name with 'A' or'M'
Select Ename from Emp where Ename like'[am]%'
 
--13) Yearly Salary of Smith
select Ename, Sal*12 as'Annual salary' from Emp where Ename='Smith'
 
--14)Name and Salary of employees whose salary not in range 1500 and 2850
select Ename,Sal from Emp where Sal not between 1500 and 2850
 
--15)Managers who have more than 2 Employees
 
select MGR_Id ,count(*) AS Employees from Emp where MGR_Id  is not null group by MGR_Id  having count(*) > 2;