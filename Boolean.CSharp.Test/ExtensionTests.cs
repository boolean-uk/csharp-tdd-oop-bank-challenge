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
    public class ExtensionTests
    {
        Manager manager;
        Account account;
        Customer customer;
        

        [SetUp]
        public void SetUp() 
        {
            manager = new();
            customer = new();
            account = new("test", Branch.Norway);
            customer.Accounts.Add(account);
        }

        [Test]
        public void CalculateBalance()
        {
            customer.Deposit("test", 500);
            customer.Deposit("test", 400);
            customer.Withdraw("test", 300);
            Assert.That(account.GetBalance(), Is.EqualTo(600));
        }

        [Test]
        public void GetBranch()
        {
            Assert.That(account.Branch, Is.EqualTo(Branch.Norway));
        }

        [Test]
        public void CreateOverdraft() 
        {
            account.RequestOverdraft(300);
            Assert.That(account.Overdrafts.Last().Amount, Is.EqualTo(300));
        }

        [Test]
        public void ApproveOverdraft()
        {
            account.RequestOverdraft(300);
            manager.AcceptOverdraft(account ,account.Overdrafts.Last());
            Assert.That(account.GetBalance(), Is.EqualTo(-300));
        }

        [Test]
        public void RejectOverdraft()
        {
            account.RequestOverdraft(300);
            manager.RejectOverdraft(account, account.Overdrafts.Last());
            Assert.That(account.GetBalance(), Is.EqualTo(0));
        }
    }
}
