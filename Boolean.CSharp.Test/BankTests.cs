using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Accounts;
using NUnit.Framework;
using Boolean.CSharp.Main.Enum;

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
        public void DecideOverdraftTest()
        {
            Branch Oslo = new Branch("Oslo");
            Branch Bergen = new Branch("Bergen");

            Bank bank = new Bank("DNB", 10000, Oslo, Bergen);
            Person person = new Person("Ben", Role.MANAGER, bank);

            Savings savings = new Savings(Oslo);

            savings.requestOverdraft(2000);

            bool expected = true;

            bool result = bank.decideOverdraft(savings._requests.First(), person.Role, true);

            Assert.That(expected == result);
            Assert.That(bank.emergencyFund == 8000);
        }

    }
}