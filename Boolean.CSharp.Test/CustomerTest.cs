using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Accounts;
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
            customer.CreateAccount("Savings Account");
            customer.CreateAccount("Spending Account");
            Assert.That(customer.GetNumberOfAccounts(), Is.EqualTo(2));
        }
    }
}
