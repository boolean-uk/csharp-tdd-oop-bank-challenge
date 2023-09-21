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
    }
}