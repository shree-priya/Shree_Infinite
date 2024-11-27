using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment3
{
    internal class Question2
    {
        static void Main()
        {
            Console.WriteLine("Box 1");
            Console.Write("Length: ");
            double l1 = double.Parse (Console.ReadLine());
            Console.Write("Breadth: ");
            double b1 = double.Parse(Console.ReadLine());
            Console.WriteLine("-------------------");
            Console.WriteLine("Box 2:");
            Console.Write("Length: ");
            double l2 = double.Parse(Console.ReadLine());
            Console.Write("Breadth: ");
            double b2 = double.Parse(Console.ReadLine());

            Box a = new Box(l1, b1);
            Box b = new Box(l2, b2);

            Console.WriteLine("***Box 1 Details***");
            a.Display();

            Console.WriteLine("***Box 2 Details***");
            b.Display();

            Box box3 = Box.Add(a, b);

            Console.WriteLine("Box3 :");
            box3.Display();

            Console.ReadLine();
        }
        class Box
        {
            public double length { get; set; }
            public double breadth { get; set; }

            public Box(double l, double b)
            {
                length = l;
                breadth = b;
            }

            public static Box Add(Box b1, Box b2)
            {
                double x = b1.length + b2.length;
                double y = b1.breadth + b2.breadth;
                return new Box(x,y);
            }

            public void Display()
            {
                Console.WriteLine($"Length = {length}, Breadth = {breadth}");
            }
        }
    }
}


