﻿using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Branches;
using Boolean.CSharp.Main.Interfaces;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

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


            bank.RequestDeposit(customer, 50, customer.accounts[0]);
            bank.RequestDeposit(customer, 25, customer.accounts[0]);
            string date = DateTime.Now.ToString("dd/MM/yyyy");
            string expected = 
                "date       || credit  || debit   || balance\n" +
                date+     " || 25.00   ||         || 75.00  \n" +
                date +    " || 50.00   ||         || 50.00  \n";

            string result1 = bank.RequestBankStatement(customer.customerId, customer.accounts[0]);

            bool result2 = bank.RequestDeposit(customer, 222222, customer.accounts[0]);//not enough money

            bool result3 = bank.RequestDeposit(customer, 25, 2); //account does not exist


            Assert.That(result1 == expected);
            Assert.That(result2 == false);
            Assert.That(result3 == false);
        }


        [Test]
        public void TestRequestWithdraw() 
        {
            Bank bank = new Bank();
            Customer customer = new Customer(500);
            bank.CreateCustomer(customer);
            IBranch branch1 = new Amax();
            customer.accounts.Add(bank.CreateAccount(customer.customerId, branch1, false));


            bank.RequestDeposit(customer, 500, customer.accounts[0]);

            //test regular withdraw
            bool result1 = bank.RequestWithdraw(customer, 100, customer.accounts[0], false);
            Assert.That(result1 == true);
            string date = DateTime.Now.ToString("dd/MM/yyyy");
            string expected =
            "date       || credit  || debit   || balance\n" +
            date +    " ||         || 100.00  || 400.00 \n" +
               date + " || 500.00  ||         || 500.00 \n";
            string result2 = bank.RequestBankStatement(customer.customerId, customer.accounts[0]);
            Assert.That(result2 == expected);

            Assert.That(customer.funds == 100);


            //test Overdraw (400 left in account)
            Manager manager = new Manager();
            manager.overDraftLimit = 200;
            bank.SetOverdraftLimit(manager);

            bool result3 = bank.RequestWithdraw(customer, 1000, customer.accounts[0], true);
            Assert.That(result3 == false); // limit does not cover this high of an overdraw


            bool result4 = bank.RequestWithdraw(customer, 600, customer.accounts[0], true);
            Assert.That(result4 == true);
            expected =
            "date       || credit  || debit   || balance\n" +
             date +   " ||         || 600.00  || -200.00\n" +
            date +    " ||         || 100.00  || 400.00 \n" +
               date + " || 500.00  ||         || 500.00 \n";

            string result5 = bank.RequestBankStatement(customer.customerId, customer.accounts[0]);
            Assert.That(result5 == expected);
            Assert.That(customer.funds == 700);
        }
    }
}
