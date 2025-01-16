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

            Assert.AreEqual("Customer 1", customer1.GetCustomerId);
            Assert.AreEqual("Customer 2", customer2.GetCustomerId);

            Assert.AreNotEqual("Customer 2", customer1.GetCustomerId);

            Assert.AreEqual(branch, customer1.GetCurrentAccount.GetBranch);

            Assert.NotNull(customer2.GetCurrentAccount);
        }
    }
}
