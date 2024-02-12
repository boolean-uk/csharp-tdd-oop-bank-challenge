﻿using Boolean.CSharp.Main;
using NUnit.Framework;
using Boolean.CSharp.Main.Enums;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CoreTests
    {
        [Test]
        public void TestCreateCurrentAccount()
        {
            CurrentAccount currentaccount = new CurrentAccount();
            currentaccount.creatCurrentAccount(123, 500, "Current", Branch.Sandnes, "None");
            Assert.AreEqual(123, currentaccount.AccountId);   

        }

        [Test]
        public void TestCreateSavingAccount()
        {
            SavingsAccount savingsaccount = new SavingsAccount();
            savingsaccount.createSavingsAccount(234, 1000, "Saving", "Sandnes", "None");
            Assert.AreEqual(234, savingsaccount.AccountId);
            Assert.AreEqual(1000, savingsaccount.Balance);
        }

        [Test]
        public void TestDepositCurrentAccount()
        {
            CurrentAccount currentaccount = new CurrentAccount();
            BankTransaction transaction = new BankTransaction();
            transaction.makeTransaction(DateTime.Now.ToString("dd/MM/yyyy"), "Deposit", 500, currentaccount);
            transaction.makeTransaction(DateTime.Now.ToString("dd/MM/yyyy"), "Deposit", 1000, currentaccount);

            Assert.AreEqual(1500, transaction.NewBalance);
        }

        [Test]
        public void TestWithdrawCurrentAccount()
        {
            CurrentAccount currentaccount = new CurrentAccount();
            BankTransaction transaction = new BankTransaction();
            transaction.makeTransaction(DateTime.Now.ToString("dd/MM/yyyy"), "Deposit", 500, currentaccount);
            transaction.makeTransaction(DateTime.Now.ToString("dd/MM/yyyy"), "Deposit", 1000, currentaccount);
            transaction.makeTransaction(DateTime.Now.ToString("dd/MM/yyyy"), "Withdrawal", 700, currentaccount);

            Assert.AreEqual(800, transaction.NewBalance);

        }


        [Test]
        public void TestGenerateBankStatement2()
        {

            Customer customer = new Customer();
            CurrentAccount currentaccount = new CurrentAccount();
            BankTransaction newtransaction = new BankTransaction();
            BankTransaction secondtransaction = new BankTransaction();
            BankTransaction thirdtransaction = new BankTransaction();
            newtransaction.makeTransaction("10.01.2012", "Deposit", 1000, currentaccount);

            customer.TransactionHistory.Add(newtransaction);

            secondtransaction.makeTransaction("13.01.2012", "Deposit", 2000, currentaccount);

            customer.TransactionHistory.Add(secondtransaction);

            thirdtransaction.makeTransaction("14.01.2012", "Withdrawal", 500, currentaccount);

            customer.TransactionHistory.Add(thirdtransaction);

            customer.generateStatement();

            // Assert
            var expectedOutput = "      Date ||     Credit ||      Debit ||    Balance\r\n" +
                                 $"{"14.01.2012"} ||          0 ||        500 || 2500,00\r\n" +
                                 $"{"13.01.2012"} ||       2000 ||          0 || 3000,00\r\n" +
                                 $"{"10.01.2012"} ||       1000 ||          0 || 1000,00\r\n";

            Assert.AreEqual(expectedOutput, customer.generateStatement());
        } 



    }
}