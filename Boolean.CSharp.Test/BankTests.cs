﻿using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Accounts;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class BankTests
    {
        [Test]
        public void TestCanCreateAccountInBank()
        {
            //setup
            Bank bank = new();
            Customer customer = new("I", "+4712345678");

            //execute
            Account? shouldBeCurrentAccount = bank.CreateAccount(customer, AccountTypes.Current, AccountBranches.Bergen);
            Account? shouldBeSavingsAccount = bank.CreateAccount(customer, AccountTypes.Savings, AccountBranches.Bergen);

            //verify
            Assert.That(shouldBeCurrentAccount, Is.Not.Null);
            Assert.That(shouldBeCurrentAccount!.GetAccountType(), Is.EqualTo(AccountTypes.Current));

            Assert.That(shouldBeSavingsAccount, Is.Not.Null);
            Assert.That(shouldBeSavingsAccount!.GetAccountType(), Is.EqualTo(AccountTypes.Savings));
        }

        [Test]
        public void TestCanGetAccountsByCustomer()
        {
            //setup
            Bank bank = new();
            Customer customer = new("K", "+4712345678");
            Account? a1 = bank.CreateAccount(customer, AccountTypes.Current, AccountBranches.Bergen);
            Account? a2 = bank.CreateAccount(customer, AccountTypes.Savings, AccountBranches.Bergen);

            //execute
            List<Account> accounts = bank.GetAccounts(customer);

            //verify
            Assert.That(accounts, Is.Not.Null);
            Assert.That(accounts.Count, Is.EqualTo(2));
            Assert.That(accounts.Contains(a1!));
            Assert.That(accounts.Contains(a2!));
        }
    }
}
