﻿using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Accounts;
using Boolean.CSharp.Main.Classes;
using Boolean.CSharp.Main.enums;
using Boolean.CSharp.Main.Interfaces;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Twilio.Types;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class ExtensionTests
    {
        [Test]
        public void Test_01_GetBalance_BasedOnTransactionHistory_LotsaTransactions()
        {
            //Arrange
            Customer customer = new Customer("Andreas Lauvhjell");
            AccountCurrent currentAccount = new AccountCurrent(customer, Branch.Retail);
            for (int i = 0; i < 20; i++) //10x each
            {
                if (!(i % 2 == 0))
                {
                    currentAccount.Deposit(1900);
                }
                else
                {
                    currentAccount.Withdraw(1000);
                }
            }
            currentAccount.Deposit(1);

            //Act
            decimal expectedResult = currentAccount.GetBalance();
            decimal actualResult = 9001;

            //Assert
            Assert.That(expectedResult, Is.EqualTo(actualResult));
        }


        [Test]
        public void Test_02_BranchTest()
        {
            //Arrange
            Customer customer1 = new Customer("Andreas Lauvhjell");
            Customer customer2 = new Customer("Halfdan the Black");
            Customer customer3 = new Customer("Harald Fairhair");
            Customer customer4 = new Customer("Eirik Bloodaxe");
            Customer customer5 = new Customer("Harald Greycloak");
            Customer customer6 = new Customer("Håkon the Good");

            AccountCurrent retail1 = new AccountCurrent(customer1, Branch.Retail);
            AccountCurrent retail2 = new AccountCurrent(customer2, Branch.Retail);
            AccountCurrent retail3 = new AccountCurrent(customer3, Branch.Commercial);
            AccountCurrent retail4 = new AccountCurrent(customer4, Branch.Private);
            AccountSavings retail5 = new AccountSavings(customer5, Branch.Pension);
            AccountSavings retail6 = new AccountSavings(customer6, Branch.Pension);

            List<Account> accounts =
            [
                retail1,
                retail2,
                retail3,
                retail4,
                retail5,
                retail6,
            ];

            //Act
            int expectedRetail = accounts.Count(account => account.Branch == Branch.Retail);
            int expectedCommercial = accounts.Count(account => account.Branch == Branch.Commercial);
            int expectedPrivate = accounts.Count(account => account.Branch == Branch.Private);
            int expectedPension = accounts.Count(account => account.Branch == Branch.Pension);


            int actualRetail = 2;
            int actualCommercial = 1;
            int actualPrivate = 1;
            int actualPension = 2;

            //Assert
            Assert.That(expectedRetail, Is.EqualTo(actualRetail));
            Assert.That(expectedCommercial, Is.EqualTo(actualCommercial));
            Assert.That(expectedPrivate, Is.EqualTo(actualPrivate));
            Assert.That(expectedPension, Is.EqualTo(actualPension));
        }

        [Test]
        public void Test_03_OverdraftRequest()
        {
            //Arrange
            Customer customer = new Customer("Andreas Lauvhjell");
            AccountCurrent currentAccount = new AccountCurrent(customer, Branch.Retail);
            currentAccount.Deposit(1000);

            //Act
            currentAccount.RequestOverdraft(2000); //testbool approved the request. Prolly bad programming habit, but I like to live dangerously
            int expectedResult = currentAccount.OverdraftRequests.Count;
            int actualResult = 1;

            //Assert
            Assert.That(expectedResult, Is.EqualTo(actualResult));
        }

        [Test]
        public void Test_05_Approve_OverdraftRequest()
        {
            //Arrange
            Customer customer = new Customer("Andreas Lauvhjell");
            BankManager manager = new BankManager("Scrooge McDuck");
            AccountCurrent currentAccount = new AccountCurrent(customer, Branch.Retail);
            currentAccount.Deposit(1000);
            currentAccount.RequestOverdraft(2000);

            //
            string expectedResultString = manager.ManageOverdraftRequest(currentAccount, true);
            string actualResultString = "The overdraft was approved.";
            decimal expectedResultAmount = currentAccount.GetBalance();
            decimal actualResultAmount = -1000;

            ITransaction? overdraftRequest = currentAccount.OverdraftRequests
                .OrderByDescending(t => t.Date)
                .Where(t => t.Type == TransactionType.Debit)
                .FirstOrDefault();

            TransactionStatus expectedStatus = overdraftRequest.Status;
            TransactionStatus actualStatus = TransactionStatus.Approved;

            //Assert
            Assert.That(expectedResultAmount, Is.EqualTo(actualResultAmount));
            Assert.That(expectedResultString, Is.EqualTo(actualResultString));
            Assert.That(expectedStatus, Is.EqualTo(actualStatus));
        }

        [Test]
        public void Test_05_Reject_OverdraftRequest()
        {
            //Arrange
            Customer customer = new Customer("Andreas Lauvhjell");
            BankManager manager = new BankManager("Scrooge McDuck");
            AccountCurrent currentAccount = new AccountCurrent(customer, Branch.Retail);
            currentAccount.Deposit(1000);
            currentAccount.RequestOverdraft(-2000);

            //
            string expectedResultString = manager.ManageOverdraftRequest(currentAccount, false);
            string actualResultString = "The overdraft was rejected.";
            decimal expectedResultAmount = currentAccount.GetBalance();
            decimal actualResultAmount = 1000;


            ITransaction? overdraftRequest = currentAccount.OverdraftRequests
                .OrderByDescending(t => t.Date)
                .Where(t => t.Type == TransactionType.Debit)
                .FirstOrDefault();

            TransactionStatus expectedStatus = overdraftRequest.Status;
            TransactionStatus actualStatus = TransactionStatus.Refused;

            //Assert
            Assert.That(expectedResultAmount, Is.EqualTo(actualResultAmount));
            Assert.That(expectedResultString, Is.EqualTo(actualResultString));
            Assert.That(expectedStatus, Is.EqualTo(actualStatus));
        }

        [Test]
        public void Test_06_SMS_sender()
        {
            //Arrange
            Customer customer = new Customer("Andreas Lauvhjell", "YOURNUMBERHERE");
            AccountCurrent currentAccount = new AccountCurrent(customer, Branch.Retail);

            //
            decimal amount = 1000;
            currentAccount.Deposit(amount, true); //Sends the message with the true bool

            /* Sends it once more to easily assert that the Twilio SMS sender works.
             * I won't rewrite the tests and methods to return string to get it to only send SMS once in this test. Right now this sends it once more to show TwilioHelper sends the message and works" */
            string expectedResult = TwilioHelper.SendSMS(customer.Number, $"You have withdrawn {amount}£.");
            string actualResult = $"Message should have been sent to {customer.Number}, bro";

            //Assert
            Assert.That(expectedResult, Is.EqualTo(actualResult));
        }
    }
}
