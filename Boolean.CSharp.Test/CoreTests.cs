using Boolean.CSharp.Main;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CoreTests
    {
        private Customer _customer;

        public CoreTests()
        {
            _customer = new Customer();
        }

        [Test]
        public void addAccountTest()
        {
            SavingsAccount newSavings = (SavingsAccount)_customer.createAccount(762308, accountType.savings);
            CurrentAccount newCurrent = (CurrentAccount)_customer.createAccount(556223, accountType.current);
            Assert.That(_customer.Accounts.Contains(newSavings));
            Assert.That(_customer.Accounts.Contains(newCurrent));
        }

    }
}