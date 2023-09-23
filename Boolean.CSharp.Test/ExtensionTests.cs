using Boolean.CSharp.Main;
using NUnit.Framework;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class ExtensionTests
    {
        [Test]
        public void TestCalculateInterest()
        {
            var savingsAccount = new SavingsAccount(0.05m, "Savings Branch");

            savingsAccount.Deposit(1000);

            decimal expectedInterest = 4.17m; 

            decimal actualInterest = savingsAccount.CalculateInterest();

            Assert.AreEqual((double)expectedInterest, (double)actualInterest, 0.01);
        }

        [Test]
        public void TestCalculateInterestWithZeroBalance()
        {
            var savingsAccount = new SavingsAccount(0.05m, "Savings Branch");

            double tolerance = 0.01;

            Assert.AreEqual(0, (double)savingsAccount.CalculateBalance(), tolerance);
        }

        [Test]
        public void TestDailyWithdrawalLimit()
        {
            var savingsAccount = new SavingsAccount(0.05m, "Savings Branch");

            Assert.Throws<InvalidOperationException>(() => savingsAccount.Withdraw(1500));
        }

        [Test]
        public void TestCalculateBalanceWithMultipleTransactions()
        {
            var account = new Account("Main Branch");

            account.Deposit(1000);

            account.Withdraw(500);

            account.Deposit(200);

            decimal expectedBalance = 700; 

            Assert.AreEqual(expectedBalance, account.CalculateBalance());
        }

        [Test]
        public void TestCalculateBalanceWithNoTransactions()
        {
            var account = new Account("Main Branch");

            decimal expectedBalance = 0;

            Assert.AreEqual(expectedBalance, account.CalculateBalance());
        }

        [Test]
        public void TestOverdraftRequest()
        {
            var currentAccount = new CurrentAccount(1000, "Current Branch");

            currentAccount.RequestOverdraft(500);

            currentAccount.ApproveOverdraftRequests();

            Assert.AreEqual(-500, currentAccount.CalculateBalance());
        }

        [Test]
        public void TestApproveOverdraftRequest()
        {
            var currentAccount = new CurrentAccount(1000, "Current Branch");

            currentAccount.RequestOverdraft(500);
            currentAccount.RequestOverdraft(300);

            currentAccount.ApproveOverdraftRequests();

            Assert.AreEqual(-800, currentAccount.CalculateBalance());
        }

        [Test]
        public void TestRejectOverdraftRequest()
        {
            var currentAccount = new CurrentAccount(1000, "Current Branch");

            Assert.Throws<InvalidOperationException>(() => currentAccount.RequestOverdraft(1500));
        }

        [Test]
        public void TestAccountBranchAssociation()
        {
            var account = new Account("Main Branch"); 

            Assert.AreEqual("Main Branch", account.Branch);
        }

        [Test]
        public void TestCurrentAccountBranchAssociation()
        {
            var currentAccount = new CurrentAccount(1000, "Current Branch"); 

            Assert.AreEqual("Current Branch", currentAccount.Branch);
        }

        [Test]
        public void TestSavingsAccountBranchAssociation()
        {
            var savingsAccount = new SavingsAccount(0.05m, "Savings Branch"); 

            Assert.AreEqual("Savings Branch", savingsAccount.Branch);
        }

        [Test]
        public void TestAccountsWithSameBranch()
        {
            var currentAccount = new CurrentAccount(1000, "Main Branch");
            var savingsAccount = new SavingsAccount(0.05m, "Main Branch");

            Assert.AreEqual("Main Branch", currentAccount.Branch);
            Assert.AreEqual("Main Branch", savingsAccount.Branch);
        }

        [Test]
        public void TestAccountsWithDifferentBranches()
        {
            var currentAccount = new CurrentAccount(1000, "Main Branch");
            var savingsAccount = new SavingsAccount(0.05m, "Downtown Branch");

            Assert.AreNotEqual(currentAccount.Branch, savingsAccount.Branch);
        }

        // write a test for sending a statement as a message to a phone number

    }
}