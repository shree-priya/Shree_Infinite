using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    internal class Strings
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-----DisplayLength------");
            StringLength();
            Console.WriteLine("----ReverseString------");
            ReverseString();
            Console.WriteLine("----Check both are same----");
            CheckEqual();
            Console.ReadLine();
        }
        public static int StringLength()
        {
            Console.Write("Enter a word :");
            string a = Console.ReadLine();
            return a.Length;

        }

        public static void ReverseString()
        {
            Console.Write("Enter a string :");
            string b = Console.ReadLine();
            string d = new string(b.Reverse().ToArray());
            Console.WriteLine(d);

        }
        public static void CheckEqual()
        {
            Console.Write("----Enter 1st word :");
            string a = Console.ReadLine();
            Console.Write("Enter 2nd word :");
            string b = Console.ReadLine();
            if (a.Equals(b))
            {
                Console.WriteLine("Both are same");
            }
            else
            {
                Console.WriteLine("Both are different");
            }
            Console.ReadLine();

        }
    }
}
