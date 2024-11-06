using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment1
{
    internal class Question4
    {
        static void main(string[] args)
        {
            Console.Write("Enter a string :");
            string s = Console.ReadLine();
            Console.WriteLine("Enter a character:");
            char a = Console.ReadLine()[0];
            int count = 0;
            foreach (char c in s)
            {
                if (c == a) count++;
            }
            Console.WriteLine($"{a} appears {count} times");

        }
    }
}
