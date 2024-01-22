using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Boolean.CSharp.Main
{
    public class Transaction
    {
        private double _amount;
        private string _type;
        private DateTime _time;

        public Transaction(double amount)
        {
            _amount = amount;
            _type = amount > 0 ? "Deposit" : "Withdrawal";
            _time = DateTime.Now;
        }

        public double Amount { get => _amount; }
        public string Type { get => _type; }
        public DateTime Time { get => _time; }
    }
}