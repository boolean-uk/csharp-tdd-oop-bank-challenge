using BankingApp.Boolean.CSharp.Main;
using BankingApp.Boolean.CSharp.Main.Accounts;
using NUnit.Framework;
using System.Data.Common;
using System;
using System.Security.Principal;
using System.Transactions;
using static System.Formats.Asn1.AsnWriter;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class BankingAppCoreTests
    {
        private Core _core;

        public BankingAppCoreTests()
        {
            _core = new Core();

        }
        //As a customer,
        //So I can safely store use my money,
        //I want to create a current account.
        [Test]
        public void CreateCurrentAccountTest()
        {
            var account = new CurrentAccount();


            Assert.IsNotNull(account);
            Assert.AreEqual(0, account.Balance);


        }

        //As a customer,
        //So I can save for a rainy day,
        //I want to create a savings account.
        [Test]
        public void CreateSavingsAccountTest()
        {
            var account = new SavingAccount();

            Assert.IsNotNull(account);
            Assert.AreEqual(0, account.Balance);

        }

        //As a customer,
        //So I can keep a record of my finances,
        //I want to generate bank statements with transaction dates, amounts, and balance at the time of transaction.

        //As a customer,
        //So I can use my account,
        //I want to deposit and withdraw funds.
        [Test]
        public void BankStatementTest()
        {
            var account = new CurrentAccount();

            var bankStatement = account.GenerateStatement();

            Assert.IsNotNull(bankStatement);


        }
        [Test]
        public void PrintBankStatementTest()
        {
            Account account = new CurrentAccount();

            var deposit1 = account.Deposit(new DateTime(2012, 1, 10), 1000);
            var deposit2 = account.Deposit(new DateTime(2012, 1, 13), 2000);

            var withdrawal = account.Withdraw(new DateTime(2012, 1, 14), 500);

            var expectedValue = "date || credit || debit || balance \n" +
            $"{withdrawal.Date} ||  || {withdrawal.Amount} || {withdrawal.BalanceAfterTransaction}\n" +
            $"{deposit2.Date} || {deposit2.Amount} ||  || {deposit2.BalanceAfterTransaction}\n" +
            $"{deposit1.Date} || {deposit1.Amount} ||  || {deposit1.BalanceAfterTransaction}\n";

            var bankStatement = BankStatement.PrintStatement(account.Transactions);

            Assert.AreEqual(expectedValue, bankStatement);

            Assert.NotNull(account.Transactions);
            Assert.AreEqual(3, account.Transactions.Count);
        }

    }
}