using NUnit.Framework;
using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Boolean.CSharp.Main
{
    public abstract class Account
    {
        private double _balance;
        private User _owner;
        private List<Transaction> _transactions;

        public Account(User user)
        {
            _balance = 0;
            _owner = user;
            _transactions = new List<Transaction>();
        }

        public Account(User user, double balance)
        {
            _balance = balance;
            _owner = user;
            _transactions = new List<Transaction>();
        }

        public double Balance { get => _balance; }
        public User Owner { get => _owner; }
        public List<Transaction> Transactions { get => _transactions; }

        public void Deposit(double amount)
        {
            Transaction transaction = new Transaction(amount);
            _balance += transaction.Amount;
            _transactions.Add(transaction);
        }
        
        public bool Withdraw(double amount)
        {
            if (amount < 0 || _balance-amount < 0)
            {
                Console.WriteLine("Not enough balance for withdrawal");
                return false;
            }

            Transaction transaction = new Transaction(amount);
            _balance -= transaction.Amount;
            _transactions.Add(transaction);

            return true;
        }

    }
}