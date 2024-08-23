using Boolean.CSharp.Main;
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
        [Test]
        public void TestDeposit(double funds)
        {
            Account account = new Account();

            account.funds += funds;

            Assert.That(account.funds == funds);
        }
    }
}
