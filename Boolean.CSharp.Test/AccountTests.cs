using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class AccountTests
    {
        [Test]
        public void currentAccountTest()
        {
            Branch branch = new Branch("Gåsbu Branch");
            Customer customer1 = new Customer("Customer1", branch);

            customer1.CurrentAccount().deposit(100);
            Assert.AreEqual(100, customer1.CurrentAccount().Balance());

            customer1.CurrentAccount().wihdraw(100);
            Assert.AreEqual(0, customer1.CurrentAccount().Balance());

            // check if account is negative
            customer1.CurrentAccount().wihdraw(100);
            Assert.AreEqual(0, customer1.CurrentAccount().Balance());

            customer1.CurrentAccount().setOverDrawAmount(100);
            customer1.CurrentAccount().wihdraw(100);
            Assert.AreEqual(-100, customer1.CurrentAccount().Balance());

        }
    }
}
