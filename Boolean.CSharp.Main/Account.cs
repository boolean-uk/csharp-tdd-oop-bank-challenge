using NUnit.Framework;
using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Boolean.CSharp.Main
{
    public abstract class Account : IAccount
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

        public double Balance { get => _balance; set => _balance = value; }
        public User Owner { get => _owner; }
        public List<Transaction> Transactions { get => _transactions; }

        public void Deposit(double amount)
        {
            Transaction transaction = new Transaction(amount, TransactionType.Deposit, Balance);
            Balance += transaction.Amount;
            Transactions.Add(transaction);
        }
        
        public bool Withdraw(double amount)
        {
            if (amount < 0 || Balance-amount < 0)
            {
                Console.WriteLine("Not enough balance for withdrawal");
                return false;
            }

            Transaction transaction = new Transaction(amount, TransactionType.Withdrawal, Balance);
            Balance -= transaction.Amount;
            Transactions.Add(transaction);

            return true;
        }

    }
}