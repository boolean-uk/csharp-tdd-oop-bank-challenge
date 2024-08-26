using Boolean.CSharp.Main;
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

            
        }
    }
}
