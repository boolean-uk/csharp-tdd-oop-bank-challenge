using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Transaction
    {
        public DateTime DateTime { get; set; }
        public int Amount { get; set; } = 0;
        public int Balance { get; set; } = 0;
        public TransactionType TransactionType { get; set; }

        

        public Transaction(TransactionType transactionType,DateTime dateTime, int Amount, int Balance) {
            this.TransactionType = transactionType;
            this.DateTime = dateTime;
            this.Amount = Amount;
            this.Balance = Balance;
            
        }
    }
}
