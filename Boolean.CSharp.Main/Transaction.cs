using System;
using System.Collections.Generic;
using System.Linq;
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
        public float BalanceBeforeTransaction { get { return _currentBalance; } }
        public Transaction(float amount, TransactionType type, float beforeBalance)
        {
            _ID = Guid.NewGuid().ToString();
            _dateTime = DateTime.Now;
            _amount = amount;
            _type = type;
            _currentBalance = beforeBalance;
        }

    }
}
