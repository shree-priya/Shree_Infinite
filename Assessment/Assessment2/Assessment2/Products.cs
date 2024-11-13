using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment2
{
    class Products
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }

        public Products(int productId, string productName,double price)
        {
            ProductId = productId;
            ProductName = productName;
            Price = price;
        }

    }
    class Question2
    {
        static void Main()
        {

            List<Products> prod = new List<Products>();
            Console.WriteLine("Enter the details :");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("enter product id:");
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine("enter product name :");
                string name = Console.ReadLine();
                Console.WriteLine("enter product price :");
                double price = double.Parse(Console.ReadLine());
                prod.Add(new Products(id, name, price));
            }
            for(int i = 0; i < 9; i++)
            {
            for(int j = 0; j < 10 - i - 1; j++)
                {
                    if (prod[j].Price > prod[j + 1].Price)
                    {
                        var temp = prod[j];
                        prod[j] = prod[j + 1];
                        prod[j + 1] = temp;
                    }
                    
                }
            }
            foreach(var i in prod)
            {
                Console.WriteLine($"Id: {i.ProductId},Name :{i.ProductName},Price :{i.Price}");
            }
            Console.ReadLine();
        }




    }
}
