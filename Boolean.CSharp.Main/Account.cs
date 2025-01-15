using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public abstract class Account
    {
        public string AccountNumber { get; set; }
        public double Balance { get; set; }
        public string Type { get; set; }
        public List<Transaction> Transactions { get; set; }
        //public bool Overdraft { get; set; }


        public Account(string accountNumber, double balance, string type)
        {
            AccountNumber = accountNumber;
            Balance = balance;
            Type = type;
            Transactions = new List<Transaction>();
            //Overdraft = false;

        }

        public double AddFunds(double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("You cannot deposit negative or 0");
                return 0;
            }
            Balance += amount;
            Transactions.Add(new Transaction(DateTime.Now.ToString(), amount.ToString(), "0", Balance.ToString()));
            return Balance;
        }

        public double Withdraw(double amount)
        {

            if (amount <= 0)
            {
                Console.WriteLine("Invalid amount to withdraw");
                return Balance;
            }

            if (amount > Balance)
            {
                Console.WriteLine($"Not enough to withdraw, your balance is: {Balance}");
                return Balance;
                
            }

            Balance -= amount;
            Transactions.Add(new Transaction(DateTime.Now.ToString(), "0", amount.ToString(), Balance.ToString()));
            return Balance;
        }


        /*        
                date       || credit  || debit  || balance
                14/01/2012 ||         || 500.00 || 2500.00
                13/01/2012 || 2000.00 ||        || 3000.00
                10/01/2012 || 1000.00 ||        || 1000.00
        */


        public void ViewTransaction()
        {
            Console.WriteLine($"Account number: {AccountNumber}");
            Console.WriteLine($"Account type: {Type}\n");
            Console.WriteLine("{0,-20} || {1,-20} || {2,-20} || {3,-20}", "Date", "Credit", "Debit", "Balance");

            Transactions.Reverse();

            foreach (var transaction in Transactions)
            {
                Console.WriteLine("{0,-20} || {1,-20} || {2,-20} || {3,-20}",
                    transaction.Date,
                    transaction.Credit,
                    transaction.Debit,
                    transaction.Balance);
            }
        }


    }
}
