using Boolean.CSharp.Main;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class Tests
    {
        private UserAccount _userAccount;
        private Bank _bank;

        [SetUp]
        public void Setup()
        {
            _bank = new Bank();
            _userAccount = UserAccount.CreateAccount("John", "Current","London");
        }


        [Test]
        public void TestDeposit()
        {
            _bank.Deposit("John", "Current", "London", 200);
            Assert.That(_bank.GetBalance("John", "Current", "London"), Is.EqualTo(200));
        }    

        [Test]
        public void TestWithdraw()
        {
            _bank.Deposit("John", "Current", "London", 200);
            _bank.Withdraw("John", "Current", "London", 100);
            Assert.That(_bank.GetBalance("John", "Current", "London"), Is.EqualTo(100));
        }

        [Test]
        public void TestWithdrawMoreThanBalance()
        {
            _bank.Deposit("John", "Current", "London", 200);
            _bank.Withdraw("John", "Current", "London", 300);
            Assert.That(_bank.GetBalance("John", "Current", "London"), Is.EqualTo(-100));
        }

    }
}