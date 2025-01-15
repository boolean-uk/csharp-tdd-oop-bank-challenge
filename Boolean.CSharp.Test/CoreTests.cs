using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Abstract;
using Boolean.CSharp.Main.Classes;
using Boolean.CSharp.Main.Interface;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CoreTests
    {

        [Test]
        public void UserCreateAccounts()
        {
            User user = new User("giar");
            Assert.IsNotNull(user);

            string result1 = user.CreateCurrentAccount("My Current");
            string result2 = user.CreateSavingsAccount("My Saving");

            Assert.That(result1, Is.EqualTo("Successfully created account"));
            Assert.That(result2, Is.EqualTo("Successfully created account"));
            Assert.That(user.Accounts.Count, Is.EqualTo(2));
        }

        [Test]
        public void UserCreateMoreAccounts()
        {
            User user = new User("giar");
            Assert.IsNotNull(user);

            string result1 = user.CreateCurrentAccount("My Current");
            string result2 = user.CreateCurrentAccount("This should not be added");
            string result3 = user.CreateSavingsAccount("My Savings");
            string result4 = user.CreateSavingsAccount("This should not be added 2");

            Assert.That(result2, Is.EqualTo("Account already exists"));
            Assert.That(result4, Is.EqualTo("Account already exists"));
            Assert.That(user.Accounts.Count, Is.EqualTo(2));
        }

        [Test]
        public void DepositFundsToCurrentAccount()
        {
            User user = new User("giar");
            user.CreateCurrentAccount("My Current");
            var acc = user.GetCurrentAccount();
            acc.Deposit(500);

            Assert.That(acc.Balance, Is.EqualTo(500));

        }
        [Test]
        public void DepositNegativeFundsToCurrentAccount()
        {
            User user = new User("giar");
            user.CreateCurrentAccount("My Current");
            var acc = user.GetCurrentAccount();
            acc.Deposit(-233);

            Assert.That(acc.Balance, Is.EqualTo(0));
        }

        [Test]
        public void WithdrawFundsFromSavingsAccount()
        {
            User user = new User("giar");
            user.CreateSavingsAccount("My Savings");
            var acc = user.GetSavingsAccount();

            acc.Deposit(500);
            acc.Withdraw(300);

            Assert.That(acc.Balance, Is.EqualTo(200));
        }
        [Test]
        public void WithdrawNonExistingFundsFromSavingsAccount()
        {
            User user = new User("giar");
            user.CreateSavingsAccount("My Savings");
            var acc = user.GetSavingsAccount();
            acc.Withdraw(600);

            Assert.That(acc.Balance, Is.EqualTo(0));
        }
        [Test]
        public void GenerateTransactionLog()
        {
            User user = new User("giar");
            user.CreateSavingsAccount("My Savings");
            var acc = user.GetSavingsAccount();

            acc.Deposit(400);
            acc.Deposit(300);
            acc.Withdraw(100);
            acc.Withdraw(50);
            // 700 - 150 = 550

            string report = acc.GenerateReport();

            Assert.That(report, Is.Not.Empty);
        }

        // EXTENSIONS:

        // Overdraft
        [Test]
        public void SetOverdraftTrue()
        {
            User user = new User("giar");
            user.CreateCurrentAccount("My Savings");
            CurrentAccount? acc = user.GetCurrentAccount();

            acc.Deposit(400);
            acc.Deposit(300);
            acc.Withdraw(100);
            acc.Withdraw(50);
            // 700 - 150 = 550
            acc.SetOverdraft(true);

            acc.Withdraw(750);
            // 550 - 750 = -200

            Assert.That(acc.Balance, Is.EqualTo(-200));
        }

        [Test]
        public void BankWithSpecificBranches()
        {

            Bank bank = new Bank("Sparebank 1");
            BankBranch branch = bank.CreateBranch("Oslo");

            User user = new User("giar");
            user.CreateCurrentAccount("My Current");
            CurrentAccount? acc = user.GetCurrentAccount();
            branch.AddUser(user);

            acc.Deposit(400);
            acc.Deposit(300);
            acc.Withdraw(100);
            acc.Withdraw(50);
            // 700 - 150 = 550
            acc.SetOverdraft(true);

            acc.Withdraw(750);
            // 550 - 750 = -200

            Assert.That(acc.Balance, Is.EqualTo(-200));
        }
        [Test]
        public void ApproveOrRejectOverdraftRequests()
        {

            Bank bank = new Bank("Sparebank 1");
            BankBranch branch = bank.CreateBranch("Oslo");

            User user = new User("giar");
            user.CreateCurrentAccount("My Current");
            CurrentAccount? acc = user.GetCurrentAccount();
            branch.AddUser(user);

            user.RequestOverdraft(acc);
            Assert.That(branch.currAccounts.Count, Is.EqualTo(1));

            branch.AnswerOverdraftRequest(acc, true);

            Assert.That(branch.currAccounts.Count, Is.EqualTo(0));
            Assert.True(acc.overdraft);





            acc.Deposit(400);
            acc.Deposit(300);
            acc.Withdraw(100);
            acc.Withdraw(50);
            // 700 - 150 = 550
            acc.Withdraw(750);
            // 550 - 750 = -200

            Assert.That(acc.Balance, Is.EqualTo(-200));
        }
    }
}