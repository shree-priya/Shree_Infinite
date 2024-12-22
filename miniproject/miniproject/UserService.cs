using System;
using System.Data.SqlClient;
using TrainReservationSystem.Models;

namespace TrainReservationSystem.Services
{
    public class UserService
    {
        private readonly string _connectionString;

        public UserService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public User Authenticate(string username, string password)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM Users WHERE Username = @Username AND Password = @Password", connection);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new User
                        {
                            UserId = (int)reader["UserId"],
                            Username = (string)reader["Username"],
                            
                        };
                    }
                }
            }
            return null;
        }

        public void Register(string username, string password)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                // Check if the username already exists
                var checkCommand = new SqlCommand("SELECT COUNT(*) FROM Users WHERE Username = @Username", connection);
                checkCommand.Parameters.AddWithValue("@Username", username);
                int userCount = (int)checkCommand.ExecuteScalar();

                if (userCount > 0)
                {
                    Console.WriteLine("Username already exists. Please try with another name.");
                    return;
                }

                // Insert the new user if the username is unique
                var command = new SqlCommand("INSERT INTO Users (Username, Password) VALUES (@Username, @Password)", connection);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);

                command.ExecuteNonQuery();
                Console.WriteLine("User registered successfully.");
            }
        }
    }
}
