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
            throw new NotImplementedException();
        }

        public double Balance { get => _amount; }
        public string Type { get => _type; }
        public DateTime Time { get => _time; }
    }
}