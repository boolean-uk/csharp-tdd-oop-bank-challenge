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

        public Transaction(double amount, double balance)
        {
            _transactionDate = DateTime.UtcNow;
            _amount = amount;
            _balance = balance;          
        }

        public DateTime TransactionDate { get { return _transactionDate; } }
        public double Amount { get { return _amount; } set { _amount = value; } }
        public double Balance { get { return _balance; } set { _balance = value; } }
    }
}
