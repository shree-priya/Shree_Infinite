using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using TrainReservationSystem.Models;


namespace TrainReservationSystem.Services
{
    public class BookingService
    {
        private readonly string _connectionString;

        public BookingService(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Book a ticket
        public void BookTicket(Booking booking)
        {
            try
            {
                // Check if the journey date is in the past
                if (booking.JourneyDate < DateTime.UtcNow.Date)
                {
                    throw new InvalidJourneyDateException("The journey date cannot be in the past.");
                }

                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    // Retrieve the fixed journey time from the Trains table
                    var command = new SqlCommand("SELECT JourneyTime FROM Trains WHERE TrainNumber = @TrainNumber", connection);
                    command.Parameters.AddWithValue("@TrainNumber", booking.TrainNumber);

                    TimeSpan journeyTime;
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            journeyTime = reader.GetTimeSpan(reader.GetOrdinal("JourneyTime"));
                        }
                        else
                        {
                            throw new Exception("Train not found.");
                        }
                    }

                    // Combine user-provided journey date with journey time to set the complete journey date and time
                    DateTime completeJourneyDate = booking.JourneyDate.Date + journeyTime;

                    // Insert the booking with the combined journey date and time
                    command = new SqlCommand(@"
                INSERT INTO Bookings (UserId, TrainNumber, CoachId, PassengerName, PassengerAge, BookingDate, JourneyDate)
                VALUES (@UserId, @TrainNumber, @CoachId, @PassengerName, @PassengerAge, @BookingDate, @JourneyDate)", connection);

                    command.Parameters.AddWithValue("@UserId", booking.UserId);
                    command.Parameters.AddWithValue("@TrainNumber", booking.TrainNumber);
                    command.Parameters.AddWithValue("@CoachId", booking.CoachId);
                    command.Parameters.AddWithValue("@PassengerName", booking.PassengerName);
                    command.Parameters.AddWithValue("@PassengerAge", booking.PassengerAge);
                    command.Parameters.AddWithValue("@BookingDate", booking.BookingDate.ToUniversalTime()); // Convert to UTC
                    command.Parameters.AddWithValue("@JourneyDate", completeJourneyDate); // Convert to UTC
                    //command.Parameters.AddWithValue("@JourneyTime", journeyTime);

                    command.ExecuteNonQuery();
                }
            }
            catch (InvalidJourneyDateException ex)
            {
                // Handle invalid journey date error
                Console.WriteLine($"Invalid entry: {ex.Message}. Please ensure the journey date is in the future.");
            }
            catch (SqlException ex)
            {
                // Handle SQL errors
                Console.WriteLine($"SQL error: {ex.Message}. Please contact support if the issue persists.");
            }
            catch (Exception ex)
            {
                // Handle general errors
                Console.WriteLine($"An unexpected error occurred: {ex.Message}. Please try again later.");
            }
        }

        // Get all bookings
        public List<Booking> GetAllBookings()
        {
            var bookings = new List<Booking>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM Bookings", connection);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        bookings.Add(NewMethod(reader));
                    }
                }
            }
            return bookings;
        }

        // Convert data from SQL to Booking object
        private static Booking NewMethod(SqlDataReader reader)
        {
            return new Booking
            {
                BookingId = reader.GetInt32(reader.GetOrdinal("BookingId")),
                UserId = reader.GetInt32(reader.GetOrdinal("UserId")),
                TrainNumber = reader.GetString(reader.GetOrdinal("TrainNumber")),
                CoachId = reader.GetInt32(reader.GetOrdinal("CoachId")),
                PassengerName = reader.GetString(reader.GetOrdinal("PassengerName")),
                PassengerAge = reader.GetInt32(reader.GetOrdinal("PassengerAge")),
                BookingDate = reader.GetDateTime(reader.GetOrdinal("BookingDate")),
                JourneyDate = reader.GetDateTime(reader.GetOrdinal("JourneyDate"))
            };
        }

        // Get Booking by BookingId
        public Booking GetBookingById(int bookingId)
        {
            Booking booking = null;

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM Bookings WHERE BookingId = @BookingId", connection);
                command.Parameters.AddWithValue("@BookingId", bookingId);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read()) // If a booking is found
                    {
                        booking = new Booking
                        {
                            BookingId = reader.GetInt32(reader.GetOrdinal("BookingId")),
                            UserId = reader.GetInt32(reader.GetOrdinal("UserId")),
                            TrainNumber = reader.GetString(reader.GetOrdinal("TrainNumber")),
                            CoachId = reader.GetInt32(reader.GetOrdinal("CoachId")),
                            PassengerName = reader.GetString(reader.GetOrdinal("PassengerName")),
                            PassengerAge = reader.GetInt32(reader.GetOrdinal("PassengerAge")),
                            BookingDate = reader.GetDateTime(reader.GetOrdinal("BookingDate")),
                            JourneyDate = reader.GetDateTime(reader.GetOrdinal("JourneyDate"))
                        };
                    }
                }
            }

            return booking;  // Return the found booking, or null if not found
        }

        // Cancel a booking by ID
        public int CancelBooking(int bookingId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("DELETE FROM Bookings WHERE BookingId = @BookingId", connection);
                command.Parameters.AddWithValue("@BookingId", bookingId);

                command.ExecuteNonQuery();
            }
            return bookingId;
        }

        // Get bookings by UserId
        public List<Booking> GetBookingsByUser(int userId)
        {
            var bookings = new List<Booking>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM Bookings WHERE UserId = @UserId", connection);
                command.Parameters.AddWithValue("@UserId", userId);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        bookings.Add(new Booking
                        {
                            BookingId = reader.GetInt32(reader.GetOrdinal("BookingId")),
                            UserId = reader.GetInt32(reader.GetOrdinal("UserId")),
                            TrainNumber = reader.GetString(reader.GetOrdinal("TrainNumber")),
                            CoachId = reader.GetInt32(reader.GetOrdinal("CoachId")),
                            PassengerName = reader.GetString(reader.GetOrdinal("PassengerName")),
                            PassengerAge = reader.GetInt32(reader.GetOrdinal("PassengerAge")),
                            BookingDate = reader.GetDateTime(reader.GetOrdinal("BookingDate")),
                            JourneyDate = reader.GetDateTime(reader.GetOrdinal("JourneyDate"))
                        });
                    }
                }
            }

            // Display bookings with formatted date
            foreach (var booking in bookings)
            {
                Console.WriteLine($"Booking ID: {booking.BookingId}, Train Number: {booking.TrainNumber}, Journey Date: {booking.JourneyDate.ToString("yyyy-MM-dd")}");
            }

            return bookings;
        }
    }
}

