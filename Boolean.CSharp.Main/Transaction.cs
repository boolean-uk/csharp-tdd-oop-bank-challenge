using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Boolean.CSharp.Main
{
    public class Transaction
    {
        private double _amount;
        private TransactionType _type;
        private DateTime _time;

        public Transaction(double amount, TransactionType type)
        {
            _amount = amount;
            _type = type;
            _time = DateTime.Now;
        }

        public double Amount { get => _amount; }
        public TransactionType Type { get => _type; }
        public DateTime Time { get => _time; }
    }
}