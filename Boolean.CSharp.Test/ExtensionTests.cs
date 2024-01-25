using Boolean.CSharp.Main;
using Boolean.CSharp.Main.AccountManagement;
using Boolean.CSharp.Main.Accounts;
using Boolean.CSharp.Main.Branches;
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

        [Test]
        public void BranchTest()
        {
            Branch valleyBranch = new Branch("Valley Branch");
            Branch coastBranch = new Branch("Coast Branch");
            bank.LinkAccountToBranch(valleyBranch, bank.GetCustomerAccounts(john)[0]);
            bank.LinkAccountToBranch(valleyBranch, bank.GetCustomerAccounts(jane)[0]);
            bank.LinkAccountToBranch(coastBranch, bank.GetCustomerAccounts(john)[1]);
            Assert.That(bank.GetBranchAccounts(valleyBranch).Count == 2);
            Assert.That(bank.GetBranchAccounts(coastBranch).Count == 1);
        }

        [Test]
        public void OverdraftDisallowedByDefaultTest()
        {
            BankAccount account = bank.GetCustomerAccounts(jane)[0];
            ITransaction disallowedPurchase = new DebitTransaction(20m);
            Assert.Throws<InvalidOperationException>(() => account.ApplyTransaction(disallowedPurchase));
        }

        [Test]
        public void OverdraftRequestTest()
        {
            CurrentBankAccount account = (CurrentBankAccount)bank.GetCustomerAccounts(jane)[0];
            decimal balanceBeforeTransaction = account.Balance;
            ITransaction purchase = new DebitTransaction(20);
            account.ApplyOverdraftTransaction(purchase);
            Assert.That(account.Transactions.GetTransactions().Last() is OverdraftTransaction);
            Assert.That(account.Balance == balanceBeforeTransaction);
            OverdraftTransaction transactionToBeApproved = (OverdraftTransaction)account.Transactions.GetTransactions().Last();
            transactionToBeApproved.Approve();
            Assert.That(account.Balance < 0 && account.Balance == balanceBeforeTransaction - purchase.Amount);
        }

    }
}
