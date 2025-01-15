using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boolean.CSharp.Main;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class AccountTests
    {
        [Test]
        public void currentAccountTest()
        {
            Branch branch = new Branch("Gåsbu Branch");
            Customer customer1 = new Customer("Customer1", branch);

            customer1.GetCurrentAccount.deposit(100);
            Assert.AreEqual(100, customer1.GetCurrentAccount.Balance());

            customer1.GetCurrentAccount.withdraw(100);
            Assert.AreEqual(0, customer1.GetCurrentAccount.Balance());

            // check if account is negative
            customer1.GetCurrentAccount.withdraw(100);
            Assert.AreEqual(0, customer1.GetCurrentAccount.Balance());

            customer1.GetCurrentAccount.setOverDrawAmount(100);
            customer1.GetCurrentAccount.withdraw(100);
            Assert.AreEqual(-100, customer1.GetCurrentAccount.Balance());

        }
        [Test]
        public void savingAccountTest()
        {
            Branch branch = new Branch("Gåsbu Branch");
            Customer customer1 = new Customer("Customer1", branch);

            customer1.GetSavingAccount.deposit(100);
            Assert.AreEqual(100, customer1.GetSavingAccount.Balance());

            customer1.GetSavingAccount.withdraw(100);
            Assert.AreEqual(0, customer1.GetSavingAccount.Balance());

            // check if account is negative
            customer1.GetSavingAccount.withdraw(100);
            Assert.AreEqual(0, customer1.GetSavingAccount.Balance());

            customer1.GetSavingAccount.setOverDrawAmount(100);
            customer1.GetSavingAccount.withdraw(100);
            Assert.AreEqual(-100, customer1.GetSavingAccount.Balance());

        }
    }
}
