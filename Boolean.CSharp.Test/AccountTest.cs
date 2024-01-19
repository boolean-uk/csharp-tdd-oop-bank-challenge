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
            _account = new CurrentAccount();
        }

        [Test]
        [TestCase(10, 90)]
        [TestCase(99.5, 0.5)]
        [TestCase(23.23, 100-23.23)]
        public void WithdrawMoneyTest(double amount, double fact)
        {
            _account.Withdraw(amount);
            Assert.That(Math.Round(_account.Balance), Is.EqualTo(Math.Round(fact)));
        }
    }
}
