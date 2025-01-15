using Boolean.CSharp.Main;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Test
{
    public class ExtensionTests
    {
        [Test]
        public void TestBranch()
        {
            User user = new User("Aksel");
            user.CreateAccount(user.Name, "Oslo", "test");
            Assert.That(user.Accounts[0].Branch, Is.EqualTo("Oslo"));
        }
        [Test]
        public void TestOverdraft()
        {
            User user = new User("Aksel");
            user.CreateAccount(user.Name, "Oslo", "test");
            user.Accounts[0].OverdraftRequest(100m);
            Assert.That(user.Accounts[0].Total(), Is.EqualTo(0m));
            Assert.That(user.Accounts[0].Transactions.Count, Is.EqualTo(0));
            Assert.That(user.Accounts[0].Overdraft.Count, Is.EqualTo(1));
            Assert.That(user.Accounts[0].OverdraftApproval(user.Admin,true, user.Accounts[0].Overdraft[0].Id), Is.False);
            Manager manager = new Manager("Sander");



            manager.CreateAccount(manager.Name, "Oslo", "test");
            manager.Accounts[0].OverdraftRequest(100m);
            manager.Accounts[0].OverdraftApproval(true, true, manager.Accounts[0].Overdraft[0].Id);
            Assert.That(manager.Accounts[0].Total(), Is.EqualTo(-100m));
            Assert.That(manager.Accounts[0].Transactions.Count, Is.EqualTo(1));
            Assert.That(manager.Accounts[0].Overdraft.Count, Is.EqualTo(0));
        }
    }
}
