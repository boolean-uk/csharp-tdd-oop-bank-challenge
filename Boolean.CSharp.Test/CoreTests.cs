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

            Current sample = newBranch.CreateCurrentAccount(newBranch, customer, "000001"); //Making an account with the method

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

            Savings sample = newBranch.CreateSavingsAccount(newBranch, customer, "000001");

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
        public void CheckStatementTest()
        {
            Branch newBranch = new Branch("Oslo");

            Customer customer = new Customer("John Doe");

            Current sample = newBranch.CreateCurrentAccount(newBranch, customer, "000001");

            newBranch.Deposit(sample.AccountNr, 500);
            newBranch.Deposit(sample.AccountNr, 300);
            newBranch.Withdraw(sample.AccountNr, 500);

            double expected = 300;

            double result = sample.GetBalance();

            Assert.AreEqual(expected, result);

        }

        [Test]
        public void BankStatementTest()
        {
            Branch newBranch = new Branch("Oslo");

            Customer customer = new Customer("John Doe");

            Current sample = newBranch.CreateCurrentAccount(newBranch, customer, "000001");

            newBranch.Deposit(sample.AccountNr, 500);
            newBranch.Deposit(sample.AccountNr, 300);
            newBranch.Withdraw(sample.AccountNr, 500);

            Savings sample2 = newBranch.CreateSavingsAccount(newBranch, customer, "000002");

            newBranch.Deposit(sample2.AccountNr, 500);
            newBranch.Deposit(sample2.AccountNr, 300);
            newBranch.Deposit(sample2.AccountNr, 1200);
            newBranch.Withdraw(sample2.AccountNr, 500);
            newBranch.Withdraw(sample2.AccountNr, 100);


            string print = newBranch.Statement(customer.Name);

            double expected1 = 300;
            double expected2 = 1400;

            double result1 = sample.GetBalance();
            double result2 = sample2.GetBalance();

            Assert.AreEqual(expected1, result1);
            Assert.AreEqual(expected2, result2);

        }
    }
}