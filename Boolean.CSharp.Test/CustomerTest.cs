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
            Customer customer = new Customer("testName",Main.Branch.First);
            customer.CreateSpendingAccount("testSaving", customer.Branch);
            customer.CreateSavingsAccount("testCurrent", customer.Branch);
            Assert.That(customer.GetAccounts().Count, Is.EqualTo(2));
        }
    }
}
