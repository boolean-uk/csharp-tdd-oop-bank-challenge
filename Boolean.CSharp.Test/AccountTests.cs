using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Accounts;
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
            _customer = new Customer("M");
            _account = _bank.CreateAccount(_customer, AccountTypes.Current, AccountBranches.Bergen)!;
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
            decimal balance = _account.GetBalance();

            //verify
            Assert.That(balance, Is.Not.Null);
            Assert.That(balance, Is.EqualTo(0));
        }

        [Test]
        public void TestAccountBalanceIncreasesWhenDeposit()
        {
            //execute
            bool shouldNotDeposit = _account.Deposit(-3.39m);
            bool didDeposit = _account.Deposit(39.39m);
            decimal balance = _account.GetBalance();

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
            _account.Deposit(1039.14m); //Set some value
            bool shouldWithdraw = _account.Withdraw(39);
            decimal balance = _account.GetBalance();


            //verify
            Assert.That(shouldNotWithdraw, Is.False);
            Assert.That(shouldWithdraw, Is.True);
            Assert.That(balance, Is.Not.Null);
            Assert.That(balance, Is.EqualTo(1000.14m));
        }

        [Test]
        public void TestGenerateBankStatement()
        {
            //setup
            DateTime before = DateTime.Now;
            _account.Deposit(14.44m);
            _account.Withdraw(4.39m);

            //execute
            List<Transaction> statement = _account.GenerateBankStatement();
            //For testing purposes also print a visual bank statement:
            _account.PrintBankStatement();

            //verify
            Assert.That(statement, Is.Not.Null);
            Assert.That(statement[0].GetDate(), Is.GreaterThan(before));
            Assert.That(statement[0].GetDate(), Is.LessThan(DateTime.Now));
            Assert.That(statement[0].GetCredit(), Is.EqualTo(14.44m));
            Assert.That(statement[0].GetDebit(), Is.EqualTo(0m));
            Assert.That(statement[0].GetBalance(), Is.EqualTo(14.44m));
            Assert.That(statement[1].GetDebit(), Is.EqualTo(4.39m));
            Assert.That(statement[1].GetCredit(), Is.EqualTo(0m));
            Assert.That(statement[1].GetBalance(), Is.EqualTo(14.44m - 4.39m));
        }

        [Test]
        public void TestAccountIsAssociatedWithBranch()
        {

            //execute
            AccountBranches b = _account.GetBranch();

            //assert
            Assert.That(b, Is.EqualTo(AccountBranches.Bergen));
        }

        [Test]
        public void TestRequestOverdraft()
        {
            //execute
            bool withdrew = _account.Withdraw(14.39m); //Withdraw more than we can
            List<Overdraft> overdrafts = _account.GetOverdraftRequests();

            //verify
            Assert.That(withdrew, Is.False);
            Assert.That(overdrafts, Is.Not.Null);
            Assert.That(overdrafts.Count, Is.EqualTo(1));
        }
    }
}
