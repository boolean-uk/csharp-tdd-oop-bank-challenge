using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boolean.CSharp.Main.Enum;
using Boolean.CSharp.Main.Interfaces;

namespace Boolean.CSharp.Main
{
    public abstract class Account
    {
        private double _balance = 0;
        List<Transaction> _transactions;

        public Account()
        {
            _transactions = new List<Transaction>();
        }

        public double GetBalance()
        {
            ITransaction transaction = _transactions.OrderByDescending(t => t.DateTime).FirstOrDefault();
            _balance = transaction?.Balance ?? 0;
            return _balance;
        }
        
        public void Deposit(double amount)
        {
            double oldBalance = _balance;
            _balance = _balance + amount;
            // Should use interface instead.
            Transaction Transaction = new Transaction(_balance, amount, oldBalance, TransactionType.Credit);
            _transactions.Add(Transaction);
        }
        public void WithDraw(double amount)
        {
            double oldBalance = _balance;
            _balance = _balance - amount;
            Transaction Transaction = new Transaction(_balance, amount, oldBalance, TransactionType.Debit);
            _transactions.Add(Transaction);
        }

        public double Balance => GetBalance();
        public List<Transaction> Transactions { get { return _transactions; } }

    }
}
