create database Assessment3
use Assessment3

CREATE TABLE Coursedetails (
    C_id VARCHAR(10) PRIMARY KEY,
    C_Name VARCHAR(50) NOT NULL,
    Start_date DATE NOT NULL,
    End_date DATE NOT NULL,
    Fee INT NOT NULL
);

INSERT INTO Coursedetails (C_id, C_Name, Start_date, End_date, Fee)
VALUES
    ('DN003', 'DotNet', '2018-02-01', '2018-02-28', 15000),
    ('DV004', 'DataVisualization', '2018-03-01', '2018-04-15', 15000),
    ('JA002', 'AdvancedJava', '2018-01-02', '2018-01-20', 10000),
    ('JC001', 'CoreJava', '2018-01-02', '2018-01-12', 3000);

SELECT * FROM coursedetails;

CREATE TABLE T_CourseInfo (CourseName VARCHAR(50) NOT NULL, StartDate DATE NOT NULL);

CREATE FUNCTION Calculateduration (
    @Start_date DATE,
    @End_date DATE
)
RETURNS INT
AS
BEGIN
    RETURN DATEDIFF(DAY, @Start_date, @End_date);
END;

SELECT dbo.Calculateduration('2018-01-02', '2018-01-20') AS duration_in_days;

--2

CREATE TRIGGER InsertCourseInfo
ON Coursedetails
AFTER INSERT
AS
BEGIN
    INSERT INTO T_CourseInfo (CourseName, StartDate)
    SELECT C_Name, Start_date
    FROM INSERTED;
END;

INSERT INTO Coursedetails (C_id, C_Name, Start_date, End_date, Fee)
VALUES ('JS005', 'JavaScript', '2018-05-01', '2018-05-30', 12000);

SELECT * FROM T_CourseInfo;
SELECT * FROM coursedetails;


--3
CREATE TABLE Products_Details (
    ProductId INT IDENTITY(1,1) PRIMARY KEY,  
    ProductName VARCHAR(50) NOT NULL,
    Price DECIMAL(10, 2) NOT NULL,
    DiscountedPrice AS (Price - (Price * 0.1)) 
);
CREATE PROCEDURE InsertProductDetails
    @ProductName VARCHAR(50),
    @Price DECIMAL(10, 2),
    @GeneratedProductId INT OUTPUT,
    @DiscountedPrice DECIMAL(10, 2) OUTPUT
AS
BEGIN
   declare @InsertedProducts table (ProductId INT);
    INSERT INTO Products_Details (ProductName, Price)
    OUTPUT INSERTED.ProductId INTO @InsertedProducts
    VALUES (@ProductName, @Price);
    SELECT @GeneratedProductId = ProductId FROM @InsertedProducts;
    SET @DiscountedPrice = @Price - (@Price * 0.1);
END;
   

 

