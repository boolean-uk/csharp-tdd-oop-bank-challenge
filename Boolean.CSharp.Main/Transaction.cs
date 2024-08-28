using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Boolean.CSharp.Main
{
    public class Transaction
    {
        private decimal _balance;
        private decimal _amount;

        private DateTime _Date { get; } = DateTime.Now;
        public string Date => _Date.ToString("yyyy-MM-dd");
        public TransactionType TransactionType { get; }
        public decimal Amount { get { return _amount;  } }
        public decimal Balance { get { return _balance;  } }

        public Transaction(decimal amount, TransactionType transactionType, decimal balance)
        {
            this._amount = amount;
            this._balance = balance;
            this.TransactionType = transactionType;
        }

    }
}
