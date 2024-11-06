using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    internal class Student
    {
        int rollno;
        string name;
        string Class;
        string semester;
        string branch;
        int[] marks = new int [5];
        
         
        public Student(int rollNo, string Name,string cls,string SEM,string Branch)
        {
            this.rollno = rollNo;
            this.name = Name;
            this.Class = cls;
            this.semester = SEM;
            this.branch = Branch;
        }
        public void GetMarks()
        {
            for (int i = 0; i < marks.Length; i++)
            {
                Console.WriteLine($"Enter 5 sub marks: {i+1}");
                marks[i] = int.Parse(Console.ReadLine());
                
            }
            
        }
        
        public void DisplayResult()
        {
            foreach (int i in marks)
            {
                if (i < 35)
                {
                    Console.WriteLine("failed");
                }
            }
            double avg = marks.Average();

            if (avg  < 50)
            {
                 Console.WriteLine("failed");
            }
            else
            {
                 Console.WriteLine("Passed");
            }
            
        }
        public void Displaydata() 
        { 
            Console.WriteLine($"RollNo :{ rollno}");
            Console.WriteLine($"Name :{name}");
            Console.WriteLine($"Class :{Class}");
            Console.WriteLine($"Semester :{semester}");
            Console.WriteLine($"Branch :{branch}");
        }
        static void Main( String[] args)
        {
            Console.WriteLine("Enter Rollno: ");
            int a= int.Parse( Console.ReadLine() );
            Console.WriteLine("Enter the name:");
            string b = Console.ReadLine();
            Console.WriteLine("Enter the Student Class :");
            string c = Console.ReadLine();
            Console.WriteLine("Enter the semester: ");
            string d = Console.ReadLine();
            Console.WriteLine("Enter the branch :");
            string e = Console.ReadLine();

            Student student = new Student(a,b,c,d,e);
            student.GetMarks();
            student.DisplayResult();
            student.Displaydata();
            Console.ReadLine();
        }
    }
}
