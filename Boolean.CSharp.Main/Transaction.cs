using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Transaction
    {
        private DateTime _transactionDate;
        private double _amount;
        private double _balance;

        public Transaction(DateTime transactionDate, double amount, double balance)
        {
            _transactionDate = transactionDate;
            _amount = amount;
            _balance = balance;
        }

        public DateTime DateTime { get { return _transactionDate; } set { _transactionDate = value; } }
        public double Amount { get { return _amount; } set { _amount = value; } }
        public double Balance { get { return _balance; } set { _balance = value; } }
    }
}
