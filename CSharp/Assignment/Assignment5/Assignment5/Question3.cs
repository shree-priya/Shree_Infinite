using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    internal class Question3
    {
        static void Main()
        {
            Console.Write("enter file path: ");
            string path = Console.ReadLine();

            if (File.Exists(path))
            {
                int count = File.ReadAllLines(path).Length;
                Console.WriteLine($"The file '{path}' has {count} lines.");
            }
            else
            {
                Console.WriteLine($"The file '{path}' does not exist.");
            }
            Console.ReadLine();
        }
    }
}
