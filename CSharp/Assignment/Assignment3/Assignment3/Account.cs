using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    internal class Account
    {
        public int AccNo;
        public string CustName;
        public string AccType;
        
        double balance;
        public Account(int accNo, string custName, string accType, double initialBalance)
        {
            AccNo = accNo;
            CustName = custName;
            AccType = accType;
            balance = initialBalance;
        }
        public void Credit( double amount)
        {
            balance += amount;
            Console.WriteLine($"balance : {balance}");
        }
        public void Debit(double amount)
        {
            if (balance >= amount)
            {
                balance -= amount;
                Console.WriteLine($"balance: {balance}");
            }
            else
            {
                Console.WriteLine("Insufficient balance ");
            }
        }
        public void ShowData()
        {
            Console.WriteLine($"Account No: {AccNo}");
            Console.WriteLine($"Customer Name : {CustName}");
            Console.WriteLine($"Account Type : {AccType}");
          

        }
        
        static void Main(string[] args)
        {
            
            Console.WriteLine("Enter the AccNo :");
            int accNo = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter CustName:");
            string custName = Console.ReadLine();
            Console.WriteLine("Enter Account Type :");
            string accType = Console.ReadLine();
            Console.WriteLine("Enter the balance: ");
            double initialbalance = double.Parse(Console.ReadLine());
            Account account = new Account(accNo, custName, accType, initialbalance);
            Console.WriteLine("Enter the transaction type: ");
            char transType = char.Parse(Console.ReadLine().ToUpper());
            Console.WriteLine("Enter Amount:");
            double amount = double.Parse(Console.ReadLine());
            account.ShowData();
            

            if (transType == 'D')
            {
                account.Credit(amount);
            }
            else if (transType == 'W')
            {
                account.Debit(amount);
            }

            Console.ReadLine();

        }
    }
}
