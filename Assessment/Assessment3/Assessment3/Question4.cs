using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment3
{
    internal class Question4
    {
        static void Main()
        {
            Calculator calc = new Calculator();
            Calculate add = new Calculate(calc.add);
            Calculate sub = new Calculate(calc.sub);
            Calculate multiply = new Calculate(calc.multi);
            Console.WriteLine("Enter two input");
            Console.Write("Input 1 : ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Input 2 : ");
            int b = int.Parse(Console.ReadLine());
            int sum = add(a, b);
            Console.WriteLine("Addition: " + sum);
            int diff = sub(a, b);
            Console.WriteLine("Subtraction : " + diff);
            int prod = multiply(a, b);
            Console.WriteLine("Multiplication : " + prod);
            Console.ReadLine();
        }
        public delegate int Calculate(int a,int b);
        class Calculator
        {
            public int add(int a,int b)
            {
                return a+b;
            }
            public int sub(int a,int b)
            {
                return a-b;
            }
            public int multi(int a,int b)
            {
                return a*b;
            }
        }
    }
    
}

