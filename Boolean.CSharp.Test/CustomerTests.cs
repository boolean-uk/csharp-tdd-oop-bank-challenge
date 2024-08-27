using Boolean.CSharp.Main;
using Boolean.CSharp.Main.BankAccountClasses;
using Boolean.CSharp.Main.Persons;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    public class CustomerTests
    {
        [Test]
        public void CreateCurrentAccount()
        {
            Bank bank = new Bank();
            Customer customer = new Customer(bank, 32, "john");

            customer.CreateAccount("Current account Test");

            Assert.That((bank.BankAccounts.Count == 1), Is.True);
        }

        [Test]
        public void CreateSavingsAccount()
        {
            Bank bank = new Bank();
            Customer customer = new Customer(bank, 32, "john");

            customer.CreateSavingsAccount("Savings account Test");

            Assert.That((bank.BankAccounts.Count == 1), Is.True);
        }
    }
}