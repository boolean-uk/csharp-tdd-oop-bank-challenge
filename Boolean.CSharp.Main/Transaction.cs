using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Transaction
    {
        public double Amount { get; }
        public double BalanceAtTransaction { get; }
        public DateTime TransactionDate { get; }

        public Transaction(double amount, double balanceAtTransaction)
        {
            Amount = amount;
            BalanceAtTransaction = balanceAtTransaction;
            TransactionDate = DateTime.Now;
        }
    }
}
