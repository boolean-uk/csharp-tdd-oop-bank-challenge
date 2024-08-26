using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Branches;
using Boolean.CSharp.Main.Interfaces;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Test
{
    public class BankTests
    {
        [Test]
        public void TestCreateCustomer()
        {
            Customer customer = new Customer(55);

            Bank bank = new Bank();

            Assert.That(bank.CreateCustomer(customer));
            Assert.That(!bank.CreateCustomer(customer));

        }

        [Test]
        public void TestManager()
        {
            double newLimit = 500;
            Bank bank = new Bank();
            Manager manager = new Manager();
            manager.overDraftLimit = newLimit;
            bank.SetOverdraftLimit(manager);
            Assert.That(bank.GetOverdraftLimit() == newLimit);
        }


        [Test]
        public void TestCreateAccount()
        {
            Customer customer1 = new Customer(55);
            Customer customer2 = new Customer(0);
            Customer customer3 = new Customer(10000);

            Bank bank = new Bank();

            bank.CreateCustomer(customer2);
            bank.CreateCustomer(customer3);
            bank.CreateCustomer(customer1);
            IBranch branch1 = new Amax();
            IBranch branch2 = new AmericanExpress();

            int result1 = bank.CreateAccount(customer1.customerId, branch1, false);
            int result2 = bank.CreateAccount(customer2.customerId, branch1, true);
            int result3 = bank.CreateAccount(customer3.customerId, branch2, false);
            int result4 = bank.CreateAccount(customer3.customerId, branch2, true);
            int result5 = bank.CreateAccount(42, branch2, false);

            Assert.That(result1 == 0);
            Assert.That(result2 == 0);
            Assert.That(result3 == 0);
            Assert.That(result4 == 1);
            Assert.That(result5 == -1);
        }

        [Test]
        public void TestRequestDeposit()
        {
            Bank bank = new Bank();
            Customer customer = new Customer(100);
            bank.CreateCustomer(customer);
            IBranch branch1 = new Amax();
            customer.accounts.Add(bank.CreateAccount(customer.customerId, branch1, false));


            bank.RequestDeposit(customer.customerId, 50, customer.accounts[0], false);
            bank.RequestDeposit(customer.customerId, 25, customer.accounts[0], false);
            string date = DateTime.Now.ToString("dd/MM/yyyy");
            string expected = 
                "date       || credit  || debit  || balance\n" +
                date+     " ||  25.00  ||        || 75.00\n" +
                date +    " ||  50.00  ||        || 50.00\n";
            
            Assert.That(bank.RequestBankStatement(customer.customerId, customer.accounts[0]) == expected);
        }

    }
}
