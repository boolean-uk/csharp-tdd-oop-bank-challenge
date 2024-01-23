using Boolean.CSharp.Main;
using Boolean.CSharp.Main.AccountTypes;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CoreTests
    {
        private HeadQuarters bank;
        private Private user;

        public CoreTests()
        {
            bank = new HeadQuarters();
            int id = bank.GenerateUserId();
            user = new Private(id);

        }

        [Test]
        public void createCurrentAccount()
        {
            user.CreateCurrentAccount();
            
            Assert.IsNotNull(user.CurrentAccount);
            Assert.That(user.CurrentAccount.Type == "current");
        }

        [Test]
        public void createSavingAccount()
        {
            user.CreateSavingAccount();

            Assert.IsNotNull(user.SavingAccount);
            Assert.That(user.SavingAccount.Type == "saving");
        }

        [TestCase(659.72)]
        [TestCase(10)]
        public void depositAmount(decimal deposit)
        {
            user.CreateCurrentAccount();
            user.CurrentAccount.Deposit(deposit);
            
            Assert.That(user.CurrentAccount.Balance == deposit);
        }

        [TestCase(1000, 659.72)]
        [TestCase(100, 9.52)]
        [TestCase(10, 6)]
        public void WithdrawAmount(decimal deposit, decimal withdraw)
        {
            user.CreateCurrentAccount();
            user.CurrentAccount.Deposit(deposit);
            user.CurrentAccount.Withdraw(withdraw);
            
            decimal sum = deposit - withdraw;

            Assert.That(user.CurrentAccount.Balance == sum);
        }

        [TestCase( 659.72)]
        [TestCase( 9.52)]
        [TestCase(10 )]
        public void GenerateSingleBankTransaction(decimal deposit)
        {
            user.CreateCurrentAccount();
            user.CurrentAccount.Deposit(deposit);
            string[] Result = user.CurrentAccount.BankTransactions[0];
           
            

            Assert.IsNotNull(user.CurrentAccount);
            Assert.That(Result.Length > 0);
            Assert.That(Result.Contains(deposit.ToString()));
           
        }

        [TestCase(1000,659.72)]
        [TestCase(100, 9.52)]
        [TestCase(10, 6)]
        public void generateBankstatement(decimal deposit, decimal withdraw)
        {
            user.CreateCurrentAccount();
            user.CurrentAccount.Deposit(deposit);
            user.CurrentAccount.Withdraw(withdraw);
            bool Result = user.CurrentAccount.GenerateBankStatement();
            decimal sum = deposit - withdraw;

            Assert.IsNotNull(user.CurrentAccount);
            Assert.That(Result == true);
            Assert.That(user.CurrentAccount.Balance == sum);
        }

    }
}