using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    internal class Program
    {
        static void SwapNumber()
        {

            Console.Write("Enter a 1st number :");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Enter a 2nd number :");
            int b = int.Parse(Console.ReadLine());
            int temp = a;
            a = b;
            b = temp;
            Console.WriteLine(a + " " + b);
        }
        static void NumberInRow()
        {
            Console.Write("Enter a digit: ");
            int digit = int.Parse(Console.ReadLine());
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine("{0} {0} {0} {0}", digit);
                Console.WriteLine("{0}{0}{0}{0}", digit);
            }

        }
        static void DisplayDay()
        {
            Console.Write("Input: ");
            int num = int.Parse(Console.ReadLine());
            switch (num)
            {
                case 0:
                    Console.Write("Sunday");
                    break;
                case 1:
                    Console.WriteLine("Monday");
                    break;
                case 2:
                    Console.WriteLine("Tuesday");
                    break;
                case 3:
                    Console.WriteLine("Wednesday");
                    break;
                case 4:
                    Console.WriteLine("Thursday");
                    break;
                case 5:
                    Console.WriteLine("Friday");
                    break;
                case 6:
                    Console.WriteLine("Saturday");
                    break;
                default:
                    Console.WriteLine("Invalid Number");
                    break;

            }

        }
        static void IntegerToArray()
        {
            Console.Write("Enter a number :");
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            Console.Write("Enter the elements: ");
            for (int i = 0; i < n; i++)
            {
                Console.Write($"{i + 1} :");
                arr[i] = int.Parse(Console.ReadLine());
            }
            int total = 0, min = arr[0], max = arr[0];
            foreach (int num in arr)
            {
                total += num;
                if (num < min) min = num;
                if (num > max) max = num;
            }
            double avg = (double)total / n;
            Console.WriteLine($"Average : {avg}");
            Console.WriteLine($"Minimum : {min}");
            Console.WriteLine($"Maximum : {max}");

        }
        static void marks()
        {
            int[] marks = new int[10];

            Console.WriteLine("Enter 10 marks:");
            for (int i = 0; i < 10; i++)
            {
                Console.Write($"{i + 1}: ");
                marks[i] = int.Parse(Console.ReadLine());
            }
            int total = 0, min = marks[0], max = marks[0];
            foreach (int num in marks)
            {
                total += num;
                if (num < min) min = num;
                if (num > max) max = num;
            }
            double avg = (double)total / marks.Length;
            Array.Sort(marks);
            Console.WriteLine($"Total :{total}");
            Console.WriteLine("Ascending Order:");
            DisplayArray(marks); 
            Console.WriteLine("Descending Order:");
            Array.Reverse(marks); 
            DisplayArray(marks); }

        static void CopyArray()
        {
            Console.Write("Enter the no of elements : ");
            int n = int.Parse(Console.ReadLine());
            int[] OrgArr = new int[n];
            int[] CpyArr = new int[n];
            Console.WriteLine("Enter elements of original array:");
            for (int i = 0; i < n; i++)
            { Console.Write($"{i + 1}: ");
                OrgArr[i] = int.Parse(Console.ReadLine());
            } 
            for (int i = 0; i < n; i++)
            { 
                CpyArr[i] = OrgArr[i];
            } 
            Console.WriteLine("Original Array:");
            DisplayArray(OrgArr);
            Console.WriteLine("Copied Array:");
            DisplayArray(CpyArr);
        }
        static void DisplayArray(int[] array)
        {
            foreach (int num in array)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }

    



        static void Main(string[] args)
        {
            Console.WriteLine("*************Swap two Numbers************");
            SwapNumber();
            Console.WriteLine("*************Number in Rows************");
            NumberInRow();
            Console.WriteLine("*************Display the Day************");
            DisplayDay();
            Console.WriteLine("---------------------------");
            Console.WriteLine("***************Arrays***********");
            IntegerToArray();
            Console.WriteLine("***************Marks***********");
            marks();
            Console.WriteLine("***************Copy Array***********");
            CopyArray();
            Console.ReadLine();

        }
    }
}
