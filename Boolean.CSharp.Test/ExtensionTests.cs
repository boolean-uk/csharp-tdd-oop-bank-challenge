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
          bool result =  HQ.AddNewLocation(EBranches.Kristiansand);
          HQ.AddNewLocation(EBranches.Vanderbijlpark);

            Assert.That(HQ.AllBranches.Count >0);
            Assert.That(Enum.IsDefined(typeof(EBranches),EBranches.Kristiansand), Is.EqualTo(result == true));
        }

        [Test]
        public void AddUserToBranch()
        {
            HQ.AddNewLocation(EBranches.Vanderbijlpark);
            Branch branch = new Branch(EBranches.Johannesburg);

            branch.AddUser(DummyCustomer);

            Assert.That(DummyCustomer.Branch == branch.Id);
            Assert.That(branch.users.Count > 0);

        }
    }
}
