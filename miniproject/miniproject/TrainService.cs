using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using TrainReservationSystem.Models;

namespace TrainReservationSystem.Services
{
    public class TrainService
    {
        private readonly string _connectionString;

        public TrainService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Train> GetTrainsBetweenStations(string source, string destination)
        {
            var trains = new List<Train>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM Trains WHERE Source = @Source AND Destination = @Destination", connection);
                command.Parameters.AddWithValue("@Source", source);
                command.Parameters.AddWithValue("@Destination", destination);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        trains.Add(new Train
                        {
                            TrainId = (int)reader["TrainId"],
                            TrainNumber = (string)reader["TrainNumber"],
                            TrainName = (string)reader["TrainName"],
                            Source = (string)reader["Source"],
                            Destination = (string)reader["Destination"],
                            FirstClassTicketPrice = (decimal)reader["FirstClassTicketPrice"],
                            SecondClassTicketPrice = (decimal)reader["SecondClassTicketPrice"],
                            SleeperTicketPrice = (decimal)reader["SleeperTicketPrice"],
                            IsActive = (bool)reader["IsActive"]
                        });
                    }
                }
            }
            return trains;
        }

        public Train GetTrainDetails(string identifier)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM Trains WHERE TrainNumber = @Identifier OR TrainName = @Identifier", connection);
                command.Parameters.AddWithValue("@Identifier", identifier);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Train
                        {
                            TrainId = (int)reader["TrainId"],
                            TrainNumber = (string)reader["TrainNumber"],
                            TrainName = (string)reader["TrainName"],
                            Source = (string)reader["Source"],
                            Destination = (string)reader["Destination"],
                            FirstClassTicketPrice = (decimal)reader["FirstClassTicketPrice"],
                            SecondClassTicketPrice = (decimal)reader["SecondClassTicketPrice"],
                            SleeperTicketPrice = (decimal)reader["SleeperTicketPrice"],
                            IsActive = (bool)reader["IsActive"]
                        };
                    }
                }
            }
            return null;
        }

        public void AddTrain(Train train)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("INSERT INTO Trains (TrainNumber, TrainName, Source, Destination, FirstClassTicketPrice, SecondClassTicketPrice, SleeperTicketPrice, IsActive, JourneyTime) VALUES (@TrainNumber, @TrainName, @Source, @Destination, @FirstClassTicketPrice, @SecondClassTicketPrice, @SleeperTicketPrice, @IsActive, @JourneyTime)", connection);
                command.Parameters.AddWithValue("@TrainNumber", train.TrainNumber);
                command.Parameters.AddWithValue("@TrainName", train.TrainName);
                command.Parameters.AddWithValue("@Source", train.Source);
                command.Parameters.AddWithValue("@Destination", train.Destination);
                command.Parameters.AddWithValue("@FirstClassTicketPrice", train.FirstClassTicketPrice);
                command.Parameters.AddWithValue("@SecondClassTicketPrice", train.SecondClassTicketPrice);
                command.Parameters.AddWithValue("@SleeperTicketPrice", train.SleeperTicketPrice);
                command.Parameters.AddWithValue("@IsActive", train.IsActive);
                command.Parameters.AddWithValue("@JourneyTime", train.JourneyTime); // Add JourneyTime parameter

                command.ExecuteNonQuery();
            }
        }
        public void DeleteTrain(string trainNumber)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("DELETE FROM Trains WHERE TrainNumber = @TrainNumber", connection);
                command.Parameters.AddWithValue("@TrainNumber", trainNumber);

                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Console.WriteLine("Train deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Train not found.");
                }
            }
        }
        public void UpdateTrain(Train train)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand(
                    "UPDATE Trains SET TrainName = @TrainName, Source = @Source, Destination = @Destination, " +
                    "FirstClassTicketPrice = @FirstClassTicketPrice, SecondClassTicketPrice = @SecondClassTicketPrice, " +
                    "SleeperTicketPrice = @SleeperTicketPrice, IsActive = @IsActive WHERE TrainNumber = @TrainNumber",
                    connection);

                command.Parameters.AddWithValue("@TrainNumber", train.TrainNumber);
                command.Parameters.AddWithValue("@TrainName", train.TrainName);
                command.Parameters.AddWithValue("@Source", train.Source);
                command.Parameters.AddWithValue("@Destination", train.Destination);
                command.Parameters.AddWithValue("@FirstClassTicketPrice", train.FirstClassTicketPrice);
                command.Parameters.AddWithValue("@SecondClassTicketPrice", train.SecondClassTicketPrice);
                command.Parameters.AddWithValue("@SleeperTicketPrice", train.SleeperTicketPrice);
                command.Parameters.AddWithValue("@IsActive", train.IsActive);

                command.ExecuteNonQuery();
            }
        }
    }
}