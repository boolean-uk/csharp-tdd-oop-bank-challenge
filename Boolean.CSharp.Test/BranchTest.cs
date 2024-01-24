using Boolean.CSharp.Main.Accounts;
using Boolean.CSharp.Main;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Test
{
    public class BranchTest
    {
        //User story 2: Branch Association
        //This test checks if a BankAccount can be associated with a Branch
        [Test]
        public void BankAccountCanBeAssociatedWithBranch()
        {
            //Arrange
            Branch branch = new Branch();
            SavingsAccount savingsAccount = new SavingsAccount();

            //Act
            branch.AddAccount(savingsAccount);

            //Assert
            Assert.IsTrue(branch.accounts.Contains(savingsAccount));

        }


        //Testing if the Branch can manage to add multiple Accounts
        [Test]
        public void BranchCanManageMultipleAccounts()
        {
            //Arrange
            Branch branch = new Branch();
            SavingsAccount savingsAccount1 = new SavingsAccount();
            SavingsAccount savingsAccount2 = new SavingsAccount();

            //Act
            branch.AddAccount(savingsAccount1);
            branch.AddAccount(savingsAccount2);

            //Assert

            Assert.IsTrue(branch.accounts.Contains(savingsAccount1));
            Assert.IsTrue(branch.accounts.Contains(savingsAccount2));
            Assert.AreEqual(2, branch.accounts.Count);
        }

        //Testing if the Branch can remove Account
        [Test]
        public void BranchCanRemoveAccount()
        {
            // Arrange
            Branch branch = new Branch();
            SavingsAccount savingsAccount = new SavingsAccount();
            branch.AddAccount(savingsAccount);

            // Act
            branch.RemoveAccount(savingsAccount);

            // Assert
            Assert.IsFalse(branch.accounts.Contains(savingsAccount));
            Assert.AreEqual(0, branch.accounts.Count);
        }
    }
}
