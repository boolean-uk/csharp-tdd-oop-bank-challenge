using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boolean.CSharp.Main.Enum;

namespace Boolean.CSharp.Main
{
    public class Transactions
    {
        public double amount;
        public DateTime date;
        public TransactionType transactionType;

        public Transactions(double amount, DateTime datetime, TransactionType transactionType) 
        {
            this.amount = amount;
            this.date = datetime;
            this.transactionType = transactionType;
        }
    }
}
