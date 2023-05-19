﻿using Boolean.CSharp.Main;
using NUnit.Framework;
using System.Xml.Linq;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CoreTests
    {
        [Test]
        public void CreateUser()
        {
            // I want to create a user account.

            // Arrange
            Core _core = new Core();

            string name = "Max";
            string password = "password";
            List<List<Transaction>> accountslist = new List<List<Transaction>>();

            // Act
            _core.CreateUser(name, password, accountslist);

            // Assert
            Assert.AreEqual(_core.UserList.Count, 1);
        }

        [Test]
        public void CreateCurrentAccount()
        {
            // I want to create a bank account.

            // Arrange
            Core _core = new Core();

            List<List<Transaction>> accountslist = new List<List<Transaction>>();
            _core.CreateUser("Max", "password", accountslist);
            var user = _core.UserList.First();
            var type = AccountType.Current;

            //Act
            _core.CreateBankAccount(user, type);

            // Assert
            Assert.AreEqual(accountslist.Count, 1);
        }

        [Test]
        public void CreateSavingsAccount()
        {
            // I want to create a savings account.

            // Arrange
            Core _core = new Core();

            List<List<Transaction>> accountslist = new List<List<Transaction>>();
            _core.CreateUser("Max", "password", accountslist);
            var user = _core.UserList.First();
            var type = AccountType.Savings;

            // Act
            _core.CreateBankAccount(user, type);

            // Assert
            Assert.AreEqual(accountslist.Count, 1);
        }

        [Test]
        public void DepositAmount()
        {
            // I want to deposit funds.

            // Arrange
            Core _core = new Core();

            List<List<Transaction>> accountslist = new List<List<Transaction>>();
            _core.CreateUser("Max", "password", accountslist);
            var user = _core.UserList.First();
            var type = AccountType.Current;

            _core.CreateBankAccount(user, type);

            var accountname = _core.UserList.First().AccountsList.First();

            int amount = 1000;

            // Act
            _core.DepositAmount(user, amount, accountname);

            // Assert
            Assert.AreEqual(amount, user.AccountsList.First().First().Balance);
        }

        [Test]
        public void WithdrawAmount()
        {
            // I want to withdraw funds.

            // Arrange
            Core _core = new Core();

            List<List<Transaction>> accountslist = new List<List<Transaction>>();
            _core.CreateUser("Max", "password", accountslist);
            var user = _core.UserList.First();
            var type = AccountType.Current;

            _core.CreateBankAccount(user, type);

            var accountname = _core.UserList.First().AccountsList.First();

            int amount = 1000;

            // Act
            _core.WithdrawAmount(user, amount, accountname);

            // Assert
            Assert.AreEqual(-amount, user.AccountsList.First().First().Balance);
        }

        [Test]
        public void CheckBalance()
        {
            // I want to check the balance.

            // Arrange
            Core _core = new Core();

            List<List<Transaction>> accountslist = new List<List<Transaction>>();
            _core.CreateUser("Max", "password", accountslist);
            var user = _core.UserList.First();
            var type = AccountType.Current;

            _core.CreateBankAccount(user, type);

            var accountname = _core.UserList.First().AccountsList.First();

            int amount = 1000;
            int amount1 = 500;

            // Act
            _core.DepositAmount(user, amount, accountname);
            _core.WithdrawAmount(user, amount1, accountname);

            // Assert
            Assert.AreEqual(amount - amount1, _core._balance);
        }

        [Test]
        public void PrintBankStatement()
        {
            // I want to generate bank statements with transaction dates, amounts, and balance at the time of transaction.

            // Arrange
            Core _core = new Core();

            List<List<Transaction>> accountslist = new List<List<Transaction>>();
            _core.CreateUser("Max", "password", accountslist);
            var user = _core.UserList.First();
            var type = AccountType.Current;

            _core.CreateBankAccount(user, type);

            var accountname = _core.UserList.First().AccountsList.First();

            int amount = 1000;
            int amount1 = 2000;
            int amount2 = 500;

            _core.DepositAmount(user, amount, accountname);
            _core.DepositAmount(user, amount1, accountname);
            _core.WithdrawAmount(user, amount2, accountname);

            // Act
            _core.BankStatement(user, accountname);

            // Assert
            Assert.AreEqual(amount + amount1 - amount2, _core._balance);
        }
    }
}