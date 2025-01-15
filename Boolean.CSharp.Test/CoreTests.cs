using System.Security.Principal;
using Boolean.CSharp.Main;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CoreTests
    {
        private Core _core;

        public CoreTests()
        {
            _core = new Core();

        }

        [Test]
        public void CreateCurrentAccountTest()
        {
            var bank = new Bank();
            Assert.IsTrue(bank.CreateCurrentAccount("1234C"));
        }

        [Test]
        public void CreateExistingAccountTest()
        {
            var bank = new Bank();
            bank.CreateCurrentAccount("1234C");
            Assert.IsFalse(bank.CreateCurrentAccount("1234C"));
            Assert.AreEqual(1, bank.accountList.Count);
        }

        [Test]
        public void CreateSavingAccountTest()
        {
            var bank = new Bank();
            Assert.IsTrue(bank.CreateSavingAccount("5678S"));
        }

        [Test]
        public void CreateExistingAccountTest2()
        {
            var bank = new Bank();
            bank.CreateSavingAccount("5678S");
            Assert.IsFalse(bank.CreateSavingAccount("5678S"));
            Assert.AreEqual(1, bank.accountList.Count);
        }

        [Test]
        public void AddFundsTest()
        {
            var account = new CurrentAccount("1234C", 0d);
            Assert.AreEqual(100, account.AddFunds(100));
        }

        [Test]
        public void AddFundsTestWithBalance()
        {
            var account = new CurrentAccount("1234C", 50d);
            Assert.AreEqual(150, account.AddFunds(100));
        }

        [Test]
        public void WithdrawTest()
        {
            Account account = new CurrentAccount("1234C", 100d);
            Assert.AreEqual(0, account.Withdraw(100));
        }

        [Test]
        public void WithdrawNoBalance()
        {
            Account account = new CurrentAccount("1234C", 0d);
            Assert.AreEqual(0, account.Withdraw(100));
        }

        [Test]
        public void WithdrawLowBalance()
        {
            Account account = new CurrentAccount("1234C", 50d);
            Assert.AreEqual(50, account.Withdraw(100));
        }

        [Test]
        public void WithdrawTest2()
        {
            Account account = new CurrentAccount("1234C", 1000d);
            Assert.AreEqual(900, account.Withdraw(100));
        }

        [Test]
        public void TransactionTest()
        {
            Account account = new CurrentAccount("123C", 100);
            account.AddFunds(250);
            account.Withdraw(100);
            account.ViewTransaction();
        }

    }
}