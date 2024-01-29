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
            Bank bank = new Bank();
            //Execute
            bank.createCustomer("Sebastian", "Hanssen");
            //verify
            Assert.That(Is.Not.Null, bank.customers);
            Assert.That("Sebastian", bank.customers[0].firstName);
        }

    }
}