using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment3
{
    internal class Question3
    {
        static void Main()
        {
            write();
            Console.ReadLine();
        }
        public static void write()
        {
            FileStream filestream = new FileStream("program.txt", FileMode.Append,FileAccess.Write);
            StreamWriter streamwriter = new StreamWriter(filestream);
            Console.WriteLine("enter the data:");
            string a = Console.ReadLine();
            streamwriter.WriteLine(a);
            streamwriter.Close();
            filestream.Close();
        }
    }
}
