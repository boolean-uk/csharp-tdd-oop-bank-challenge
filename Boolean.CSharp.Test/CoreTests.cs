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

    }
}