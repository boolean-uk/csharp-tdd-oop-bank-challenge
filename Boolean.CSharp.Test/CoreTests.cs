using Boolean.CSharp.Main;
using NUnit.Framework;
using System.Diagnostics.CodeAnalysis;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CoreTests
    {
        [Test]
        public void CreateAccTest()
        {
            // init
            Account account = new(5000);
            decimal expected = 5000;

            //run
            decimal compute = account.GetBalance();

            //assert
            Assert.That(compute, Is.EqualTo(expected));

        }
        [Test]
        public void SavingsAccTest()
        {
            //init
            SavingsAccount account = new(500);
            decimal expected = 500;

            //run
            decimal computed = account.GetBalance();

            //Assert 
            Assert.That(computed, Is.EqualTo(expected));
        }
        [Test]
        public void DepositTest()
        {
            // init 
            SavingsAccount savingsAccount = new(500m);
            decimal expected = 500m + 543;

            // run
            savingsAccount.Deposit(543);

            // assert
            Assert.That(expected, Is.EqualTo(savingsAccount.GetBalance()));
        }
        [Test]
        public void PrintStatementTest()
        {
            //init
            SavingsAccount savingsAccount = new(500);
            
            //run


            //Assert
        }

    }

}
