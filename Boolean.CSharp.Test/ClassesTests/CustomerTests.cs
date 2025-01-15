using NUnit.Framework;
using System;
using Boolean.CSharp.Main.Classes;

namespace Boolean.CSharp.Tests
{
    [TestFixture]
    public class CustomerTests
    {
        private Bank bank;
        private Customer customer;

        [SetUp]
        public void SetUp()
        {
            bank = new Bank("Experis Bank", "Bergen Branch");
            customer = bank.CreateCustomer("Jone", "Hjorteland", "jonehjorteland@experis.no", "Vestre Strømkaien 13, 5008 Bergen");
        }

        [Test]
        public void customerCreationShouldInitializeCorrectly()
        {
            Assert.AreEqual("Jone", customer.FirstName);
            Assert.AreEqual("Hjorteland", customer.LastName);
            Assert.AreEqual("jonehjorteland@experis.no", customer.Email);
            Assert.AreEqual("Vestre Strømkaien 13, 5008 Bergen", customer.Address);
            Assert.AreEqual("Bergen Branch", customer.Branch);
            Assert.AreEqual(0, customer.Accounts.Count);
        }

        [Test]
        public void createAccountShouldAddAccountToCustomer()
        {
            customer.CreateAccount("Savings");

            Assert.AreEqual(1, customer.Accounts.Count);
            Assert.AreEqual("Savings", customer.Accounts[0].AccountType);
            Assert.AreEqual("Bergen Branch", customer.Accounts[0].Branch);
        }

        [Test]
        public void createAccountShouldCreateAccountWithCorrectOwnerAndBranch()
        {
            customer.CreateAccount("Current");

            var account = customer.Accounts[0];
            Assert.AreEqual("Current", account.AccountType);
            Assert.AreEqual(customer, account.Owner);
            Assert.AreEqual("Bergen Branch", account.Branch);
        }
    }
}
