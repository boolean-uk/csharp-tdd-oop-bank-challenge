using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Models
{
    public enum TransactionType
    {
        Credit,
        Debit
    }

    public class Transaction
    {
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public TransactionType Type { get; set; }

        public Transaction(double amount, TransactionType type)
        {
            Date = DateTime.Now;
            Amount = amount;
            Type = type;
        }
    }
}
