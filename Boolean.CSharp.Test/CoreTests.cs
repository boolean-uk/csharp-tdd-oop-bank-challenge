using Boolean.CSharp.Main;
using NUnit.Framework;
using Boolean.CSharp.Main.extra;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CoreTests
    {
        CurrentAccount current;
        SavingsAccount savings;

        [SetUp]
        public void SetUp()
        {
            current = new CurrentAccount();
            savings = new SavingsAccount();
        }

        [Test]
        public void ShouldDepositCurrent()
        {
            current.Deposit(51d);

            Assert.That(current.Transactions.Count, Is.GreaterThanOrEqualTo(1));
            Assert.That(current.GetBalance(), Is.EqualTo(51d));
        }

        [Test]
        public void ShouldDepositSavings()
        {
            savings.Deposit(32d);

            Assert.That(savings.Transactions.Count, Is.GreaterThanOrEqualTo(1));
            Assert.That(savings.GetBalance(), Is.EqualTo(32d));
        }

        [Test]
        public void ShouldWithdraw()
        {
            current.Deposit(45d);
            bool withdrawal = current.Withdraw(5d);

            Assert.That(current.GetBalance(), Is.EqualTo(40d));
            Assert.That(withdrawal, Is.True);
        }

        [Test]
        public void ShouldNotWithdraw()
        {
            current.Deposit(45d);
            bool withdrawal = current.Withdraw(50d);

            Assert.That(current.GetBalance(), Is.EqualTo(45d));
            Assert.That(withdrawal, Is.False);
        }

        [Test]
        public void TestBankStatement()
        {
            current.Deposit(500);
            current.Deposit(500);
            current.Withdraw(750);
            current.Deposit(1000);

            Assert.That(current.BankStatement().Count, Is.AtLeast(10));
        }

    }
}