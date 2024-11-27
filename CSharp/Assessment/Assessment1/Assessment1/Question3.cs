using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment1
{
    internal class Question3
    { 
    static void Main(string[] args)
        {
        Console.WriteLine("Enter the numbers: ");
        String a = Console.ReadLine();
        int[] num = a.Split(',').Select(int.Parse).ToArray();
            if(a.Length == 3)
            {
                int res = Math.Max(num[0], Math.Max(num[1], num[2]));
                Console.WriteLine("Final Result : "+ res);
            }
        }

    }
}
