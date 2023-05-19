using Boolean.CSharp.Main;
using Boolean.CSharp.Source;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CoreTests
    {
        private BankApp _bankapp;

        public CoreTests()
        {
            _bankapp = new BankApp();

        }

        [Test]
        public void TestQuestion1()
        {
            CurrentAccount account = new CurrentAccount();
            decimal balance = account.DepositMoney(500M);
            Assert.AreEqual(balance, account.balance);
        }

    }
}