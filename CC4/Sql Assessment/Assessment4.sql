create database Assessment1

use Assessment1;

---creating table books

create table Books 
(Book_id int primary key, Title varchar(20), Author varchar(20), 
ISBN bigint unique, Published_date DateTime)

--inserting values 

insert into books values 
(1,'My First SQL Book','Mary Parker',981483029127,'2012-02-22 12:08:17'), 
(2,'My Second SQL Book','John Mayer',857300923713,'1972-07-03 09:22:45'), 
(3,'My Third SQL Book','Cary Flint',523120967812,'2015-10-18 14:05:44') 

--name ends with er

select * from books 
select* from books where author like '%er'

--create table reviews

create table Reviews 
(Book_id int references books(book_id), Reviewer_name varchar(20), Content varchar(30), 
Rating int, Published_date Datetime) 

--insert values

insert into reviews values 

(1,'John Smith','My first review',4,'2017-12-10 05:50:11.1'), 
(2,'John Smith','My second review',5,'2017-10-13 15:05:12.6'), 
(2,'Alice Walker','Another review',1,'2017-10-22 23:47:10') 

--Display the Title ,Author and ReviewerName 

select * from reviews 

select b.title,b.author,r.Reviewer_name from Books b, Reviews r 
where b.book_id = r.book_id group by   b.author,b.title,r.Reviewer_name 

--Display the reviewer name who reviewed more than one book

select reviewer_name from reviews group by Reviewer_name having count(Book_id)>1 

---------------------------------------------------------------------------------
--create customer table

create table customers (ID int primary key, Name varchar(20), Age int, 
Address varchar(30), Salary float) 

--insert the values

insert into customers values 
(1,'Ramesh',32,'Ahmedabad',2000.00),(2,'Khilan',25,'Delhi',1500.00), 
(3,'Kaushik',23,'Kota',2000.00),(4,'Chaitali',25,'Mumbai',6500.00), 
(5,'Hardik',27,'Bhopal',8500.00),(6,'Komal',22,'MP',4500.00), 
(7,'Muffy',24,'Indore',10000.00) 

--Display the Name for the customer from above customer table who live in same address which has character o anywhere in addres
  
select * from customers 
select name from customers where Address like '%o%' 

--create table order

create table orders (Order_ID int, Date Datetime, 
Customer_ID int references customers(id), Amount float) 

--insert values

insert into orders values 
(102,'2009-10-08',3,3000),(100,'2009-10-08',3,1500), 
(101,'2009-11-20',2,1560),(103,'2008-05-20',4,2060) 

--display the Date,Total no of customer placed order on same Date

select * from orders 

select date,count(order_id) 'Total no. of customers' from orders 
group by date having count(order_id)>1 

-----------------------------------------------------------------------------------------------

--create Employee table

create table Employee 
(ID int, Name varchar(30),Age int, Address varchar(20), Salary float)  

--insert values

insert into employee values 
(1,'Ramesh',32,'Ahmedabad',2000.00),(2,'Khilan',25,'Delhi',1500.00), 
(3,'Kaushik',23,'Kota',2000.00),(4,'Chaitali',25,'Mumbai',6500.00), 
(5,'Hardik',27,'Bhopal',8500.00),(6,'Komal',22,'MP',null), 
(7,'Muffy',24,'Indore',null) 

--Display the Names of the Employee in lower case, whose salary is null

select lower(name) 'Name in lower case' from employee where salary is null

---------------------------------------------------------------------------------
--create StudentDetails table

create table StudentDetails (Register_no int, Name varchar(20), Age int, 
Qualification varchar(10), Mobile_no bigint, Mail_id varchar(30), 
Location varchar(20), Gender char) 

--insert values 

insert into StudentDetails values 
(2,'Sai',22,'B.E',9952836777,'Sai@gmail.com','Chennai','M'), 
(3,'Kumar',20,'BSC',7890125648,'Kumar@gmail.com','Madurai','M'), 
(4,'Selvi',22,'B.Tech',8904567342,'Selvi@gmail.com','Selam','F'), 
(5,'Nisha',25,'M.E',7834672310,'Nisha@gmail.com','Theni','F'), 
(6,'SaiSaran',21,'B.A',7890345678,'Saran@gmail.com','Madurai','F'), 
(7,'Tom',23,'BCA',8901234675,'Tom@gmail.com','Pune','M')
  
--display the Gender,Total no of male and female from the above relation

select * from StudentDetails 
select gender,count(gender) 'Total' from StudentDetails group by gender 
