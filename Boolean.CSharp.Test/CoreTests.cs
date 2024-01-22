﻿using Boolean.CSharp.Main;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CoreTests
    {
        private User GetSampleUser()
        {
            return new User("Harry Potter", "LordVoldemort23", "SneepyWeepyStreet", "111111", "harry@potter.hogwarts");
        }

        [Test]
        public void DoingADepositShouldIncreaseTheBalance()
        {
            var account = new Account(AllEnums.Branches.Antwerpen, GetSampleUser());
            account.Deposit(100, DateTime.Now);
            Assert.AreEqual(100, account.GetBalance());
        }

        [Test]
        public void DoingWithdrawShouldDecreaseTheBalance()
        {
            var account = new Account(AllEnums.Branches.Antwerpen, GetSampleUser());
            account.Deposit(200, DateTime.Now);
            account.Withdraw(100, DateTime.Now);
            Assert.AreEqual(100, account.GetBalance());
        }

        [Test]
        public void PrintStateMentShouldReturnFormattedStateMent()
        {
            var account = new Account(AllEnums.Branches.Antwerpen, GetSampleUser());
            account.Deposit(1000, new DateTime(1992, 5, 5));
            account.Deposit(2000, new DateTime(1992, 5, 6));
            account.Withdraw(999, new DateTime(1992, 5, 7));
            var statement = account.PrintStatement();
            var expectedStatement =
    "date       || credit  || debit  || balance" + Environment.NewLine +
    "07/05/1992 ||         || 999.00 || 2001.00" + Environment.NewLine +
    "06/05/1992 || 2000.00 ||        || 3000.00" + Environment.NewLine +
    "05/05/1992 || 1000.00 ||        || 1000.00";
            Assert.AreEqual(expectedStatement, statement);
        }
        [Test]
        public void DoesCurrentAccountInheritFromAccAndInitializeItCorrectly()
        {
            var currentAccount = new CurrentAccount(AllEnums.Branches.Antwerpen, GetSampleUser());
            Assert.AreEqual(0, currentAccount.GetBalance());
        }

        [Test]
        public void DoesSAvingAccountInheritFromAccAndInitializeItCorrectly()
        {
            var savingsAccount = new SavingsAccount(AllEnums.Branches.Antwerpen, GetSampleUser());
            Assert.AreEqual(0, savingsAccount.GetBalance());
        }
    }
}