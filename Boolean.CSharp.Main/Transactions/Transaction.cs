using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Transaction
    {
        private DateTime _Date {  get; } = DateTime.Now;
        public string FormattedDate => _Date.ToString("dd/MM/yyy");
        public decimal Amount { get; }

        public decimal RemainingBalance { get; }

        public TransactionType Type { get; }

        public Transaction(decimal amount, TransactionType type, decimal remainingBalance)
        {
            Amount = amount;
            Type = type;
            RemainingBalance = remainingBalance;
        }
    }
}
