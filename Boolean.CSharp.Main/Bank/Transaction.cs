using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Bank
{
    public class Transaction :ITransaction
    {
        public Transaction(decimal amount, DateTime date) 
        {
            Amount = amount;
            Date = date;
        }

        public decimal Amount { get; set; }

        public DateTime Date { get; }
    }
}
