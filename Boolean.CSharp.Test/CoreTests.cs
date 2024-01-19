using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Core;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CoreTests
    {

        CurrentAccount current;
        SavingsAccount saving;

        [SetUp]
        public void setup()
        {
            current = new CurrentAccount();
            saving = new SavingsAccount();

        }

        [Test]
        public void createCurrentAccount()
        {
            CurrentAccount current = new CurrentAccount();
            Assert.Pass();
        }

        [Test]
        public void createSavingsAccount() { 
            SavingsAccount savingsAccount = new SavingsAccount();
            Assert.Pass();
        }

        [Test]
        public void DepositSavingsAccount()
        {
            Assert.That(saving.Deposit(15.10d), Is.True);
        }

        [Test]
        public void WithdrawSavingsAccount()
        {
            saving.Deposit(15.10d);
            Assert.That(saving.Withdraw(15.10d), Is.True);
        }

        [Test]
        public void WithdrawOverTotalSavingsAccount()
        {
            Assert.That(saving.Withdraw(15.10d), Is.False);
        }

        [Test]
        public void DepositWithInfo()
        {
            saving.Deposit(15.10d);
            Transaction transaction = saving.transactions[0];
            Assert.That(transaction.Time, Is.EqualTo(DateTime.Now.ToString("dd/mm/yyyy")));
            Assert.That(transaction.Balance, Is.EqualTo(15.10d.ToString("C2")));
            Assert.That(transaction.Amount, Is.EqualTo(15.10d.ToString("C2")));
        }

        [Test]
        public void WithdrawWithInfo()
        {
            saving.Deposit(15.10d);
            saving.Withdraw(15.10d);
            Transaction transaction = saving.transactions[1];
            Assert.That(transaction.Time, Is.EqualTo(DateTime.Now.ToString("dd/mm/yyyy")));
            Assert.That(transaction.Balance, Is.EqualTo(0d.ToString("C2")));
            Assert.That(transaction.Amount, Is.EqualTo((-15.10d).ToString("C2")));
        }



    }
}