using System;
using System.Data.SqlClient;
using TrainReservationSystem.Models;

namespace TrainReservationSystem.Services
{
    public class CancellationService
    {
        private readonly string _connectionString;

        public CancellationService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void CancelBooking(int bookingId)
        {
            var booking = GetBookingById(bookingId);

            if (booking == null)
            {
                throw new Exception("Booking not found.");
            }

            // Check if the journey date is in the past
            if (booking.JourneyDate < DateTime.Now.Date)
            {
                throw new InvalidOperationException("Cannot cancel a past booking.");
            }

            var refundAmount = CalculateRefund(booking.BookingDate, booking.JourneyDate);

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();


                    var cancellationCommand = new SqlCommand("INSERT INTO Cancellations (BookingId, CancellationDate, RefundAmount) VALUES (@BookingId, @CancellationDate, @RefundAmount)", connection);
                    cancellationCommand.Parameters.AddWithValue("@BookingId", bookingId);
                    cancellationCommand.Parameters.AddWithValue("@CancellationDate", DateTime.Now);
                    cancellationCommand.Parameters.AddWithValue("@RefundAmount", refundAmount);

                    cancellationCommand.ExecuteNonQuery();
                    

                   
                    var command1 = new SqlCommand("DELETE FROM Bookings WHERE BookingId = @BookingId", connection);
                    command1.Parameters.AddWithValue("@BookingId", bookingId);

                    command1.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                // Log SQL-specific errors
                Console.WriteLine($"SQL Error: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                // Log general errors
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        private Booking GetBookingById(int bookingId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM Bookings WHERE BookingId = @BookingId", connection);
                command.Parameters.AddWithValue("@BookingId", bookingId);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Booking
                        {
                            BookingId = (int)reader["BookingId"],
                            UserId = (int)reader["UserId"],
                            TrainNumber = (string)reader["TrainNumber"],
                            CoachId = (int)reader["CoachId"],
                            PassengerName = (string)reader["PassengerName"],
                            PassengerAge = (int)reader["PassengerAge"],
                            BookingDate = (DateTime)reader["BookingDate"],
                            JourneyDate = (DateTime)reader["JourneyDate"]
                        };
                    }
                }
            }
            return null;
        }

        private decimal CalculateRefund(DateTime bookingDate, DateTime journeyDate)
        {
            var daysBetween = (journeyDate - DateTime.Now).Days;
            if (daysBetween < 0)
            {
                throw new Exception("Cannot cancel a past booking.");
            }

            if (daysBetween >= 10)
            {
                return 100.00m; // 100% refund
            }
            else
            {
                var refundPercentage = 100 - (10 * (10 - daysBetween));
                return refundPercentage;
            }
        }
    }
}
