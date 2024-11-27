using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6
{
    internal class Question1
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter numbers: ");
            string a = Console.ReadLine();
            string[] num = a.Split(' ');

            List<string> res = new List<string>();
            foreach (string i in num)
            {
                int b = int.Parse(i);
                int square = b * b;
                if (square > 20)
                {
                    res.Add($"{b} - {square}");
                }
            }
            Console.WriteLine(string.Join(", ", res)); 
            Console.ReadLine();
        }
    }
}
