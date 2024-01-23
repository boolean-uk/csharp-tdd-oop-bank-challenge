﻿using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Accounts;
using Boolean.CSharp.Main.Concretes;
using Boolean.CSharp.Main.Interfaces;
using NUnit.Framework;
using System.Transactions;
using Transaction = Boolean.CSharp.Main.Concretes.Transaction;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CoreTests
    {
        private IAccount _currentAccount;
        private IAccount _savingsAccount;

        public CoreTests()
        {
            _currentAccount = new CurrentAccount();
            _savingsAccount = new SavingsAccount();

        }

        [Test]
        public void AddAccountTest()
        {
            IAccount savingsAccount = new SavingsAccount();
            IAccount currentAccount = new CurrentAccount();
            ICustomer customer = new Customer();

            customer.AddAccount(savingsAccount);
            customer.AddAccount(currentAccount);

            List<IAccount> accounts = customer.GetAccounts();

            Assert.That(accounts.Count,Is.EqualTo(2));
        }


        [Test]
        public void AddTransaction()
        {
            double amount = 10.00d;
            double amount2 = -10.00d;
            ITransaction transaction = new Transaction(amount, _currentAccount.GetBalance());
            _currentAccount.AddTransaction(transaction);
            ITransaction transaction2 = new Transaction(amount, _currentAccount.GetBalance());
            _currentAccount.AddTransaction(transaction2);
            ITransaction transaction3 = new Transaction(amount2, _currentAccount.GetBalance());
            _currentAccount.AddTransaction(transaction3);

            double actualBalance = _currentAccount.GetBalance();
            
            Assert.That(amount, Is.EqualTo(actualBalance));
            
        }

    }
}