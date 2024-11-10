using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    public class InsufficientBalanceException : Exception
    {
        public InsufficientBalanceException()
        {
            Console.WriteLine("Insufficient balance");
        }
    }
     public class BankingSystem
    {
        private double balance;

        public BankingSystem(double a)
        {
            if (a < 0)
            {
                Console.WriteLine("balance cannot be negative.");
            }
            else
            {
                this.balance = a;
            }
        }

        public void Deposit(double amt)
        {
            if (amt < 0)
            {
                Console.WriteLine("Deposit amount can't be negative.");
            }
            else
            {
                balance += amt;
                Console.WriteLine($"Deposit successful. Current balance: {balance}");
            }
        }

        public void Withdraw(double amt)
        {
            if (amt < 0)
            {
                Console.WriteLine("Withdrawal amt can;t be negative.");
            }
            else if (amt > balance)
            {
                throw new InsufficientBalanceException(); 
            }
            else
            {
                balance -= amt;
                Console.WriteLine($"Withdrawal successful. Current balance: {balance}");
            }
        }

        public double GetBalance()
        {
            return balance;
        }
    }

    public class Banking {
        static void Main(string[] args)
        {
            Console.Write("Enter balance :");
            double a = Convert.ToDouble(Console.ReadLine());
            BankingSystem acc = new BankingSystem(a);
            Console.Write("Enter deposit amt:");
            double b = Convert.ToDouble(Console.ReadLine());
            acc.Deposit(b);
            Console.Write("Enter withdrawal amt:");
            double c = Convert.ToDouble(Console.ReadLine());
            

            try
            {
                acc.Withdraw(c);
                Console.ReadLine();

            }
            catch (InsufficientBalanceException)
            {

            }
        }
        
    }
}
