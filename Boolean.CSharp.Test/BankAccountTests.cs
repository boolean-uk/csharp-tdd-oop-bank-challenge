using Boolean.CSharp.Main;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class BankAccountTests
    {

        [Test]
        public void Test1CreateACurrentAccount()
        {
            CurrentAccount currentAccount = new CurrentAccount();
            Assert.IsNotNull(currentAccount);
        }

    }
}