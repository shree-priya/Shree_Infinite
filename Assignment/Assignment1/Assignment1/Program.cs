using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    internal class Program
    {
        static void CheckEqualNo()
        {
            Console.Write("Input 1st number : ");
            int num1 = int.Parse(Console.ReadLine());
            Console.Write("Input 2nd number :");
            int num2 = int.Parse(Console.ReadLine());
            if (num1 == num2)
            {
                Console.WriteLine($"{num1} and {num2} are equal");
            }
            else
            {
                Console.WriteLine($"{num1} and {num2} are not equal");
            }
        }
        static void PositiveOrNegative()
        {
            Console.Write("Enter a number :");
            int num = int.Parse(Console.ReadLine());
            if (num > 0)
            {
                Console.WriteLine($"{num} is a positive number ");
            }
            else if (num < 0)
            {
                Console.WriteLine($" {num} is a negative number ");
            }
            else
            {
                Console.WriteLine("The number is zero");
            }
        }
        static  void AllOperation()
        {
            Console.Write("Input First number :");
            int num1= int.Parse(Console.ReadLine());
            Console.Write("Input Opertion :");
            char operation =char.Parse(Console.ReadLine());
            Console.Write("Input Second number :");
            int num2= int.Parse(Console.ReadLine());
            if (operation == '+')
            {
                Console.WriteLine($"{num1} +{num2} ={num1 + num2}");
            }
            else if (operation == '-')
            {
                Console.WriteLine($"{num1} - {num2} ={num1 - num2}");

            }
            else if (operation == '*')
            {
                Console.WriteLine($"{num1} *{num2} = {num1 * num2}");

            }
            else if (operation == '/')
            {
                if (num2 != 0)
                {
                    Console.WriteLine($"{num1} / {num2} = {num1 / num2}");
                }
                else
                {
                    Console.WriteLine("zero is not allowed");
                }
            }
        }
        static void Table()
        {
            Console.Write("Enter the number :");
            int num = int.Parse(Console.ReadLine());
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"{num} *{i} ={num * i}");
            }
        }
        static void Sum()
        {
            Console.Write("Input the First number :");
            int num1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Input the second number :");
            int num2 = int.Parse(Console.ReadLine());
            int sum = num1 + num2;
            if (num1 == num2)
            {
                Console.WriteLine($"{sum * 3}");
            }
        }
            static void Main(string[] args)

        {
            Console.WriteLine("-----EqualOrNot----");
            CheckEqualNo();
            Console.WriteLine("------PositiveOrNegative------");
            PositiveOrNegative();
            Console.WriteLine("---------AllOperation--------");
            AllOperation();
            Console.WriteLine("----------Table----------");
            Table();
            Console.WriteLine("---------Sum-------");
            Sum();
            Console.Read();
        }
    }
}
