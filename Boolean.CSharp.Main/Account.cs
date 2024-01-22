using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boolean.CSharp.Main.Enum;

namespace Boolean.CSharp.Main
{
    public abstract class Account
    {
        protected double _balance;
        List<Transaction> _transactions;

        public Account()
        {
            _transactions = new List<Transaction>();
        }
        public Account(double balance)
        {
            _balance = balance;
            _transactions = new List<Transaction>();
        }

        public void deposit(double amount)
        {
            double oldBalance = _balance;
            _balance = _balance + amount;
            Transaction Transaction = new Transaction(_balance, amount, oldBalance, TransactionType.Credit);
            _transactions.Add(Transaction);
        }
        public void withDraw(double amount)
        {
            double oldBalance = _balance;
            _balance = _balance - amount;
            Transaction Transaction = new Transaction(_balance, amount, oldBalance, TransactionType.Debit);
            _transactions.Add(Transaction);
        }

        public double Balance { get { return _balance; } }
        public List<Transaction> Transactions { get { return _transactions; } }

    }
}
