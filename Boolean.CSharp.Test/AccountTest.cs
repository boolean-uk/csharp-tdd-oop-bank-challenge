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
        public void RegularAccountTest()
        {
            RegularAccount account = new("Regular", Branch.Trondheim);
            Assert.That(account, Is.Not.Null);
            Assert.That(account.Branch, Is.EqualTo(Branch.Trondheim));
        }

        [Test]
        public void RegularAccountDepositTest()
        {
            RegularAccount account = new("Regular", Branch.Trondheim);
            double amount = 200;
            AccountTransaction transaction = account.Deposit(amount);
            Assert.That(transaction.Account, Is.EqualTo(account.AccountId));
            Assert.That(transaction.Amount, Is.EqualTo(amount));
            Assert.That(transaction.Created, Is.EqualTo(DateTime.Now).Within(1).Minutes);

            amount = -200;
            Assert.Throws<IllegalOperationException>(() => account.Deposit(amount));
        }

        [Test]
        public void RegularAccountWithdrawTest()
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

        [Test]
        public void RegularAccountBalanceTest()
        {
            List<AccountTransaction> transactions = new List<AccountTransaction>();
            RegularAccount account = new("Regular", Branch.Trondheim);
            transactions.Add(account.Deposit(1000));
            Assert.That(account.Transactions, Is.EquivalentTo(transactions));
            Assert.That(account.Balance, Is.EqualTo(1000));

            transactions.Add(account.Withdraw(500));
            Assert.That(account.Transactions, Is.EquivalentTo(transactions));
            Assert.That(account.Balance, Is.EqualTo(500));

            transactions.Add(account.Deposit(9999));
            transactions.Add(account.Deposit(2));
            transactions.Add(account.Withdraw(1200));
            transactions.Add(account.Deposit(20000));
            transactions.Add(account.Withdraw(12000));
            transactions.Add(account.Withdraw(99));

            Assert.That(account.Transactions, Is.EquivalentTo(transactions));
            Assert.That(account.Balance, Is.EqualTo(transactions.Sum(i => i.Amount)));
        }

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
        public void SavingsAccountWithdrawalLimitTest()
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
        public void SavingsAccountWithdrawTest()
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
            Assert.Throws<LockedAccountException>(() => account.Withdraw(withdrawalLimit - 1));
        }

    }
}
