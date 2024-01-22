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
        public void GenerateBankStatements()
        {
            Assert.IsTrue(false);
        }

        [Test]
        public void DepositMoney()
        {
            Assert.IsTrue(false);
        }

        [Test]
        public void WithdrawMoney()
        {
            Assert.IsTrue(false);
        }

    }
}