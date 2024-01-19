using Boolean.CSharp.Main;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CoreTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void TestMakeUserAccount()
        {
            BankApplication bankApp = new BankApplication();
            Custommer custommer1 = new Custommer();
            

            custommer1.makeAccount("Normal");
            custommer1.makeAccount("Saving");
            var users = bankApp.seeAccount();

            // There should be 1 user in the bank and the custommer should have 2 accounts.
            Assert.IsTrue(users.Count == 1 && custommer1.accounts.Count == 2);


        }

    }
}