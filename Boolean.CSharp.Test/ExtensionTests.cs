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
        private HeadQuarters HQ;
        private Private DummyCustomer;
        
        public ExtensionTests()
        {
            HQ = new HeadQuarters();
            DummyCustomer = new Private(51);
            

        }
        [Test]
        public void CalculateByTransactionHistory()
        {

            Business Engineer = new Business(HQ.GenerateUserId());

            Engineer.CreateCurrentAccount();
            Engineer.CurrentAccount.Deposit(1000);
            Engineer.CurrentAccount.Deposit(6000);
            Engineer.CurrentAccount.Withdraw(500);

            Engineer.CurrentAccount.CalculateBalance();

            Assert.That(Engineer.CurrentAccount.CalculateBalance(), Is.EqualTo(6500));
        }
        [Test]
        public void AddBranchToHQ()
        {
          bool result = HQ.AddNewLocation(Location.Kristiansand);
            HQ.AddNewLocation(Location.Vanderbijlpark);

            Assert.That(HQ.AllBranches.Count >0);
            Assert.That(Enum.IsDefined(typeof(Location), Location.Kristiansand), Is.EqualTo(result == true));
        }

        [Test]
        public void AddUserToBranch()
        {
            HQ.AddNewLocation(Location.Vanderbijlpark);
            Branch branch = new Branch(Location.Johannesburg);

            branch.AddUser(DummyCustomer);

            Assert.That(DummyCustomer.Branch == branch.Id);
            Assert.That(branch.users.Count > 0);

        }

        [Test]
        public void CheckTransactionStatusApproved()
        {
            DummyCustomer.CurrentAccount.Deposit(5000);
            DummyCustomer.CurrentAccount.Deposit(5000);
            string message = DummyCustomer.CurrentAccount.CheckTransactionStatus(1);
            Assert.That(message, Is.EqualTo("TransactionId: 1, Transaction status: approved. New Balance: 10000"));

        }
        [Test]
        public void TryingToWithdrawMoreThanBalance()
        {
            DummyCustomer.CurrentAccount.Deposit(5000);
            string message = DummyCustomer.CurrentAccount.Withdraw(17000);
            
            Assert.That(message, Is.EqualTo("Request is pending"));
        }


        [Test]
        public void RequestOverdraftStatusPending()
        {
            DummyCustomer.CreateCurrentAccount();
            DummyCustomer.CurrentAccount.Deposit(5000);
            decimal balance = DummyCustomer.CurrentAccount.Balance;

            Assert.That(balance < 20000m);
           
            KeyValuePair<int,string> Result = DummyCustomer.CurrentAccount.RequestOverdraft(20000);
            int id = Result.Key;
           string message = DummyCustomer.CurrentAccount.CheckTransactionStatus(id);
          
          Assert.That(Result.Value, Is.EqualTo("Request is pending"));
          Assert.That(message, Is.EqualTo("TransactionId:1, Overdraftrequest Status: pending"));
        }

        [Test]
        public void ManageOverdraftRequests()
        {
            Manager BankManager = new Manager(HQ.GenerateUserId());
            DummyCustomer.CreateCurrentAccount();
            DummyCustomer.CurrentAccount.Deposit(1000);
            DummyCustomer.CurrentAccount.Deposit(2000);
            KeyValuePair<int, string> Result = DummyCustomer.CurrentAccount.RequestOverdraft(5000);
            int id = Result.Key;
            string fail = DummyCustomer.ManageOverdraftRequests(DummyCustomer.CurrentAccount);
            BankManager.ManageOverdraftRequests(DummyCustomer.CurrentAccount);
            string message = DummyCustomer.CurrentAccount.CheckTransactionStatus(id);
            Assert.That(fail, Is.EqualTo("Administrator not approved"));
            Assert.That(Result.Value, Is.EqualTo("Request is pending"));
            Assert.That(message, Is.EqualTo("TransactionId: 2, Transaction status: approved. New Balance: -2000"));
            Assert.That(DummyCustomer.CurrentAccount.OverdraftRequests.Count, Is.EqualTo(0));
        }


    }
}
