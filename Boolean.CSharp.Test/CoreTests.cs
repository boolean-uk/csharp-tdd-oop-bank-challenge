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
            User user = new Customer(20000);
            user.AddPhone(new MobilePhone());

            Assert.That((user.CreateAccount(AccountType.Savings) == null));
        }

        [Test]
        public void GetOverdraftTest()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void DepositAndWithdrawlTest()
        {
            User user = new Customer(100);
            user.CreateAccount(AccountType.Savings);

            Account account = user.CreateAccount(AccountType.Savings);


            Assert.That(user.Money == 100);
            Assert.That(account.Deposit(100));
            Assert.That(user.Money == 0);
            Assert.That(account.Deposit(9999) == false);
            Assert.That(account.Withdrawl(50));
            Assert.That(account.Withdrawl(50));
            Assert.That(user.Money == 100 && account.GetBalance() == 100);
        }

        [Test]
        public void GetBalanceTest()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void GetAndSendStatementTest()
        {
            throw new NotImplementedException();
        }
    }
}