using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Bank.AccountTypes;
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
        private Extension _extension;
        public ExtensionTests()
        {
            _extension = new Extension();
        }

        [Test]
        public void CanGetBalanceFromTransactionHistoryTest()
        {
            decimal expectedBalance = 2500.00M;
            CurrentAccount currentAccount = new CurrentAccount("Current");
            currentAccount.MakeDeposit(1000.00M);
            currentAccount.MakeDeposit(2000.00M);
            currentAccount.MakeWithdrawal(500.00M);

            decimal actualBalance = currentAccount.GetBalance();

            Assert.That(actualBalance, Is.EqualTo(expectedBalance));
        }

    }
}
