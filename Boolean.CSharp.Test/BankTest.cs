using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Account;
using Boolean.CSharp.Main.Enum;
using Boolean.CSharp.Main.Person;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class BankTest
    {

        public BankTest()
        {

        }

        [TestCase("Espen", "Luna", 93458577)]
        [TestCase("Knut", "Knutsen", 12345678)]
        public void TestAddCustomer(string firstname, string lastname, int phonenumber)
        {
            Bank bank = new Bank(new Manager());
            Customer c1 = new Customer(firstname, lastname, phonenumber); 
            bool addedCustomer = bank.AddCustomer(c1);
            Assert.That(addedCustomer, Is.True);
            Assert.That(bank.Customers.Count(), Is.EqualTo(1));
            Assert.That(bank.Customers[0].FirstName, Is.EqualTo(firstname));
            Assert.That(bank.Customers[0].LastName, Is.EqualTo(lastname));
            Assert.That(bank.Customers[0].PhoneNumber, Is.EqualTo(phonenumber));
        }

        [Test]
        public void TestRemoveCustomer() 
        {
            Bank bank = new Bank(new Manager());
            Customer c1 = new Customer("Espen", "Luna", 93458577);
            bank.AddCustomer(c1);

            bool removedCustomer = bank.RemoveCustomer(c1);
            Assert.That(removedCustomer, Is.True);

            Assert.That(bank.Customers.Count(), Is.EqualTo(0));
        }

        [Test]
        public void TestFindCustomer()
        {
            Bank bank = new Bank(new Manager());
            Customer c1 = new Customer("Espen", "Luna", 93458577);
            Customer c2 = new Customer("Per", "Pedersen", 12345678);
            Customer c3 = new Customer("Knut", "Knutsen", 87654321);

            bank.AddCustomer(c1);
            bank.AddCustomer(c2);
            Customer foundCustomer1 = bank.FindCustomer(93458577);

            Assert.That(foundCustomer1.FirstName, Is.EqualTo("Espen"));
            Assert.That(foundCustomer1.LastName, Is.EqualTo("Luna"));
            Assert.That(foundCustomer1.PhoneNumber, Is.EqualTo(93458577));

            Customer foundCustomer2 = bank.FindCustomer(12345678);
            Assert.That(foundCustomer2.FirstName, Is.EqualTo("Per"));
            Assert.That(foundCustomer2.LastName, Is.EqualTo("Pedersen"));
            Assert.That(foundCustomer2.PhoneNumber, Is.EqualTo(12345678));

            Assert.That(bank.FindCustomer(3123854), Is.EqualTo(null));


        }

        [Test]
        public void TestCreateAccount()
        {
            Bank bank = new Bank(new Manager());

            Customer c = new Customer("Espen", "Luna", 93458577);

            BankAccount currentAccount = bank.CreateAccount(c, AccountType.Current, BankBranches.Bergen, "Brukskonto1");
            Assert.That(currentAccount.GetType(), Is.EqualTo(typeof(CurrentAccount)));

            BankAccount savingAccount = bank.CreateAccount(c, AccountType.Saving, BankBranches.Bergen, "Sparekonto1");
            Assert.That(savingAccount.GetType(), Is.EqualTo(typeof(SavingAccount)));

            Assert.That(c.BankAccounts.Count(), Is.EqualTo(2));
        }
    }
}
