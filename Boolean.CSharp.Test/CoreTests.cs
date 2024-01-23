using Boolean.CSharp.Main;
using NUnit.Framework;
using Boolean.CSharp.Main.Interfaces;

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
        public void CreateUserAcc()
        {
            Core _core = new Core();
            // Arrange
            
            List<IAccount> accountList = new List<IAccount>();
            // Act
            _core.CreateUserAcc("Malimo1", "password", accountList);
            _core.CreateUserAcc("Malimo2", "password", accountList);
            // Assert
            Assert.AreEqual(_core.userList.Count, 2);

            

        }
        [Test]
        public void creatCurrentAcc() {
        // Arrange
            Core _core = new Core();
            List<IAccount> accounts = new List<IAccount>();
            _core.CreateUserAcc("Malimo1", "password", accounts);
            var user = _core.userList[0];
            var type = AccountType.Current;
        // Act
            _core.creatBankAcc(user, type);
        // Assert
            Assert.AreEqual(accounts.Count, 1);
        }

        [Test]
        public void createSavingAcc() { 
        // Arrange
            Core core = new Core();
            List<IAccount> accounts = new List<IAccount>();
            _core.CreateUserAcc("Malimo1", "password", accounts);
            var user = _core.userList[0];
            var type = AccountType.Saving;
        // Act
            _core.creatBankAcc(user,type);
        // Assert
            Assert.AreEqual(accounts.Count,1);
        }
        [Test]
        public void DepositAmount() {

            Core _core = new Core();

            List<IAccount> accounts = new List<IAccount>();
            _core.CreateUserAcc("Max", "password", accounts);
            var user = _core.userList.First();
            var type = AccountType.Current;

            _core.creatBankAcc(user, type);

            var accountname = _core.userList.First().AccountList.First();

            int amount = 1000;

            // Act
            _core.depositAmount(user, amount, accountname);

            // Assert
            Assert.AreEqual(amount, user.AccountList.First().Transactions.First().Balance);
        }

        [Test]
        public void WithdrawAmount()
        {

            // Arrange
            Core _core = new Core();

            List<IAccount> accountslist = new List<IAccount>();
            _core.CreateUser("Max", "password", accountslist);
            var user = _core.userList.First();
            var type = AccountType.Current;

            _core.creatBankAcc(user, type);

            var accountname = _core.userList.First().AccountList.First();

            int amount = 1000;

            // Act
            _core.WithdrawAmount(user, amount, accountname);

            // Assert
            Assert.AreEqual(-amount, user.AccountList.First().Transactions.First().Balance);

        }

        [Test]
        public void GenereateBankStatement() {
            // Arrange
            Core _core = new Core();
            List<IAccount> accounts = new List<IAccount>();
            _core.CreateUserAcc("Malimo", "password", accounts);
            var user = _core.userList.First();
            var type = AccountType.Current;
            _core.creatBankAcc(user, type);

            var accountName = _core.userList.First().AccountList.First();
            int amount1 = 1000;
            int amount2 = 2000;
            int amount3 = 500;

            _core.DepositAmount(user, amount1, accountName);
            _core.DepositAmount(user, amount2, accountName);
            _core.WithdrawAmount(user, amount3, accountName);
            // Act
            _core.BankStatement(user, accountName);

            // Assert
            Assert.AreEqual(amount1 + amount2 -amount3, _core.userList.First().AccountList.First().Transactions.Last().Balance);


        }
    }
}