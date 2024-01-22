using Boolean.CSharp.Main;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CoreTests
    {
        [Test]
        public void DepositTest()
        {
            var userAccount = new BankAccount("1");
            userAccount.Deposit(1000);
            Assert.AreEqual(1000, userAccount.Balance);
        }

        [Test]
        public void withdraw()
        {
            var userAccount = new BankAccount("1");
            userAccount.Deposit(3000);
            userAccount.Withdraw(1000);
            Assert.AreEqual(2000, userAccount.Balance);
        }

        [Test]
        public void InvalidWithdraw()
        {
            var userAccount = new BankAccount("1");
            userAccount.Deposit(1000);
            userAccount.Withdraw(2000);
            Assert.AreEqual(1000, userAccount.Balance);
        }
    }
}