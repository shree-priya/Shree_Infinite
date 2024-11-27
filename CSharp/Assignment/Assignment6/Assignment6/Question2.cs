using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6
{
    internal class Question2
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter words:");
            string a = Console.ReadLine();
            string[] words = a.Split(',');
            var res = words.Where(i => i.StartsWith("a") && i.EndsWith("m"));

            Console.WriteLine(string.Join(",", res));
            Console.ReadLine();

        }
    }
}
