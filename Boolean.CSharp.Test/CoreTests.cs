using System.Runtime.InteropServices;
using Boolean.CSharp.Main;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CoreTest
    {
        
        [TestCase("", 4000)]
        [TestCase("SavingsAccount", -1000)]
        [TestCase("SavingsAccount", 0)]
        public void TestCreateCurrentAccount_ThrowException(string name, decimal startingBalance) {

            Branch br = new Branch("LA");
            Account account = null;
            TestDelegate createAccount = () => account = new CurrentAccount(name, startingBalance, br);

            Assert.That(createAccount, Throws.Exception);
            Assert.That(account, Is.Null);
            
           
        }

        [TestCase("SavingsAccount", 4000)]
        public void TestCreateCurrentAccount_ThrowNoException(string name, decimal startingBalance) {

            Branch br = new Branch("LA");
            Account account = null;
            TestDelegate createAccount = () => account = new CurrentAccount(name, startingBalance, br);

            Assert.That(createAccount, Throws.Nothing);
            Assert.That(account, Is.Not.Null);

            Assert.That(account.GetAccountType(), Is.EqualTo(AccountType.CURRENT));
            Assert.That(account.AccountName, Is.EqualTo(name));
            Assert.That(account.CalculateAccountBalance(), Is.EqualTo(startingBalance));
            Assert.That(account.AccountBranch, Is.EqualTo(br));
        }

        
        [TestCase("", 4000)]
        [TestCase("SavingsAccount", -1000)]
        [TestCase("SavingsAccount", 0)]
        public void TestCreateSavingsAccount_ThrowException(string name, decimal startingBalance) {

            Branch br = new Branch("LA");
            Account account = null;
            TestDelegate createAccount = () => account = new SavingsAccount(name, startingBalance, br);

            Assert.That(createAccount, Throws.Exception);
            Assert.That(account, Is.Null);
        }

        [TestCase("SavingsAccount", 4000)]
        public void TestCreateSavingsAccount_ThrowNoException(string name, decimal startingBalance) {

            Branch br = new Branch("LA");
            Account account = null;
            TestDelegate createAccount = () => account = new SavingsAccount(name, startingBalance, br);
            
            Assert.That(createAccount, Throws.Nothing);
            Assert.That(account, Is.Not.Null);

            Assert.That(account.GetAccountType(), Is.EqualTo(AccountType.SAVINGS));
            Assert.That(account.AccountName, Is.EqualTo(name));
            Assert.That(account.CalculateAccountBalance, Is.EqualTo(startingBalance));
            Assert.That(account.AccountBranch, Is.EqualTo(br));
        }

        
        [TestCase("TestAccount", -100)]
        [TestCase("TestAccount", 0)]
        public void TestDeposit_ThrowException(string name, decimal depositamount) {
            decimal startingBalance = 500m;

            Branch br = new Branch("LA");
            Account account = new SavingsAccount(name, startingBalance, br);

            TestDelegate action = () => account.Deposit(depositamount);

            
            Assert.That(action, Throws.Exception);
            Assert.That(account.CalculateAccountBalance(), Is.EqualTo(startingBalance));
            Assert.That(account.GetTransactionListCount(), Is.EqualTo(1)); // since we add a deposit when we create the account
            
        }

        [TestCase("TestAccount", 100)]
        public void TestDeposit_ThrowNoException(string name, decimal depositamount) {
            decimal startingBalance = 500m;

            Branch br = new Branch("LA");
            Account account = new SavingsAccount(name, startingBalance, br);

            TestDelegate action = () => account.Deposit(depositamount);

            Assert.That(action, Throws.Nothing);
            Assert.That(account.CalculateAccountBalance, Is.EqualTo(startingBalance+depositamount));
            Assert.That(account.GetTransactionListCount(), Is.GreaterThan(0));
        }


        
        [TestCase("TestAccount", -100)]
        [TestCase("TestAccount", 0)]
        public void TestWithdraw_ThrowException_WithdrawamountIsLessOrEqualTo0(string name, decimal withdrawamount) {
            decimal startingBalance = 500m;

            Branch br = new Branch("LA");
            Account account = new SavingsAccount(name, startingBalance, br);

            TestDelegate action = () => account.Withdraw(withdrawamount);

           
            Assert.That(action, Throws.Exception);
            Assert.That(account.CalculateAccountBalance(), Is.EqualTo(startingBalance));
            Assert.That(account.GetTransactionListCount(), Is.EqualTo(1)); // since we add a deposit when we create the account
            
        }

        [TestCase("TestAccount", 600)]
        public void TestWithdraw_ThrowException_withdrawamountIsGreaterThatnAccountBalance(string name, decimal withdrawamount) {
            decimal startingBalance = 500m;

            Branch br = new Branch("LA");
            Account account = new SavingsAccount(name, startingBalance, br);

            TestDelegate action = () => account.Withdraw(withdrawamount);

            Assert.That(action, Throws.Exception);
            Assert.That(account.CalculateAccountBalance(), Is.EqualTo(startingBalance));
            Assert.That(account.GetTransactionListCount(), Is.EqualTo(1)); // since we add a deposit when we create the account
        }

        [TestCase("TestAccount", 100)]
        public void TestWithdraw_ThrowNoException(string name, decimal withdrawamount) {
            decimal startingBalance = 500m;

            Branch br = new Branch("LA");
            Account account = new SavingsAccount(name, startingBalance, br);

            TestDelegate action = () => account.Withdraw(withdrawamount);

            Assert.That(action, Throws.Nothing);
            Assert.That(account.CalculateAccountBalance(), Is.EqualTo(startingBalance-withdrawamount));
            Assert.That(account.GetTransactionListCount(), Is.GreaterThan(1));
        }


        [Test]
        public void TestGeneratestatement() {
            // Arrange
            string accountName = "TestAccount";
            decimal initialBalance = 2000.00m;
            Branch br = new Branch("LA");
            Account testAccount = new CurrentAccount(accountName, initialBalance, br);

            // Act
            testAccount.Withdraw(500.00m);
            testAccount.Deposit(1000.00m);
            testAccount.Deposit(200.00m);

            // Change ExpectedStatement if teting another time
            string expectedStatement = $"statement from {accountName}\nDate    ||    Withdraw    ||    Deposit   || Balance\n";
            expectedStatement += "23-01-2024    ||   0,00    ||    2000,00     ||    2000,00\n";
            expectedStatement += "23-01-2024    ||   500,00    ||    0,00     ||    1500,00\n";
            expectedStatement += "23-01-2024    ||   0,00    ||    1000,00     ||    2500,00\n";
            expectedStatement += "23-01-2024    ||   0,00    ||    200,00     ||    2700,00";

            string actualStatement = testAccount.GenerateStatement();

            // Assert
            Assert.AreEqual(expectedStatement, actualStatement);
        }
        



    }
}