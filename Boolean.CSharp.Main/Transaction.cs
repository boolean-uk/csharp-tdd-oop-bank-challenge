using Boolean.CSharp.Main.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Boolean.CSharp.Main
{
    public class Transaction
    {
        private DateTime _dateCreated;
        private int _amount;
        private int _balance;
        private TransactionAction _transactionAction;

        public Transaction(int amount, int balance, TransactionAction transactionAction)
        {
            _dateCreated = DateTime.Now;
            _amount = amount;
            _balance = balance;
            _transactionAction = transactionAction;
        }

        public DateTime DateCreated { get { return _dateCreated; } }
        public int Amount { get { return _amount; } }
        public int Balance { get { return _balance; } }
        public TransactionAction TransactionAction { get { return _transactionAction; } }
    }
}