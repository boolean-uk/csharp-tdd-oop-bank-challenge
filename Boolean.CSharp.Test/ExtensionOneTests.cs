using Boolean.CSharp.Main;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class ExtensionOneTests
    {
        [Test]
        // test if to order for transactions doesnt mather
        public void BalanceIsCorrectlyCalculatedBasedOnTransactionHistory()
        {
            var account = new Account(AllEnums.Branches.Antwerpen);
            account.Deposit(1000, DateTime.Now);
            account.Deposit(500, DateTime.Now.AddDays(1));
            account.Withdraw(200, DateTime.Now.AddDays(2));
            Assert.AreEqual(1300, account.GetBalance());
            // 1000 + 500 - 200 = 1300
        }

        [Test]
        public void IfWeMakeANewAccountItShouldHaveABalanceOfZero()
        {
            var account = new Account(AllEnums.Branches.Antwerpen);
            Assert.AreEqual(0, account.GetBalance());
        }

        [Test]
        public void TheBalanceShouldBeNegativeWhenWeDoOnlyAWidawal()
        { // will change this test after adding overdraft with extension 3
            var account = new Account(AllEnums.Branches.Antwerpen);
            account.Deposit(200, DateTime.Now);
            account.Withdraw(150, DateTime.Now);
            Assert.AreEqual(50, account.GetBalance());
        }
    }
}
