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
        public Enums TransactionType { get; set; }
        
        

        public Transaction(DateTime date, decimal amount, decimal balance, Enums type ) 
        {
            
            Date = date;
            Amount = amount;
            BalanceAfterTransaction = balance;
            TransactionType = type;
        
        }
    }
}
