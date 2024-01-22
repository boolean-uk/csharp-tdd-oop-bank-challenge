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
            customer.CreateSpendingAccount("testSaving", Main.Branch.First);
            customer.CreateSavingsAccount("testCurrent", Main.Branch.First);
            Assert.That(customer.GetAccounts().Count, Is.EqualTo(2));
        }
    }
}
