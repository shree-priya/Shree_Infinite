using System;
using TrainReservationSystem.Models;
using TrainReservationSystem.Services;

namespace TrainReservationSystem
{
    class Program
    {
        private static string _connectionString = "data source=DESKTOP-1SI2RLO\\SQLEXPRESS;initial catalog=trainticket;integrated security=true";

        static void Main(string[] args)
        {
            var userService = new UserService(_connectionString);
            var trainService = new TrainService(_connectionString);
            var coachService = new CoachService(_connectionString);
            var bookingService = new BookingService(_connectionString);
            var adminService = new Admin(_connectionString);
            var cancellationService = new CancellationService(_connectionString);

            while (true)
            {
                
                Console.WriteLine("Welcome to the Train Reservation System!");
                
                Console.WriteLine("Please choose an option:");
                Console.WriteLine("1. User Register");
                Console.WriteLine("2. Admin Login");
                Console.WriteLine("3. User Login");
                Console.WriteLine("4. Exit");

                var choice = Console.ReadLine();

                if (choice == "1")
                {
                    Register(userService);  
                }
                else if (choice == "2")
                {
                    AdminLogin(trainService, coachService, bookingService,adminService);  
                }
                else if (choice == "3")
                {
                    UserLogin(userService, trainService, coachService, bookingService,cancellationService);  
                }
                else if (choice == "4")
                {
                    Console.WriteLine("Thank you for using the Train Reservation System. Goodbye!");
                    break;  
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                }
            }
        }

       
        private static void Register(UserService userService)
        {
            Console.Write("Enter username: ");
            var username = Console.ReadLine();
            Console.Write("Enter password: ");
            var password = Console.ReadLine();
            

            userService.Register(username, password);

            Console.WriteLine("Registration successful.");
        }
 
      
        private static void AdminLogin(TrainService trainService, CoachService coachService, BookingService bookingService ,Admin adminService)
        {
            Console.Write("Enter username: ");
            var username = Console.ReadLine();
            Console.Write("Enter password: ");
            var password = Console.ReadLine();

           var admin = adminService.AuthenticateAdmin(username, password);

            if (admin == null )
            {
                Console.WriteLine("Invalid admin credentials.");
                return;
            }

            Console.WriteLine("Admin login successful.");
            Admin.AdminMenu(trainService, coachService, bookingService);
        }

        // User login and menu options
        private static void UserLogin(UserService userService, TrainService trainService, CoachService coachService, BookingService bookingService,CancellationService cancellationService)
        {
            Console.Write("Enter username: ");
            var username = Console.ReadLine();
            Console.Write("Enter password: ");
            var password = Console.ReadLine();

            var user = userService.Authenticate(username, password);

            if (user == null )
            {
                Console.WriteLine("Invalid user credentials.");
                return;
            }

            Console.WriteLine("User login successful.");
            UserMenu(user, trainService, coachService, bookingService, cancellationService);
        }

      

        // User Menu for booking and cancelling tickets
        private static void UserMenu(User user, TrainService trainService, CoachService coachService, BookingService bookingService, CancellationService cancellationService)
        {
            while (true)
            {
                Console.WriteLine("User Menu:");
                Console.WriteLine("1. View trains between two stations");
                Console.WriteLine("2. View train details");
                Console.WriteLine("3. Book ticket");
                Console.WriteLine("4. view booking details");
                Console.WriteLine("5. Cancel ticket");
                Console.WriteLine("6. Logout");
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
                        Console.WriteLine($"Train Number: {train.TrainNumber}, Name: {train.TrainName}, Source: {train.Source}, Destination: {train.Destination}, First Class Price: {train.FirstClassTicketPrice}, Second Class Price: {train.SecondClassTicketPrice}, Sleeper Price: {train.SleeperTicketPrice}, Active: {train.IsActive}");
                    }
                }
                else if (choice == "2")
                {
                    Console.Write("Enter train number or name: ");
                    var identifier = Console.ReadLine();
                    var train = trainService.GetTrainDetails(identifier);
                    if (train != null)
                    {
                        Console.WriteLine($"Train Number: {train.TrainNumber}, Name: {train.TrainName}, Source: {train.Source}, Destination: {train.Destination}, First Class Price: {train.FirstClassTicketPrice}, Second Class Price: {train.SecondClassTicketPrice}, Sleeper Price: {train.SleeperTicketPrice}, Active: {train.IsActive}");
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
                    Console.Write("Enter number of tickets to book: ");
                    var ticketCount = int.Parse(Console.ReadLine());

                    for (int i = 0; i < ticketCount; i++)
                    {
                        Console.Write("Enter passenger name: ");
                        var passengerName = Console.ReadLine();
                        Console.Write("Enter passenger age: ");
                        var passengerAge = int.Parse(Console.ReadLine());
                        Console.Write("Enter coach type (1A/2A/sleeper): ");
                        var coachType = Console.ReadLine();

                        // Retrieve the available coach and train details
                        var coach = coachService.GetCoachByTrainNumberAndType(trainNumber, coachType);

                        var train = trainService.GetTrainDetails(trainNumber);

                        if (coach == null || train == null || coach.AvailableSeats <= 0)
                        {
                            Console.WriteLine("No available seats in this coach.");
                            continue;
                        }
                        Console.Write("Enter JourneyDate: ");
                        var journeydate = DateTime.Parse(Console.ReadLine());
                    
                        // Book the ticket
                        var booking = new Booking
                        {
                            UserId = user.UserId,
                            TrainNumber = trainNumber,
                            CoachId = coach.CoachId,
                            PassengerName = passengerName,
                            PassengerAge = passengerAge,
                            BookingDate = DateTime.Now,
                            JourneyDate = journeydate,
                            
                        };

                        bookingService.BookTicket(booking);

                        // Update available seats in the coach
                        coachService.UpdateAvailableSeats(coach.CoachId, coach.AvailableSeats - 1);

                        Console.WriteLine($"Ticket booked successfully for {passengerName}. Remaining seats: {coach.AvailableSeats}");
                    }
                }
                else if (choice == "4")
                {
                    var bookings = bookingService.GetAllBookings();
                    foreach (var booking in bookings)
                    {
                        Console.WriteLine($"Booking ID: {booking.BookingId}, Train Number: {booking.TrainNumber}, Coach ID: {booking.CoachId}, Passenger Name: {booking.PassengerName}, Age: {booking.PassengerAge}, Booking Date: {booking.BookingDate}, Journey Date: {booking.JourneyDate}");
                    }
                }
                else if (choice == "5")
                {
                    Console.Write("Enter booking ID to cancel: ");
                    var bookingId = int.Parse(Console.ReadLine());

                    try
                    {
                        cancellationService.CancelBooking(bookingId);
                        var booking = bookingService.GetBookingById(bookingId);
                        if (booking != null)
                        {
                            var coach = coachService.GetCoachById(booking.CoachId);
                            coachService.UpdateAvailableSeats(coach.CoachId, coach.AvailableSeats + 1);
                        }
                        Console.WriteLine("Ticket canceled successfully.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Failed to cancel the ticket: {ex.Message}");
                    }
                }

                else if (choice == "6")
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

