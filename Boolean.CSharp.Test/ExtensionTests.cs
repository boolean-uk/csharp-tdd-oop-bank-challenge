using Boolean.CSharp.Main.Models;
using Boolean.CSharp.Main.Models.Accounts;
using NUnit.Framework;
using System;
using System.Linq;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class ExtensionTests
    {
        private AccountManager _accountManager;
        private OverdraftManager _overdraftManager;

        [SetUp]
        public void Setup()
        {
            _accountManager = new AccountManager();
            _overdraftManager = new OverdraftManager();
        }

        [Test]
        public void GetBalanceAfterTransaction()
        {
            // Arrange
            var account = new Account(Branch.UK, "1234567890");
            account.Deposit(1000);
            account.Deposit(500);
            account.Withdraw(200);
            var transaction = account.Transactions.Last();

            // Act
            var balance = account.GetBalanceAfterTransaction(transaction);

            // Assert
            Assert.AreEqual(1300, balance);
        }

        [Test]
        public void AddCurrent()
        {
            // Act
            _accountManager.AddCurrent(Branch.UK, "1234567890");

            // Assert
            Assert.IsNotEmpty(_accountManager.Accounts);
            Assert.IsInstanceOf<CurrentAccount>(_accountManager.Accounts.Values.First());
        }

        [Test]
        public void RequestOverdraft()
        {
            // Arrange
            var account = new CurrentAccount(new Branch(), "1234567890");
            double amount = 500;

            // Act
            account.RequestOverdraft(amount, _overdraftManager);

            // Assert
            Assert.Contains(account.AccountNumber, _overdraftManager.Requests.Keys);
            Assert.AreEqual(amount, _overdraftManager.Requests[account.AccountNumber].Amount);
        }

        [Test]
        public void ApproveOverdraft()
        {
            // Arrange
            int accountNumber = _accountManager.AddCurrent(Branch.UK, "1234567890");
            _overdraftManager.CreateRequest(accountNumber, 500);

            // Act
            _overdraftManager.ApproveRequest(accountNumber, 500);

            // Assert
            Assert.AreEqual(500, ((CurrentAccount)_accountManager.Accounts[accountNumber]).OverdraftLimit);
        }
    }
}
