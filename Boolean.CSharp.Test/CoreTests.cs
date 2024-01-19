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



    }
}