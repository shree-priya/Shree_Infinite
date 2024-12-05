using System;
using System.Collections.Generic;
using System.Linq;

namespace Assessment4
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

class Program3
{
    static void Main()
    {
        List<Employee> employeelist = new List<Employee>
            {
              new Employee { EmployeeID = 1001, FirstName = "Malcolm", LastName = "Daruwalla", Title = "Manager", DOB = DateTime.Parse("16/11/1984"), DOJ = DateTime.Parse("8/6/2011"), City = "Mumbai" },
              new Employee { EmployeeID = 1002, FirstName = "Asdin", LastName = "Dhalla", Title = "AsstManager", DOB = DateTime.Parse("20/08/1984"), DOJ = DateTime.Parse("7/7/2012"), City = "Mumbai" },
              new Employee { EmployeeID = 1003, FirstName = "Madhavi", LastName = "Oza", Title = "Consultant", DOB = DateTime.Parse("14/11/1987"), DOJ = DateTime.Parse("12/4/2015"), City = "Pune" },
              new Employee { EmployeeID = 1004, FirstName = "Saba", LastName = "Shaikh", Title = "SE", DOB = DateTime.Parse("3/6/1990"), DOJ = DateTime.Parse("2/2/2016"), City = "Pune" },
              new Employee { EmployeeID = 1005, FirstName = "Nazia", LastName = "Shaikh", Title = "SE", DOB = DateTime.Parse("8/3/1991"), DOJ = DateTime.Parse("2/2/2016"), City = "Mumbai" },
              new Employee { EmployeeID = 1006, FirstName = "Amit", LastName = "Pathak", Title = "Consultant", DOB = DateTime.Parse("7/11/1989"), DOJ = DateTime.Parse("8/8/2014"), City = "Chennai" },
              new Employee { EmployeeID = 1007, FirstName = "Vijay", LastName = "Natrajan", Title = "Consultant", DOB = DateTime.Parse("2/12/1989"), DOJ = DateTime.Parse("1/6/2015"), City = "Mumbai" },
              new Employee { EmployeeID = 1008, FirstName = "Rahul", LastName = "Dubey", Title = "Associate", DOB = DateTime.Parse("11/11/1993"), DOJ = DateTime.Parse("6/11/2014"), City = "Chennai" },
              new Employee { EmployeeID = 1009, FirstName = "Suresh", LastName = "Mistry", Title = "Associate", DOB = DateTime.Parse("12/8/1992"), DOJ = DateTime.Parse("3/12/2014"), City = "Chennai" },
              new Employee { EmployeeID = 1010, FirstName = "Sumit", LastName = "Shah", Title = "Manager", DOB = DateTime.Parse("12/4/1991"), DOJ = DateTime.Parse("2/1/2016"), City = "Pune" }
            };

        Console.WriteLine("Details of employees");
        var allemployees = employeelist.Select(emp => $"{emp.FirstName} {emp.LastName}, Title: {emp.Title}, DOB: {emp.DOB}, DOJ: {emp.DOJ}, City: {emp.City}");
        foreach (var employeedetails in allemployees)
        {
            Console.WriteLine(employeedetails);
        }

        Console.WriteLine("Details of employees whose location is not Mumbai");
        var employeesnotinMumbai = employeelist.Where(emp => emp.City != "Mumbai");
        foreach (var emp in employeesnotinMumbai)
        {
            Console.WriteLine($"{emp.FirstName} {emp.LastName}, Title: {emp.Title}, DOB: {emp.DOB}, DOJ: {emp.DOJ}, City: {emp.City}");
        }

        Console.WriteLine("Details of employees whose title is AsstManager");
        var asstmanager = employeelist.Where(emp => emp.Title == "AsstManager");
        foreach (var emp in asstmanager)
        {
            Console.WriteLine($"{emp.FirstName} {emp.LastName}, Title: {emp.Title}, DOB: {emp.DOB}, DOJ: {emp.DOJ}, City: {emp.City}");
        }

        Console.WriteLine("Details of employees whose last name starts with S");
        var lastnameS = employeelist.Where(emp => emp.LastName.StartsWith("S"));
        foreach (var emp in lastnameS)
        {
            Console.WriteLine($"{emp.FirstName} {emp.LastName}, Title: {emp.Title}, DOB: {emp.DOB}, DOJ: {emp.DOJ}, City: {emp.City}");
        }
        Console.ReadLine();
    }
}

