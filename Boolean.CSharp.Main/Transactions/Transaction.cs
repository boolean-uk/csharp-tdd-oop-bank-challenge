using Boolean.CSharp.Main.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Transactions
{
    public class Transaction
    {

        public DateTime Date { get;}

        public decimal Amount { get;}

        public decimal BalanceAfter { get;}

        public TransactionType Type { get;}

        public Transaction(decimal amount, TransactionType type, decimal balanceafter)
        {
            Amount = amount;
            Type = type;
            BalanceAfter = balanceafter;
            Date = DateTime.Now;
        }


    }
}
