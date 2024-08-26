using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Enums;
using Boolean.CSharp.Main.Person;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
  
    public class CoreTests
    {
        private Core _core;

        public CoreTests()
        {
            _core = new Core();

        }

        [Test]
        public void TestCurrentAccount()
        {

            //arrange
            Customer customer = new Customer("Ali Haider", 1);

            string accountNumber = "1290 11 11212";

            AccountType current = AccountType.Current;
            
            //act
            var accountToChech = customer.createAccount(current, accountNumber);

            //assert
            Assert.IsNotNull(accountToChech);

        }
        [Test]

        public void TestSavingsAccount()
        {
            Assert.Fail();
        }

    }
}