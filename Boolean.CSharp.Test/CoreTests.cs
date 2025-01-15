using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Classes;
using Boolean.CSharp.Main.Interface;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CoreTests
    {

        [Test]
        public void UserCreateAccounts()
        {
            User user = new User("giar");
            Assert.IsNotNull(user);

            string result1 = user.CreateCurrentAccount("My Current");
            string result2 = user.CreateSavingsAccount("My Saving");

            Assert.That(result1, Is.EqualTo("Successfully created account"));
            Assert.That(result2, Is.EqualTo("Successfully created account")); 
            Assert.That(user.Accounts.Count, Is.EqualTo(2));
        }

        [Test]
        public void UserCreateMoreAccounts()
        {
            User user = new User("giar");
            Assert.IsNotNull(user);

            string result1 = user.CreateCurrentAccount("My Current");
            string result2 = user.CreateCurrentAccount("This should not be added");
            string result3 = user.CreateSavingsAccount("My Savings");
            string result4 = user.CreateSavingsAccount("This should not be added 2");

            Assert.That(result2, Is.EqualTo("Account already exists"));
            Assert.That(result2, Is.EqualTo("Account already exists"));
            Assert.That(user.Accounts.Count, Is.EqualTo(2));


        }

    }
}