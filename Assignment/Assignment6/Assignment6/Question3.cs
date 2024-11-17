using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6
{
    class Employee
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpCity { get; set; }
        public double EmpSalary { get; set; }
    }

    class Question3
    {
        static void Main()
        {
            List<Employee> employees = new List<Employee>();

            Console.WriteLine("Enter the number of employees:");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Enter details for Employee {i + 1}:");
                Console.Write("EmpId: ");
                int id = int.Parse(Console.ReadLine());
                Console.Write("EmpName: ");
                string name = Console.ReadLine();
                Console.Write("EmpCity: ");
                string city = Console.ReadLine();
                Console.Write("EmpSalary: ");
                double salary = double.Parse(Console.ReadLine());

                employees.Add(new Employee { EmpId = id, EmpName = name, EmpCity = city, EmpSalary = salary });
            }

            Console.WriteLine("\nAll Employees:");
            foreach (var e in employees)
            {
                Console.WriteLine($"{e.EmpId}, {e.EmpName}, {e.EmpCity}, {e.EmpSalary}");
            }

            Console.WriteLine("\nEmployees with Salary > 45000:");
            foreach (var e in employees)
            {
                if (e.EmpSalary > 45000)
                {
                    Console.WriteLine($"{e.EmpId}, {e.EmpName}, {e.EmpCity}, {e.EmpSalary}");
                }
            }

            Console.WriteLine("\nEmployees from Bangalore:");
            foreach (var e in employees)
            {
                if (e.EmpCity.Equals("Bangalore", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"{e.EmpId}, {e.EmpName}, {e.EmpCity}, {e.EmpSalary}");
                }
            }

            Console.WriteLine("\nEmployees Sorted by Name:");
            employees.Sort((emp1, emp2) => emp1.EmpName.CompareTo(emp2.EmpName));
            foreach (var e in employees)
            {
                Console.WriteLine($"{e.EmpId}, {e.EmpName}, {e.EmpCity}, {e.EmpSalary}");
            }
            Console.ReadLine();
        }
    }
    
}
