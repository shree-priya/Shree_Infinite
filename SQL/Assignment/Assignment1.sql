use infiniteDB;
 
create table Clients(
Client_ID int primary key,
CName varchar(40) not null,
Address varchar(30),
Email varchar(30) unique,
Phone bigint,
Business varchar(20) not null)
 
 
create table Departments
(Deptno int primary key,
Dname varchar(15) not null,
Loc varchar(20))
 
 
 
create table Employees(
Empno int primary key,
EName varchar(40) not null,
Job varchar(15),
Salary bigint check(salary>0),
Deptno int foreign key references Departments(Deptno))
 
create table Projects
(Project_ID int primary key,
Descr varchar(30) not null,
Start_date DATE,
Planned_End_Date DATE,
Actual_End_Date DATE,
constraint check_date check(planned_end_date<actual_end_date),
Budget bigint check(budget>0),
Client_ID int foreign key references Clients(Client_ID))
 
 
create table EmpProjectTasks
(Project_ID int foreign key references Projects(Project_ID),
Emp_no int foreign key references Employees(Empno),
Start_date DATE,
End_date DATE,
Task varchar(25) not null,
Status varchar(15) not null,
primary key (Project_ID,Emp_no))
 
 
insert into Clients values
(1001,'ACME Utilities','Noida','contact@acmeutil.com',9567880032,'Manufacturing'),
(1002,'Trackon Consultants','Mumbai','consult@trackon.com',8734210090,'Consultant'),
(1003,'MoneySaver Distributors','kolkata','save@moneysaver.com',7799886655,'Reseller'),
(1004,'Lawful Corp','Chennai','justice@lawful.com',9210342219,'Professional')
 
select * from Clients
 
 
insert into Employees values
(7001,'Sandeep','Analyst',25000,10),
(7002,'Rajesh','Designer',30000,10),
(7003,'Madhav','Developer',40000,20),
(7004,'Manoj','Developer',40000,20),
(7005,'Abhay','Designer',35000,10),
(7006,'Uma','Tester',30000,30),
(7007,'Gita','Test.Writer',30000,40),
(7008,'Priya','Tester',35000,30),
(7009,'Nutan','Developer',45000,20),
(7010,'Smita','Analyst',20000,10),
(7011,'Anand','Project Manager',65000,10)
select * from Employees
 
insert into Departments values
(10,'Design','Pune'),(20,'Development','Pune'),
(30,'Testing','Mumbai'),(40,'Document','Mumbai')
select * from Departments
 
 
insert into Projects values
(401,'Inventory','2011-04-01','2011-10-01','2011-10-31',150000,1001),
(402,'Accounting','2011-08-01','2012-01-01',null,50000,1002),
(403,'Payroll','2011-10-01','2011-12-31',null,75000,1003),
(404,'Contact Management','2011-11-01','2011-12-31',null,50000,1004)
select * from Projects
 
 
insert into EmpProjectTasks values
(401,7001,'2011-04-01','2011-04-11','System Analysis','Completed'),
(401,7002,'2011-08-21','2011-05-30','System Design','Completed'),
(401,7003,'2011-06-11','2011-07-15','Coding','Completed'),
(401,7004,'2011-07-18','2011-09-11','Coding','Completed'),
(401,7006,'2011-06-11','2011-07-15','Testing','Completed'),
(401,7009,'2011-09-18','2011-10-05','Code change','Completed'),
(401,7008,'2011-10-06','2011-10-16','Testing','Completed'),
(401,7007,'2011-10-06','2011-10-22','Documentation','Completed'),
(401,7011,'2011-10-22','2011-10-31','Sign off','Completed'),
(402,7010,'2011-08-01','2011-08-20','System Analysis','Completed'),
(402,7002,'2011-08-22','2011-09-30','System Design','Completed'),
(402,7004,'2011-10-01',null,'Coding','In Progress')
select * from EmpProjectTasks
 