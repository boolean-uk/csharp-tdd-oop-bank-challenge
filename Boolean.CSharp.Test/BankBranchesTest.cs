using Boolean.CSharp.Main;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Boolean.CSharp.Test
{

    [TestFixture]
    public class BankBranchesTest
    {

        [TestCase(1, "Øyvind")]
        [TestCase(2, "Espen")]
        [TestCase(3, "Daniel")]
        [TestCase(4, "Silje")]
        [TestCase(5, "Eyvind")]

        public void AddCustomerTest(int id, string name)
        {
            IPerson customer1 = new Customer(name);

            BankBranch branch = new BankBranch(id);

            bool added = branch.AddCustomer(customer1);

            Assert.That(added, Is.EqualTo(true));
        }

        [Test]
        public void GetCustomersTest()
        {
            IPerson customer1 = new Customer("øyvind1");
            IPerson customer2 = new Customer("øyvind2");
            IPerson customer3 = new Customer("øyvind3");
            IPerson customer4 = new Customer("øyvind4");

            BankBranch branch = new BankBranch(1);

            branch.AddCustomer(customer1);
            branch.AddCustomer(customer2);
            branch.AddCustomer(customer3);
            branch.AddCustomer(customer4);

            List<IPerson> customers = branch.GetCustomers();

            Assert.That(customers.Count, Is.EqualTo(4));
        }
    }


}
