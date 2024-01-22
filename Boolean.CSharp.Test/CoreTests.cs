using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Classes.Accounts;
using Boolean.CSharp.Main.Classes.User;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CoreTests
    {
        private CustomerUser customer;

        [SetUp]
        public void SetUp()
        {
            customer = new CustomerUser();
        }

        [Test]
        public void CreatingACurrentAccount()
        {

            //  Arrange - set up test values
            string test;
            CurrentAccount testAccount = new CurrentAccount();

            //  Act - use the fucntion we want to test
            test = customer.CreateAccount(testAccount);

            //  Assert - check the results
            Assert.That(test, Is.EqualTo("New Account has been made"));
        }

        [Test]
        public void CreatingASavingsAccount()
        {
            //  Arrange - set up test values
            string test;
            SavingsAccount testAccount = new SavingsAccount();

            //  Act - use the fucntion we want to test
            test = customer.CreateAccount(testAccount);

            //  Assert - check the results
            Assert.That(test, Is.EqualTo("New Account has been made"));
        }

        [Test]
        [TestCase(1d,21d)]
        [TestCase(30d,50d)]
        [TestCase(80d,100d)]
        [TestCase(20d,40d)]
        public void DepositMoney(double deposit, double expected)
        {
            //  Arrange - set up test values
            double result;
            CurrentAccount testAccount = new CurrentAccount();
            customer.CreateAccount(testAccount);
            customer.Deposit(20.0d, 0);
            //  Act - use the fucntion we want to test

            Math.Round(result = customer.Deposit(deposit, 0),2);
            //  Assert - check the results
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(1000d, true)]
        [TestCase(3000d, false)]
        [TestCase(800d, true)]
        [TestCase(20000d, false)]
        public void WithdrawMoney(double withdrawl, bool expected)
        {
            //  Arrange - set up test values
            bool result;
            CurrentAccount testAccount = new CurrentAccount();
            customer.CreateAccount(testAccount);
            customer.Deposit(2500.0d, 0);
            //  Act - use the fucntion we want to test

            result = customer.Withdraw(withdrawl, 0);
            //  Assert - check the results
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void GenerateBankStatements()
        {
            Assert.IsTrue(false);
        }
    }
}