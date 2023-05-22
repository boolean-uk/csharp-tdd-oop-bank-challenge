using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Interfaces;
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
        [Test]
        public void BankBranch()
        {
            // I want accounts to be associated with specific branches.

            // Arrange
            Core _core = new Core();

            List<IAccount> accountslist = new List<IAccount>();
            _core.CreateUser("Max", "password", accountslist);
            var user = _core.UserList.First();
            var type = AccountType.Current;
            var branch = BankBranchType.Amsterdam;

            // Act
            _core.CreateBankAccount(user, type, branch);

            // Assert
            Assert.AreEqual(BankBranchType.Amsterdam, _core.UserList.First().AccountsList.First().BranchType);
        }
    }
}
