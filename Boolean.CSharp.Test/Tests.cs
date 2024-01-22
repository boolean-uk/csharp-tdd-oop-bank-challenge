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
            _userAccount = UserAccount.CreateAccount("John", "Current");
        }


        [Test]
        public void TestDeposit()
        {
            _bank.Deposit("John", "Current", 200);
            Assert.That(_userAccount.Balance, Is.EqualTo(200));
        }    

        [Test]
        public void TestWithdraw()
        {
            _bank.Deposit("John", "Current", 200);
            _bank.Withdraw("John", "Current", 100);
            Assert.That(_userAccount.Balance, Is.EqualTo(100));
        }

        [Test]
        public void TestCreateAccount()
        {
            UserAccount newUser = UserAccount.CreateAccount("Najem", "Current");
            Assert.That(newUser.Name, Is.EqualTo("Najem"));
            Assert.That(newUser.AccountType, Is.EqualTo("Current"));
        }

        [Test]
        public void TestWithdrawMoreThanBalance()
        {
            _bank.Deposit("John", "Current", 200);
            _bank.Withdraw("John", "Current", 300);
            Assert.That(_userAccount.Balance, Is.EqualTo(0));
        }

    }
}