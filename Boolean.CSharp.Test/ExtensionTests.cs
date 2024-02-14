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
    public class ExtensionTests
    {
        [Test]
        public void CheckEnum()
        {
            //Set Up
            Bank bank = new Bank(1, BankLocation.Oslo);
            bool checkEnum = bank.BankLocation is Enum;
            //Execute
            bank.createCustomer("Sebastian", "Hanssen");
            //verify
            Assert.That(bank.customers.Count, Is.Not.Null);
            Assert.That(bank.customers[0].FirstName, Is.EqualTo("Sebastian"));
            Assert.That(checkEnum, Is.EqualTo(true));;
        }
    }
}
