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
        private User _owner;
        private List<Transaction> _transactions;

        public Account(User user)
        {
            _owner = user;
            _transactions = new List<Transaction>();
        }

        public User Owner { get => _owner; }
        public List<Transaction> Transactions { get => _transactions; }

        public void Deposit(double amount)
        {
            Transaction transaction = new Transaction(amount, TransactionType.Deposit, GetBalance());
            Transactions.Add(transaction);
        }
        
        public bool Withdraw(double amount)
        {
            Transaction transaction = new Transaction(amount, TransactionType.Withdrawal, GetBalance());
            if (transaction.NewBalance < 0)
            {
                Console.WriteLine("The balance is too low for the withdrawal");
                return false;
            }

            Transactions.Add(transaction);

            return true;
        }

        public double GetBalance()
        {
            return Transactions.Count > 0  ? Transactions[Transactions.Count - 1].NewBalance : 0;
        }
    }
}