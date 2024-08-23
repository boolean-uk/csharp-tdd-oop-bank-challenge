using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Transaction : ITransaction
    {
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }
        public decimal BalanceAfterTransaction { get; set; }
        public string Type { get; set; }

        public Transaction(decimal amount, string type, decimal balanceAfterTransaction)
        {
            TransactionDate = DateTime.Now;
            Amount = amount;
            Type = type;
            BalanceAfterTransaction = balanceAfterTransaction;
        }
    }
}
