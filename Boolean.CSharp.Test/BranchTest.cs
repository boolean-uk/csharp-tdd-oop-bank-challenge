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
        //User story 2: Branch Association (Extension)
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

        //User Story 3: Overdraft Request (Extension)
        //This test checks if a customer can request an overdraft on their account.
        [Test]
        public void CustomerCanRequestOverdraft()
        {
            //Arrange
            SavingsAccount savingsAccount = new SavingsAccount();
            Branch branch = new Branch();
            branch.AddAccount(savingsAccount);

            //Act
            bool overdraftRequested = savingsAccount.RequestOverdraft();

            //Assert
            Assert.IsTrue(overdraftRequested);
        }

        //
        [Test]
        public void CustomerCannotRequestOverdraftTwice()
        {
            //Arrange
            SavingsAccount savingsAccount = new SavingsAccount();
            Branch branch = new Branch();
            branch.AddAccount(savingsAccount);

            //Act
            bool firstOverdraftRequested = savingsAccount.RequestOverdraft();
            bool secondOverdraftRequested = savingsAccount.RequestOverdraft(); // Attempt to request overdraft again

            //Assert
            Assert.IsTrue(firstOverdraftRequested);
            Assert.IsFalse(secondOverdraftRequested);
        }
       
    }
}
