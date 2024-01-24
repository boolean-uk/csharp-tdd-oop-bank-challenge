using Boolean.CSharp.Main;
using Boolean.CSharp.Main.AccountTypes;
using Boolean.CSharp.Main.Interfaces;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
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
            List<OverdraftRequest> overdraftrequests = new List<OverdraftRequest>();
            _core.CreateUser("Max", "password", accountslist, overdraftrequests);
            var user = _core.UserList.First();
            var type = AccountType.Current;
            var branch = BankBranchType.Amsterdam;

            // Act
            _core.CreateBankAccount(user, type, branch);

            // Assert
            Assert.AreEqual(BankBranchType.Amsterdam, _core.UserList.First().AccountsList.First().BranchType);
        }

        [Test]
        public void RequestOverdraft()
        {
            // I want to be able to request an overdraft on my account.

            // Arrange
            Core _core = new Core();

            List<IAccount> accountslist = new List<IAccount>();
            List<OverdraftRequest> overdraftrequests = new List<OverdraftRequest>();
            _core.CreateUser("Max", "password", accountslist, overdraftrequests);
            var user = _core.UserList.First();
            var type = AccountType.Current;
            var branch = BankBranchType.Amsterdam;
            
            _core.CreateBankAccount(user, type, branch);

            var accountname = _core.UserList.First().AccountsList.First();

            int amount = 1000;
            int amount1 = 2000;

            _core.DepositAmount(user, amount, accountname);

            // Act
            _core.WithdrawAmount(user, amount1, accountname);

            // Assert
            Assert.AreEqual(1, _core.UserList.First().OverdraftRequests.Count());
        }

        [Test]
        public void ApproveOverdraft()
        {
            // I want to approve or reject overdraft requests.

            // Arrange
            Core _core = new Core();

            List<IAccount> accountslist = new List<IAccount>();
            List<OverdraftRequest> overdraftrequests = new List<OverdraftRequest>();
            _core.CreateUser("Max", "password", accountslist, overdraftrequests);
            var user = _core.UserList.First();
            var type = AccountType.Current;
            var branch = BankBranchType.Amsterdam;

            _core.CreateBankAccount(user, type, branch);

            var accountname = _core.UserList.First().AccountsList.First();

            int amount = 1000;
            int amount1 = 2000;

            _core.DepositAmount(user, amount, accountname);
            _core.WithdrawAmount(user, amount1, accountname);

            //manager can select id of overdraftrequest to approve
            int id = 0;

            // Act
            _core.ApproveOverdraft(user, id);

            // Assert
            Assert.AreEqual(0, _core.UserList.First().AccountsList.First().Transactions.Last().Balance);
        }
    }
}
