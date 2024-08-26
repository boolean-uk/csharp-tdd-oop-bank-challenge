using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Boolean.CSharp.Main
{
    public class Transaction
    {
        private DateTime _Date { get; } = DateTime.Now;
        public string Date => _Date.ToString("yyyy-MM-dd");
        public TransactionType TransactionType { get; }
        public decimal Amount { get; }

        public decimal Balance { get; }    

        public Transaction(decimal amount, decimal balance, TransactionType transactionType)
        {
            this.Amount = amount;
            this.Balance = balance;
            this.TransactionType = transactionType;
        }

    }
}
