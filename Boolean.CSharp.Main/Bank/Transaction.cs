using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Bank
{
    public class Transaction : ITransaction
    {

        public Transaction(decimal amount, DateTime date, decimal balance, string transactionType )
        {
            Amount = amount;
            Date = date;
            Balance = balance;
            TransactionType = transactionType;
        }

        public decimal Amount { get; set; }

        public DateTime Date { get; }

        public decimal Balance { get; }
        public string TransactionType { get; }

       
    }
}
