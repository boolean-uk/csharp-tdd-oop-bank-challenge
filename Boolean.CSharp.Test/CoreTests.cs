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

            bankAccount.DepositFunds(10000, "23/07/2008");
            bankAccount.DepositFunds(500, "23/07/2008");
            bankAccount.WithdrawFunds(100, "24/07/2008");
            savingsAccount.DepositFunds(50000, "29/02/2016");
        }

        [TestCase(10000, "23/01/2001", true)]
        [TestCase(1000, "", false)]
        [TestCase(-50, "26/12/2005", false)]
        public void DepositMoney(float amount, string date, bool expected)
        {
            bool result = bankAccount.DepositFunds(amount, date);
            Assert.That(expected, Is.EqualTo(result));
        }

        [TestCase(10000, "19/01/2024", true)]
        [TestCase(1000000, "02/02/1999", false)]
        [TestCase(-50, "", false)]
        public void WithdrawMoney(float amount, string date, bool expected)
        {
            bool result = bankAccount.WithdrawFunds(amount, date);
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