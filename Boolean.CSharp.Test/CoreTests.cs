using System.Runtime.CompilerServices;
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
            accountInfo = account1.showAccountInfo();

            //Assert
            Assert.That(accountInfo, Is.EqualTo("Declan Rice", London));



        }
        [Test]
        public void Generatestatements()
        {

            //Arrange


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
        public void DepositOrWithdraw()
        { 
            //Arrange


            //Act


            //Assert
        
        

        }
        [Test]
        public void ApproveOrRejectOverdraft()

        {

            //Arrange


            //Act


            //Assert
        }

            


    }
}