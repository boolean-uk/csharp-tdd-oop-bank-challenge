﻿using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using Boolean.CSharp.Main;
using Boolean.CSharp.Main.AccountType;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CoreTests
    {
        public Bank Bank { get; set; }
        public Customer Customer { get; set; }
        public Branch Branch { get; set; }
        [SetUp]
        public void SetUp()
        {
            Bank = new Bank();
            Branch = new Branch("Cooperations", Bank);
            new Branch("Cooperations", Bank);
            Bank.BranchList.Add(Branch);
            Customer = new Customer("John", Branch);
            Branch.CustomerList.Add(Customer);
        }

        [Test]
        public void CreateNewAccountOnExistingCustomerTest()
        {
            IAccount account = Branch.CreateAccount(Customer, 'c');
            Assert.That(account, Is.EqualTo(Customer.accounts[0]));
            Assert.AreEqual(account.GetType(), typeof(CurrentAccount));
        }

        [Test]
        public void createNewAccountOnNonExistingCustomerTest()
        {
            IAccount account = Branch.CreateAccount(Customer, 's');
            Assert.That(account, Is.EqualTo(Customer.accounts[0]));
            Assert.AreEqual(account.GetType(), typeof(SavingsAccount));
        }

        [Test]
        public void DepositAmountToSavingsAccountTest()
        {
            IAccount customerAccount = Branch.CreateAccount(Customer, 's');
            double depositBalance = Customer.Deposit(customerAccount, 100);
            Assert.AreEqual(customerAccount.balance, depositBalance);
        }

        [Test]
        public void WithDrawFromSavingsAccount()
        {
            IAccount customerAccount = Branch.CreateAccount(Customer, 's');
            Customer.Deposit(customerAccount, 100);
            double withdrawBalance = Customer.Withdraw(customerAccount, 90);
            Assert.AreEqual(customerAccount.balance, withdrawBalance);
        }

        [Test]
        public void AttemptWithdrawNegativeNumberTest()
        {
            IAccount customerAccount = Branch.CreateAccount(Customer, 'c');
            Customer.Deposit(customerAccount, 200);
            Customer.Withdraw(customerAccount, -200);
            Assert.AreEqual(customerAccount.balance, 200);
            Assert.AreEqual(customerAccount.transactions.Count, 1);
        }

        [Test]
        public void TransactionsAddsUpTest()
        {
            IAccount customerAccount = Branch.CreateAccount(Customer, 's');
            Customer.Deposit(customerAccount, 100);     // 100
            Customer.Deposit(customerAccount, 200);     // 300
            Customer.Deposit(customerAccount, 300);     // 600
            Customer.Deposit(customerAccount, 200);     // 800
            Assert.AreEqual(customerAccount.balance, customerAccount.transactions.Sum(x => x.amount));

            Customer.Withdraw(customerAccount, 300);    // 500
            Assert.AreEqual(customerAccount.balance, customerAccount.transactions.Sum(x => x.amount));
        }


    }
}