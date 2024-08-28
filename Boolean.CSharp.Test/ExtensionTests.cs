﻿using Boolean.CSharp.Main;
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
        public void PrintStatementTest()
        {
            //init
            SavingsAccount savingsAccount = new(500);
            savingsAccount.Deposit(543);
            savingsAccount.Withdraw(200);
            decimal expected = savingsAccount.GetBalance();

            //run
            savingsAccount.ManagerAccess("password");
            decimal computed = savingsAccount.CalculateBalance();

            //Assert
            Assert.AreEqual(expected, computed);
        }
    }
}
