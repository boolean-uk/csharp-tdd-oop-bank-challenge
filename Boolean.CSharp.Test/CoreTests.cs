using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Accounts;
using Boolean.CSharp.Main.enums;
using Boolean.CSharp.Main.Users;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CoreTests
    {
        DateTime dob = new DateTime(1996, 8, 20);

        [Test]
        public void TestCreateGeneralAccount()
        {
            // Arrange
            IUser user1 = new RegularCustomer("Bob", dob);
            IUser user2 = new Manager("Jim");

            // Act
            bool? res1 = (user1 as RegularCustomer)?.OpenNewAccount(AccountType.General);
            bool? res2 = (user2 as RegularCustomer)?.OpenNewAccount(AccountType.General);

            // Assert
            Assert.That(res1, Is.True);
            Assert.That(user1.GetAccounts().Count, Is.EqualTo(1));
            Assert.That(user1.GetAccounts()[0].GetType(), Is.EqualTo(typeof(GeneralAccount)));

            Assert.That(res2, Is.Null);
        }

        [Test]
        public void TestCreateSavingsAccount()
        {
            // Arrange
            IUser user1 = new RegularCustomer("Bob", dob);
            IUser user2 = new Manager("Jim");

            // Act
            bool? res1 = (user1 as Customer)?.OpenNewAccount(AccountType.Savings); // Implemented Customer
            bool? res2 = (user2 as Customer)?.OpenNewAccount(AccountType.Savings); // Does not implement Customer

            // Assert
            Assert.That(res1, Is.True);
            Assert.That(user1.GetAccounts().Count, Is.EqualTo(1));
            Assert.That(user1.GetAccounts()[0].GetType(), Is.EqualTo(typeof(SavingsAccount)));

            Assert.That(res2, Is.Null);
        }

        [Test]
        public void TestDepositFunds()
        {
            // Arrange
            Customer user = new RegularCustomer("Bob", dob);
            user.OpenNewAccount(AccountType.General);
            IAccount account = user.GetAccounts()[0];

            // Act
            decimal preBalance = account.GetBalance();
            bool res = account.Deposit(500m);
            decimal postBalance = account.GetBalance();

            // Assert
            Assert.That(res, Is.True);
            Assert.That(preBalance, Is.EqualTo(0m));
            Assert.That(postBalance, Is.EqualTo(500m));

        }

        [Test]
        public void TestWithdrawFunds()
        {
            // Arrange
            Customer user = new RegularCustomer("Bob", dob);
            user.OpenNewAccount(AccountType.General);
            IAccount account = user.GetAccounts()[0];
            account.Deposit(5000m);

            // Act
            decimal preBalance = account.GetBalance();
            decimal withdrawnAmount = account.Withdraw(1337m);
            decimal postBalance = account.GetBalance();

            // Assert
            Assert.That(withdrawnAmount, Is.EqualTo(1337m));
            Assert.That(preBalance, Is.EqualTo(5000m));
            Assert.That(postBalance, Is.EqualTo(5000m - 1337m));
        }

        [Test]
        public void TestAcceptanceCriteria() 
        {
            Customer user = new RegularCustomer("Bob", dob);
            user.OpenNewAccount(AccountType.General);
            IAccount account = user.GetAccounts()[0];
            DateTime now = DateTime.Now;
            DateTime tomorrow = DateTime.Now.AddDays(1);

            // TODO: Look into mocking the DateTime that will be generated
            account.Deposit(1000m);  // 2012-01-10
            account.Deposit(2000m);  // 2012-01-13
            account.Withdraw(500m);  // 2012-01-14

            account.PrintBankStatement(now, tomorrow);
        }
    }
}