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
            // Manager manager = new Manager("Kristian");
            Bank bank = new Bank(BankLocation.Stavanger);

            Assert.That(bank.Location, Is.EqualTo(BankLocation.Stavanger));
            Assert.That(bank.Users.Count, Is.EqualTo(0));
        }

        [Test]
        public void TestAddUser()
        {
            // Manager manager = new Manager("Kristian");
            Bank bank = new Bank(BankLocation.Stavanger);
            User user = new User(0, "Kristian", BankLocation.Stavanger);

            bank.AddUser(user);

            Assert.That(bank.Users.Count, Is.EqualTo(1));
            Assert.That(bank.Users.Contains(user), Is.True);
        }

        [Test]
        public void TestRemoveUserFail()
        {
            // Manager manager = new Manager("Kristian");
            Bank bank = new Bank(BankLocation.Stavanger);
            User user = new User(0, "Kristian", BankLocation.Stavanger);

            Assert.That(bank.RemoveUser(user), Is.False);
            Assert.That(bank.Users.Count, Is.EqualTo(0));
        }

        [Test]
        public void TestRemoveUser()
        {
            // Manager manager = new Manager("Kristian");
            Bank bank = new Bank(BankLocation.Stavanger);
            User user = new User(0, "Kristian", BankLocation.Stavanger);

            bank.AddUser(user);

            Assert.That(bank.RemoveUser(user), Is.True);
            Assert.That(bank.Users.Count, Is.EqualTo(0));
        }

        [Test]
        public void TestRemoveUserID()
        {
            // Manager manager = new Manager("Kristian");
            Bank bank = new Bank(BankLocation.Stavanger);
            User user = new User(0, "Kristian", BankLocation.Stavanger);

            bank.AddUser(user);

            Assert.That(bank.RemoveUser(user.Id), Is.True);
        }

        [Test]
        public void TestGetUserById()
        {
            Bank bank = new Bank(BankLocation.Stavanger);
            User user = new User(0, "Kristian", BankLocation.Stavanger);

            bank.AddUser(user);

            User test = bank.GetUserById(0);

            Assert.That(test, Is.EqualTo(user));
        }

        [Test]
        public void TestCreateUser()
        {
            Bank bank = new Bank(BankLocation.Stavanger);
            User user = bank.CreateUser(0, "Kristian");

            Assert.That(user.Name, Is.EqualTo("Kristian"));
            Assert.That(user.Id , Is.EqualTo(0));
            Assert.That(user.Location, Is.EqualTo(bank.Location));
        }

        public void TestOverdraftRequest()
        {
            Bank bank = new Bank(BankLocation.Stavanger);
            User user = bank.CreateUser(0, "Kristian");

            bank.GenerateOverdraftRequest(user, 100);

            Assert.That(bank.Manager.OverdraftRequests.Count, Is.EqualTo(1));
            Assert.That(bank.Manager.OverdraftRequests[0].Amount, Is.EqualTo(100));
        }
    }
}
