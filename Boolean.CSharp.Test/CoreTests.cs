using Boolean.CSharp.Source;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CoreTests
    {
      
        [Test]
        public void TestDepositMoneyCurrentAccount()
        {
            CurrentAccount account = new CurrentAccount();
            account.DepositMoney(500M);
            decimal balance = account.GetBalance();
            Assert.AreEqual(balance, 500M);
        }
        [Test]
        public void TestWithdrawMoneyCurrentAccount()
        {
            CurrentAccount account = new CurrentAccount();
            account.DepositMoney(1000M);
            account.WithdrawMoney(500M);
            decimal balance = account.GetBalance();
            Assert.AreEqual(balance, 500M);
        }
        [Test]
        public void TestDepositMoneySavingsAccount()
        {
            SavingsAccount savings = new SavingsAccount();
            savings.DepositMoney(1000M);
            decimal balance = savings.GetBalance();
            Assert.AreEqual(balance, 1000M);
        }
      
        [Test]
        public void TestWithdrawMoneySavingsAccount()
        {
            SavingsAccount savings = new SavingsAccount();
            savings.DepositMoney(1000M);
            savings.WithdrawMoney(500M);
            decimal balance = savings.GetBalance();
            Assert.AreEqual(balance, 500M);
        }
        
        [Test]
        public void TestDifferenceAccount()
        {
            SavingsAccount savings = new SavingsAccount();
            CurrentAccount balance = new CurrentAccount();
            savings.DepositMoney(1000M);
            balance.DepositMoney(500M);
            Assert.AreEqual(savings.GetBalance(), 1000M);
            Assert.AreEqual(balance.GetBalance(), 500M);
        }
        
        [Test]
        public void TestBankStatement()
        {
            CurrentAccount account = new CurrentAccount();
            account.DepositMoney(1000M);
            account.WithdrawMoney(500M);
            //Assert.AreEqual(account.BankStatement(), "??" );
        }


    }
}