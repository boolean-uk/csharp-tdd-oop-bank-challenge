using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Bank
{
    public class Transaction :ITransaction
    {
        public Transaction(decimal amount, DateTime date, decimal balance )
        {
            Amount = amount;
            Date = date;
            Balance = balance;
        }

        public decimal Amount { get; set; }

        public DateTime Date { get; }

        public decimal Balance { get; set; } 
    }
}
