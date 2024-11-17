using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6
{
    public class TravelConcession
    {
        public static void CalculateConcession(int age, double totalFare)
        {
            if (age <= 5)
            {
                Console.WriteLine("Little Champs - Free Ticket");
            }
            else if (age > 60)
            {
                double concessionFare = totalFare * 0.7; // 30% off
                Console.WriteLine($"Senior Citizen - Fare: {concessionFare}");
            }
            else
            {
                Console.WriteLine($"Ticket Booked - Fare: {totalFare}");
            }
        }
    }
    class Question4
    {
        private const double TotalFare = 500.0;

        static void Main()
        {
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();

            Console.Write("Enter your age: ");
            int age = int.Parse(Console.ReadLine());

            TravelConcession.CalculateConcession(age, TotalFare);
            Console.ReadLine();
        }
    }

    
}
