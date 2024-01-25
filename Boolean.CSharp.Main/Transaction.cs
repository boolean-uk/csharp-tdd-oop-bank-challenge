using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boolean.CSharp.Main.Enum;
using Boolean.CSharp.Main.Interfaces;

namespace Boolean.CSharp.Main
{
    public class Transaction : ITransaction
    {
        private double _balance;
        private double _amount;
        private DateTime _dateTime;
        private double _oldBalance;
        private TransactionType _transactionType;

        public Transaction()
        {

        }
        public Transaction(double balance, double amount, double oldBalance, TransactionType transactionType)
        {
            _balance = balance;
            _amount = amount;
            _dateTime = DateTime.Now;
            _oldBalance = oldBalance;
            _transactionType = transactionType;
        }
        public double Balance => _balance;
        public double Amount => _amount;
        public DateTime DateTime => _dateTime;
        public double OldBalance => _oldBalance;
        public TransactionType TransactionType => _transactionType;
    }
}
