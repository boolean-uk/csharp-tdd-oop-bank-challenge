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
    public class ExtensionTests
    {
        private BankUser _bankuser;
        private CurrentAccount _currentAccount;
        private Account _savingsAccount;
        private Manager _manager;

        [SetUp]
        public void SetUp()
        {
            _bankuser = new BankUser();
            _savingsAccount = new SavingsAccount();
            _manager = new Manager();
            _currentAccount = new CurrentAccount();
        }


        [Test]
        public void accountAssociatedToBranch()
        {
            bool branch = _savingsAccount.setBranch("branch");
            Assert.That(branch, Is.True);

            Assert.That(_savingsAccount.branch, Is.EqualTo("branch"));

            //change branch to same branch
            bool branchAgain = _savingsAccount.setBranch("branch");
            Assert.That(branchAgain, Is.True);
            Assert.That(_savingsAccount.branch, Is.EqualTo("branch"));
        }


        [Test]
        public void accountAssociatedToEmptyStringFalse()
        {
            bool branchEmpty = _currentAccount.setBranch("");
            Assert.That(branchEmpty, Is.False);
        }



        [Test]
        public void RequestOverdraft()
        {
            bool overdraft = _savingsAccount.requestOverdraft(100m);
            Assert.True(overdraft);
        }



        [Test]
        public void OverdraftRequestDenied()
        {

            _bankuser.CreateCurrentAccount();
            Account account = _bankuser.Accounts[0];
            account.Deposit(100m);
            decimal balance = account.GetBalance();
            Assert.That(balance, Is.EqualTo(100m));

            account.requestOverdraft(100m);
            string denied = account.denieOverdraft(100m);
            Assert.That(denied, Is.EqualTo("denied"));

            decimal balance1 = account.GetBalance();
            Assert.That(balance1, Is.EqualTo(100m));

 

        }



        [Test]
        public void OverdraftRequestApproved()
        {
            _bankuser.CreateCurrentAccount();
            Account accountnew = _bankuser.Accounts[0];
            accountnew.Deposit(100m);
            decimal balancenew = accountnew.GetBalance();
            Assert.That(balancenew, Is.EqualTo(100m));

            accountnew.requestOverdraft(200m);
            string approved = accountnew.approveOverdraft(200m);
            Assert.That(approved, Is.EqualTo("approved"));

            decimal balancenew1 = accountnew.GetBalance();
            Assert.That(balancenew1, Is.EqualTo(-100m));
        }


        [Test]
        public void sendToPhone()
        {
            SavingsAccount account = new SavingsAccount();

            // Mock transactions
            account.Deposit(100m);
            account.Withdraw(50m);
            account.Deposit(200m);

            // Expected statement
            string expectedStatement =
                "Transaction Date: " + DateTime.Today.Date.ToString("dd-MM-yyyy HH:mm:ss") + Environment.NewLine +
                "Credit: 100" + Environment.NewLine +
                "Debit: 0" + Environment.NewLine +
                "Balance at the time of transaction: 100" + Environment.NewLine +
                Environment.NewLine +
                "Transaction Date: " + DateTime.Today.Date.ToString("dd-MM-yyyy HH:mm:ss") + Environment.NewLine +
                "Credit: 0" + Environment.NewLine +
                "Debit: 50" + Environment.NewLine +
                "Balance at the time of transaction: 50" + Environment.NewLine +
                Environment.NewLine +
                "Transaction Date: " + DateTime.Today.Date.ToString("dd-MM-yyyy HH:mm:ss") + Environment.NewLine +
                "Credit: 200" + Environment.NewLine +
                "Debit: 0" + Environment.NewLine +
                "Balance at the time of transaction: 250" + Environment.NewLine + Environment.NewLine + Environment.NewLine;

            // Act
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            // Call the method that contains Console.WriteLine
             account.sendToPhone("12345678");

            string result = sw.ToString();

            // Assert the output
            Assert.AreEqual(expectedStatement, result);


        }


    }
}


