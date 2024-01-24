using Boolean.CSharp.Main;
using Boolean.CSharp.Main.CoreFiles;
using Boolean.CSharp.Main.Other;
using Boolean.CSharp.Main.Users;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CoreTests
    {
        private Main.Core _core;

        public CoreTests()
        {
            _core = new Main.Core();
        }

        [Test]
        public void CreateAccountWMobileTest()
        {
            Bank bank = new Bank();
            User user = new Customer(20000);
            user.AddPhone(new MobilePhone());
            Account account = user.CreateAccount(bank, AccountType.Savings);

            Assert.That(account != null);


            User user1 = new Customer(20000);
            Account account1 = user.CreateAccount(bank, AccountType.Savings);
            Assert.That(account1.SetPhoneNumber(user.PhoneNumber));
        }

        [Test]
        public void GetOverdraftTest()
        {
            Bank bank = new Bank();
            User user = new Customer(200);
            Manager manager = new Manager(10000);

            Account account = user.CreateAccount(bank, AccountType.Savings);
            Assert.That(account.RequestOverdraft(1000));
            List<Overdraft> overdraftList = manager.GetOverdraftRequests(bank);
            Assert.That(overdraftList.Count() == 1);

            Assert.IsFalse(account.Withdraw(450));
            overdraftList.First().OverdraftState = OverdraftState.Accepted;
            Assert.IsTrue(account.Withdraw(450));
        }

        [Test]
        public void DepositAndWithdrawlTest()
        {
            Bank bank = new Bank();
            User user = new Customer(100);
            Account account = user.CreateAccount(bank, AccountType.Savings);


            Assert.That(user.Money == 100);
            Assert.That(account.Deposit(100));
            Assert.That(user.Money == 0);
            Assert.That(account.Deposit(9999) == false);
            Assert.That(account.Withdraw(50));
            Assert.That(account.Withdraw(50));
            Assert.That(user.Money == 100 && account.GetBalance() == 0);
        }

        [Test]
        public void GetBalanceTest()
        {
            Bank bank = new Bank();
            User user = new Customer(100);
            Account account = user.CreateAccount(bank, AccountType.Savings);


            account.Deposit(100);
        }
    }
}