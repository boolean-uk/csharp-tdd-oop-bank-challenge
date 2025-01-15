using Boolean.CSharp.Main;
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
            var curr = user.GetCurrentAccount();
            user.Deposit(curr, 500);

            Assert.That(curr.Balance, Is.EqualTo(500));

        }
        [Test]
        public void DepositNegativeFundsToCurrentAccount()
        {
            User user = new User("giar");
            user.CreateCurrentAccount("My Current");
            var acc = user.GetCurrentAccount();
            user.Deposit(acc, -233);

            Assert.That(acc.Balance, Is.EqualTo(0));
        }

        [Test]
        public void WithdrawFundsFromSavingsAccount()
        {
            User user = new User("giar");
            user.CreateSavingsAccount("My Savings");
            var acc = user.GetSavingsAccount();
            user.Deposit(acc, 500);
            user.Withdraw(acc, 300);

            Assert.That(acc.Balance, Is.EqualTo(200));
        }
        [Test]
        public void WithdrawNonExistingFundsFromSavingsAccount()
        {
            User user = new User("giar");
            user.CreateSavingsAccount("My Savings");
            var acc = user.GetSavingsAccount();
            user.Withdraw(acc, 600);

            Assert.That(acc.Balance, Is.EqualTo(0));
        }
    }
}