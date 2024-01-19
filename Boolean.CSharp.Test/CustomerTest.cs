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
            customer.CreateAccount("Savings Account", AccountType.Savings);
            customer.CreateAccount("Spending Account", AccountType.Current);
            Assert.That(customer.GetNumberOfAccounts(), Is.EqualTo(2));
        }
    }
}
