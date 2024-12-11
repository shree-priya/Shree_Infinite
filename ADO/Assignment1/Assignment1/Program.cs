using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public DateTime DOB { get; set; }
        public DateTime DOJ { get; set; }
        public string City { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> emp = new List<Employee>
            {
                new Employee { EmployeeID = 1001, FirstName = "Malcolm", LastName = "Daruwalla", Title = "Manager", DOB = new DateTime(1984, 11, 16), DOJ = new DateTime(2011, 6, 8), City = "Mumbai" },
                new Employee { EmployeeID = 1002, FirstName = "Asdin", LastName = "Dhalla", Title = "AsstManager", DOB = new DateTime(1984, 8, 20), DOJ = new DateTime(2012, 7, 7), City = "Mumbai" },
                new Employee { EmployeeID = 1003, FirstName = "Madhavi", LastName = "Oza", Title = "Consultant", DOB = new DateTime(1987, 11, 14), DOJ = new DateTime(2015, 4, 12), City = "Pune" },
                new Employee { EmployeeID = 1004, FirstName = "Saba", LastName = "Shaikh", Title = "SE", DOB = new DateTime(1990, 6, 3), DOJ = new DateTime(2016, 2, 2), City = "Pune" },
                new Employee { EmployeeID = 1005, FirstName = "Nazia", LastName = "Shaikh", Title = "SE", DOB = new DateTime(1991, 3, 8), DOJ = new DateTime(2016, 2, 2), City = "Mumbai" },
                new Employee { EmployeeID = 1006, FirstName = "Amit", LastName = "Pathak", Title = "Consultant", DOB = new DateTime(1989, 11, 7), DOJ = new DateTime(2014, 8, 8), City = "Chennai" },
                new Employee { EmployeeID = 1007, FirstName = "Vijay", LastName = "Natrajan", Title = "Consultant", DOB = new DateTime(1989, 12, 2), DOJ = new DateTime(2015, 6, 1), City = "Mumbai" },
                new Employee { EmployeeID = 1008, FirstName = "Rahul", LastName = "Dubey", Title = "Associate", DOB = new DateTime(1993, 11, 11), DOJ = new DateTime(2014, 11, 6), City = "Chennai" },
                new Employee { EmployeeID = 1009, FirstName = "Suresh", LastName = "Mistry", Title = "Associate", DOB = new DateTime(1992, 8, 12), DOJ = new DateTime(2014, 12, 3), City = "Chennai" },
                new Employee { EmployeeID = 1010, FirstName = "Sumit", LastName = "Shah", Title = "Manager", DOB = new DateTime(1991, 4, 12), DOJ = new DateTime(2016, 1, 2), City = "Pune" }
            };

            Console.WriteLine("***********Employees who joined before 1/1/2015***********");
            var a = emp.Where(e => e.DOJ < new DateTime(2015, 1, 1));
            foreach (var joindate in a)
            {
                Console.WriteLine($"{joindate.FirstName} {joindate.LastName}");
            }

            Console.WriteLine("**********Employees whose DOB is after 1/1/1990***********");
            var b = emp.Where(e => e.DOB > new DateTime(1990, 1, 1));
            foreach (var DOB in b)
            {
                Console.WriteLine($"{DOB.FirstName} {DOB.LastName}");
            }

            Console.WriteLine("************Employees whose title is Consultant or Associate**********");
            var c = emp.Where(e => e.Title == "Consultant" || e.Title == "Associate");
            foreach (var title in c)
            {
                Console.WriteLine($"{title.FirstName} {title.LastName}");
            }

            Console.WriteLine("************Total number of employees************");
            Console.WriteLine($"{emp.Count}");

            Console.WriteLine("***********Total number of employees in Chennai***********");
            Console.WriteLine($"{emp.Count(e => e.City == "Chennai")}");

            Console.WriteLine("***********Highest EmployeeID**********");
            Console.WriteLine($"{emp.Max(e => e.EmployeeID)}");

            Console.WriteLine("**************Total number of employees who joined after 1/1/2015************* ");
            Console.WriteLine($"{emp.Count(e => e.DOJ > new DateTime(2015, 1, 1))} ");

            Console.WriteLine("**************Total number of employees whose designation is not 'Associate'**********");
            Console.WriteLine($"{emp.Count(e => e.Title != "Associate")}");

            Console.WriteLine("***************Total number of employees based on City**************");
            var d = emp.GroupBy(e => e.City)
                       .Select(g => new { City = g.Key, Count = g.Count() });
            foreach (var Groupbycity in d)
            {
                Console.WriteLine($"{Groupbycity.City}: {Groupbycity.Count}");
            }


            Console.WriteLine("************Total number of employees based on City and Title************");
            var h = emp.GroupBy(e => new { e.City, e.Title })
                       .Select(g => new { g.Key.City, g.Key.Title, Count = g.Count() });
            foreach (var group in h)
            {
                Console.WriteLine($"{group.Title}[{group.City}] : {group.Count}");
            }


            Console.WriteLine("*************Youngest employee in the list**************");
            var qes11 = emp.OrderByDescending(e => e.DOB).First();
            Console.WriteLine($"{qes11.FirstName} {qes11.LastName}");


            Console.ReadLine();
        }
    }
}