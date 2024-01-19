using Boolean.CSharp.Main;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CoreTests
    {
        private BankAccount bankAccount;
        private SavingsAccount savingsAccount;

        [SetUp]
        public void SetUp()
        {
            bankAccount = new BankAccount();
            savingsAccount = new SavingsAccount();

            bankAccount.DepositFunds(10000);
            savingsAccount.DepositFunds(50000);
        }

        [TestCase(10000, true)]
        [TestCase(1000, true)]
        [TestCase(-50, false)]
        public void DepositMoney(float amount, bool expected)
        {
            bool result = bankAccount.DepositFunds(amount);
            Assert.That(expected, Is.EqualTo(result));
        }

        [TestCase(10000, true)]
        [TestCase(1000000, false)]
        [TestCase(-50, false)]
        public void WithdrawMoney(float amount, bool expected)
        {
            bool result = bankAccount.WithdrawFunds(amount);
            Assert.That(expected, Is.EqualTo(result));
        }

        [Test]
        public void PrintTransactions()
        {
            string result = bankAccount.GetTransactions();
            Console.WriteLine(result);
        }
    }
}