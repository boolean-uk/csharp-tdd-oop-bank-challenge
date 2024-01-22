using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Classes;
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
            double amount = 20.0d;
            customer.Deposit(amount, 0);
            //  Act - use the fucntion we want to test

            Math.Round(result = customer.Deposit(deposit, 0),2);
            //  Assert - check the results
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void WithdrawMoney()
        {
            Assert.IsTrue(false);
        }

        [Test]
        public void GenerateBankStatements()
        {
            Assert.IsTrue(false);
        }
    }
}