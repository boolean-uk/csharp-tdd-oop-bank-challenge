using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Accounts;
using Boolean.CSharp.Main.Branches;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CustomerTest
    {
        private Customer _customer;
        private Branch _branch;
        [SetUp]
        public void SetUp() 
        {
            _customer = new();
            _branch = new("Test", "Test");

        }

        [Test]
        public void CustomerCanCreateAccount()
        {
            _customer.CreateAccount(new CurrentAccount(_branch, "Current Account"));
            _customer.CreateAccount(new SavingsAccount(_branch, "Savings Account"));
            Assert.That(_customer.GetNumberOfAccounts(), Is.EqualTo(2));
        }

        [Test]
        public void CanRequestOverdraft()
        {
            string accountName = "First account";
            CurrentAccount account = new CurrentAccount(_branch, accountName);
            _customer.RequestOverdraft(account, 100);
            Assert.That(_branch.Requests.Count, Is.EqualTo(1));
        }
    }
}
