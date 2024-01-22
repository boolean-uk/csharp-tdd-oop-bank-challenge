using System.Security.Principal;
using Boolean.CSharp.Main;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    public class CoreTests
    {
        
        [Test]
        public void addMonyToCurrent()
        {
            Bank bank = new Bank();
            Customer bob = new Customer("Bob");
            Account current = new Account("Current");
            bank.addCustomer(bob);
            bank.addAccountToCustomer("Cob",current);
            bank.depositMoney("Bob", "Current", 2000, "14/01/2012");

            List<string> printTest = bank.printStatement("Bob", "Current");

            Assert.IsTrue(printTest[0] == "date       || credit  || debit  || balance");
            Assert.IsTrue(printTest[1] == "14/01/2012 || 2000.00 ||        || 2000.00");

        }

    }
}