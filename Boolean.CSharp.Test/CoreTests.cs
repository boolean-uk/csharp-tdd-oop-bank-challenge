using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Accounts;
using Boolean.CSharp.Main.Classes;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CoreTests
    {

        [Test]
        public void Test_01_SavingsAccount()
        {
            //Arrange
            Customer customer = new Customer("Andreas Lauvhjell");
            AccountSavings currentAccount = new AccountSavings(customer);
            currentAccount.Deposit(1000d);

            //Act
            double expectedResult = currentAccount.Withdraw(500d);
            double actualResult = 500d;
            //Assert
            Assert.That(expectedResult, Is.EqualTo(actualResult));

        }

        [Test]
        public void Test_02_CurrentAccount()
        {
            //Arrange
            Customer customer = new Customer("Andreas Lauvhjell");
            AccountCurrent currentAccount = new AccountCurrent(customer);
            currentAccount.Deposit(1000d);

            //Act
            double expectedResult = currentAccount.Withdraw(500d);
            double actualResult = 500d;
            //Assert
            Assert.That(expectedResult, Is.EqualTo(actualResult));

        }

        [Test]
        public void Test_03_GenerateBankStatement_Current()
        {
            //Arrange
            Customer customer = new Customer("Andreas Lauvhjell");
            AccountCurrent currentAccount = new AccountCurrent(customer);
            currentAccount.Deposit(1000d);
            currentAccount.Deposit(2000d);
            currentAccount.Withdraw(500d);

            //Act
            double expectedResultDouble = currentAccount.Balance;
            double actualResultDouble = 2500d;

            string expectedResultString = currentAccount.GenerateBankStatement();
            string actualResultString = 
                "date       || credit  || debit  || balance " +
                "14/01/2012 ||         || 500.00 || 2500.00 " +
                "13/01/2012 || 2000.00 ||        || 3000.00 " +
                "10/01/2012 || 1000.00 ||        || 1000.00"; //Unsure how to check this atm, but probably something like this? This would probably need some adjustment.

            //Arrange
            Assert.That(expectedResultDouble, Is.EqualTo(actualResultDouble));
        }
    }
}