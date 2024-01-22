using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Boolean.CSharp.Main
{
    public class Transaction
    {
        private double _originalBalance;
        private double _amount;
        private double _newBalance;
        private TransactionType _type;
        private DateTime _time;

        public Transaction(double amount, TransactionType type, double balance)
        {
            _originalBalance = balance;
            _amount = amount;
            _newBalance = type == TransactionType.Deposit ? balance + amount : balance - amount;
            _type = type;
            _time = DateTime.Now;
        }

        public double OriginalBalance { get => _originalBalance; }
        public double Amount { get => _amount; }
        public double NewBalance { get => _newBalance; }
        public TransactionType Type { get => _type; }
        public DateTime Time { get => _time; }
    }
}