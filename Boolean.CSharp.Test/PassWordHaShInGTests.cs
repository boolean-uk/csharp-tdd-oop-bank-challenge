using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    public class PassWordHaShInGTests
    {
        private const string TestPassword = "Lordtdtt@VoldeMort12555@@";

        [Test]
        public void HashingSamePasswordProducesDifferentResults()
        {
            var hash1 = BCrypt.Net.BCrypt.HashPassword(TestPassword);
            var hash2 = BCrypt.Net.BCrypt.HashPassword(TestPassword);

            Assert.AreNotEqual(hash1, hash2);
        }

        [Test]
        public void HashedPasswordCanBeVerified()
        {
            var hash = BCrypt.Net.BCrypt.HashPassword(TestPassword);
            var isValid = BCrypt.Net.BCrypt.Verify(TestPassword, hash);

            Assert.IsTrue(isValid);
        }

        [Test]
        public void IncorrectPasswordDoesNotVerify()
        {
            var hash = BCrypt.Net.BCrypt.HashPassword(TestPassword);
            var isValid = BCrypt.Net.BCrypt.Verify("WrongPassword", hash);

            Assert.IsFalse(isValid);
        }

        [Test]
        public void NullPasswordHandling()
        {
            Assert.Throws<ArgumentNullException>(() => BCrypt.Net.BCrypt.HashPassword(null));
        }

        [Test]
        public void EmptyPasswordHandling()
        {
            var hash = BCrypt.Net.BCrypt.HashPassword("");
            Assert.IsNotNull(hash);
        }
    }
}
