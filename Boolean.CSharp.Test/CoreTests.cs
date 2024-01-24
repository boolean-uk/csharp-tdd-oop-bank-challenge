using Boolean.CSharp.Main;
using Boolean.CSharp.Main.AccountManagement;
using Boolean.CSharp.Main.Accounts;
using Boolean.CSharp.Main.BankStatements;
using Boolean.CSharp.Main.Customers;
using Boolean.CSharp.Main.Transactions;
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
            Assert.That(bank.GetCustomerAccounts(john)[0] is CurrentBankAccount);
            Assert.That(bank.GetCustomerAccounts(john)[1] is SavingsBankAccount);
        }

        [Test]
        public void TransactionTest()
        {
            BankAccount account = bank.GetCustomerAccounts(jane)[0];
            ITransaction transaction1 = new CreditTransaction(1000m);
            account.ApplyTransaction(transaction1);
            Assert.That(account.Balance == 1000m);
            ITransaction transaction2 = new DebitTransaction(500m);
            account.ApplyTransaction(transaction2);
            Assert.That(account.Balance == 500m);
            account.ApplyTransaction(transaction1);
            Assert.That(account.Balance == 1500m);
            Assert.That(account.Transactions.GetTransactions().Count == 3);
        }

        [Test]
        public void BankStatementTest()
        {
            BankAccount account = bank.GetCustomerAccounts(jane)[0];
            ITransaction workPayment = new CreditTransaction(6000m);
            ITransaction clothingPurchase = new DebitTransaction(150m);
            ITransaction groceryPurchase = new DebitTransaction(25m);
            ITransaction giftFrromJohn = new CreditTransaction(200m);
            ITransaction concertPurchase = new DebitTransaction(350m);
            account.ApplyTransaction(workPayment);
            account.ApplyTransaction(clothingPurchase);
            account.ApplyTransaction(groceryPurchase);
            account.ApplyTransaction(giftFrromJohn);
            account.ApplyTransaction(concertPurchase);
            IBankStatement statement = new SimpleBankStatement(account);
            Console.WriteLine(statement.GenerateStatement());
            Assert.That(statement.GenerateStatement().Contains("5850"));
        }

    }
}