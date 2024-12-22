using System;
using System.Data.SqlClient;
using TrainReservationSystem.Models;

namespace TrainReservationSystem.Services
{
    public class CoachService
    {
        private readonly string _connectionString;

        public CoachService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AddCoach(Coach coach)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    var command = new SqlCommand("INSERT INTO Coaches (TrainNumber, CoachType, SeatCount, AvailableSeats) VALUES (@TrainNumber, @CoachType, @SeatCount, @AvailableSeats)", connection);
                    command.Parameters.AddWithValue("@TrainNumber", coach.TrainNumber);
                    command.Parameters.AddWithValue("@CoachType", coach.CoachType);
                    command.Parameters.AddWithValue("@SeatCount", coach.SeatCount);
                    command.Parameters.AddWithValue("@AvailableSeats", coach.AvailableSeats);

                    command.ExecuteNonQuery();
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

        public Coach GetCoachByTrainNumberAndType(string trainNumber, string coachType)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    var command = new SqlCommand("SELECT * FROM Coaches WHERE TrainNumber = @TrainNumber AND CoachType = @CoachType", connection);
                    command.Parameters.AddWithValue("@TrainNumber", trainNumber);
                    command.Parameters.AddWithValue("@CoachType", coachType);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Coach
                            {
                                CoachId = (int)reader["CoachId"],
                                TrainNumber = (string)reader["TrainNumber"],
                                CoachType = (string)reader["CoachType"],
                                SeatCount = (int)reader["SeatCount"],
                                AvailableSeats = (int)reader["AvailableSeats"]
                            };
                        }
                    }
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
            return null;
        }

        public void UpdateAvailableSeats(int coachId, int availableSeats)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    var command = new SqlCommand("UPDATE Coaches SET AvailableSeats = @AvailableSeats WHERE CoachId = @CoachId", connection);
                    command.Parameters.AddWithValue("@AvailableSeats", availableSeats);
                    command.Parameters.AddWithValue("@CoachId", coachId);

                    command.ExecuteNonQuery();
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
        public Coach GetCoachById(int coachId)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    var command = new SqlCommand("SELECT * FROM Coaches WHERE CoachId = @CoachId", connection);
                    command.Parameters.AddWithValue("@CoachId", coachId);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Coach
                            {
                                CoachId = (int)reader["CoachId"],
                                TrainNumber = (string)reader["TrainNumber"],
                                CoachType = (string)reader["CoachType"],
                                SeatCount = (int)reader["SeatCount"],
                                AvailableSeats = (int)reader["AvailableSeats"]
                            };
                        }
                    }
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
            return null;
        }

    }
}
