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
            throw new NotImplementedException();
        }

        public Account(User user, double balance)
        {
            throw new NotImplementedException();
        }

        public double Balance { get => _balance; }
        public User Owner { get => _owner; }
        public List<Transaction> Transactions { get => _transactions; }

        public void Deposit(double amount)
        {
            throw new NotImplementedException();
        }
        
        public bool Withdraw(double amount)
        {
            throw new NotImplementedException();
        }

    }
}