using System.Security.Principal;
using Boolean.CSharp.Main;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    public class CoreTests
    {



        [Test]
        public void addCustomer()
        {
            Bank bank = new Bank();
            Customer bob = new Customer("Bob");
            bool customerTest = bank.addCustomer(bob);

            Assert.IsTrue(customerTest);

        }

        [Test]
        public void addAccountToCustomer()
        {
            Bank bank = new Bank();
            Customer bob = new Customer("Bob");
            Account current = new Account("Current");
            bank.addCustomer(bob);
            bool addAccountTest = bank.addAccountToCustomer("Bob", current);

            Assert.IsTrue(addAccountTest);

        }

        [Test]
        public void addMoneyToCurrent()
        {
            Bank bank = new Bank();
            Customer bob = new Customer("Bob");
            Account current = new Account("Current");
            bank.addCustomer(bob);
            bank.addAccountToCustomer("Bob", current);
            bool addMoneyTest = bank.depositMoney("Bob", "Current", 2000f, "14/01/2012");


            Assert.IsTrue(addMoneyTest);

        }
        [Test]
        public void withdrawMoneyFromCurrent()
        {
            Bank bank = new Bank();
            Customer bob = new Customer("Bob");
            Account current = new Account("Current");
            bank.addCustomer(bob);
            bank.addAccountToCustomer("Bob", current);
            bank.depositMoney("Bob", "Current", 2000f, "14/01/2012");
            bool withdrawMoneyTest = bank.withdrawMoney("Bob", "Current", 1000f, "15/01/2012");


            Assert.IsTrue(withdrawMoneyTest);
        }


        [Test]
        public void printAccountStatus()
        {
            Bank bank = new Bank();
            Customer bob = new Customer("Bob");
            Account current = new Account("Current");
            bank.addCustomer(bob);
            bank.addAccountToCustomer("Bob",current);
            bank.depositMoney("Bob", "Current", 2000f, "14/01/2012");

            List<string> printTest = bank.printStatement("Bob", "Current");

            Assert.IsTrue(printTest[0] == "date       || credit  || debit  || balance");
            Assert.IsTrue(printTest[1] == "14/01/2012 || 2000.00 ||        || 2000.00");

        }
        [Test]
        public void printAccountStatus2()
        {
            Bank bank = new Bank();
            Customer bob = new Customer("Bob");
            Account current = new Account("Current");
            bank.addCustomer(bob);
            bank.addAccountToCustomer("Bob", current);
            bank.depositMoney("Bob", "Current", 2000f, "14/01/2012");
            bank.depositMoney("Bob", "Current", 1000f, "15/01/2012");

            List<string> printTest = bank.printStatement("Bob", "Current");

            Assert.IsTrue(printTest[0] == "date       || credit  || debit  || balance");
            Assert.IsTrue(printTest[1] == "14/01/2012 || 2000.00 ||        || 2000.00");
            Assert.IsTrue(printTest[2] == "15/01/2012 || 1000.00 ||        || 3000.00");

        }

        [Test]
        public void printAccountStatus3()
        {
            Bank bank = new Bank();
            Customer bob = new Customer("Bob");
            Account current = new Account("Current");
            bank.addCustomer(bob);
            bank.addAccountToCustomer("Bob", current);
            bank.depositMoney("Bob", "Current", 2000f, "14/01/2012");
            bank.depositMoney("Bob", "Current", 1000f, "15/01/2012");
            bank.withdrawMoney("Bob", "Current", 1000f, "15/01/2012");

            List<string> printTest = bank.printStatement("Bob", "Current");

            Assert.IsTrue(printTest[0] == "date       || credit  || debit  || balance");
            Assert.IsTrue(printTest[1] == "14/01/2012 || 2000.00 ||        || 2000.00");
            Assert.IsTrue(printTest[2] == "15/01/2012 || 1000.00 ||        || 3000.00");
            Assert.IsTrue(printTest[3] == "15/01/2012 ||        || 1000.00 || 2000.00");
        }




    }
}