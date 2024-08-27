using Boolean.CSharp.Main;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CoreTests
    {
        private Core _core;

        public CoreTests()
        {
            _core = new Core();

        }

        [Test]
        public void CreateAccountTest()
        {
            List<Account> accounts = new List<Account>(); // A list of accounts
            Bank bank = new Bank(accounts); // Bank object
            
            Customer customer = new Customer("John Doe"); //Customer
            Account current = new Current(customer, "000001", "Current", "Oslo", 0.0); //Making an account with the constructor

            bool expected = true;

            bank.CreateAccount(customer, "000001", "Current", "Oslo"); //Making an account with the method

            bool result = false;
            if (accounts.Contains(current)) //Checking if its added to the list of accounts 
            {
                result = true;
            }

            Assert.IsTrue(expected == result);

            
        }
    }
}