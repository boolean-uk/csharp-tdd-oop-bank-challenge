using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Classes.Accounts;
using Boolean.CSharp.Main.Classes.User;
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
        public void RequestingOverdraft()
        {
            //  Arrange - set up test values

            //  Act - use the fucntion we want to test

            //  Assert - check the results
            Assert.IsTrue(false);
        }

        [Test]
        public void ManageOverdraft()
        {
            //  Arrange - set up test values

            //  Act - use the fucntion we want to test

            //  Assert - check the results
            Assert.IsTrue(false);
        }
    }
}
