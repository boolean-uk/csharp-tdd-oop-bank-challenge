using Boolean.CSharp.Main;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class ExtensionTests
    {
        [Test]
        public void TestCalculateBankBalanceWithTransactionHistory()
        {
            Bank bank = new Bank();
            string user = "Bob";
            string bankType = "current";
            double amountDeposit = 1000;
            double amountWithdraw = 700;
            double expectedResult = 300;

            int bankID = bank.AddAccount(user, bankType);
            bank.Deposit(bankID, amountDeposit);
            bank.Withdraw(bankID, amountWithdraw);

            double result = bank.CalculateBalance(bankID);

            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
