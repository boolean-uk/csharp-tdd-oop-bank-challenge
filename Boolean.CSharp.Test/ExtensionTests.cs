using BankingApp.Boolean.CSharp.Main;
using BankingApp.Boolean.CSharp.Main.Accounts;
using BankingApp.Boolean.CSharp.Main.Overdraft;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class ExtensionTests
    {
        private Extension _extension;
        public ExtensionTests()
        {
            _extension = new Extension();
        }


        //As an engineer,
        //So I don't need to keep track of state,
        //I want account balances to be calculated based on transaction history instead of stored in memory.
        [Test]
        public void BalanceIsBasedOnTransactionHistoryTest()
        {
            var testAccount = new CurrentAccount();

            testAccount.Deposit(DateTime.Now, 600);
            testAccount.Withdraw(DateTime.Now.AddHours(1), 300);

            Assert.AreEqual(300, testAccount.Balance);



        }
        // As a bank manager,
        //So I can expand,
        //I want accounts to be associated with specific branches.
        [Test]
        public void AccontCanBeAssociatetWithBranchTest()
        {
            var testAccount = new CurrentAccount
            {
                Branch = Branch.Amsterdam
            };

            Assert.AreEqual(Branch.Amsterdam, testAccount.Branch);
        }

        //As a customer,
        //So I have an emergency fund,
        //I want to be able to request an overdraft on my account.
        [Test]
        public void RequestAnOverdraftTest()
        {
            var testAccount = new CurrentAccount();
            var request = new OverdraftRequest
            {
                Account = testAccount,
                RequestedAmount = 200
            };

            testAccount.OverdraftHistory.AddRequest(request);

            Assert.Contains(request, testAccount.OverdraftHistory.Requests);
        }
        //As a bank manager,
        //So I can safeguard our funds,
        //I want to approve or reject overdraft requests.
        [Test]
        public void ApproveOverdraftTest()
        {
            var testAccount = new CurrentAccount();
            var request = new OverdraftRequest
            {
                Account = testAccount,
                RequestedAmount = 200
            };

            testAccount.OverdraftHistory.AddRequest(request);
            testAccount.OverdraftHistory.ApproveRequest(request);

            Assert.IsTrue(request.IsApproved);
            Assert.AreEqual(200, testAccount.OverdraftLimit);
        }

        //As a customer,
        //So I can stay up to date,
        //I want statements to be sent as messages to my phone.



    }
}
