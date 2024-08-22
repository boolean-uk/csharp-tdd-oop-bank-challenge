using Boolean.CSharp.Main;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CoreTests
    {


        public CoreTests()
        {


        }

        [Test]
        public void CreateAccount()
        {
            Customer customer = new Customer();
            customer.CreateAccount(AccountType.Current);
            customer.CreateAccount(AccountType.Current);

            Assert.AreEqual(customer.accounts[0].Type, AccountType.Current);
            Assert.AreEqual(customer.accounts[1].Balance, 0m);
            Assert.IsTrue(customer.accounts.Count() == 2);
        }

    }
}