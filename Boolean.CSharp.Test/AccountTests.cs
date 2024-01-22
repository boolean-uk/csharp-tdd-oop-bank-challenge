using Boolean.CSharp.Main;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class AccountTests
    {
        [Test]
        // Currently testing with null owner because user is not implemented yet
        public void TestCurrentAccountCreation()
        {
            Account account = new CurrentAccount(null);

            Assert.That(account.Balance, Is.EqualTo(0));
            Assert.That(account.Owner, Is.Null);
            Assert.That(account.Transactions.Count, Is.EqualTo(0));
        }

        [Test]
        public void TestSavingsAccountCreation()
        {
            Account account = new SavingsAccount(null);

            Assert.That(account.Balance, Is.EqualTo(0));
            Assert.That(account.Owner, Is.Null);
            Assert.That(account.Transactions.Count, Is.EqualTo(0));
        }

        [Test]
        public void TestInitialBalanceCreation()
        {
            Account account = new SavingsAccount(null, 200);

            Assert.That(account.Balance, Is.EqualTo(200));
            Assert.That(account.Transactions.Count, Is.EqualTo(0));
        }

        [Test]
        public void TestAccountDeposit()
        {
            Account account = new SavingsAccount(null);

            account.Deposit(100);

            Assert.That(account.Balance, Is.EqualTo(1));
            Assert.That(account.Transactions.Count, Is.EqualTo(1));
        }

        [Test]
        public void TestAccountWithdrawalFail()
        {
            Account account = new SavingsAccount(null);

            Assert.That(account.Withdraw(100), Is.False);
            Assert.That(account.Balance, Is.EqualTo(0));
            Assert.That(account.Transactions.Count, Is.EqualTo(0));
        }

        [Test]
        public void TestAccountWithdrawal()
        {
            Account account = new SavingsAccount(null);

            account.Deposit(200);

            Assert.That(account.Withdraw(100), Is.True);
            Assert.That(account.Balance, Is.EqualTo(100));
            Assert.That(account.Transactions.Count, Is.EqualTo((2)));
        }
    }
}
