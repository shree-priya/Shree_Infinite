using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    internal class SaleDetails
    {
        int Salesno;
        int Productno;
        double Price;
        DateTime dateofsale;
        int Qty;
        double TotalAmount;
        public SaleDetails(int salesno, int productno, DateTime dateOfSale, int qty,double price)
        {
            this.Salesno = salesno;
            this.Productno = productno;
            this.dateofsale = dateOfSale;
            this.Qty = qty;
            this.Price = price;
            this.TotalAmount = 0; 
        }
        public void Sales()
        {
            TotalAmount = Qty * Price;
        }
        public void showData()
        {
           Console.WriteLine($"SalesNo :{Salesno}");
           Console.WriteLine($"ProductNo :{Productno}");
            Console.WriteLine($"DateofSale :{dateofsale}");
            Console.WriteLine($"TotalAmount :{TotalAmount}");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Salesno:");
            int a= int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Productno:");
            int b= int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Price:");
            double c = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter the date :");
            DateTime d = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter the qty :");
            int e = int.Parse(Console.ReadLine());

            SaleDetails saleDetails = new SaleDetails(a, b, d, e,c);

            saleDetails.Sales();
            saleDetails.showData();
            Console.ReadLine();


        }
    }
   
   
}
