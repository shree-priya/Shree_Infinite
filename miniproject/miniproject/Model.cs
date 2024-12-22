using System;
using System.Collections.Generic;
namespace TrainReservationSystem.Models
{
   public class Train
{
    public int TrainId { get; set; }
    public string TrainNumber { get; set; }
    public string TrainName { get; set; }
    public string Source { get; set; }
    public string Destination { get; set; }
    public decimal FirstClassTicketPrice { get; set; }
    public decimal SecondClassTicketPrice { get; set; }
    public decimal SleeperTicketPrice { get; set; }
    public bool IsActive { get; set; }
    public TimeSpan JourneyTime { get; set; } 
}


    public enum CoachType
    {
        FirstClass,
        SecondClass,
        Sleeper
        
    }
    public class Coach
    {
        public int CoachId { get; set; }
        public string TrainNumber { get; set; }
        public string CoachType { get; set; }
        public int SeatCount { get; set; }
        public int AvailableSeats { get; set; }
    }
    public class Booking
    {
        public int BookingId { get; set; }
        public int UserId { get; set; }
        public string TrainNumber { get; set; }
        public int CoachId { get; set; }
        public string PassengerName { get; set; }
        public int PassengerAge { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime JourneyDate { get; set; }
       
    }

    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
       
    }
    

    public class Cancellation
    {
        public int CancellationId { get; set; }
        public int BookingId { get; set; }
        public DateTime CancellationDate { get; set; }
        public decimal RefundAmount { get; set; }
    }
}