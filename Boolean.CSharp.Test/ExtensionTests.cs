using BankingApp.Boolean.CSharp.Main;
using BankingApp.Boolean.CSharp.Main.Accounts;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public void BalanceIsBasedOnTransactionHistory()
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
        public void AccontCanBeAssociatetWithBranch()
        {
            var testAccount = new CurrentAccount
            {
                Branch = Branch.Amsterdam
            };

            Assert.AreEqual(Branch.Amsterdam, testAccount.Branch);
        }
    }
}
