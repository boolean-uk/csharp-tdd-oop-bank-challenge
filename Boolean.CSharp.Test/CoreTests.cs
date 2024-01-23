using Boolean.CSharp.Main;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CoreTests
    {
        private Customer _customer;
        public CoreTests()
        {
            _customer = new Customer();
        }

        [Test]
        public void addAccountTest()
        {
            SavingsAccount newSavings = (SavingsAccount)_customer.createAccount(762308, AccountType.savings, "Belfast");
            CurrentAccount newCurrent = (CurrentAccount)_customer.createAccount(556223, AccountType.current, "Slough");
            Assert.That(_customer.Accounts.Contains(newSavings));
            Assert.That(_customer.Accounts.Contains(newCurrent));
        }
        [TestCase(10f, 3f, 7f)]
        [TestCase(621f, 21f, 600f)]
        [TestCase(1000f, 100f, 900f)]
        public void depositWithdrawChangesBalance(float deposit, float withdraw, float total)
        {
            CurrentAccount currentAccount = (CurrentAccount)_customer.createAccount(642758, AccountType.current, "Middlesburough");
            currentAccount.deposit(deposit);
            currentAccount.withdraw(withdraw);
            Assert.That(currentAccount.getTotal(), Is.EqualTo(total));
            Assert.That(currentAccount.Transactions.Count, Is.EqualTo(2));
        }
        [TestCase(0f, 1000f)]
        [TestCase(-5f, -5f)]
        [TestCase(0f, 101f)]
        public void failedDepositWithdrawThrowsException(float deposit, float withdraw)
        {
            //setup
            SavingsAccount savingsAccount = (SavingsAccount)_customer.createAccount(123456, AccountType.savings, "Manchester");
            savingsAccount.deposit(100);
            //verify
            Assert.That(() => savingsAccount.deposit(deposit), Throws.Exception);
            Assert.That(() => savingsAccount.withdraw(withdraw), Throws.Exception);
        }
        [Test]
        public void tooLargeWithdrawTest()
        {
            SavingsAccount account = (SavingsAccount)_customer.createAccount(123456, AccountType.savings, "New Castle");
            account.deposit(1000f);
            Assert.That(() => account.withdraw(1110f), Throws.Exception);
        }
        [Test]
        public void transactionsAddToList()
        {
            SavingsAccount savingsAccount = (SavingsAccount)_customer.createAccount(123456, AccountType.savings, "Birmingham");
            var result = savingsAccount.deposit(1000f);
            DateTime time = DateTime.Now;
            Transaction transaction = new Transaction(1000f, TransactionType.deposit, time.ToString("D"), savingsAccount.getTotal());
            string expectedJson = JsonConvert.SerializeObject(transaction);
            string resultJson = JsonConvert.SerializeObject(result);
            Assert.That(resultJson, Is.EqualTo(expectedJson));
        }
        [Test]
        public void printStatementTest()
        {
            SavingsAccount savingsAccount = (SavingsAccount)_customer.createAccount(123456, AccountType.savings, "Brighton");
            savingsAccount.deposit(1000f);
            savingsAccount.withdraw(25.99f);
            List<string> statement = new List<string>();
            statement = savingsAccount.printStatement();
            DateTime time = DateTime.Now;
            Assert.That(statement.ElementAt(0), Is.EqualTo($"{time.ToString("D")}  ||  1000     ||  deposit  ||  1000  "));
        }
        [TestCase(500f, 500f, -500f)]
        [TestCase(500f, 250f, -250f)]
        [TestCase(100f, 50f, -50f)]
        [TestCase(-100f, 1f, 9f)]
        public void overdraftTest(float over, float with, float it)
        {
            //setup
            CurrentAccount account = (CurrentAccount)_customer.createAccount(221133, AccountType.current, "London");
            account.requestOverdraft(over);
            if (over < 0)
                account.deposit(10f);
            //execution
            account.withdraw(with);
            
            //evaluation
            Assert.That(account.getTotal(), Is.EqualTo(it));
        }
        [Test]
        public void branchTest()
        {
            CurrentAccount account = (CurrentAccount)_customer.createAccount(221133, AccountType.current, "Slough");
            string branch = account.Branch;
            Assert.That(branch, Is.EqualTo("Slough"));
        }
    }
}