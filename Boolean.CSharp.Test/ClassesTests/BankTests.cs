using NUnit.Framework;
using System;
using Boolean.CSharp.Main.Classes;

namespace Boolean.CSharp.Tests
{
    [TestFixture]
    public class BankTests
    {
        private Bank bank;

        [SetUp]
        public void setUp()
        {
            bank = new Bank("Experis Bank", "Bergen Branch");
        }

        [Test]
        public void bankCreationShouldInitializeCorrectly()
        {
            Assert.AreEqual("Experis Bank", bank.Name);
            Assert.AreEqual("Bergen Branch", bank.Branch);
            Assert.AreEqual(0, bank.Customers.Count);
        }

        [Test]
        public void createCustomerShouldAddCustomerToBank()
        {
            var customer = bank.CreateCustomer("Jone", "Hjorteland", "jonehjorteland@experis.no", "Vestre Strømkaien 13, 5008 Bergen");
            Assert.AreEqual(1, bank.Customers.Count);
            Assert.AreEqual(customer, bank.Customers[0]);
        }

        [Test]
        public void createCustomerShouldReturnCustomerObject()
        {
            var customer = bank.CreateCustomer("Jone", "Hjorteland", "jonehjorteland@experis.no", "Vestre Strømkaien 13, 5008 Bergen");
            Assert.IsInstanceOf<Customer>(customer);
            Assert.AreEqual("Jone", customer.FirstName);
            Assert.AreEqual("Hjorteland", customer.LastName);
            Assert.AreEqual("jonehjorteland@experis.no", customer.Email);
        }
    }
}
