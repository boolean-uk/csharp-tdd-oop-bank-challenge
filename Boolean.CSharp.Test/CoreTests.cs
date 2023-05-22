using Boolean.CSharp.Main;
using NUnit.Framework;
using System.Security.Principal;
using System;
using System.Xml.Linq;
using Boolean.CSharp.Main.Interfaces;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CoreTests
    {
        [Test]
        public void CreateUser()
        {
            // I want to create a user account.

            // Arrange
            Core _core = new Core();

            string name = "Max";
            string password = "password";
            List<IAccount> accountslist = new List<IAccount>();

            // Act
            _core.CreateUser(name, password, accountslist);

            // Assert
            Assert.AreEqual(_core.UserList.Count, 1);
        }

        [Test]
        public void CreateCurrentAccount()
        {
            // I want to create a bank account.

            // Arrange
            Core _core = new Core();

            List<IAccount> accountslist = new List<IAccount>();
            _core.CreateUser("Max", "password", accountslist);
            var user = _core.UserList.First();
            var type = AccountType.Current;
            var branch = BankBranchType.Amsterdam;

            //Act
            _core.CreateBankAccount(user, type, branch);

            // Assert
            Assert.AreEqual(accountslist.Count, 1);
        }

        [Test]
        public void CreateSavingsAccount()
        {
            // I want to create a savings account.

            // Arrange
            Core _core = new Core();

            List<IAccount> accountslist = new List<IAccount>();
            _core.CreateUser("Max", "password", accountslist);
            var user = _core.UserList.First();
            var type = AccountType.Savings;
            var branch = BankBranchType.Amsterdam;

            // Act
            _core.CreateBankAccount(user, type, branch);

            // Assert
            Assert.AreEqual(accountslist.Count, 1);
        }

        [Test]
        public void DepositAmount()
        {
            // I want to deposit funds.

            // Arrange
            Core _core = new Core();

            List<IAccount> accountslist = new List<IAccount>();
            _core.CreateUser("Max", "password", accountslist);
            var user = _core.UserList.First();
            var type = AccountType.Current;
            var branch = BankBranchType.Amsterdam;

            _core.CreateBankAccount(user, type, branch);

            var accountname = _core.UserList.First().AccountsList.First();

            int amount = 1000;

            // Act
            _core.DepositAmount(user, amount, accountname);

            // Assert
            Assert.AreEqual(amount, user.AccountsList.First().Transactions.First().Balance);
        }

        [Test]
        public void WithdrawAmount()
        {
            // I want to withdraw funds.

            // Arrange
            Core _core = new Core();

            List<IAccount> accountslist = new List<IAccount>();
            _core.CreateUser("Max", "password", accountslist);
            var user = _core.UserList.First();
            var type = AccountType.Current;
            var branch = BankBranchType.Amsterdam;

            _core.CreateBankAccount(user, type, branch);

            var accountname = _core.UserList.First().AccountsList.First();

            int amount = 1000;

            // Act
            _core.WithdrawAmount(user, amount, accountname);

            // Assert
            Assert.AreEqual(-amount, user.AccountsList.First().Transactions.First().Balance);
        }

        [Test]
        public void CheckBalance()
        {
            // I want to check the balance.
            // I want account balances to be calculated based on transaction history instead of stored in memory.

            // Arrange
            Core _core = new Core();

            List<IAccount> accountslist = new List<IAccount>();
            _core.CreateUser("Max", "password", accountslist);
            var user = _core.UserList.First();
            var type = AccountType.Current;
            var branch = BankBranchType.Amsterdam;

            _core.CreateBankAccount(user, type, branch);

            var accountname = _core.UserList.First().AccountsList.First();

            int amount = 1000;
            int amount1 = 500;

            // Act
            _core.WithdrawAmount(user, amount1, accountname);
            _core.DepositAmount(user, amount, accountname);

            // Assert
            Assert.AreEqual(-amount1 + amount, _core.UserList.First().AccountsList.First().Transactions.Last().Balance);
        }

        [Test]
        public void PrintBankStatement()
        {
            // I want to generate bank statements with transaction dates, amounts, and balance at the time of transaction.

            // Arrange
            Core _core = new Core();

            List<IAccount> accountslist = new List<IAccount>();
            _core.CreateUser("Max", "password", accountslist);
            var user = _core.UserList.First();
            var type = AccountType.Current;
            var branch = BankBranchType.Amsterdam;

            _core.CreateBankAccount(user, type, branch);

            var accountname = _core.UserList.First().AccountsList.First();

            int amount = 1000;
            int amount1 = 2000;
            int amount2 = 500;

            _core.DepositAmount(user, amount, accountname);
            _core.DepositAmount(user, amount1, accountname);
            _core.WithdrawAmount(user, amount2, accountname);

            // Act
            _core.BankStatement(user, accountname);

            // Assert
            Assert.AreEqual(amount + amount1 - amount2, _core.UserList.First().AccountsList.First().Transactions.Last().Balance);
        }
    }
}