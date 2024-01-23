using Boolean.CSharp.Main.Models;
using Boolean.CSharp.Main.Models.Accounts;
using NUnit.Framework;
using System;
using System.Linq;
using System.Security.Principal;

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
            _overdraftManager = new OverdraftManager(_accountManager);
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
            var request = _overdraftManager.Requests.FirstOrDefault(r => r.AccountNumber == account.AccountNumber);
            Assert.IsNotNull(request);
            Assert.AreEqual(amount, request.Amount);
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

        [Test]
        public void WithdrawWithinOverdraftLimit()
        {
            // Arrange
            CurrentAccount account = new CurrentAccount(Branch.UK, "123456789");
            account.OverdraftLimit = 500;

            double depositAmount = 200;
            account.Deposit(depositAmount);
            double withdrawAmount = 400; // Within the overdraft limit

            // Act
            Assert.DoesNotThrow(() => account.Withdraw(withdrawAmount));

            // Assert
            Assert.AreEqual(-200, account.Balance); // Balance should be negative but within overdraft limit
        }

        [Test]
        public void WithdrawExceedingOverdraftLimit()
        {
            // Arrange
            CurrentAccount account = new CurrentAccount(Branch.UK, "123456789");
            account.OverdraftLimit = 500;

            double depositAmount = 200;
            account.Deposit(depositAmount);
            double withdrawAmount = 800; // Exceeds the overdraft limit

            // Act & Assert
            var ex = Assert.Throws<InvalidOperationException>(() => account.Withdraw(withdrawAmount));
            Assert.That(ex.Message, Is.EqualTo("Cannot withdraw this amount, because it would exceed overdraft limit."));
        }
    }
}
