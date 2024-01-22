using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Account
    {
        private string _accountName;
        private string _accountType;
        private double _balance;
        public Account(string accountName)
        {
            _accountName = accountName;
            _balance = 0;
            _accountType = "";
        }

        public string AccountName { get { return _accountName; } set { _accountName = value; } }
        public string AccountType { get { return _accountType; } set { _accountType = value; } }
        public double Balance { get { return _balance;} set { _balance = value; } }


        public void Deposit(double amount)
        {
            Console.WriteLine("You have deposited " + amount);
            Balance += amount;      
        }


        public void Withdraw(double amount)
        {
            if (Balance > amount)
            {
                Console.WriteLine("You have withdrawn " + amount);
                Balance -= amount;
                Console.WriteLine("You now have " + Balance + " left in your balance");
            } else
            {
                Console.Write("You do not have enough in your balance to withdraw " + amount);
            }
        }
    }
}
