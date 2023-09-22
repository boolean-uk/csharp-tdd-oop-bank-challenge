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
            var savingsAccount = new SavingsAccount(0.05m);

            savingsAccount.Deposit(1000);

            decimal expectedInterest = 4.17m; 

            decimal actualInterest = savingsAccount.CalculateInterest();

            Assert.AreEqual((double)expectedInterest, (double)actualInterest, 0.01);
        }

        [Test]
        public void TestCalculateInterestWithZeroBalance()
        {
            var savingsAccount = new SavingsAccount(0.05m);

            double tolerance = 0.01;

            Assert.AreEqual(0, (double)savingsAccount.CalculateBalance(), tolerance);
        }

        [Test]
        public void TestDailyWithdrawalLimit()
        {
            var savingsAccount = new SavingsAccount(0.05m); 

            Assert.Throws<InvalidOperationException>(() => savingsAccount.Withdraw(1500));
        }

        [Test]
        public void TestBranchAssociation()
        {
            var account = new Account();

            account.Branch = "Main Branch";

            Assert.AreEqual("Main Branch", account.Branch);
        }

        [Test]
        public void TestCalculateBalanceWithMultipleTransactions()
        {
            var account = new Account();
            account.Deposit(1000);
            account.Withdraw(500);
            account.Deposit(200);

            decimal expectedBalance = 700; 

            Assert.AreEqual(expectedBalance, account.CalculateBalance());
        }

        [Test]
        public void TestCalculateBalanceWithNoTransactions()
        {
            var account = new Account();

            decimal expectedBalance = 0;

            Assert.AreEqual(expectedBalance, account.CalculateBalance());
        }

        [Test]
        public void TestRequestOverdraft()
        {
            var currentAccount = new CurrentAccount(1000);

            currentAccount.RequestOverdraft(500);

            Assert.AreEqual(-500, currentAccount.CalculateBalance());
        }

        [Test]
        public void TestRejectOverdraftRequestExceedLimit()
        {
            var currentAccount = new CurrentAccount(1000);

            Assert.Throws<InvalidOperationException>(() => currentAccount.RequestOverdraft(1500));
        }


        [Test]
        public void TestApproveOverdraftRequests()
        {
            var currentAccount = new CurrentAccount(1000);

            currentAccount.RequestOverdraft(500);
            currentAccount.RequestOverdraft(300);

            currentAccount.ApproveOverdraftRequests();

            Assert.AreEqual(-800, currentAccount.CalculateBalance());
        }

        [Test]
        public void TestRejectOverdraftRequest()
        {
            var currentAccount = new CurrentAccount(1000);

            currentAccount.RequestOverdraft(500);

            Assert.AreEqual(-500, currentAccount.CalculateBalance());
        }

        [Test]
        public void TestAcceptOverdraftRequestWithinLimit()
        {
            var currentAccount = new CurrentAccount(1000);

            currentAccount.RequestOverdraft(500);

            Assert.AreEqual(-500, currentAccount.CalculateBalance());
        }

        [Test]
        public void TestRejectOverdraftRequestExceedsLimit()
        {
            var currentAccount = new CurrentAccount(1000);

            Assert.Throws<InvalidOperationException>(() => currentAccount.RequestOverdraft(1500));
        }

        // write a test for sending a statement as a message to a phone number

    }
}