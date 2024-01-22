using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Concretes;
using Boolean.CSharp.Main.Interfaces;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CoreTests
    {
        private Core _core;

        public CoreTests()
        {
            _core = new Core();

        }

        [Test]
        public void AddAccountTest()
        {
            ICustomer customer = new Customer();
            customer.AddSavingsAccount();
            customer.AddCurrentAccount();

            List<IAccount> accounts = customer.GetAccounts();

            Assert.That(accounts.Count,Is.EqualTo(2));
        }

    }
}