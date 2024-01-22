using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Classes;
using Boolean.CSharp.Main.Classes.Accounts;
using Boolean.CSharp.Main.Classes.User;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class ExtensionTests
    {

        private CustomerUser customer;

        [SetUp]
        public void SetUp()
        {
            customer = new CustomerUser();
        }

        [Test]
        public void TestTest()
        {

            //  Arrange - set up test values

            //  Act - use the fucntion we want to test

            //  Assert - check the results
            Assert.IsTrue(true);
        }

        [Test]
        [TestCase(eBranch.North)]
        [TestCase(eBranch.WestWest)]
        [TestCase(eBranch.West)]
        [TestCase(eBranch.East)]
        public void BranchesAndAccounts(eBranch e)
        {
            //  Arrange - set up test values
            string result;
            CurrentAccount testAccount = new CurrentAccount(e);
            customer.CreateAccount(testAccount);

            //  Act - use the fucntion we want to test
            result = customer.CheckBranch(0);

            //  Assert - check the results
            Assert.That(result, Is.EqualTo(e.ToString()));
        }

        [Test]
        [TestCase(100, 200)]
        [TestCase(100, 500)]
        public void RequestingOverdraft(double deposit, double draft)
        {
            //  Arrange - set up test values
            CurrentAccount testAccount = new CurrentAccount();
            customer.CreateAccount(testAccount);
            customer.Deposit(deposit, 0);

            //  Act - use the fucntion we want to test
            BankStatement test = customer.RequestOverdraft(draft, 0);

            //  Assert - check the results
            Assert.That(Math.Round(test.Transaction,2), Is.EqualTo(Math.Round((deposit-draft)*-1,2)));
        }

        [Test]
        [TestCase(1000, false, "Request denied")]
        [TestCase(300, true)]
        [TestCase(500, true)]
        public void ManageOverdraft(double amount, bool approved, string expected)
        {
            //  Arrange - set up test values
            CurrentAccount testAccount = new CurrentAccount();
            customer.CreateAccount(testAccount);
            customer.Deposit(200, 0);
            ManagerUser manager = new ManagerUser();

            //  Act - use the fucntion we want to test
            //manager.ManageRequest(customer.RequestOverdraft(amount, 0), approved);

            //  Assert - check the results
            Assert.IsTrue(false);
        }
    }
}
