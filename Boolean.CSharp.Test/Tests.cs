using Boolean.CSharp.Main;
using NUnit.Framework;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void TestDeposit()
        {
            var account = new Account();

            account.Deposit(1000);

            Assert.AreEqual(1000, account.CalculateBalance());
        }

        [Test]
        public void TestDepositNegativeAmount()
        {
            var account = new Account();

            Assert.Throws<ArgumentException>(() => account.Deposit(-100));
        }

        [Test]
        public void TestWithdraw()
        {
            var account = new Account();
            account.Deposit(1000);

            account.Withdraw(500);

            Assert.AreEqual(500, account.CalculateBalance());
        }

        [Test]
        public void TestWithdrawNegativeAmount()
        {
            var account = new Account();
            account.Deposit(1000);

            Assert.Throws<ArgumentException>(() => account.Withdraw(-100));
        }

        [Test]
        public void TestWithdrawInsufficientFunds()
        {
            var account = new Account();

            Assert.Throws<InvalidOperationException>(() => account.Withdraw(100));
        }

        [Test]
        public void TestGenerateStatement()
        {
            var account = new Account();
            account.Deposit(1000);
            account.Withdraw(500);

            var statement = account.GenerateStatement();

            Assert.NotNull(statement);

            Assert.NotNull(statement.Transactions);
            Assert.AreEqual(2, statement.Transactions.Count);

            var transactions = statement.Transactions;

            Assert.AreEqual(1000, transactions[0].Amount);
            Assert.AreEqual(1000, transactions[0].Balance); 
            Assert.AreEqual(true, transactions[0].IsDeposit);
            Assert.AreEqual(500, transactions[1].Amount);
            Assert.AreEqual(500, transactions[1].Balance); 
            Assert.AreEqual(false, transactions[1].IsDeposit);
        }

        [Test]
        public void TestCalculateBalance()
        {
            var account = new Account();
            account.Deposit(1000);
            account.Withdraw(500);

            var balance = account.CalculateBalance();

            Assert.AreEqual(500, balance);
        }
    }
}
