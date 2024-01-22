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
        [TestCase(1000)]
        public void RequestingOverdraft(double draft)
        {
            //  Arrange - set up test values
            CurrentAccount testAccount = new CurrentAccount();
            customer.CreateAccount(testAccount);

            //  Act - use the fucntion we want to test
            OverdraftRequest test = customer.RequestOverdraft(draft, 0);

            //  Assert - check the results
        }

        [Test]
        [TestCase(eStatus.Denied, "Your request has been denied")]
        [TestCase(eStatus.Approved, "Your request has been approved")]
        public void ManageOverdraft(eStatus test, string expected)
        {
            //  Arrange - set up test values
            CurrentAccount testAccount = new CurrentAccount();
            customer.CreateAccount(testAccount);
            ManagerUser manager = new ManagerUser();

            //  Act - use the fucntion we want to test
            string result = manager.ManageRequest(customer.RequestOverdraft(1000, 0), test);

            //  Assert - check the results
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
