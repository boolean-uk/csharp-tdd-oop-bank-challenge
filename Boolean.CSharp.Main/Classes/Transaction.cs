using Boolean.CSharp.Main.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Classes
{
    public class Transaction 
    {
        public Transaction(IAccount account, decimal amount, DateOnly transactionDate)
        {
            Account = account;
            this.amount = amount;
            this.transactionDate = transactionDate;
        }

        public Transaction() { }
        public IAccount Account { get; set; }

        public decimal amount { get; set; }

        public DateOnly transactionDate { get; set; }



    }
}
