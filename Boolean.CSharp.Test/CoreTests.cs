using Boolean.CSharp.Main;
using NUnit.Framework;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;

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
        public void TestWithdrawFunds()
        {
            User user = new User("Øystein", "Bjørkeng");
            SavingsAccount savingsAccount = new SavingsAccount("My savings account", user, 2000.0m);

            savingsAccount.Withdraw(200.0m, "Debit");

            Assert.That(savingsAccount.balance == 1800.0m);
        }

        [Test]
        public void TestDepositFunds()
        {
            User user = new User("Øystein", "Bjørkeng");
            SavingsAccount savingsAccount = new SavingsAccount("My savings account", user, 2000.0m);

            savingsAccount.Deposit(200.0m, "Credit");

            Assert.That(savingsAccount.balance == 2200.0m);
        }

    }
}