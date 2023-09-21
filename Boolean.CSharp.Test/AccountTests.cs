using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Enums;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class AccountTests
    {
        // User Story: I want to create a current account
        [Test]
        public void CreateCurrentAccountTest()
        {
            CurrentAccount current = new CurrentAccount(1);

            Assert.AreEqual(8, current.Number.Length);
        }

        // User Story: I want to create a savings account
        [Test]
        public void CreateSavingsAccountTest()
        {
            SavingsAccount savings = new SavingsAccount(1);

            Assert.AreEqual(8, savings.Number.Length);
        }

        // User Story: I want to deposit [...] funds
        [Test]
        public void DepositFundsToCurrentAccountTest()
        {
            decimal amount = 2000.00m;
            CurrentAccount current = new CurrentAccount(1);

            current.Deposit(amount);

            Assert.AreEqual(amount, current.GetBalance());
        }

        // User Story: I want to deposit [...] funds
        [Test]
        public void DepositFundsToSavingsAccountTest()
        {
            decimal amount = 1000.00m;
            SavingsAccount savings = new SavingsAccount(1);

            savings.Deposit(amount);

            Assert.AreEqual(amount, savings.GetBalance());
        }

    }
}