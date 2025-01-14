using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Accounts;
using Boolean.CSharp.Main.Enums;
using Boolean.CSharp.Main.Exceptions;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    public class AccountTest
    {

        [Test]
        public void SavingsAccountTest()
        {
            SavingsAccount account = new("Savings", 500, Branch.Trondheim);
            Assert.That(account, Is.Not.Null);
            Assert.That(account.Branch, Is.EqualTo(Branch.Trondheim));
            Assert.That(account.WithdrawalLimit, Is.EqualTo(500));
            Assert.That(account.WithdrawalLock, Is.LessThanOrEqualTo(DateTime.Now));
        }

        [Test]
        public void SavingsAccountDeposit()
        {
            SavingsAccount account = new("Savings", 500, Branch.Trondheim);
            double amount = 200;
            AccountTransaction transaction = account.Deposit(amount);
            Assert.That(transaction.Account, Is.EqualTo(account.AccountId));
            Assert.That(transaction.Amount, Is.EqualTo(amount));
            Assert.That(transaction.Created, Is.EqualTo(DateTime.Now).Within(1).Minutes);

            amount = -200;
            Assert.Throws<ArgumentException>(() => account.Deposit(amount));
        }

        [Test]
        public void SavingsAccountWithdrawalLimit()
        {
            DateTime withdrawalLock = DateTime.Now.AddDays(1);
            SavingsAccount account = new("Savings", 500, Branch.Trondheim);
            Assert.That(account.WithdrawalLock, Is.EqualTo(DateTime.Now).Within(1).Minutes);
            Assert.That(account.WithdrawalLimit, Is.EqualTo(500));
            account.WithdrawalLimit = 1000;
            Assert.That(account.WithdrawalLimit, Is.EqualTo(1000));

            account = new("Savings", 500, withdrawalLock, Branch.Trondheim);
            Assert.That(account.WithdrawalLock, Is.EqualTo(withdrawalLock).Within(1).Minutes);
            Assert.That(account.WithdrawalLimit, Is.EqualTo(500));
            account.WithdrawalLimit = 1000;
            Assert.That(account.WithdrawalLimit, Is.EqualTo(500));
        }

        [Test]
        public void SavingsAccountWithdraw()
        {
            double withdrawalLimit = 500;
            double depositAmount = 2000;
            double withdrawAmount = 200;
            SavingsAccount account = new("Savings", withdrawalLimit, Branch.Trondheim);
            account.Deposit(depositAmount);

            AccountTransaction transaction = account.Withdraw(withdrawAmount);
            Assert.That(transaction.Account, Is.EqualTo(account.AccountId));
            Assert.That(transaction.Amount, Is.EqualTo(-withdrawAmount));
            Assert.That(transaction.Created, Is.EqualTo(DateTime.Now).Within(1).Minutes);

            withdrawAmount += withdrawalLimit;
            Assert.Throws<LimitExceededException>(() => account.Withdraw(withdrawAmount));

            account.WithdrawalLimit = depositAmount + 100;
            Assert.Throws<InsufficientFundsException>(() => account.Withdraw(depositAmount + 50));

            account = new("Savings", withdrawalLimit, DateTime.Now.AddDays(3), Branch.Trondheim);
            Assert.Throws<LockedAccountException>(() => account.Withdraw(withdrawAmount));
        }

        [Test]
        public void RegularAccountTest()
        {
            RegularAccount account = new("Regular", Branch.Trondheim);
            Assert.That(account, Is.Not.Null);
            Assert.That(account.Branch, Is.EqualTo(Branch.Trondheim));
        }

        [Test]
        public void RegularAccountDeposit()
        {
            RegularAccount account = new("Regular", Branch.Trondheim);
            double amount = 200;
            AccountTransaction transaction = account.Deposit(amount);
            Assert.That(transaction.Account, Is.EqualTo(account.AccountId));
            Assert.That(transaction.Amount, Is.EqualTo(amount));
            Assert.That(transaction.Created, Is.EqualTo(DateTime.Now).Within(1).Minutes);

            amount = -200;
            Assert.Throws<ArgumentException>(() => account.Deposit(amount));
        }

        [Test]
        public void RegularAccountWithdraw()
        {
            double depositAmount = 2000;
            double withdrawAmount = 200;
            RegularAccount account = new("Regular", Branch.Trondheim);
            account.Deposit(depositAmount);

            AccountTransaction transaction = account.Withdraw(withdrawAmount);
            Assert.That(transaction.Account, Is.EqualTo(account.AccountId));
            Assert.That(transaction.Amount, Is.EqualTo(-withdrawAmount));
            Assert.That(transaction.Created, Is.EqualTo(DateTime.Now).Within(1).Minutes);

            Assert.Throws<InsufficientFundsException>(() => account.Withdraw(depositAmount + 50));
        }
    }
}
