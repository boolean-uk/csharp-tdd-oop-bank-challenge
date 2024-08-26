using Boolean.CSharp.Main;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Test
{
    public class BankTests
    {
        [Test]
        public void TestCreateCustomer()
        {
            Customer customer = new Customer(55);

            Bank bank = new Bank();

            Assert.That(bank.CreateCustomer(customer));
            Assert.That(!bank.CreateCustomer(customer));

        }
    }
}
