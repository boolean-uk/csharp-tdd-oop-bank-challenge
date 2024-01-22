using System;

namespace Boolean.CSharp.Main
{
    public class Transaction
    {
        public enum TransactionType
        {
            Credit,
            Debit
        }

        private DateTime _time;
        private TransactionType _typeOfTransaction;
        private float _amount;
        private float _balance;

        public DateTime Time => _time;
        public TransactionType TypeOfTransaction => _typeOfTransaction;
        public float Amount => _amount;
        public float Balance => _balance;

        public Transaction(DateTime time, TransactionType typeOfTransaction, float amount, float balance)
        {
            this._time = time;
            this._typeOfTransaction = typeOfTransaction;
            this._amount = amount;
            this._balance = balance;
        }
    }
}
