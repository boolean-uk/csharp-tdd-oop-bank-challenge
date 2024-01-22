using Boolean.CSharp.Main;
using NUnit.Framework;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Transactions;

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
            Main.Transaction transaction = new Main.Transaction(200.0m, "Debit");

            savingsAccount.Withdraw(transaction);

            Assert.That(savingsAccount.Balance == 1800.0m);
        }

        [Test]
        public void TestDepositFunds()
        {
            User user = new User("Øystein", "Bjørkeng");
            SavingsAccount savingsAccount = new SavingsAccount("My savings account", user, 2000.0m);

            Main.Transaction transaction = new Main.Transaction(200.0m, "Credit");

            savingsAccount.Deposit(transaction);

            Assert.That(savingsAccount.Balance == 2200.0m);
        }

    }
}