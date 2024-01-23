using NUnit.Framework;
using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace Boolean.CSharp.Main
{
    public abstract class Account(User user) : IAccount
    {
        public User Owner { get; set; } = user;
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();

        public void Deposit(double amount)
        {
            Transactions.Add(new Transaction(amount, TransactionType.Deposit, GetBalance()));
        }
        
        public bool Withdraw(double amount, double overdraftAmount)
        {
            Transaction transaction = new Transaction(amount, TransactionType.Withdrawal, GetBalance());
            if (transaction.NewBalance < 0 && transaction.NewBalance < 0-overdraftAmount)
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