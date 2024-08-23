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
        [TestCase(5, 2)]
        [TestCase(500, 0)]
        [TestCase(5000, 723)]
        [TestCase(250, 69)]
        [TestCase(35, 2)]
        [TestCase(52, 42)]
        public void TestBalance(double funds, double withdraw)
        {
            AmericanExpress branch = new AmericanExpress();
            Savings account = new Savings(1, 1, branch);

            account.Deposit(funds);

            account.Withdraw(withdraw);

            Assert.That(account.Balance() == funds - withdraw);
        }


    }
}
