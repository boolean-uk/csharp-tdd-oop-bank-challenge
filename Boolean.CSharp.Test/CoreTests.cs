using Boolean.CSharp.Main;
using NUnit.Framework;

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

        [TestCase("Ola", "current")]
        [TestCase("Lise", "savings")]
        public void CreateCurrentAccount(string name, string bankType)
        {
            Bank bank = new Bank();

            int result = bank.AddAccount(name, bankType);

            Assert.That(result, Is.EqualTo(0));
        }

        [Test]

        public void DepositFromAccount()
        {
            Bank bank = new Bank();
            string name = "test";
            string bankType = "current";
            double amount = 1000.00;

            int BankID = bank.AddAccount(name, bankType);
            double result = bank.Deposit(BankID, amount);

            Assert.That(result, Is.EqualTo(amount));
        }

        [Test]
        public void WithdrawFromBank()
        {
            Bank bank = new Bank();
            string name = "test";
            string bankType = "current";
            double amountDeposit = 1000;
            double amountWithdraw = 800;
            double expectedResult = 200;

            int bankID = bank.AddAccount(name, bankType);
            bank.Deposit(bankID, amountDeposit);
            double result = bank.Withdraw(bankID, amountWithdraw);

            Assert.That(result, Is.EqualTo(expectedResult));
        }
        

        public void TestGenerateBankStatement()
        {
            Bank bank = new Bank();
            string user = "Bob";

            //Deposit and withdraw

            string result = bank.PrintBankStateMent(user);

            Assert.NotNull(result);
        }
    }
}