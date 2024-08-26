using Boolean.CSharp.Main;

using Boolean.CSharp.Main.Enums;
using Boolean.CSharp.Main.Person;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{

    public class CoreTests
    {
        private Core _core;

        public CoreTests()
        {
            _core = new Core();

        }

        [Test]
        public void TestCurrentAccountCreated()
        {

            //arrange
            Customer customer = new Customer("Ali Haider", 1);

            string accountNumber1 = "1290 11 11212";

            AccountType current = AccountType.Current;

            //act
            bool currentAccountCreated = customer.createAccount(current, accountNumber1);

            //assert
            Assert.IsTrue(currentAccountCreated);
            Assert.AreEqual(1, customer.accounts.Count());
            var accountCreated = customer.accounts[0];
            Assert.IsNotNull(accountCreated);
            Assert.AreEqual(accountNumber1, accountCreated.AccountNumber);
            Assert.AreEqual(current, accountCreated.Type);

        }
        [Test]
        public void TestSavingsAccountCreated()
        {

            Customer customer = new Customer("Khan", 2);

            string accountNumber2 = "1234 112 113";

            AccountType savings = AccountType.Savings;

            bool savingsAccountCreated = customer.createAccount(savings, accountNumber2);

            Assert.IsTrue(savingsAccountCreated);
            Assert.AreEqual(1, customer.accounts.Count());
            var accountCreated = customer.accounts[0];
            Assert.IsNotNull(accountCreated);
            Assert.AreEqual(accountNumber2, accountCreated.AccountNumber);
            Assert.AreEqual(savings, accountCreated.Type);

        }
    }
}