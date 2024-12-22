using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainReservationSystem.Models;

namespace TrainReservationSystem.Services
{
    public class Admin
    {
        private readonly string _connectionString;

        public Admin(string connectionString)
        {
            _connectionString = connectionString;
        }
       
        

            public string Username { get; set; }
            public string adminPassword { get; set; }

        


        public Admin AuthenticateAdmin(string username, string password)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM AdminLogin WHERE adminName = @Username AND adminPassword = @Password", connection);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Admin(_connectionString)
                        {
                            Username = (string)reader["adminName"],
                            adminPassword = (string)reader["adminPassword"],
                            
                        };
                    }
                }
            }
            return null;
        }
        // Admin Menu for managing trains, coaches, and bookings
        public static void AdminMenu(TrainService trainService, CoachService coachService, BookingService bookingService)
        {
            while (true)
            {
                Console.WriteLine("Admin Menu:");
                Console.WriteLine("1. View trains between two stations");
                Console.WriteLine("2. View train details");
                Console.WriteLine("3. Add train");
                Console.WriteLine("4. Add coach to train");
                Console.WriteLine("5. Modify train");
                Console.WriteLine("6. Delete train");
                Console.WriteLine("7. Logout");
                var choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.Write("Enter source station: ");
                    var source = Console.ReadLine();
                    Console.Write("Enter destination station: ");
                    var destination = Console.ReadLine();
                    var trains = trainService.GetTrainsBetweenStations(source, destination);
                    foreach (var train in trains)
                    {
                        Console.WriteLine($"Train Number: {train.TrainNumber}, \nName: {train.TrainName}, \nSource: {train.Source}, \nDestination: {train.Destination}, \nFirst Class Price: {train.FirstClassTicketPrice}, \nSecond Class Price: {train.SecondClassTicketPrice}, \nSleeper Price: {train.SleeperTicketPrice}, \nActive: {train.IsActive}");
                    }
                }
                else if (choice == "2")
                {
                    Console.Write("Enter train number or name: ");
                    var identifier = Console.ReadLine();
                    var train = trainService.GetTrainDetails(identifier);
                    if (train != null)
                    {
                        Console.WriteLine($"Train Number: {train.TrainNumber},\nName: {train.TrainName}, \nSource: {train.Source}, \nDestination: {train.Destination}, \nFirst Class Price: {train.FirstClassTicketPrice}, \nSecond Class Price: {train.SecondClassTicketPrice}, \nSleeper Price: {train.SleeperTicketPrice}, \nActive: {train.IsActive}");

                    }
                    else
                    {
                        Console.WriteLine("Train not found.");
                    }
                }
                else if (choice == "3")
                {
                    Console.Write("Enter train number: ");
                    var trainNumber = Console.ReadLine();
                    Console.Write("Enter train name: ");
                    var trainName = Console.ReadLine();
                    Console.Write("Enter source station: ");
                    var source = Console.ReadLine();
                    Console.Write("Enter destination station: ");
                    var destination = Console.ReadLine();
                    Console.Write("Enter First Class ticket price: ");
                    if (!decimal.TryParse(Console.ReadLine(), out var firstClassTicketPrice))
                    {
                        Console.WriteLine("Invalid input for First Class ticket price. Please enter a valid decimal number.");
                        return;
                    }
                    Console.Write("Enter Second Class ticket price: ");
                    var secondClassTicketPrice = decimal.Parse(Console.ReadLine());
                    Console.Write("Enter Sleeper ticket price: ");
                    var sleeperTicketPrice = decimal.Parse(Console.ReadLine());
                    Console.Write("Is the train active? (yes/no): ");
                    var isActive = Console.ReadLine().ToLower() == "yes";
                    Console.Write("Enter journey time (HH:mm): ");
                    if (!TimeSpan.TryParse(Console.ReadLine(), out var journeyTime))
                    {
                        Console.WriteLine("Invalid input for journey time. Please enter a valid time in HH:mm format.");
                        return;
                    }

                    trainService.AddTrain(new Train
                    {
                        TrainNumber = trainNumber,
                        TrainName = trainName,
                        Source = source,
                        Destination = destination,
                        FirstClassTicketPrice = firstClassTicketPrice,
                        SecondClassTicketPrice = secondClassTicketPrice,
                        SleeperTicketPrice = sleeperTicketPrice,
                        IsActive = isActive,
                        JourneyTime = journeyTime // Add JourneyTime parameter
                    });

                    Console.WriteLine("Train added successfully.");
                }
                else if (choice == "4")
                {
                    Console.Write("Enter train number: ");
                    var trainNumber = Console.ReadLine();
                    Console.Write("Enter coach type (1A/2A/sleeper): ");
                    var coachType = Console.ReadLine();
                    Console.Write("Enter seat count: ");
                    var seatCount = int.Parse(Console.ReadLine());
                    Console.Write("Enter available seats: ");
                    var availableSeats = int.Parse(Console.ReadLine());

                    coachService.AddCoach(new Coach
                    {
                        TrainNumber = trainNumber,
                        CoachType = coachType,
                        SeatCount = seatCount,
                        AvailableSeats = availableSeats
                    });

                    Console.WriteLine("Coach added successfully.");
                }
                else if (choice == "5")
                {
                    Console.Write("Enter train number to modify: ");
                    var trainNumber = Console.ReadLine();
                    var train = trainService.GetTrainDetails(trainNumber);
                    if (train != null)
                    {
                        Console.Write("Enter new train name: ");
                        train.TrainName = Console.ReadLine();
                        Console.Write("Enter new source station: ");
                        train.Source = Console.ReadLine();
                        Console.Write("Enter new destination station: ");
                        train.Destination = Console.ReadLine();
                        Console.Write("Enter new First Class ticket price: ");
                        train.FirstClassTicketPrice = decimal.Parse(Console.ReadLine());
                        Console.Write("Enter new Second Class ticket price: ");
                        train.SecondClassTicketPrice = decimal.Parse(Console.ReadLine());
                        Console.Write("Enter new Sleeper ticket price: ");
                        train.SleeperTicketPrice = decimal.Parse(Console.ReadLine());
                        Console.Write("Is the train active? (yes/no): ");
                        train.IsActive = Console.ReadLine().ToLower() == "yes";

                        trainService.UpdateTrain(train);
                        Console.WriteLine("Train details updated successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Train not found.");
                    }
                }
                else if (choice == "6")
                {
                    Console.Write("Enter train number to delete: ");
                    var trainNumber = Console.ReadLine();
                    trainService.DeleteTrain(trainNumber);
                }
                else if (choice == "7")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                }
            }
        }
       
    }
}
