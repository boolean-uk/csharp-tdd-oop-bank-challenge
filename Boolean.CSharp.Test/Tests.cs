using Boolean.CSharp.Main;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class Tests
    {
        private UserAccount _userAccount;
        private Bank _bank;
        private Transaction _transaction;

        [SetUp]
        public void Setup()
        {
            _userAccount = new UserAccount();
            _bank = new Bank();
            _userAccount = UserAccount.CreateAccount("John", "Current");
        }

        [TestCase("John", "Current")]
        [TestCase("Jane", "Savings")]
        public void TestCreateAccount(string name, string accountType)
        {
            _userAccount = UserAccount.CreateAccount(name, accountType);
            Assert.AreEqual(_userAccount.Name, name);
            Assert.AreEqual(_userAccount.AccountType, accountType);
        }

        [Test]
        public void TestDeposit()
        {
            _userAccount.Deposit("John", "Current", 200);
            Assert.That(_userAccount.Balance, Is.EqualTo(200));
        }    

        [Test]
        public void TestWithdraw()
        {
            _userAccount.Deposit("John", "Current", 200);
            _userAccount.Withdraw("John", "Current", 100);
            Assert.That(_userAccount.Balance, Is.EqualTo(100));
        }

        [Test]
        public void TestGetAccountByNumber()
        {
            _userAccount.Deposit("John", "Current", 200);
            _userAccount.Withdraw("John", "Current", 100);
            _userAccount = Bank.GetAccountByNumber("ACCT-1");
            Assert.That(_userAccount.Balance, Is.EqualTo(100));
        }


        [TestCase("John", "Current", 200)]
        [TestCase("Jane", "Savings", 100)]
        public void TestTransaction(string name, string accountType, decimal amount)
        {
            _userAccount = UserAccount.CreateAccount(name, accountType);
            _userAccount.Deposit(name, accountType, amount);
            _userAccount.Withdraw(name, accountType, amount);
            _userAccount = Bank.GetAccountByNumber("ACCT-1");
            Bank.GenerateStatement(_userAccount);
        }

    }
}