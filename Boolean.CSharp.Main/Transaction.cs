using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Boolean.CSharp.Main
{
    public class Transaction
    {
        private double _balance;
        private double _originalBalance;
        private string _type;
        private DateTime _time;

        public Transaction()
        {
            throw new NotImplementedException();
        }

        public double Balance { get => _balance; }
        public double OriginalBalance { get => _originalBalance; }
        public string Type { get => _type; }
        private DateTime Time { get => _time; }
    }
}