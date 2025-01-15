﻿using Boolean.CSharp.Main;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CoreTests
    {
        private Core _core;

        public CoreTests()
        {
            _core = new Core();

        }

        [Test]
        public void CreateCurrentAccount()
        {
            Bank bank = new Bank();
            Iperson person = new Customer("11101010111", bank);
            person.CreateCurrentAccount();
            Assert.That(person.GetCurrentAccount(), Is.Not.EqualTo(null));
        }
        [Test]
        public void CreateSavingsAccount()
        {
            Bank bank = new Bank();
            Iperson person = new Customer("11101010111", bank);
            person.CreateSavingsAccount();
            Assert.That(person.GetSavingsAccount(), Is.Not.EqualTo(null));
        }
        [Test]
        public void GenerateBankStatements()
        {
            Bank bank = new Bank();
            Iperson customer = new Customer("11101010111",bank);
            customer.CreateSavingsAccount();
            Iaccount SavingsAccount = customer.GetSavingsAccount();
            SavingsAccount.Deposit(100);
            SavingsAccount.Withdraw(50);
            SavingsAccount.GenerateBankStatements();
            //check terminal
        }
        [Test]
        public void Deposit()
        {
            Bank bank = new Bank();
            Iperson customer = new Customer("11101010111", bank);
            customer.CreateCurrentAccount();
            Iaccount CurrentAccount = customer.GetCurrentAccount();
            CurrentAccount.Deposit(100);
            Assert.That(CurrentAccount.CalculateBalance(), Is.EqualTo(100));
        }
        [Test]
        public void Withdraw()
        {
            Bank bank = new Bank();
            Iperson customer = new Customer("11101010111", bank);
            customer.CreateCurrentAccount();
            Iaccount CurrentAccount = customer.GetCurrentAccount();
            CurrentAccount.Deposit(100);
            CurrentAccount.Withdraw(50);
            Assert.That(CurrentAccount.CalculateBalance(), Is.EqualTo(50));
        }
        [Test]
        public void RequestOverdraft()
        {
            Bank bank = new Bank();
            Iperson customer = new Customer("11101010111", bank);
            Manager manager = new Manager("22222222222", bank );
            customer.CreateCurrentAccount();
            //request overdraft
            Iaccount account = customer.GetCurrentAccount();
            Request request = account.RequestOverdraft(10000, account.GetAccountID());
            manager.ApproveOverdraft(request);
            account.Withdraw(1000);
            Assert.That(account.CalculateBalance(), Is.EqualTo((decimal)-1000));
        }
        [Test]
        public void RequestOverdraft2()
        {
            Bank bank = new Bank();
            Iperson customer = new Customer("11101010111", bank);
            Manager manager = new Manager("22222222222", bank);
            customer.CreateCurrentAccount();
            //request overdraft
            Iaccount account = customer.GetCurrentAccount();
            account.Withdraw(1000);
            Assert.That(account.CalculateBalance(), Is.EqualTo(0));
        }
    }
}