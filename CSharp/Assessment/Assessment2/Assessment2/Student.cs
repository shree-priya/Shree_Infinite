using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment2
{
    abstract class Student
    {
        public string Name { get; set; }
        public int StudentId { get; set; }
        public double Grade { get; set; }
        public Student(string name, int studentId, double grade)
        {
            Name = name;
            StudentId = studentId;
            Grade = grade;
        }
        public abstract bool IsPassed(double grade);
    }
    class Undergraduate : Student
    {
        public Undergraduate(string name, int studentId, double grade) : base(name, studentId, grade)
        {
        }
        public override bool IsPassed(double grade)
        {
            return grade > 70.0;
        }
    }
    class Graduate : Student
    {
        public Graduate(string name, int studentId, double grade) : base(name, studentId, grade)
        {
        }
        public override bool IsPassed(double grade)
        {
            return grade > 80.0;
        }
    }
    class Question1
    {
        static void Main()
        {
            Console.WriteLine("****UG DETAILS****");
            Console.WriteLine("Enter the name :");
            string ugname = Console.ReadLine();
            Console.WriteLine("Enter the Id :");
            int ugid = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the grade: ");
            double uggrade = double.Parse(Console.ReadLine());
            Undergraduate ug= new Undergraduate(ugname,ugid,uggrade);
            Console.WriteLine($"{ug.Name} Passed: {ug.IsPassed(ug.Grade)}");
            Console.ReadLine();

            Console.WriteLine("****GRADUATE DETAILS****");
            Console.WriteLine("Enter the name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter the Id :");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the grade: ");
            double grade = double.Parse(Console.ReadLine());

            Graduate grad = new Graduate(name,id,grade);
            Console.WriteLine($"{grad.Name} Passed : {grad.IsPassed(grad.Grade)}");
            Console.ReadLine();
        }
    }
}
