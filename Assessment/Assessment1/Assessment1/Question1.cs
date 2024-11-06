using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment1
{
    internal class Question1
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a string: ");
            string a = Console.ReadLine();
            Console.WriteLine("Enter a position :");
            int pos = int.Parse(Console.ReadLine());
            if (pos >= 0 && pos < args.Length)
             {
                 string b = (a.Substring(0, pos) + a.Substring(pos + 1));
                 Console.WriteLine(b);
                 Console.ReadLine();
             }
             
            
            
        }

    }
}
