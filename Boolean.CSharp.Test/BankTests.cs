using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Accounts;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class BankTests
    {

        [Test]
        public void CreateAccountTest()
        {
            Bank bank = new Bank("DNB", 10000);
            Branch oslo = new Branch("Oslo");
            Savings savings = new Savings() {branch = oslo};
            Current current = new Current() {branch = oslo};

            bool expected = true;

            bool result = bank.createAccount(savings);

            Assert.That(expected == result);
            
        }

        [Test]
        public void TestQuestion1()
        {

        }

    }
}