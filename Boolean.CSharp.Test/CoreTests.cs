using Boolean.CSharp.Main;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class Core
    {
        [Test]
        public void DepositShouldIncreaseBalance() 
        {
            //Arrange
            Branch branch = new Branch("NorwegianBranch");
            IAccount account = new Account(branch);
            double initialBalance = account.GetBalance();
            double depositAmount = 1000;

            //Act
            account.Deposit(depositAmount, DateTime.Now);

            //Assert
            double expectedBalance = initialBalance + depositAmount;
            Assert.AreEqual(expectedBalance, account.GetBalance());
        }

        [Test]
        public void DepositShouldDecreaseBalance() 
        {
            //Arrange
            Branch branch = new Branch("NorwegianBranch");
            IAccount account = new Account(branch);
            account.Deposit(2000, DateTime.Now);
            double initialBalance = account.GetBalance();
            double withdrawalAmount = 500;

            //Act
            account.Withdraw(withdrawalAmount, DateTime.Now);

            //Assert
            double expectedBalance = initialBalance - withdrawalAmount;
            Assert.AreEqual(expectedBalance, account.GetBalance());
        }

        [Test]
        public void PrintStatementShouldShouldReturnString()
        {
            //Arrange
            Branch branch = new Branch("NorwegianBranch");
            IAccount account = new Account(branch);
            account.Deposit(1000, DateTime.Now);

            //Act
            string statement = account.PrintStatement();

            //Assert
            Assert.IsNotNull(statement);
            Assert.IsNotEmpty(statement);
        }
        [Test]
        public void PrintBankStatementShouldShowCorrectTransactions()
        {
            Branch branch = new Branch("NorwegianBranch");
            IAccount account = new Account(branch);
            account.Deposit(1000, new DateTime(2012, 1, 10));
            account.Deposit(2000, new DateTime(2012, 1, 13));
            account.Withdraw(500, new DateTime(2012, 1, 14));

            // Print the statement to the console
            Console.WriteLine(account.PrintStatement());

        }



    }
}