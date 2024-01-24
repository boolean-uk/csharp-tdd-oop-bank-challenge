using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Boolean.CSharp.Main
{
    public class Transaction
    {
        public DateTime Date { get; }
        public double Credit { get; }
        public double Debit { get; }
        public double BalanceAtTransactionTime { get; }
        public TransactionType Type { get; }

        public Transaction(DateTime date, double amount, TransactionType type, double balanceAtTransactionTime)
        {
            Date = date;
            if(type == TransactionType.CREDIT)
            {
                Credit = amount;
            }
            else
            {
                Debit = amount;
            }
            BalanceAtTransactionTime = balanceAtTransactionTime;
            Type = type;
        }   
    }
}