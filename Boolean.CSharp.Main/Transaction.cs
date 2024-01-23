using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Transaction
    {
        public DateTime Date { get; }
        public double Amount { get; }
        public TransactionType Type { get; }
        public double Balance { get; }

        public Transaction(double amount, TransactionType type, double balance)
        {
            Date = DateTime.Now;
            Amount = amount;
            Type = type;
            Balance = balance;
        }
    }
}
