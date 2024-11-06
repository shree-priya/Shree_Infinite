using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment1
{
    internal class Question2
    {
        static void main(String[] args)
        {
            Console.Write("Enter a string :");
            string c=Console.ReadLine();
            Console.WriteLine(ExchangeChar(c));
        }
        static string ExchangeChar(string s) {
            if (s.Length <= 0)
            {
                return s;
            }
            char a=s[0];
            char b = s[s.Length - 1];
            return b + s.Substring(1, s.Length - 2) + a;
    }
}
