﻿using Boolean.CSharp.Main;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class BankTests
    {

        [Test]
        public void Test1CreateACurrentAccount()
        {
            // Create account...
            CurrentAccount currentAccount = new CurrentAccount();
            Assert.IsNotNull(currentAccount);
        }

        [Test]
        public void Test2DepositAndWithdrawFromCurrentAccount()
        {
            // Store and use money...
            CurrentAccount currentAccount = new CurrentAccount();
            bool result1 = currentAccount.Deposit(1000);
            bool result2 = currentAccount.Withdraw(500);
            Assert.IsTrue(result1);
            Assert.IsTrue(result2);

            Assert.That(currentAccount.Balance == 500);
        }

        [Test]
        public void Test3CreateASavingsAccount()
        {
            SavingsAccount savingsAccount = new SavingsAccount();
            Assert.IsNotNull(savingsAccount);
        }

        [Test]
        public void Test4DepositAndWithdrawFromSavingsAccount()
        {
            SavingsAccount savingsAccount = new SavingsAccount();
            savingsAccount.Deposit(1000);
            savingsAccount.Withdraw(500);
            Assert.That(savingsAccount.Balance == 500);
        }

        [Test]
        public void Test5GenerateBankStatement()
        {
            BankStatement bankStatement = new BankStatement();
            Assert.IsNotNull(bankStatement);
        }
    }
}