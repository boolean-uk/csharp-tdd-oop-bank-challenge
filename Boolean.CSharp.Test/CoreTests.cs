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

    }
}