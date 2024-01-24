using Boolean.CSharp.Main.Accounts;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Test
{
    public class SavingsAccountTest
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

    }
}






