using Boolean.CSharp.Main;
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
        public void GetBalanceBasedOnTransactionHistory()
        {
            //Arrange
            IAccount account = new Account();

            //Act
            account.Deposit(1000, new DateTime(2022, 1, 10));
            account.Deposit(640, new DateTime(2022, 1, 12));
            account.Withdraw(140, new DateTime(2022, 1, 29));

            //Asssert
            account.PrintStatement();
            double calculatedBalance = account.GetBalance();
            Console.WriteLine($"Calculated balance: {calculatedBalance}");

            Assert.AreEqual(1500, calculatedBalance);

        }
        [Test]
        private void TestQuestion2()
        {

        }
    }
}
