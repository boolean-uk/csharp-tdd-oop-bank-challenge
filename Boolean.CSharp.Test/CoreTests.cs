﻿using Boolean.CSharp.Main;
using NUnit.Framework;
using System.Xml.Linq;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CoreTests
    {

        [TestCase("Ola", BankTypes.Current)]
        [TestCase("Lise", BankTypes.Saving)]
        public void CreateCurrentAccount(string name, BankTypes bankType)
        {
            Bank bank = new Bank();

            int result = bank.AddAccount(name, bankType);

            Assert.That(result, Is.EqualTo(0));
        }

        [Test]

        public void DepositFromAccount()
        {
            Bank bank = new Bank();
            string name = "test";
            BankTypes bankType = BankTypes.Current;
            double amount = 1000.00;

            int BankID = bank.AddAccount(name, bankType);
            double result = bank.Deposit(BankID, amount);

            Assert.That(result, Is.EqualTo(amount));
        }

        [Test]
        public void WithdrawFromBank()
        {
            Bank bank = new Bank();
            string name = "test";
            BankTypes bankType = BankTypes.Current;
            double amountDeposit = 1000;
            double amountWithdraw = 800;
            double expectedResult = 200;

            int bankID = bank.AddAccount(name, bankType);
            bank.Deposit(bankID, amountDeposit);
            double result = bank.Withdraw(bankID, amountWithdraw);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void TestGenerateBankStatement()
        {
            Bank bank = new Bank();
            string user = "Bob";
            BankTypes bankType = BankTypes.Current;
            double amountDeposit = 1000;
            double amountWithdraw = 800;
            int bankID = bank.AddAccount(user, bankType);
            bank.Deposit(bankID, amountDeposit);
            bank.Withdraw(bankID, amountWithdraw);

            string result = bank.PrintBankStateMent(user);

            Assert.NotNull(result);
        }
    }
}