using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    internal class Question2
    {
        static void Main()
        {
            Console.Write("enter no. of lines: ");
            int x = int.Parse(Console.ReadLine());

            string[] y = new string[x];

            for (int i = 0; i < x; i++)
            {
                Console.Write($"enter line {i + 1}: ");
                y[i] = Console.ReadLine();
            }

            string path = "output.txt";
            File.WriteAllLines(path, y);

            Console.WriteLine($"File '{path}' has been created and written");
            Console.ReadLine();
        }
    }
}
