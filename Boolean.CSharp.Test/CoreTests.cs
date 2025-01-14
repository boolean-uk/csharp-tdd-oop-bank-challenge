using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Abstract;
using Boolean.CSharp.Main.Class;
using Boolean.CSharp.Main.Enums;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CoreTests
    {

        private Account _currentAccount;
        private Account _savingAccount;

      
        [SetUp]
        public void SetUp() 
        {
            _currentAccount = new CurrentAccount(Role.Customer);
            _savingAccount = new SavingAccount(Role.Customer);

            _currentAccount.Deposit(1000);
            _savingAccount.Deposit(5000);


        }

        [Test]
        public void TestCreateCurrentAccount()
        {
           Assert.That(_currentAccount, Is.Not.Null);
        }

        [Test]
        public void TestCreateSavingAccount()
        {
            Assert.That(_savingAccount, Is.Not.Null);
        }

        [Test]
        public void TestBankStatement()
        {

        }

        [Test]
        public void TestDepositAndWithdrawal()
        {

        }

    }
}