﻿using System.Runtime.InteropServices;
using Boolean.CSharp.Main;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CoreTest
    {
        [TestCase("SavingsAccount", 4000)]
        [TestCase("", 4000)]
        [TestCase("SavingsAccount", -1000)]
        [TestCase("SavingsAccount", 0)]
        public void TestCreateCurrentAccount(string name, decimal startingBalance) {

            Branch br = new Branch("LA");
            Account account = null;
            TestDelegate createAccount = () => account = new CurrentAccount(name, startingBalance, br);

            if (string.IsNullOrEmpty(name) || startingBalance < 1) {
                Assert.Throws<Exception>(createAccount);
                Assert.IsNull(account);
            } else {
                Assert.DoesNotThrow(createAccount);
                Assert.IsNotNull(account);

                Assert.AreEqual(AccountType.CURRENT, account.GetAccountType());
                Assert.AreEqual(name, account.AccountName);
                Assert.AreEqual(startingBalance, account.Balance);
            }
           
        }

        [TestCase("SavingsAccount", 4000)]
        [TestCase("", 4000)]
        [TestCase("SavingsAccount", -1000)]
        [TestCase("SavingsAccount", 0)]
        public void TestCreateSavingsAccount(string name, decimal startingBalance) {

            Branch br = new Branch("LA");
            Account account = null;
            TestDelegate createAccount = () => account = new SavingsAccount(name, startingBalance, br);
             
            if (string.IsNullOrEmpty(name) || startingBalance < 1) {
                Assert.Throws<Exception>(createAccount);
                Assert.IsNull(account);
            } else {
                Assert.DoesNotThrow(createAccount);
                Assert.IsNotNull(account);

                Assert.AreEqual(AccountType.SAVINGS, account.GetAccountType());
                Assert.AreEqual(name, account.AccountName);
                Assert.AreEqual(startingBalance, account.Balance);
            }
            
           
        }

        [TestCase("TestAccount", 100)]
        [TestCase("TestAccount", -100)]
        [TestCase("TestAccount", 0)]
        public void TestDeposit(string name, decimal depositamount) {
            decimal startingBalance = 500m;

            Branch br = new Branch("LA");
            Account account = new SavingsAccount(name, startingBalance, br);

            TestDelegate action = () => account.Deposit(depositamount);

            if (depositamount > 0) {
                Assert.DoesNotThrow(action);
                Assert.AreEqual(startingBalance+depositamount, account.CalculateAccountBalance());
                Assert.IsTrue(account.GetTransactionListCount() > 0);
            } else if (depositamount <= 0) {
                Assert.Throws<InvalidOperationException>(action);
                Assert.AreEqual(startingBalance, account.Balance);
                Assert.IsTrue(account.GetTransactionListCount() == 1); // since we add a deposit when we create the account
            }
        }


        [TestCase("TestAccount", 100)]
        [TestCase("TestAccount", -100)]
        [TestCase("TestAccount", 0)]
        [TestCase("TestAccount", 600)]
        public void TestWithdraw(string name, decimal withdrawamount) {
            decimal startingBalance = 500m;

            Branch br = new Branch("LA");
            Account account = new SavingsAccount(name, startingBalance, br);

            TestDelegate action = () => account.Withdraw(withdrawamount);

            if (account.Balance > withdrawamount && withdrawamount > 0) {
                Assert.DoesNotThrow(action);
                Assert.AreEqual(startingBalance-withdrawamount, account.CalculateAccountBalance());
                Assert.IsTrue(account.GetTransactionListCount() > 0);
            } else if (withdrawamount > account.Balance) {
                Assert.Throws<InvalidOperationException>(action);
                Assert.AreEqual(startingBalance, account.Balance);
                Assert.IsTrue(account.GetTransactionListCount() == 1); // since we add a deposit when we create the account
            } else if (withdrawamount < 0) {
                Assert.Throws<InvalidOperationException>(action);
                Assert.AreEqual(startingBalance, account.Balance);
                Assert.IsTrue(account.GetTransactionListCount() == 1); // since we add a deposit when we create the account
            }
        }


        [Test]
        public void TestGeneratestatement() {
            // Arrange
            string accountName = "TestAccount";
            decimal initialBalance = 2000.00m;
            Branch br = new Branch("LA");
            Account testAccount = new CurrentAccount(accountName, initialBalance, br);

            // Act
            testAccount.Withdraw(500.00m);
            testAccount.Deposit(1000.00m);
            testAccount.Deposit(200.00m);

            // Change ExpectedStatement if teting another time
            string expectedStatement = $"statement from {accountName}\nDate    ||    Withdraw    ||    Deposit   || Balance\n";
            expectedStatement += "22-01-2024    ||   0,00    ||    2000,00     ||    2000,00\n";
            expectedStatement += "22-01-2024    ||   500,00    ||    0,00     ||    1500,00\n";
            expectedStatement += "22-01-2024    ||   0,00    ||    1000,00     ||    2500,00\n";
            expectedStatement += "22-01-2024    ||   0,00    ||    200,00     ||    2700,00";

            string actualStatement = testAccount.GenerateStatement();

            // Assert
            Assert.AreEqual(expectedStatement, actualStatement);
        }
        



    }
}