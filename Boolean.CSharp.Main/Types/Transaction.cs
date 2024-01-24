using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Transaction
    {
        public TransactionType Type { get; set; }
        public DateTime Date { get; set; }
        public int Amount { get; set; } = 0;
        public int Balance { get; set; } = 0;

        public Transaction(TransactionType Type, DateTime Date, int Amount, int Balance)
        {
            this.Type = Type;
            this.Date = Date;
            this.Amount = Amount;
            this.Balance = Balance;
        }
    }
}
