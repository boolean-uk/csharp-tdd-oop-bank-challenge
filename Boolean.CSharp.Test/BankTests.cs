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
    public class BankTests
    {
        [Test]
        public void TestBankCreation()
        {
            Bank bank = new Bank(BankLocation.Stavanger);

            Assert.That(bank.Location, Is.EqualTo(BankLocation.Stavanger));
            Assert.That(bank.Users.Count, Is.EqualTo(0));
        }

        [Test]
        public void TestAddUser()
        {
            Bank bank = new Bank(BankLocation.Stavanger);
            User user = new User(0, "Kristian", "Test@email.com", "password");

            bank.AddUser(user);

            Assert.That(bank.Users.Count, Is.EqualTo(1));
            Assert.That(bank.Users.Contains(user), Is.True);
        }

        [Test]
        public void TestRemoveUserFail()
        {
            Bank bank = new Bank(BankLocation.Stavanger);
            User user = new User(0, "Kristian", "Test@email.com", "password");

            Assert.That(bank.RemoveUser(user), Is.False);
            Assert.That(bank.Users.Count, Is.EqualTo(0));
        }

        [Test]
        public void TestRemoveUser()
        {
            Bank bank = new Bank(BankLocation.Stavanger);
            User user = new User(0, "Kristian", "Test@email.com", "password");

            bank.RemoveUser(user);

            Assert.That(bank.RemoveUser(user), Is.True);
            Assert.That(bank.Users.Count, Is.EqualTo(0));
        }

        [Test]
        public void TestRemoveUserID()
        {
            Bank bank = new Bank(BankLocation.Stavanger);
            User user = new User(0, "Kristian", "Test@email.com", "password");

            bank.AddUser(user);

            Assert.That(bank.RemoveUser(user.ID), Is.True);
        }
    }
}
