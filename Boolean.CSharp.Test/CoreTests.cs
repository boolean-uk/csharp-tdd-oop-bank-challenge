using Boolean.CSharp.Main;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CoreTests
    {
        [Test]
        public void DoingADepositShouldIncreaseTheBalance()
        {
            var account = new Account();
            account.Deposit(100, DateTime.Now);
            Assert.AreEqual(100, account.Balance);
        }
        [Test]
        public void DoingWithdrawShouldDecreaseTheBalance()
        {
            var account = new Account();
            account.Deposit(200, DateTime.Now);
            account.Withdraw(100, DateTime.Now);
            Assert.AreEqual(100, account.Balance);
        }
    }
}