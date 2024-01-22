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
        public ExtensionTests()
        {
            _extension = new Extension();
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
    }
}
