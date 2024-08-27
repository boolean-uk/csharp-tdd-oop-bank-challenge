using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Persons;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    public class CustomerTests
    {
        [Test]
        public void TestQuestion1()
        {
            Bank bank = new Bank();
            Customer customer = new Customer(bank, 32, "john");

            customer.CreateAccount("accountName");

            Assert.That((bank.BankAccounts.Count == 1), Is.True);
        }

    }
}