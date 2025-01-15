using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public enum TransactionTypes
    {
        Add,
        Subtract
    }
    public class Transaction
    {
        public TransactionTypes TransactionType; 
        public decimal Amount { get; set; }

        public Guid Id { get; set; }

        public DateTime Time { get; set; }
        public Transaction(TransactionTypes transactionType, decimal amount, DateTime time) 
        { 
            this.TransactionType = transactionType;
            this.Amount = amount;
            this.Time = time;
            this.Id = Guid.NewGuid();
        }

    }
}
