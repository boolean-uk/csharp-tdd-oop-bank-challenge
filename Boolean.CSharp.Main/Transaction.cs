using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;


namespace Boolean.CSharp.Main
{
    public enum TransactionType
    {
        DEPOSIT,
        WITHDRAW
    }
    public class Transaction
    {
        private string _ID;
        private DateTime _dateTime;
        private TransactionType _type;
        private float _amount;
        private float _currentBalance;


        public TransactionType TransactionType { get { return _type; } }
        public float Amount { get { return _amount; } }

        public DateTime DateTime { get { return _dateTime; } }
        public float Balance { get { return _currentBalance; } }


        public Transaction(float amount, TransactionType type, float balance)
        {
            _ID = Guid.NewGuid().ToString();
            _dateTime = DateTime.Now;
            _amount = amount;
            _type = type;
            _currentBalance = balance;
        }

        public Transaction(string date, float amount, TransactionType type, float balance)
        {
            _ID = Guid.NewGuid().ToString();
            _dateTime = DateTime.Parse(date);
            _amount = amount;
            _type = type;
            _currentBalance = balance;
        }

    }
}
