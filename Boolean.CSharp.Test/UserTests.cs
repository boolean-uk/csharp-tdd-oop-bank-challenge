using Boolean.CSharp.Main;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class UserTests
    {
        [Test]
        public void UserInstantiationThenValidDataShouldCreatesUserObject()
        {
            string expectedUsername = "Harry Potter";
            string expectedPassword = "LordVoldemort23!";
            string expectedStreet = "SneepyWeepyStreet";
            string expectedPostcode = "11111";
            string expectedEmail = "harry@potter.hogwarts";
            var user = new User(expectedUsername, expectedPassword, expectedStreet, expectedPostcode, expectedEmail);
            Assert.AreEqual(expectedUsername, user.Username);
            Assert.IsTrue(BCrypt.Net.BCrypt.Verify("LordVoldemort23!", user.Password));
            Assert.AreEqual(expectedStreet, user.Street);
            Assert.AreEqual(expectedPostcode, user.Postcode);
            Assert.AreEqual(expectedEmail, user.Email);
        }
    }
}