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
        public void CreateCurrentAccountTest()
        {
            List<Account> newBranchAccounts = new List<Account>(); // A list of accounts
            Branch newBranch = new Branch(newBranchAccounts, "Oslo"); // Bank object
            
            Customer customer = new Customer("John Doe"); //Customer
            Account current = new Current(customer, newBranch, "000001", "Current", 0.0); //Making an account with the constructor

            bool expected = true;

            newBranch.CreateCurrentAccount(customer, "000001", "Current", "Oslo"); //Making an account with the method

            bool result = false;
            if (newBranchAccounts.Contains(current)) //Checking if its added to the list of accounts 
            {
                result = true;
            }

            Assert.IsTrue(expected == result);

            
        }
    }
}