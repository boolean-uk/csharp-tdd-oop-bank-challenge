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
            IAccount account = new Account();
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
            IAccount account = new Account();
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
            IAccount account = new Account();
            account.Deposit(1000, DateTime.Now);

            //Act
            string statement = account.PrintStatement();

            //Assert
            Assert.IsNotNull(statement);
            Assert.IsNotEmpty(statement);
        }
    }    
}