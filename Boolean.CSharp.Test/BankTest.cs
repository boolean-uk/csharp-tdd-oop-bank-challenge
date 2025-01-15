using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Accounts;
using Boolean.CSharp.Main.Enums;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    public class BankTest
    {
        [Test]
        public void TestBank()
        {
            Bank bank = new Bank("secret");
            Assert.That(bank, Is.Not.Null);
        }

        [Test]
        public void TestCreateAccount()
        {
            string name = "A name";
            Branch branch = Branch.Trondheim;
            Bank bank = new Bank("secret");

            // Regular account
            Guid accountId = bank.CreateAccount(name, branch);
            Assert.That(accountId, Is.Not.Null);
            Account account = bank.GetAccount(accountId);
            Assert.That(account, Is.Not.Null);
            Assert.That(account.Name, Is.EqualTo(name));
            Assert.That(account.Branch, Is.EqualTo(branch));

            // Savings account
            double withdrawalLimit = 100;
            DateTime withdrawalLock = DateTime.Now;
            accountId = bank.CreateAccount(name, withdrawalLimit, withdrawalLock, branch);
            Assert.That(accountId, Is.Not.Null);
            account = bank.GetAccount(accountId);
            Assert.That(account, Is.Not.Null);
            Assert.That(account, Is.InstanceOf<SavingsAccount>());
            SavingsAccount savingsAccount = (SavingsAccount) account;
            Assert.That(savingsAccount.Name, Is.EqualTo(name));
            Assert.That(savingsAccount.Branch, Is.EqualTo(branch));
            Assert.That(savingsAccount.WithdrawalLimit, Is.EqualTo(withdrawalLimit));
            Assert.That(savingsAccount.WithdrawalLock, Is.EqualTo(withdrawalLock));
        }

        [Test]
        public void TestGetAccount()
        {
            // Most is tested during CreateAccount
            // Will be testing trying to get not exsisting account
            Bank bank = new Bank("secret");
            Assert.Throws<ArgumentException>(() => bank.GetAccount(new Guid()));
        }

        [Test]
        public void TestRequestOverdraft()
        {
            double amount = 10000;

            string name = "A name";
            Branch branch = Branch.Trondheim;
            Bank bank = new Bank("secret");
            Guid accountId = bank.CreateAccount(name, branch);
            Account account = bank.GetAccount(accountId);
            account.Deposit(10);

            Assert.Throws<ArgumentException>(() => bank.RequestOverdraft(new Guid(), 1000));

            ArgumentException? ex = Assert.Throws<ArgumentException>(() => bank.RequestOverdraft(accountId, 1));
            Assert.That(ex.Message, Is.EqualTo("You have that amount available, you do not need an overdraft!"));

            int overdraftId = bank.RequestOverdraft(accountId, amount);
            Assert.That(bank.GetOverdraftStatus(overdraftId).Item1, Is.EqualTo(1));
            Assert.That(bank.GetOverdraftRequests(overdraftId).Item1, Is.EqualTo(accountId));
            Assert.That(bank.GetOverdraftRequests(overdraftId).Item2, Is.EqualTo(amount));
        }

        [Test]
        public void TestHandleOverdraftRequest()
        {
            double amount = 10000;

            string name = "A name";
            Branch branch = Branch.Trondheim;
            Bank bank = new Bank("secret");
            Guid accountId = bank.CreateAccount(name, branch);
            Account account = bank.GetAccount(accountId);
            double balance = account.Balance;

            // Invalid Id
            ArgumentException? ex = Assert.Throws<ArgumentException>(() => bank.HandleOverdraftRequest(-1, false));
            Assert.That(ex.Message, Is.EqualTo("That request does not exsist!"));

            // Rejected
            int overdraftId = bank.RequestOverdraft(accountId, amount);
            Assert.That(bank.GetOverdraftStatus(overdraftId).Item1, Is.EqualTo(1));
            bank.HandleOverdraftRequest(overdraftId, false);
            Assert.That(bank.GetOverdraftStatus(overdraftId).Item1, Is.EqualTo(0));
            Assert.That(account.Balance, Is.EqualTo(balance));

            // Accepted
            overdraftId = bank.RequestOverdraft(accountId, amount);
            Assert.That(bank.GetOverdraftStatus(overdraftId).Item1, Is.EqualTo(1));
            bank.HandleOverdraftRequest(overdraftId, true);
            Assert.That(bank.GetOverdraftStatus(overdraftId).Item1, Is.EqualTo(2));
            Assert.That(account.Balance, Is.EqualTo(balance - amount));
        }
    }
}
