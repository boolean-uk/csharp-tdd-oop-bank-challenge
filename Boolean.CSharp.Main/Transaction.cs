using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Boolean.CSharp.Main
{
    public class Transaction
    {
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string TransactionType { get; set; } // "Deposit" or "Withdrawal"

        public UserAccount Account { get; set; } // // Reference to the associated account
        public Transaction(DateTime date, decimal amount, string transactionType, UserAccount account)
        {
            Date = date;
            Amount = amount;
            TransactionType = transactionType;
            Account = account;
        }
    }
}
