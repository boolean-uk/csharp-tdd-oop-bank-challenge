using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.extra
{
    public class Transaction
    {
        private TransactionType _type;
        private DateTime _time;
        private double _amount;
        private double _oldBalance;
        private double _newBalance;

        public double OldBalance { get { return _oldBalance; } }
        public double NewBalance { get { return _newBalance; } }
        public double Amount { get { return _amount; } }

        public override string ToString()
        {
            return String.Format("{0,-12} || {1, -6} || {2, -6} || {3, -6}",
                _time.ToString("MM/dd/yyyy"),
                _type.Equals(TransactionType.Deposit) ? _amount : "",
                _type.Equals(TransactionType.Withdrawal) ? _amount : "", 
                _newBalance);
        }


        public Transaction(Transaction previous, TransactionType type, double amount)
        { 
            _type = type;
            _time = DateTime.Now;
            _amount = amount;
            _oldBalance = previous._newBalance;
            _newBalance = CalculateNew();
        }

        public Transaction(TransactionType type, double amount)
        {
            _type = type;
            _time = DateTime.Now;
            _amount = amount;
            _oldBalance = 0;
            _newBalance = CalculateNew();
        }

        private double CalculateNew()
        {
            if (_type.Equals(TransactionType.Deposit))
            {
                return _oldBalance + _amount;
            }
            if (_type.Equals(TransactionType.Withdrawal))
            {
                return _oldBalance - _amount >= 0 ? _oldBalance - _amount : _oldBalance;
            }
            return 0d;
        }

        public bool Succeeded()
        {
            if (_type.Equals(TransactionType.Deposit))
            {
                return _oldBalance + _amount == _newBalance;
            }
            if (_type.Equals(TransactionType.Withdrawal))
            {
                return _oldBalance - _amount == _newBalance;
            }

            return false;
        }
    }
}

public enum TransactionType
{
    Deposit, Withdrawal
}
