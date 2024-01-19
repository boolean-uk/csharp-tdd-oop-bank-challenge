using Boolean.CSharp.Main;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using System;
using System.Security.Principal;
using System.Transactions;
using System.Xml;
//using Transaction = Boolean.CSharp.Main.Transaction;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CoreTests
    {
        private BankUser _bankuser;
        private CurrentAccount _currentAccount;
        private SavingsAccount _savingsAccount;

        [SetUp]
        public void SetUp()
        {
            _bankuser = new BankUser();
        }

        [Test]
        public void creatingNewBankUser() 
        {  
            //testing that creating new BankUser gives an empty list of accounts
            Assert.That(_bankuser.Accounts.Count, Is.EqualTo(0) );

        }

        [Test]
        public void creatingNewSavingsAccount() 
        {
            bool SavingsAccountCreated = _bankuser.CreateSavingsAccount();
            SavingsAccount savingsAccount = _bankuser.Accounts.First() as SavingsAccount;

            //testing that the new savings account is created and has balance 0
            Assert.That(SavingsAccountCreated, Is.True);
            Assert.That(savingsAccount.GetBalance(), Is.EqualTo(0m));

            //testing that it was added to the BankUser's list of accounts
            Assert.That(_bankuser.Accounts.Contains(savingsAccount));
            //Assert.That(_bankuser.Accounts.Contains(savingsAccount), Is.True);

        }


    [Test]
        public void creatingNewCurrentAccount()
        {
            bool CurrentAccountCreated = _bankuser.CreateCurrentAccount();
            CurrentAccount currentAccount = _bankuser.Accounts.First() as CurrentAccount;

            //testing that the new current account is created and has balance 0
            Assert.That(CurrentAccountCreated, Is.True);
            Assert.That(currentAccount.GetBalance(), Is.EqualTo(0m));


            //testing that it was added to the BankUser's list of accounts
            Assert.IsTrue(_bankuser.Accounts.Contains(currentAccount));
            Assert.AreEqual(1, _bankuser.Accounts.Count);
        }


        [Test]
        public void DepositIntoCurrentAccount()
        {
            bool CurrentAccount = _bankuser.CreateCurrentAccount();
            CurrentAccount currentAccountDeposit = _bankuser.Accounts.First() as CurrentAccount;
            bool CurrentAccountDeposit = currentAccountDeposit.Deposit(1000m);

            Assert.IsTrue(CurrentAccountDeposit);
            Assert.That(currentAccountDeposit.GetBalance(), Is.EqualTo(1000m));

            bool CurrentAccountDepositAgain = currentAccountDeposit.Deposit(1000m);
            Assert.IsTrue(CurrentAccountDepositAgain);
            Assert.That(currentAccountDeposit.GetBalance(), Is.EqualTo(2000m));
        }



        [Test]
        public void DepositNegativeAmountCurrentAccount()
        {
            bool CurrentAccountNegative = _bankuser.CreateCurrentAccount();
            CurrentAccount currentAccountDepositNegative = _bankuser.Accounts.First() as CurrentAccount;

            Assert.IsFalse(currentAccountDepositNegative.Deposit(-100m));

            //checking that nothing has been deposited
            Assert.That(currentAccountDepositNegative.GetBalance(), Is.EqualTo(0m));
          
        }




        [Test]
        public void WithdrawalFromCurrentAccount()
        {
            bool CurrentAccountWithdr = _bankuser.CreateCurrentAccount();
            CurrentAccount currentAccountWithdraw = _bankuser.Accounts.First() as CurrentAccount;
            currentAccountWithdraw.Deposit(1000m);
            bool CurrentAccountWithdrawal = currentAccountWithdraw.Withdraw(500m);

            Assert.IsTrue(CurrentAccountWithdrawal);
            Assert.That(currentAccountWithdraw.GetBalance(), Is.EqualTo(500m));
        }



        [Test]
        public void WithdrawMoreThanBalance()
        {
            bool AccountBalanceTooLow = _bankuser.CreateSavingsAccount();
            SavingsAccount accountBalanceTooLow = _bankuser.Accounts.First() as SavingsAccount;
            accountBalanceTooLow.Deposit(50m);
            Assert.That(accountBalanceTooLow.GetBalance(), Is.EqualTo(50m));

            Assert.IsFalse(accountBalanceTooLow.Withdraw(-100m));

            //testing if the balance is unchanged
            Assert.That(accountBalanceTooLow.GetBalance(), Is.EqualTo(50m));
        }


        [Test]
        public void DepositIntoSavingsAccount()
        {
            bool SavAccount = _bankuser.CreateSavingsAccount();
            SavingsAccount savingsAccountDeposit = _bankuser.Accounts.First() as SavingsAccount;
            bool SavAccountDeposit = savingsAccountDeposit.Deposit(1000m);

            Assert.IsTrue(SavAccount);
            Assert.That(savingsAccountDeposit.GetBalance(), Is.EqualTo(1000m));
        }


        [Test]
        public void DepositNegativeAmountSavingsAccount()
        {
            bool SavingsAccountNegative = _bankuser.CreateSavingsAccount();
            SavingsAccount savingsAccountDepositNegative = _bankuser.Accounts.First() as SavingsAccount;

            Assert.IsFalse(savingsAccountDepositNegative.Deposit(-100m));
            //checking that nothing has been deposited
            Assert.That(savingsAccountDepositNegative.GetBalance(), Is.EqualTo(0m));
        }



        [Test]
        public void Account_GenerateStatement_ShouldReturnCorrectStatement()
        {
            SavingsAccount account = new SavingsAccount();

            // Mock transactions
            account.Deposit(100m);
            account.Withdraw(50m);
            account.Deposit(200m);

            // Expected statement
            string expectedStatement =
                "Transaction Date: " + DateTime.Today.Date.ToString("dd-MM-yyyy HH:mm:ss") + Environment.NewLine +
                "Credit: 100" + Environment.NewLine +
                "Debit: 0" + Environment.NewLine +
                "Balance at the time of transaction: 100" + Environment.NewLine +
                Environment.NewLine +
                "Transaction Date: " + DateTime.Today.Date.ToString("dd-MM-yyyy HH:mm:ss") + Environment.NewLine +
                "Credit: 0" + Environment.NewLine +
                "Debit: 50" + Environment.NewLine +
                "Balance at the time of transaction: 50" + Environment.NewLine +
                Environment.NewLine +
                "Transaction Date: " + DateTime.Today.Date.ToString("dd-MM-yyyy HH:mm:ss") + Environment.NewLine +
                "Credit: 200" + Environment.NewLine +
                "Debit: 0" + Environment.NewLine +
                "Balance at the time of transaction: 250" + Environment.NewLine +
                Environment.NewLine;

            // Act
            string generatedStatement = account.GenerateStatement();

            // Assert
            Assert.AreEqual(expectedStatement, generatedStatement);
        }



        [Test]
        public void TransactionPropertiesTest()
        {
            Main.Transaction transaction = new Main.Transaction(DateTime.Now, 500m, 0m);

            Assert.That(transaction.Date, Is.EqualTo(DateTime.Now).Within(1).Seconds); // Allow a small time difference
            Assert.That(transaction.Credit, Is.EqualTo(500m));
            Assert.That(transaction.Debit, Is.EqualTo(0m));
        }


        [Test]
        public void TransactionInvalidPropertiesTest()
        {
            Assert.Throws<ArgumentException>(() => new Main.Transaction(DateTime.Now, 500m, 10m));
            // The transaction can only have deposit or credit, not both at the same time.
        }





    }
}