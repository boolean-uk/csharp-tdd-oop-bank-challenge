using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boolean.CSharp.Main.Enum;

namespace Boolean.CSharp.Main
{
    public class Transaction
    {
        private double _balance;
        private double _amount;
        private DateTime _dateTime;
        private double _oldBalance;
        private TransactionType _transactionType;

        public Transaction(double balance, double amount, double oldBalance, TransactionType transactionType)
        {
            _balance = balance;
            _amount = amount;
            _dateTime = DateTime.Now;
            _oldBalance = oldBalance;
            _transactionType = transactionType;
        }
        public double Balance { get { return _balance; } }
        public double Amount { get { return _amount; } }
        public DateTime DateTime { get { return _dateTime; } }

        public double OldBalance { get { return _oldBalance; } }
        public TransactionType TransactionType { get { return _transactionType; } }
    }
}
