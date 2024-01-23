using Boolean.CSharp.Main;
using Boolean.CSharp.Main.AccountManagement;
using Boolean.CSharp.Main.Accounts;
using Boolean.CSharp.Main.Customers;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CoreTests
    {
        private BankAccountManager bank;
        private Customer john;
        private Customer jane;


        [SetUp]
        public void Initialization()
        {
            bank = new BankAccountManager();
            john = new Customer("John Doe");
            jane = new Customer("Jane Doe");
            bank.LinkAccountToCustomer(john, new CurrentBankAccount());
            bank.LinkAccountToCustomer(john, new SavingsBankAccount());
            bank.LinkAccountToCustomer(jane, new CurrentBankAccount());
        }

        [Test]
        public void InitializationAndCreateAccountTest()
        {
            Assert.That(bank.GetCustomerAccounts(john).Count == 2);
            Assert.That(bank.GetCustomerAccounts(jane).Count == 1);
        }

    }
}