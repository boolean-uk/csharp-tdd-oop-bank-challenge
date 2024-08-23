﻿using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Accounts;
using Boolean.CSharp.Main.Enums;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CoreTests
    {
        private Core _core;

        public CoreTests()
        {
            _core = new Core();

        }

        [TestCase(5000)]
        public void TestGetBalance(int depositAmount)
        {
            User user = new User("Jonas", Role.Customer);
            ConsumptionAccount account = new ConsumptionAccount(user, Branch.Oslo);
            account.Deposit(depositAmount);

            int result = account.GetBalance();

            Assert.That(result, Is.EqualTo(depositAmount));
        }

        [TestCase(5000)]
        public void TestDeposit(int depositAmount)
        {
            User user = new User("John", Role.Customer);
            ConsumptionAccount account = new ConsumptionAccount(user, Branch.Trondheim);
            account.Deposit(depositAmount);

            int result = account.GetBalance();

            Assert.That(result, Is.EqualTo(depositAmount));
        }

        [TestCase(5000, 3000, 2000)]
        public void TestWithdraw(int depositAmount, int withdrawAmount, int expected)
        {
            User user = new User("Marius", Role.Customer);
            ConsumptionAccount account = new ConsumptionAccount(user, Branch.Stavanger);
            account.Deposit(depositAmount);
            account.Withdraw(withdrawAmount);

            int result = account.GetBalance();

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}