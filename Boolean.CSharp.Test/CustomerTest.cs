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
        [Test]
        public void CustomerCanCreateAccount()
        {
            Customer customer = new();
            Branch branch = new("Test", "Test");
            customer.CreateAccount(new CurrentAccount(branch, "Current Account"));
            customer.CreateAccount(new SavingsAccount(branch, "Savings Account"));
            Assert.That(customer.GetNumberOfAccounts(), Is.EqualTo(2));
        }
    }
}
