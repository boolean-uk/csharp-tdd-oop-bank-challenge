using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Boolean.CSharp.Main
{
    public class Transaction(double amount, TransactionType type, double balance)
    {
        public double OriginalBalance { get; set; } = balance;
        public double Amount { get; set; } = amount;
        public double NewBalance { get; set; } = (type == TransactionType.Deposit) ? balance + amount : balance - amount;
        public TransactionType Type { get; set; } = type;
        public DateTime Time { get; set; } = DateTime.Now;
    }
}