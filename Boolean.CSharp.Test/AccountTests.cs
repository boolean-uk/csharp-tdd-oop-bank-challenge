using Boolean.CSharp.Main;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class AccountTests
    {
        Account account;

        [SetUp]
        public void SetUp()
        {
            account = new("test");
        }

        [Test]
        public void GetBalance()
        {
            Assert.That(account.Balance, Is.EqualTo(0));
        }

        [Test]
        public void Deposit()
        {
            Assert.That(account.Deposit(500), Is.EqualTo("500 deposited to test, new balance is 500"));
        }

        [Test]
        public void Withdraw()
        {
            account.Deposit(1000);
            Assert.That(account.Withdraw(250), Is.EqualTo("250 withdrawn from test, new balance is 750"));
        }

        [Test]
        public void CantWithdrawLackingFunds()
        {
            account.Deposit(500);
            Assert.That(account.Withdraw(750), Is.EqualTo("Cannot withdraw from test, balance is less than withdrawal amount"));
        }


    }
}
