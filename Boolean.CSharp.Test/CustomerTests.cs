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
    public class CustomerTests
    {
        [Test]
        public void customerTest()
        {
            Branch branch = new Branch("Gåsbu Branch");
            Customer customer1 = new Customer("Customer 1", branch);
            Customer customer2 = new Customer("Customer 2", branch);

            Assert.AreEqual("customer1", customer1.CustomerId());
            Assert.AreEqual("customer2", customer2.CustomerId());

            Assert.AreNotEqual("customer2", customer1.CustomerId());

            Assert.AreEqual(branch, customer1.CurrentAccount().Branch());

            Assert.NotNull(customer2.CurrentAccount());
        }
    }
}
