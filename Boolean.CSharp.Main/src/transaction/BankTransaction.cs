using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boolean.CSharp.Main.extra;

namespace Boolean.CSharp.Main.src.transaction
{
    public class BankTransaction : ITransaction
    {
        private TransactionType _type;
        private DateTime _time;
        private double _amount;
        private double _oldBalance;
        private double _newBalance;
        private Status _status;
        private double _overdraft;

        public double OldBalance { get { return _oldBalance; } }
        public double NewBalance { get { return _newBalance; } }
        public double Amount { get { return _amount; } }
        public virtual Status Status { get { return _status; } }
        public TransactionType Type { get { return _type; } }

        public BankTransaction(BankTransaction previous, TransactionType type, double amount, double overdraft = 0)
        {
            _type = type;
            _time = DateTime.Now;
            _amount = amount;
            _overdraft = overdraft;
            _oldBalance = previous._newBalance;
            _newBalance = CalculateNew();
            _status = !(_oldBalance == _newBalance && _amount != 0) ? Status.Approved : Status.Declined;
        }

        public BankTransaction(TransactionType type, double amount, double overdraft = 0)
        {
            _type = type;
            _time = DateTime.Now;
            _amount = amount;
            _overdraft = overdraft;
            _oldBalance = 0;
            _newBalance = CalculateNew();
            _status = !(_oldBalance == _newBalance && _amount != 0) ? Status.Approved : Status.Declined;
        }

        public override string ToString()
        {
            return string.Format("{0,-12} || {1, -6} || {2, -6} || {3, -6}",
                _time.ToString("MM/dd/yyyy"),
                _type.Equals(TransactionType.Deposit) ? _amount : "",
                _type.Equals(TransactionType.Withdrawal) ? _amount : "",
                _newBalance);
        }

        private double CalculateNew()
        {
            if (_type.Equals(TransactionType.Deposit))
            {
                return _oldBalance + _amount;
            }
            if (_type.Equals(TransactionType.Withdrawal))
            {
                return (_oldBalance + _overdraft) - _amount >= 0 ? _oldBalance - _amount : _oldBalance;
            }
            return 0d;
        }
    }
}