using Boolean.CSharp.Main.Models;
using NUnit.Framework;
using System;
using System.Security.Principal;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CoreTests
    {
        private Account _account;

        [SetUp]
        public void Setup()
        {
            _account = new Account();
        }

        [Test]
        public void Deposit()
        {
            // Arrange
            double initialBalance = _account.Balance;
            double depositAmount = 100.00;

            // Act
            _account.Deposit(depositAmount);

            // Assert
            Assert.AreEqual(initialBalance + depositAmount, _account.Balance);
            Assert.AreEqual(1, _account.Transactions.Count);
            Assert.AreEqual(TransactionType.Credit, _account.Transactions[0].Type);
            Assert.AreEqual(depositAmount, _account.Transactions[0].Amount);
        }

        [Test]
        public void WithdrawBalanceIsSufficient()
        {
            // Arrange
            _account.Deposit(200.00);
            double initialBalance = _account.Balance;
            double withdrawAmount = 100.00;

            // Act
            _account.Withdraw(withdrawAmount);

            // Assert
            Assert.AreEqual(initialBalance - withdrawAmount, _account.Balance);
            Assert.AreEqual(2, _account.Transactions.Count);
            Assert.AreEqual(TransactionType.Debit, _account.Transactions[1].Type);
            Assert.AreEqual(withdrawAmount, _account.Transactions[1].Amount);
        }

        [Test]
        public void WithdrawBalanceIsInsufficient()
        {
            // Arrange
            double withdrawAmount = 100.00;

            // Act & Assert
            var ex = Assert.Throws<InvalidOperationException>(() => _account.Withdraw(withdrawAmount));
            Assert.That(ex.Message, Is.EqualTo("Insufficient funds for withdrawal."));
        }

        [Test]
        public void GenerateStatement()
        {
            // Arrange
            BankStatement bankStatement;
            bankStatement = new BankStatement(_account.AccountNumber);

            // Act
            string statement = bankStatement.DisplayStatment();

            // Assert
            Assert.IsNotNull(statement);
        }
    }
}
