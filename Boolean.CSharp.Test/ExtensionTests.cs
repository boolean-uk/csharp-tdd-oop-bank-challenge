using BankingApp.Boolean.CSharp.Main;
using BankingApp.Boolean.CSharp.Main.Accounts;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class ExtensionTests
    {
        public Extension _extension;
        public ExtensionTests()
        {
            _extension = new Extension();
        }
        [Test]
        public void BalanceIsBasedOnTransactionHistory()
        {
            var testAccount = new CurrentAccount();

            testAccount.Deposit(DateTime.Now, 600);
            testAccount.Withdraw(DateTime.Now.AddHours(1), 300);

            Assert.AreEqual(300, testAccount.Balance);



        }
        [Test]
        private void TestQuestion2()
        {

        }
    }
}
