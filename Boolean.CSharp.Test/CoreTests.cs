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
            User user = new User("Øystein", "Bjørkeng", "Karl Johan 1");
            SavingsAccount savingsAccount = new SavingsAccount(user);
            BankTransaction transaction = new BankTransaction(2000.0m, TransactionType.Credit);
            BankTransaction transaction2 = new BankTransaction(200.0m, TransactionType.Debit);

            savingsAccount.Deposit(transaction);
            savingsAccount.Withdraw(transaction2);

            Assert.That(savingsAccount.GetBalance() == 1800.0m);
        }

        [Test]
        public void TestWithdrawFundsError()
        {
            User user = new User("Øystein", "Bjørkeng", "Blåbærveien 9");
            SavingsAccount savingsAccount = new SavingsAccount(user);
            BankTransaction deposit = new BankTransaction(100.0m, TransactionType.Credit);
            BankTransaction transaction = new BankTransaction(2200.0m, TransactionType.Debit);

            savingsAccount.Deposit(deposit);
            savingsAccount.Withdraw(transaction);

            Assert.That(savingsAccount.GetBalance() == 100.0m);
        }

        [Test]
        public void TestDepositFunds()
        {
            User user = new User("Øystein", "Bjørkeng", "Åsaveien 7a");
            SavingsAccount savingsAccount = new SavingsAccount(user);

            BankTransaction transaction = new BankTransaction(200.0m, TransactionType.Credit);

            savingsAccount.Deposit(transaction);

            Assert.That(savingsAccount.GetBalance() == 200.0m);
        }

    }
}