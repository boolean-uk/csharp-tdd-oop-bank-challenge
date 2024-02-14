using Boolean.CSharp.Main;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CoreTests
    {
        [Test]
        public void AddCustomer()
        {
            //Set Up
            Bank bank = new Bank(1, BankLocation.Oslo);
            //Execute
            bank.createCustomer("Sebastian", "Hanssen");
            //verify
            Assert.That(bank.customers.Count, Is.Not.Null);
            Assert.That(bank.customers[0].FirstName, Is.EqualTo("Sebastian"));
        }

        [Test]
        public void AddCheckingAccount()
        {
            //Set Up
            Bank bank = new Bank(1, BankLocation.Oslo);

            //Execute
            bank.createCustomer("Sebastian", "Hanssen");
            bank.customers.FirstOrDefault(x => x.FirstName == "Sebastian" && x.LastName == "Hanssen").CreateChecking("My First Checking Account");

            //verify
            Assert.That(bank.customers.Count, Is.Not.Null);
            Assert.That(bank.customers[0].Accounts, Is.Not.Null);
            Assert.That(bank.customers[0].Accounts[0].Name, Is.EqualTo("My First Checking Account"));
        }

        [Test]
        public void AddSavingAccount()
        {
            //Set Up
            Bank bank = new Bank(1, BankLocation.Oslo);

            //Execute
            bank.createCustomer("Sebastian", "Hanssen");
            bank.customers.FirstOrDefault(x => x.FirstName == "Sebastian" && x.LastName == "Hanssen").CreateSaving("My First Saving Account");

            //verify
            Assert.That(bank.customers.Count, Is.Not.Null);
            Assert.That(bank.customers[0].Accounts, Is.Not.Null);
            Assert.That(bank.customers[0].Accounts[0].Name, Is.EqualTo("My First Saving Account"));
        }

    }
}