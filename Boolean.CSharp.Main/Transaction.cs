using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Boolean.CSharp.Main
{
    public class Transaction
    {
        
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public decimal BalanceAfterTransaction { get; set; }
        public TransactionType Type { get; set; }
        public DateTime Now { get; }
        
        

        public Transaction(DateTime date, decimal amount, decimal balance, TransactionType type ) 
        {
            
            Date = date;
            Amount = amount;
            BalanceAfterTransaction = balance;
            Type = type;
        
        }
    }
}
