using Boolean.CSharp.Main.Customer;
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
        public void CreateAccount()
        {
            Customer customer = new Customer();
            customer.CreateAccount("testSaving", Main.AccountType.Savings, Main.Branch.First);
            customer.CreateAccount("testCurrent", Main.AccountType.Current, Main.Branch.First);
            Assert.That(customer.GetAccounts().Count, Is.EqualTo(2));
        }
    }
}
