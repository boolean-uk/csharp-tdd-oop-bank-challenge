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
        }



        [Test]
        public void DepositNegativeAmountCurrentAccount()
        {
            bool CurrentAccountNegative = _bankuser.CreateCurrentAccount();
            CurrentAccount currentAccountDepositNegative = _bankuser.Accounts.First() as CurrentAccount;

            Assert.IsFalse(currentAccountDepositNegative.Deposit(-100m));
            Assert.Throws<ArgumentException>(() => currentAccountDepositNegative.Deposit(-100m));
        }




        [Test]
        public void WithdrawalFromCurrentAccount()
        {
            bool CurrentAccountWithdr = _bankuser.CreateCurrentAccount();
            CurrentAccount currentAccountWithdraw = _bankuser.Accounts.First() as CurrentAccount;
            currentAccountWithdraw.Withdraw(1000m);
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

            Assert.IsFalse(accountBalanceTooLow.Withdraw(-100m));
            Assert.Throws<ArgumentException>(() => accountBalanceTooLow.Withdraw(-100m));
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
            Assert.Throws<ArgumentException>(() => savingsAccountDepositNegative.Deposit(-100m));
        }

        
        [Test]
        public void Account_RecordTransaction_ShouldAddTransaction()
        {
            // Arrange
            SavingsAccount account = new SavingsAccount();
            Main.Transaction expectedTransaction = new Main.Transaction(DateTime.Now, 500m, 0m);

            // Act
            account.Deposit(100m);

            // Assert
            CollectionAssert.Contains(account.Transactions, expectedTransaction);
        }

        [Test]
        public void CurrentAccount_GenerateStatement_ShouldReturnCorrectStatement()
        {
            // Arrange
            CurrentAccount currentAccount = new CurrentAccount();

            // Act
            string statement = currentAccount.GenerateStatement();

            // Assert
            Assert.AreEqual("Current Account Statement", statement);
        }

        [Test]
        public void SavingsAccount_GenerateStatement_ShouldReturnCorrectStatement()
        {
            // Arrange
            SavingsAccount savingsAccount = new SavingsAccount();

            // Act
            string statement = savingsAccount.GenerateStatement();

            // Assert
            Assert.AreEqual("Savings Account Statement", statement);
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