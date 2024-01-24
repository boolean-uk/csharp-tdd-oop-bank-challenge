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
        private Extension _extension;
        //private OverdraftManager _overdraftManager;
        public ExtensionTests()
        {
            _extension = new Extension();
           // _overdraftManager = new OverdraftManager();
        }
        [Test]
        public void GetBalanceBasedOnTransactionHistory()
        {
            //Arrange
            Branch branch = new Branch("NorwegianBranch");
            IAccount account = new Account(branch);

            //Act
            account.Deposit(1000, new DateTime(2022, 1, 10));
            account.Deposit(640, new DateTime(2022, 1, 12));
            account.Withdraw(140, new DateTime(2022, 1, 29));

            //Asssert
            account.PrintStatement();
            double calculatedBalance = account.GetBalance();
            Console.WriteLine($"Calculated balance: {calculatedBalance}");

            Assert.AreEqual(1500, calculatedBalance);

        }
        [Test]
        public void AccountShouldHaveAsscBranch()
        {
            Branch branch = new Branch("NorwegianBranch");
            IAccount account = new Account(branch);

            Branch associatedBranch = (account as Account)?.AssociatedBranch;

            Assert.IsNotNull(associatedBranch);
            Assert.AreEqual("NorwegianBranch", associatedBranch.BranchName);
            Console.WriteLine($"{associatedBranch.BranchName}");
        }

       /* [Test]
        public void AccountShouldOverdraft()
        {
            //Arrange
            Branch mainBranch = new Branch("NorwegianBranch");
            OverdraftManager overdraftManager = new OverdraftManager();
            IAccount account = new Account(mainBranch, overdraftManager);
            double initialBalance = account.GetBalance();
            double overdraftAmount = 200;

            //Act
            account.RequestOverdraft(overdraftAmount);

            //Assert
            Assert.IsTrue((account as Account)?.OverdraftApproved == true, "Overdraft should be approved");
            Assert.AreEqual(initialBalance, account.GetBalance(), "User's full amount should be adjusted");

            // Output user's full amount to the console
            Console.WriteLine($"User's full amount after overdraft approval: {account.GetBalance()}");
        }*/
    }
}
