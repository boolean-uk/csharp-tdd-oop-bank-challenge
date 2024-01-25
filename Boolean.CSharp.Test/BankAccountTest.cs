using Boolean.CSharp.Main.Accounts;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Test
{
    public class BankAccountTest
    {
        //User Story 1: Calculate Balance
        //This method tests if the CalculateBalance() method in the BankAccount class returns the correct balance based on the transaction history.

        [Test]
        public void CalculateBalance_ReturnsCorrectBalance()
        {
            //Arrange
            CurrentAccount bankAccount = new CurrentAccount();
            bankAccount.Deposit(1000);
            bankAccount.Withdraw(500);

            //Act
            double calculatedBalance = bankAccount.GetBalance();

            //Assert
            Assert.AreEqual(500, calculatedBalance); // The balance is expected to be 500 based on the transactions.
        }

    }
}

