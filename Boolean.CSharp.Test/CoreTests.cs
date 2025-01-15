using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using Boolean.CSharp.Main;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CoreTests
    {


        public CoreTests()
        {


        }

        [Test]
        public void checkSavings()

        {
            //Arrange


            //Act



            //Assert



        }

        [Test]
        public void CreatingAccount()

        {

            //Arrange
            var account1 = new Account("Declan", "Rice", Branch.London);

            //Act
            var accountInfo = account1.showAccountInfo();

            //Assert
            Assert.That(accountInfo, Is.EqualTo("Account for Declan Rice, Branch: London"));

        }

        [Test]
        public void CreateSavingsAccount()
        {
            //Arrange
            var savingsAccount1 = new SavingsAccount("Declan", "Rice", Branch.London);

            //Act
            string savingsAccountNumber1 = savingsAccount1.SavingsAccountNumber;

            //Assert

            Assert.That(savingsAccountNumber1, Is.EqualTo(savingsAccount1.SavingsAccountNumber));

        }

        [Test]
        public void GenerateAccountOverview()
        {

            //Arrange
            var savingsAccount = new SavingsAccount("Declan", "Rice", Branch.London);
            var currentAccount = new CurrentAccount("Declan", "Rice", Branch.London);
            savingsAccount.GenerateAccountOverview();
            currentAccount.GenerateAccountOverview();

            //Assert
            Assert.That(savingsAccount.GenerateAccountOverview, Is.Not.Null);
            Assert.That(currentAccount.GenerateAccountOverview, Is.Not.Null);


        }

        public void GenerateBankStatement()

        {
            //Arrange
            var savingsAccount = new SavingsAccount("Declan", "Rice", Branch.London);

            //Act


            //Assert


        }


        [Test]
        public void CalculateBalance()
        {
            //Arrange


            //Act



            //Assert
        }
        [Test]
        public void DepositO()
        {
            //Arrange
            var savingsAccount = new SavingsAccount("Declan", "Rice", Branch.London);
            var currentAccount = new CurrentAccount("Declan", "Rice", Branch.London);


            //Act
            currentAccount.Deposit(500M);
            savingsAccount.Deposit(1000M);
            decimal savingsBalanceCurrent = savingsAccount.Balance;
            decimal currentBalanceCurrent = currentAccount.Balance;

            //Assert
            Assert.That(savingsBalanceCurrent, Is.EqualTo(1000M));
            Assert.That(currentBalanceCurrent, Is.EqualTo(500M));

        }
      
        [Test]
        public void Withdrawal()
        {
            //Arrange
            var savingsAccount = new SavingsAccount("Declan", "Rice", Branch.London);
            var currentAccount = new CurrentAccount("Declan", "Rice", Branch.London);


            //Act
            currentAccount.Deposit(500M);
            currentAccount.Withdrawal(250M);
            decimal currentBalanceCurrent = currentAccount.Balance;

            savingsAccount.Deposit(1000M);
            savingsAccount.Withdrawal(500M);
            decimal savingsBalanceCurrent = savingsAccount.Balance;

            //Assert
            Assert.That(savingsBalanceCurrent, Is.EqualTo(500M));
            Assert.That(currentBalanceCurrent, Is.EqualTo(250M));

        }
        [Test]
        public void ApproveOrRejectOverdraft()

        {
            //Arrange
            var currentAccount = new CurrentAccount("Declan", "Rice", Branch.London);

            //Act
            string validOverdraftRequest = currentAccount.RequestOverdraft(900);
            string notValidOverdraftRequest = currentAccount.RequestOverdraft(1001);


            //Assert
            Assert.That(validOverdraftRequest.Contains("approved"));
            Assert.That(notValidOverdraftRequest.Contains("rejected"));
            Console.WriteLine(validOverdraftRequest);

        }

        [Test]

        public void GenerateStatement()
        {
            //Arrange
            var account = new Account("Declan", "Rice", Branch.London);
            var savingsAccount = new SavingsAccount("Declan", "Rice", Branch.London);
            var currentAccount = new CurrentAccount("Declan", "Rice", Branch.London);

            currentAccount.Deposit(500M);
            currentAccount.Withdrawal(250M);
            decimal currentBalanceCurrent = currentAccount.Balance;

            savingsAccount.Deposit(1000M);
            savingsAccount.Withdrawal(500M);
            decimal savingsBalanceCurrent = savingsAccount.Balance;


            //Act
            string statement = savingsAccount.GenerateStatement();
            string statement2 = currentAccount.GenerateStatement();




            //Assert
            Assert.NotNull(statement);

        }

    }
}