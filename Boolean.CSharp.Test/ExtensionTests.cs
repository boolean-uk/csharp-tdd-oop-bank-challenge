using Boolean.CSharp.Main;
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
        private Customer _user;

        [SetUp]
        public void SetUp()
        {
            _user = new Customer();
        }


        [TestCase(AccountType.GENERAL, "ITALY")]
        [TestCase(AccountType.SAVINGS, "FRANCE")]
        [TestCase(AccountType.SAVINGS, "SPAIN")]
        public void AccountsAssosiactedWithBranches(AccountType type, string branch)
        {
            IAccount acc = _user.addAccount(type, branch);
            Assert.AreEqual(acc.BRANCH, branch);

        }

        [TestCase(AccountType.GENERAL, "nothing")]
        [TestCase(AccountType.SAVINGS, "nothing")]
        public void NonexistendBranch(AccountType type, string branch)
        {
            Exception ex = Assert.Throws<System.Exception>(() => _user.addAccount(type, branch));
            Assert.That(ex.Message, Is.EqualTo("Branch does not exist!"));

        }


        [Test]
        public void TestQuestion2()
        {

        }
    }
}
