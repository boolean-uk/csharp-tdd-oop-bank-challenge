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


        [TestCase(AccountType.GENERAL, Branch.ITALY)]
        [TestCase(AccountType.SAVINGS, Branch.FRANCE)]
        [TestCase(AccountType.SAVINGS, Branch.SPAIN)]
        public void AccountsAssosiactedWithBranches(AccountType type, Branch branch)
        {
            IAccount acc = _user.addAccount(type, branch);
            Assert.That(acc.Type, branch);

        }

        [TestCase(AccountType.GENERAL, Branch.NOTHING)]
        [TestCase(AccountType.SAVINGS, Branch.NOTHING)]
        public void NonexistendBranch(AccountType type, Branch branch)
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
