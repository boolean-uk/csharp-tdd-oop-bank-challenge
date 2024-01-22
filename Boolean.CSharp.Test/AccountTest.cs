using Boolean.CSharp.Main.Accounts;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class AccountTest
    {
        #pragma warning disable
        private IAccount _account;
        [SetUp]
        public void SetUp()
        {
            _account = new CurrentAccount("Test Account");
        }

        [Test]
        [TestCase(10, 90)]
        [TestCase(99.5, 0.5)]
        [TestCase(23.23, 100-23.23)]
        public void WithdrawMoneyTest(double amount, double fact)
        {
            _account.Deposit(100);
            _account.Withdraw(amount);
            Assert.That(Math.Round(_account.Balance), Is.EqualTo(Math.Round(fact)));
        }

        [Test]
        [TestCase(10, 110)]
        [TestCase(125.3, 225.3)]
        [TestCase(10.45, 110.45)]
        public void DepositMoneyTest(double amount, double fact)
        {
            _account.Deposit(100);
            _account.Deposit(amount);
            Assert.That(Math.Round(_account.Balance), Is.EqualTo(Math.Round(fact)));
        }

        [Test]
        public void GenerateBankStatementTest()
        {
            _account.Deposit(46);
            _account.Withdraw(45);
            Assert.That(_account.BankStatements.Count, Is.EqualTo(2));
            Assert.That(_account.Balance, Is.EqualTo(1));
        }

        [Test]
        public void WithdrawShouldNotAcceptNegativeValues()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _account.Withdraw(-1));
        }

        [Test]
        public void DepositShouldNotAcceptNegativeValues()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _account.Deposit(-1));
        }
    }
}
