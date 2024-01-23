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
        private object? expectedBalance;

        [Test]
        public void SavingsAccountGeneratesInterest()
        {
            // Arrange
            SavingsAccount savingsAccount = new SavingsAccount();

            // Act
            savingsAccount.Deposit(1000);
            savingsAccount.GenerateInterest(); // Assuming there's a method for generating interest

            // Assert
            Assert.AreEqual(expectedBalance, savingsAccount.GetBalanceWithInterest());
        }

        // Add more tests specific to SavingsAccount
    }
}
