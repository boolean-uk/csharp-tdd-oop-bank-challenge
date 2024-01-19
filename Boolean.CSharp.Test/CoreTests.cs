using Boolean.CSharp.Main;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CoreTests
    {
        private BankAccount bankAccount;
        private SavingsAccount savingsAccount;
        private BankManager manager;

        [SetUp]
        public void SetUp()
        {
            bankAccount = new BankAccount("LAX");
            savingsAccount = new SavingsAccount("HRW");
            manager = new BankManager();

            bankAccount.DepositFunds("LAX", 10000, "23/07/2008");
            bankAccount.DepositFunds("LAX", 500, "23/07/2008");
            bankAccount.WithdrawFunds("LAX", 100, "24/07/2008");
            savingsAccount.DepositFunds("HRW", 50000, "29/02/2016");
        }

        [TestCase("LAX", 10000, "23/01/2001", true)]
        [TestCase("LAX", 1000, "", false)]
        [TestCase("LAX", -50, "26/12/2005", false)]
        [TestCase("HTH", 10000, "23/01/2001", false)]
        public void DepositMoney(string code, float amount, string date, bool expected)
        {
            bool result = bankAccount.DepositFunds(code, amount, date);
            Assert.That(expected, Is.EqualTo(result));
        }

        [TestCase(10000, "19/01/2024", true)]
        [TestCase(1000000, "02/02/1999", false)]
        [TestCase(-50, "", false)]
        public void WithdrawMoney(float amount, string date, bool expected)
        {
            bool result = bankAccount.WithdrawFunds("LAX", amount, date);
            Assert.That(expected, Is.EqualTo(result));
        }

        [Test]
        public void PrintTransactions()
        {
            string result = bankAccount.GetTransactions("LAX");
            Console.WriteLine(result);
        }

        [Test]
        public void GetTotalBalance()
        {
            float result = bankAccount.GetTotalBalance("LAX");
            Assert.That(10400, Is.EqualTo(result));
        }

        [TestCase("LAX", 100, "23/01/2001", true)]
        [TestCase("LAX", 10000, "23/01/2001", true)]
        [TestCase("LAX", 1000000, "", false)]
        [TestCase("LAX", 1000000, "23/01/2001", false)]
        [TestCase("LAX", -50, "26/12/2005", false)]
        [TestCase("HTH", 10000, "23/01/2001", false)]
        public void RequestOverdraftFromManager(string code, float amount, string date, bool expected)
        {
            bool result = manager.RequestOverdraft(bankAccount, code, amount, date);
            Assert.That(expected, Is.EqualTo(result));
        }
    }
}