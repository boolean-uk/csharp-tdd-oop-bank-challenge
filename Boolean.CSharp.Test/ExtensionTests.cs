using Boolean.CSharp.Main;
using Boolean.CSharp.Main.AccountManagement;
using Boolean.CSharp.Main.Accounts;
using Boolean.CSharp.Main.Customers;
using Boolean.CSharp.Main.Transactions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class ExtensionTests
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
        public void BalanceDerivedPropertyTest()
        {
            BankAccount account = bank.GetCustomerAccounts(john)[0];
            ITransaction generousGift = new CreditTransaction(5000m);
            ITransaction recklessPurchase = new DebitTransaction(4000m);
            account.ApplyTransaction(generousGift);
            account.ApplyTransaction(recklessPurchase);
            Assert.That(account.Balance == 1000m);
        }

    }
}
