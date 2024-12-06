create database Assignment4
 
use Assignment4

DECLARE @NUM INT = 5;  
DECLARE @FACT BIGINT = 1;
DECLARE @COUNT INT = 1;


WHILE @COUNT <= @NUM
BEGIN
    SET @FACT = @FACT * @COUNT;
    SET @COUNT = @COUNT + 1;
END


SELECT @NUM AS Number, @FACT AS Factorial;

--2


create procedure MultiTable
    @num int, 
    @limit int
as
begin
    declare @i int = 1
    while @i <= @limit
    begin
        print cast(@num as varchar) + ' x ' + CAST(@i as varchar) + ' = ' + cast(@num * @i as varchar)
        set @i = @i + 1
    end
end
exec MultiTable @num = 15, @limit = 10

--3

CREATE TABLE student (
    Sid INT PRIMARY KEY,
    Sname VARCHAR(50)
);

INSERT INTO student (Sid, Sname)
VALUES
(1, 'Jack'),
(2, 'Rithvik'),
(3, 'Jaspreeth'),
(4, 'Praveen'),
(5, 'Bisa'),
(6, 'Suraj');
 
  select * from student

CREATE TABLE marks (
    Mid INT PRIMARY KEY,
    Sid INT,
    Score INT,
    FOREIGN KEY (Sid) REFERENCES student(Sid)
);

INSERT INTO marks (Mid, Sid, Score)
VALUES
(1, 1, 23),
(2, 6, 95),
(3, 4, 98),
(4, 2, 17),
(5, 3, 53),
(6, 5, 13);
select * from marks

CREATE FUNCTION GetStudentStatus (@Score INT)
RETURNS VARCHAR(10)
AS
BEGIN
    IF @Score >= 50
        RETURN 'Pass';
    ELSE
        RETURN 'Fail';
    RETURN 'Fail'

END;


SELECT 
    s.Sid, 
    s.Sname, 
    m.Score, 
    dbo.GetStudentStatus(m.Score) AS Status
FROM 
    student s
JOIN 
    marks m ON s.Sid = m.Sid
ORDER BY 
    s.Sid;



    
   
    
      
