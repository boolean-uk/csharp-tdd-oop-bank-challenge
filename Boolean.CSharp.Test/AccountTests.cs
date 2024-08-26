using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Accounts;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class AccountTests
    {
        [Test]
        public void GetBalanceTest()
        {
            Savings savings = new Savings();

            savings.balance = 500;

            double expected = 500;

            double result = savings.getBalance();

            Assert.That(expected == result);
        }

        [Test]
        public void DepositTest()
        {
            Savings savings = new Savings();

            double expected = 500.30;

            double result = savings.deposit(500.30);

            Assert.That(expected == result);
        }

        [Test]
        public void WithdrawTest()
        {
            Savings savings = new Savings();

            savings.balance = 500;

            double expected = 200;

            double result = savings.withdraw(300);

            Assert.That(expected == result);

        }
    }
}
