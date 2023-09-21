using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Enums;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class AccountTests
    {
        [Test]
        public void CreateCurrentAccountTest()
        {
            CurrentAccount current = new CurrentAccount(1);

            Assert.AreEqual(8, current.Number.Length);
        }

    }
}