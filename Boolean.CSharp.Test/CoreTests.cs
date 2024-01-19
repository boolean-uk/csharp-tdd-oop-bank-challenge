using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Accounts;
using Boolean.CSharp.Main.Users;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CoreTests
    {
        [Test]
        public void TestCreateGeneralAccount()
        {
            // Arrange
            IUser user1 = new RegularCustomer();
            IUser user2 = new Manager();

            // Act
            bool? res1 = (user1 as RegularCustomer).OpenNewAccount("general");
            bool? res2 = (user2 as RegularCustomer).OpenNewAccount("general");

            // Assert
            Assert.That(res1, Is.True);
            Assert.That(user1.GetAccounts().Count, Is.EqualTo(1));
            Assert.That(user1.GetAccounts()[0].GetType(), Is.EqualTo(typeof(GeneralAccount)));

            Assert.That(res2, Is.Null);
        }

        [Test]
        public void TestCreateSavingsAccount()
        {
            // Arrange
            IUser user1 = new RegularCustomer();
            IUser user2 = new Manager();

            // Act
            bool? res1 = (user1 as RegularCustomer).OpenNewAccount("saving");
            bool? res2 = (user2 as RegularCustomer).OpenNewAccount("saving");

            // Assert
            Assert.That(res1, Is.True);
            Assert.That(user1.GetAccounts().Count, Is.EqualTo(1));
            Assert.That(user1.GetAccounts()[0].GetType(), Is.EqualTo(typeof(SavingsAccount)));

            Assert.That(res2, Is.Null);
        }

        [Test]
        public void TestDepositFunds() 
        {
            // Arrange
            Customer user = new RegularCustomer();
            user.OpenNewAccount("general");
            Account account = user.GetAccounts()[0];

            // Act
            decimal preBalance = account.GetBalance();
            bool res = account.Deposit(500m);
            decimal postBalance = account.GetBalance();

            // Assert
            Assert.That(res, Is.True);
            Assert.That(preBalance, Is.EqualTo(0m));
            Assert.That(postBalance, Is.EqualTo(500m));

        }

    }
}