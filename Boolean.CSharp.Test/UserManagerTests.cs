using Boolean.CSharp.Main;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class UserManagerTests
    {
        private UserManager userManager;

        [SetUp]
        public void Setup()
        {
            userManager = new UserManager();
        }

        [Test]
        public void RegisterThenValidDataThenCreatesAndReturnsUser()
        {
            string inputForRegister = "Harry Potter\nLordVoldemort23!\nSneepyWeepyStreet\n11111\nharry@potter.hogwarts\n";
            Console.SetIn(new StringReader(inputForRegister));
            User registeredUser = userManager.Register();
            Assert.AreEqual("Harry Potter", registeredUser.Username);
            Assert.AreEqual("LordVoldemort23!", registeredUser.Password);
            Assert.AreEqual("SneepyWeepyStreet", registeredUser.Street);
            Assert.AreEqual("11111", registeredUser.Postcode);
            Assert.AreEqual("harry@potter.hogwarts", registeredUser.Email);
        }

        [Test]
        public void LoginThenValidCredentialsTShouldReturnsUser()
        {
            string inputForRegister = "Harry Potter\nLordVoldemort23!\nSneepyWeepyStreet\n11111\nharry@potter.hogwarts\n";
            Console.SetIn(new StringReader(inputForRegister));
            userManager.Register();
            string inputForLogin = "Harry Potter\nLordVoldemort23!\n";
            Console.SetIn(new StringReader(inputForLogin));
            User loggedInUser = userManager.Login();
            Assert.AreEqual("Harry Potter", loggedInUser.Username);
        }

        [Test]
        public void LoginThenInvalidCredentialsShouldReturnsNull()
        {
            string inputForRegister = "Harry Potter\nLordVoldemort23!\nSneepyWeepyStreet\n11111\nharry@potter.hogwarts\n";
            Console.SetIn(new StringReader(inputForRegister));
            userManager.Register();
            string inputForInvalidLogin = "Harry Potter\nWrongPassword\n";
            Console.SetIn(new StringReader(inputForInvalidLogin));
            User loggedInUser = userManager.Login();
            Assert.IsNull(loggedInUser);
        }
    }
}