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
            Branch Oslo = new Branch("Oslo");
            Branch Bergen = new Branch("Bergen");
            //Branch Stavanger = new Branch("Stavanger");
          
            Bank bank = new Bank("DNB", 10000, Oslo, Bergen);
            Savings savings = new Savings(Oslo);
            Current current = new Current(Bergen);

            bool expected = true;

            bool result = bank.createAccount(current);

            Assert.That(expected == result);
        }

        [Test]
        public void RequestOverdraftTest()
        {
            Branch Oslo = new Branch("Oslo");
            Branch Bergen = new Branch("Bergen");

            Bank bank = new Bank("DNB", 10000, Oslo, Bergen);
            Savings savings = new Savings(Oslo);

            bank.createAccount(savings);

            bool expected = false;

            bool result = bank.requestOverdraft(savings, 300);

            Assert.That(expected == result);

        }

        [Test]
        public void DecideOverdraftTest()
        {
            // yo
        }

    }
}