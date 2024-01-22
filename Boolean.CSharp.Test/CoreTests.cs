﻿using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Accounts.Constants;
using Boolean.CSharp.Main.Users;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CoreTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void TestMakeUserAccount()
        {
            BankApplication bankApp = new BankApplication();
            Custommer custommer1 = new Custommer() { Name = "Kanthee", Branch = Branches.Bergen, 
            Id = 1111};

            bankApp.Add(custommer1);
            custommer1.makeAccount(AccountType.Saving);
            custommer1.makeAccount(AccountType.Current);
            var users = bankApp.seeUsers();

            // There should be 1 user in the bank and the custommer should have 2 accounts.
            Assert.IsTrue(users.Count == 1 && custommer1.getAccAccounts().Count == 2);


        }

    }
}