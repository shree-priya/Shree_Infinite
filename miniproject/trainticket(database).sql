create database trainticket
use trainticket


CREATE TABLE Users (
    UserId INT IDENTITY PRIMARY KEY,
    Username NVARCHAR(50) NOT NULL,
    Password NVARCHAR(50) NOT NULL,
);

CREATE TABLE ADMINLOGIN(
ADMINNAME NVARCHAR(50), ADMINPASSWORD NVARCHAR(50))

INSERT INTO ADMINLOGIN VALUES('priya','priya');

SELECT * FROM ADMINLOGIN

CREATE TABLE Trains (
    TrainId INT IDENTITY PRIMARY KEY,
    TrainNumber NVARCHAR(20) NOT NULL,
    TrainName NVARCHAR(100) NOT NULL,
    Source NVARCHAR(50) NOT NULL,
    Destination NVARCHAR(50) NOT NULL,
    FirstClassTicketPrice DECIMAL(18, 2) NOT NULL,
    SecondClassTicketPrice DECIMAL(18, 2) NOT NULL,
    SleeperTicketPrice DECIMAL(18, 2) NOT NULL,
    IsActive BIT NOT NULL DEFAULT 1
);

CREATE TABLE Bookings (
    BookingId INT IDENTITY PRIMARY KEY,
    UserId INT FOREIGN KEY REFERENCES Users(UserId),  
    TrainNumber NVARCHAR(20) NOT NULL,
    PassengerName NVARCHAR(100) NOT NULL,
    PassengerAge INT NOT NULL,
    BookingDate DATETIME NOT NULL,
    JourneyDate DATETIME NOT NULL,
	CoachId INT FOREIGN KEY REFERENCES Coaches(CoachId)
);

CREATE TABLE Cancellations (
    CancellationId INT IDENTITY PRIMARY KEY,
    BookingId INT,
    CancellationDate DATETIME NOT NULL,
    RefundPercentage DECIMAL(18, 2) NOT NULL
);


CREATE TABLE Coaches (
    CoachId INT IDENTITY PRIMARY KEY,
    TrainNumber NVARCHAR(20) NOT NULL,
    CoachType NVARCHAR(50) NOT NULL,
    SeatCount INT NOT NULL,
    AvailableSeats INT NOT NULL
);

select * from users;
select * from trains;
select * from coaches;
select * from bookings;
select * from Cancellations;

