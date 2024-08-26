using Boolean.CSharp.Main;
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


            bool result1 = bank.CreateAccount(customer1.customerId);
            bool result2 = bank.CreateAccount(customer2.customerId);
            bool result3 = bank.CreateAccount(customer3.customerId);
            bool result4 = bank.CreateAccount(customer3.customerId);
            bool result5 = bank.CreateAccount(42);

            Assert.That(true == result1);
            Assert.That(true == result2);
            Assert.That(true == result3);
            Assert.That(true == result4);
            Assert.That(false == result5);
        }
    }
}
