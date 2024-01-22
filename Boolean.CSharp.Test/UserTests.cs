using Boolean.CSharp.Main;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class UserTests
    {
        [Test]
        public void TestUserCreation()
        {
            User user = new User(0, "Kristian", "Test@email.com", "password");

            Assert.That(user.ID, Is.EqualTo(0));
            Assert.That(user.Name, Is.EqualTo("Kristian"));
            Assert.That(user.Email, Is.EqualTo("Test@email.com"));
            Assert.That(user.Accounts.Count, Is.EqualTo(2));
            Assert.That(user.Account.Balance, Is.EqualTo(0));
            Assert.That(user.SavingsAccount.Balance, Is.EqualTo(0));
        }

        [Test]
        public void TestDeposit()
        {
            User user = new User(0, "Kristian", "Test@email.com", "password");

            user.Deposit(100, AccountType.CurrentAccount);

            Assert.That(user.Account.Balance, Is.EqualTo(100));

        }

        [Test]
        public void TestWithdrawalFail()
        {
            User user = new User(0, "Kristian", "Test@email.com", "password");

            Assert.That(user.Withdraw(100, AccountType.CurrentAccount), Is.False);
        }

        [Test]
        public void TestWithdrawal()
        {
            User user = new User(0, "Kristian", "Test@email.com", "password");

            user.Deposit(100, AccountType.CurrentAccount);
            
            Assert.That(user.Withdraw(50, AccountType.CurrentAccount), Is.True);
            Assert.That(user.Account.Balance, Is.EqualTo(50));

        }

    }
}
