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

        [Test]
        public void createCurrentAccount()
        {
            User user = new User();
            user.CreateCurrentAccount();
            
            Assert.IsNotNull(user.CurrentAccount);
            Assert.That(user.CurrentAccount.Type == "current");
        }

        [Test]
        public void createSavingAccount()
        {
            User user = new User();
            user.CreateSavingAccount();

            Assert.IsNotNull(user.SavingAccount);
            Assert.That(user.SavingAccount.Type == "saving");
        }

        [TestCase(1000,659.72)]
        [TestCase(100, 9.52)]
        [TestCase(10, 6)]
        public void generateBankstatement(decimal deposit, decimal withdraw)
        {
            User user = new User();
            user.CreateCurrentAccount();
            user.CurrentAccount.Deposit(deposit);
            user.CurrentAccount.Withdraw(withdraw);
            List<string> Result = user.CurrentAccount.GenerateBankstatement();
            decimal sum = deposit - withdraw;

            Assert.IsNotNull(user.SavingAccount);
            Assert.That(Result.Count >0);
            Assert.That(user.CurrentAccount.Balance == sum);
        }

    }
}