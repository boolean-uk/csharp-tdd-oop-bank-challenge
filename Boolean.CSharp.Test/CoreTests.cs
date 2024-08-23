using Boolean.CSharp.Main.BankAndAccounts;
using Boolean.CSharp.Main.Branches;
using Boolean.CSharp.Main.Customers;
using NUnit.Framework;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics;

/*
## User Stories

```
As a customer,
So I can safely store use my money,
I want to create a current account.

As a customer,
So I can save for a rainy day,
I want to create a savings account.

As a customer,
So I can keep a record of my finances,
I want to generate bank statements with transaction dates, amounts, and balance at the time of transaction.

As a customer,
So I can use my account,
I want to deposit and withdraw funds.
```
*/

namespace Boolean.CSharp.Test
{
    public class CoreTests
    {
        [Test]
        public void CreateCurrentAccountTest()
        {
            //Arrange
            Bank bank = new Bank();
            Joaquin joaquin = new Joaquin();
            MasterCard mastercard = new MasterCard();

            //Act
            bool result = bank.CreateCurrent(joaquin, mastercard);
            bool duplicate = bank.CreateCurrent(joaquin, mastercard);

            //Assert
            Assert.That(result, Is.True);
            Assert.That(duplicate, Is.False);
        }

        [Test]
        public void CreateSavingAccountTest()
        {
            //Arrange
            Bank bank = new Bank();
            Joaquin joaquin = new Joaquin();
            MasterCard mastercard = new MasterCard();

            //Act
            bool result = bank.CreateSaving(joaquin, mastercard);
            bool duplicate = bank.CreateSaving(joaquin, mastercard);

            //Assert
            Assert.That(result, Is.True);
            Assert.That(duplicate, Is.False);
        }

        [Test]
        public void TransactionHistoryTest()
        {
            //Arrange
            Bank bank = new Bank();
            Joaquin joaquin = new Joaquin();
            MasterCard mastercard = new MasterCard();
            bank.CreateCurrent(joaquin, mastercard);
            bank.CreateSaving(joaquin, mastercard);

            //Act
            string resultCurrent = bank.GetTransactionHistory(joaquin, true);
            string resultSavings = bank.GetTransactionHistory(joaquin, false);

            //Assert
            Assert.That(resultCurrent, !Is.EqualTo(string.Empty));
            Assert.That(resultSavings, !Is.EqualTo(string.Empty));
        }


        [Test]
        public void DepositAndWithdrawTest()
        {
            //Arrange
            Bank bank = new Bank();
            Joaquin joaquin = new Joaquin();
            MasterCard mastercard = new MasterCard();
            bank.CreateCurrent(joaquin, mastercard);
            bank.CreateSaving(joaquin, mastercard);
            
            bank.HandleDeposit(joaquin, 100, true); //Deposit to current
            bank.HandleDeposit(joaquin, 100, false); //Deposit to savings
            
            
            //Act
            bool resultSuccess = bank.HandleWithdraw(joaquin, 100, true);
            bool resultFailure = bank.HandleWithdraw(joaquin, 101, false);

            //Assert
            Assert.That(resultSuccess, Is.True);
            Assert.That(resultFailure, Is.False);
        }

        [Test]
        public void AcceptanceCriteriaTest()
        {
            //Arrange
            Bank bank = new Bank();
            Joaquin joaquin = new Joaquin();
            MasterCard mastercard = new MasterCard();
            bank.CreateCurrent(joaquin, mastercard);

            bank.HandleDeposit(joaquin, 1000, true);
            bank.HandleDeposit(joaquin, 2000, true);
            bank.HandleWithdraw(joaquin, 500, true);

            //Act
            string result = bank.GetTransactionHistory(joaquin, true);
            decimal balance = bank.GetBalance(joaquin, true);

            //Assert
            Assert.That(result, !Is.EqualTo(string.Empty));
            Assert.That(balance, Is.EqualTo(2500));
        }

    }
}