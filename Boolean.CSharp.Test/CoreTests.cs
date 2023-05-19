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
        public void TestDepositMoneyCurrentAccount()
        {
            CurrentAccount account = new CurrentAccount();
            decimal balance = account.DepositMoney(500M);
            Assert.AreEqual(balance, account.balance);
        }
        [Test]
        public void TestWithdrawMoneyCurrentAccount()
        {
            CurrentAccount account = new CurrentAccount();
            decimal balance = account.DepositMoney(1000M);
            balance = account.WithdrawMoney(500M);
            Assert.AreEqual(balance, account.balance);
        }
        [Test]
        public void TestDepositMoneySavingsAccount()
        {
            SavingsAccount savings = new SavingsAccount();
            decimal balance = savings.DepositMoney(1000M);
            Assert.AreEqual(balance, savings.balance);
        }

        [Test]
        public void TestWithdrawMoneySavingsAccount()
        {
            SavingsAccount savings = new SavingsAccount();
            decimal balance = savings.DepositMoney(1000M);
            balance = savings.WithdrawMoney(500M);
            Assert.AreEqual(balance, savings.balance);
        }

        [Test]
        public void TestDifferenceAccount()
        {
            SavingsAccount savings = new SavingsAccount();
            CurrentAccount balance = new CurrentAccount();
            savings.DepositMoney(1000M);
            balance.DepositMoney(500M);
            Assert.AreEqual(savings.balance, 1000M);
            Assert.AreEqual(balance.balance, 500M);

        }

    }
}