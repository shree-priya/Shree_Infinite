using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Assessment2
{
    internal class Question3
    {
        static void Number(int num)
        {
            if (num < 0)
            {
                throw new ArgumentException("num can't be negative");
            }
            Console.WriteLine(num);
        }

        static void Main()
        {
            try
            {
                Console.WriteLine("Enter a number: ");
                int Num = int.Parse(Console.ReadLine());
                Number(Num);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            Console.ReadLine();
        }
    }

}

