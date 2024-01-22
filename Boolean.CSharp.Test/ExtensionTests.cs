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
            bool overdraft = _bankuser.requestOverdraft(_currentAccount, 100m);
            Assert.True(overdraft);
        }



        [Test]
        public void OverdraftRequestDenied()
        {

            
            Account account = _bankuser.Accounts[0];
            account.Deposit(100m);
            decimal balance = account.GetBalance();
            Assert.That(balance, Is.EqualTo(100m));

            _bankuser.requestOverdraft(account, 100m);
            string denied = _manager.denieOverdraft(_bankuser);
            Assert.That(denied, Is.EqualTo("denied"));

            decimal balance1 = account.GetBalance();
            Assert.That(balance1, Is.EqualTo(100m));

 

        }



        [Test]
        public void OverdraftRequestApproved()
        {
            Account accountnew = _bankuser.Accounts[0];
            accountnew.Deposit(100m);
            decimal balancenew = accountnew.GetBalance();
            Assert.That(balancenew, Is.EqualTo(100m));

            _bankuser.requestOverdraft(accountnew, 200m);
            string approved = _manager.approveOverdraft(_bankuser);
            Assert.That(approved, Is.EqualTo("denied"));

            decimal balancenew1 = accountnew.GetBalance();
            Assert.That(balancenew1, Is.EqualTo(-100m));
        }



    }
}


/*
send bank statements as message to phone - customer  
 */

