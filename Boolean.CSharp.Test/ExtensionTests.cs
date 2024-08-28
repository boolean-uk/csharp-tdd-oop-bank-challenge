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

            //run
            savingsAccount.ManagerAccess("password");
            decimal computed = savingsAccount.GetBranch();

            //Assert
            Assert.AreEqual(expected, computed);
        }
    }
}
