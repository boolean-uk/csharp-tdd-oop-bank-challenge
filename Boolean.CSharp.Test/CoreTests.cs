using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Accounts;
using Boolean.CSharp.Main.Classes;
using NUnit.Framework;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            currentAccount.Deposit(1000);

            //Act
            decimal expectedResult = currentAccount.Withdraw(500);
            decimal actualResult = 500;
            //Assert
            Assert.That(expectedResult, Is.EqualTo(actualResult));

        }

        [Test]
        public void Test_02_CurrentAccount()
        {
            //Arrange
            Customer customer = new Customer("Andreas Lauvhjell");
            AccountCurrent currentAccount = new AccountCurrent(customer);
            currentAccount.Deposit(1000);

            //Act
            decimal expectedResult = currentAccount.Withdraw(500);
            decimal actualResult = 500;
            //Assert
            Assert.That(expectedResult, Is.EqualTo(actualResult));

        }

        [Test]
        public void Test_03_GenerateBankStatement_Current()
        {
            //Arrange
            Customer customer = new Customer("Andreas Lauvhjell");
            AccountCurrent currentAccount = new AccountCurrent(customer);
            currentAccount.Deposit(1000);
            currentAccount.Deposit(2000);
            currentAccount.Withdraw(500);
            DateTime currentDate = DateTime.Now; 

            //Act
            decimal expectedResultDouble = currentAccount.GetBalance();
            decimal actualResultDouble = 2500;

            string expectedResultString = currentAccount.GenerateBankStatement();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("      Date ||     Credit ||      Debit ||    Balance");
            sb.AppendLine($"{currentDate.ToString("dd/MM/yyyy")} ||          0 ||        500 ||       2500 ");
            sb.AppendLine($"{currentDate.ToString("dd/MM/yyyy")} ||       2000 ||          0 ||       3000 ");
            sb.AppendLine($"{currentDate.ToString("dd/MM/yyyy")} ||       1000 ||          0 ||       1000 ");

            string actualResultString = sb.ToString(); //Unsure how to check this atm, but probably something like this? This would probably need some adjustment.
            Console.WriteLine("WANTED OUTPUT (TEST)");
            Console.WriteLine(actualResultString);
            
            //Assert
            Assert.That(expectedResultDouble, Is.EqualTo(actualResultDouble));
            Assert.That(expectedResultString, Is.EqualTo(actualResultString));
        }

        [Test]
        public void Test_04_GetBalance_BasedOnTransactionHistory_LotsaTransactions()
        {
            //Arrange
            Customer customer = new Customer("Andreas Lauvhjell");
            AccountCurrent currentAccount = new AccountCurrent(customer);
            for(int i = 0; i < 20; i++) //10x each
            {
                if(!(i%2 == 0))
                {
                    currentAccount.Deposit(1900);
                }
                else
                {
                    currentAccount.Withdraw(1000);
                }
            }
            currentAccount.Deposit(1);

            //Act
            decimal expectedResult = currentAccount.GetBalance();
            decimal actualResult = 9001;

            //Assert
            Assert.That(expectedResult, Is.EqualTo(actualResult));
        }
    }
}