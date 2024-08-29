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
        [Test]
        public void CalculateBalanceTest()
        {
            //init
            SavingsAccount savingsAccount = new(500);
            savingsAccount.Deposit(543);
            savingsAccount.Withdraw(200);
            decimal expected = savingsAccount.GetBalance();

            //run
            savingsAccount.EngineerAccess("password");
            decimal computed = savingsAccount.CalculateBalance();

            //Assert
            Assert.AreEqual(expected, computed);
        }
        [Test]
        public void GetBranchTest()
        {
            //init
            SavingsAccount savingsAccount = new(500);
            savingsAccount.Deposit(543);
            savingsAccount.Withdraw(200);
            Branch expected = Branch.Oslo;
            savingsAccount.SetBranch(expected);

            //run
            savingsAccount.ManagerAccess("password");
            Branch computed = savingsAccount.GetBranch();

            //Assert
            Assert.AreEqual(expected, computed);
        }
        [Test]
        public void OverDraftTest()
        {
            //init
            Account Account = new(500);
            Account.Withdraw(600);

            //run
            Account.RequestOverdraft();


            //Assert
            Assert.IsTrue(Account.OverDraftRequest == true);
        }
        [Test]
        public void OverDraftDenial()
        {
            //innit
            Account Account = new(500);
            bool expected = true;

            //run
            bool computed = Account.Withdraw(600);


            //Assert
            Assert.IsTrue(expected == computed);

        }
    }
}
