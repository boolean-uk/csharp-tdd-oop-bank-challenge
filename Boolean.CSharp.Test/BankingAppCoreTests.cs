using BamkingApp.Boolean.CSharp.Main;
using BankingApp.Boolean.CSharp.Main.Accounts;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class BankingAppCoreTests
    {
        private Core _core;

        public BankingAppCoreTests()
        {
            _core = new Core();

        }

        [Test]
        public void CreateCurrentAccountTest()
        {
            var account = new CurrentAccount();


            // Assert.IsNotNull(account);
            // Assert.AreEqual(0, account.Balance);
            Assert.IsNull(account.Transactions);

        }

        [Test]
        public void CreateSvingsAccountTest()
        {
            var account = new SavingAccount();

            // Assert.IsNotNull(account);
            // Assert.AreEqual(0, account.Balance);
            Assert.IsNull(account.Transactions);
        }

    }
}