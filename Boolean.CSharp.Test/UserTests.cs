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
            User user = new User(0, "Kristian", BankLocation.Stavanger);

            Assert.That(user.Id, Is.EqualTo(0));
            Assert.That(user.Name, Is.EqualTo("Kristian"));
            Assert.That(user.Account.GetBalance(), Is.EqualTo(0));
            Assert.That(user.SavingsAccount.GetBalance(), Is.EqualTo(0));
        }

        [Test]
        public void TestDeposit()
        {
            User user = new User(0, "Kristian", BankLocation.Stavanger);

            user.Deposit(100, user.Account);

            Assert.That(user.Account.GetBalance(), Is.EqualTo(100));

        }

        [Test]
        public void TestWithdrawalFail()
        {
            User user = new User(0, "Kristian", BankLocation.Stavanger);

            Assert.That(user.Withdraw(100, user.Account), Is.False);
        }

        [Test]
        public void TestWithdrawal()
        {
            User user = new User(0, "Kristian", BankLocation.Stavanger);

            user.Deposit(100, user.Account);

            Assert.That(user.Withdraw(50, user.Account), Is.True);
            Assert.That(user.Account.GetBalance(), Is.EqualTo(50));

        }

    }
}
