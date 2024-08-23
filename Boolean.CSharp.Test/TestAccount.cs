using Boolean.CSharp.Main.Accounts;
using Boolean.CSharp.Main.Branches;
using Boolean.CSharp.Main.Interfaces;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Test
{
    public class TestAccount
    {
        [TestCase(5)]
        [TestCase(500)]
        [TestCase(5000)]
        [TestCase(250)]
        [TestCase(35)]
        [TestCase(52)]
        public void TestBalance(double funds)
        {
            AmericanExpress branch = new AmericanExpress();
            Savings account = new Savings(1, 1, branch);

            account.Deposit(funds);

            Assert.That(account.Balance() == funds);
        }
    }
}
