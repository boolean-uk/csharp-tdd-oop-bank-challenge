using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class BankStatement
    {
        private DateTime _dateTime;
        private decimal _amount;
        private string _type;
        private decimal _balance;
        public BankStatement(DateTime dateTime, decimal amount, string type, decimal balance)
        {
            _dateTime = dateTime;
            _amount = amount;
            _type = type;
            _balance = balance;
        }

        public DateTime DateTime { get { return _dateTime; } }
        public decimal Amount { get { return _amount; } }
        public string Type { get { return _type; } }
        public decimal Balance { get { return _balance; } }
    }
}
