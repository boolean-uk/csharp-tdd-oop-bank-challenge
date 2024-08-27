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
            //List<Account> newBranchAccounts = new List<Account>(); // A list of accounts
            Branch newBranch = new Branch("Oslo"); // Bank object

            Customer customer = new Customer("John Doe"); //Customer
            //Account current = new Current(customer, newBranch, "000001", "Current", 0.0); //Making an account with the constructor

            bool expected = true;

            Account sample = newBranch.CreateCurrentAccount(customer, newBranch, "000001", "Current"); //Making an account with the method

            bool result = false;

            if (newBranch.Accounts[0].AccountNr == "000001") 
            {
                result = true; 
            }

            Assert.IsTrue(expected == result);

            bool testCheck = false;

            if (newBranch.Accounts.Contains(sample))
            {
                testCheck = true;
            }

            Assert.IsTrue(testCheck);
          
        }

        [Test]
        public void CreateSavingAccountTest()
        {
            Branch newBranch = new Branch("Oslo");

            Customer customer = new Customer("John Doe");

            bool expected = true;

            Account sample = newBranch.CreateSavingsAccount(customer, newBranch, "000001", "Savings");

            bool result = false;

            if (newBranch.Accounts[0].AccountNr == "000001")
            {
                result = true;
            }

            Assert.IsTrue(expected == result);

            bool testCheck = false;

            if (newBranch.Accounts.Contains(sample))
            {
                testCheck = true;
            }

            Assert.IsTrue(testCheck);
        }
    }
}