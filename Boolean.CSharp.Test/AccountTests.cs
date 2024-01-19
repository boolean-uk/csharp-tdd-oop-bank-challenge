using Boolean.CSharp.Main;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class AccountTests
    {
        private Bank _bank;
        private Customer _customer;
        private Account _account;

        [SetUp]
        public void SetUp()
        {
            _bank = new Bank();
            _customer = new Customer();
            _account = _bank.CreateAccount(_customer, AccountTypes.Current)!;
        }

        [Test]
        public void TestAccountBelongsToUser()
        {
            //execute
            Customer owner = _account.GetAccountOwner();

            //verify
            Assert.That(owner, Is.Not.Null);
            Assert.That(owner, Is.EqualTo(_customer));
        }

        [Test]
        public void TestAccountBalanceIsZeroByDefault()
        {
            //execute
            double balance = _account.GetBalance();

            //verify
            Assert.That(balance, Is.Not.Null);
            Assert.That(balance, Is.EqualTo(0));
        }

        [Test]
        public void TestAccountBalanceIncreasesWhenDeposit()
        {
            //execute
            bool shouldNotDeposit = _account.Deposit(-3.39);
            bool didDeposit = _account.Deposit(39.39);
            double balance = _account.GetBalance();

            //verify
            Assert.That(shouldNotDeposit, Is.False);
            Assert.That(didDeposit, Is.True);
            Assert.That(balance, Is.Not.Null);
            Assert.That(balance, Is.EqualTo(39.39));
        }

        [Test]
        public void TestAccountBalanceDecreasesWhenWithdrawing()
        {
            //execute
            bool shouldNotWithdraw = _account.Withdraw(39);
            _account.Deposit(1039.14); //Set some value
            bool shouldWithdraw = _account.Withdraw(39);
            double balance = _account.GetBalance();


            //verify
            Assert.That(shouldNotWithdraw, Is.False);
            Assert.That(shouldWithdraw, Is.True);
            Assert.That(balance, Is.Not.Null);
            Assert.That(balance, Is.EqualTo(1000.14));
        }
    }
}
