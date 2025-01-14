using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Models.Transactions
{
    public class CreditTransaction : ITransaction
    {
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public decimal Balance { get; set; }
        public CreditTransaction(decimal amount, decimal balance)
        {
            Amount = amount;
            Date = DateTime.Now;
            Balance = balance - amount;
        }

        public void printTransaction()
        {
            Console.WriteLine(transactionString());
        }

        public string transactionString()
        {
            return Date.ToString() + " || " + Amount + " || " + "\r" + " || " + Balance;
        }
    }
}
