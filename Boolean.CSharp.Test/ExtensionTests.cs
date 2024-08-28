using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Bank;
using Boolean.CSharp.Main.Bank.AccountTypes;
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
        private Extension _extension;
        public ExtensionTests()
        {
            _extension = new Extension();
        }

        //5. As an engineer, So I don't need to keep track of state, I want account balances to be calculated based on transaction history instead of stored in memory.
        [Test]
        public void CanGetBalanceFromTransactionHistoryTest()
        {
            decimal expectedBalance = 2500.00M;
            CurrentAccount currentAccount = new CurrentAccount("Current");
            currentAccount.MakeDeposit(1000.00M);
            currentAccount.MakeDeposit(2000.00M);
            currentAccount.MakeWithdrawal(500.00M);

            decimal actualBalance = currentAccount.GetBalance();

            Assert.That(actualBalance, Is.EqualTo(expectedBalance));
        }

        //6. As a bank manager, So I can expand, I want accounts to be associated with specific branches.
        [Test]
        public void CanGetAssociatedBranchTest()
        {
            Branch branch = new Branch() { BranchName = "Trondheim" };
            CurrentAccount currentAccount = new CurrentAccount("Current");
            SavingsAccount savingsAccount = new SavingsAccount("Savings");
            branch.AddAccount(currentAccount);
            branch.AddAccount(savingsAccount);

            foreach (Account account in branch.MyAccounts) 
            { 
                Assert.That(account.BranchName == branch.BranchName); 
            }

        }

        //7. 7. As a customer, So I have an emergency fund, I want to be able to request an overdraft on my account.
        //8. As a bank manager, So I can safeguard our funds, I want to approve or reject overdraft requests.
        [Test]
        public void CanOverdraftAccountTest()
        {
            CurrentAccount currentAccount = new CurrentAccount("Current");

            bool canOverDraft = currentAccount.MakeWithdrawal(500.00M);

            Assert.That(canOverDraft, Is.True);

        }


    }
}
