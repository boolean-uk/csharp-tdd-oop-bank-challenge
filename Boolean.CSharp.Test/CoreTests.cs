using Boolean.CSharp.Main;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    /*
        TODO: GÖR KLART DOMAIN MODEL UTEFTER KLASSERNA
        REVERSA BANKSTATEMENT
        GÖR KLART KLASSDIAGRAM
    */
    [TestFixture]
    public class CoreTests
    {
        private Bank _bank;
        private SavingsAccount _savingsAccount;
        private CurrentAccount _currentAccount;
        private Customer _customer;
        private BankStatementBuilder _bankStatementBuilder;

        [SetUp]
        public void Setup()
        {
            _customer = new Customer();
            _bankStatementBuilder = new BankStatementBuilder();
            _bank = new Bank(_bankStatementBuilder);
            _currentAccount = _bank.CreateCurrentAccount(_customer, "init current");
            _savingsAccount = _bank.CreateSavingsAccount(_customer, "init savings");
        }

        [Test]
        public void TestCreateCurrentAccount()
        {
            _bank.CreateCurrentAccount(_customer, "Food account");
            _bank.CreateSavingsAccount(_customer, "Stock Savings");
            Assert.That(_customer.Accounts.Count(), Is.EqualTo(4));
            Assert.That(_customer.Accounts[3].AccountName, Is.EqualTo("Stock Savings"));
            Assert.That(_customer.Accounts[2].AccountName, Is.EqualTo("Food account"));
        }

        [TestCase(100.00f, 100.00f, true)]
        public void TestDepositToSavingsAccount(float input, float expectedBalance, bool expectedReturn)
        {
            bool returnBool = _savingsAccount.Deposit(input);
            Assert.That(_savingsAccount.Balance, Is.EqualTo(expectedBalance));
            Assert.That(_savingsAccount.Transactions.Count(), Is.EqualTo(1));
            Assert.That(_savingsAccount.Transactions[0].Amount, Is.EqualTo(input));
            Assert.That(_savingsAccount.Transactions[0].Balance, Is.EqualTo(expectedBalance));
            Assert.That(_savingsAccount.Transactions[0].TypeOfTransaction, Is.EqualTo(Transaction.TransactionType.Credit));
            Assert.That(returnBool, Is.EqualTo(expectedReturn));
        }

        [TestCase(100.00f, 100.00f, true)]
        public void TestDepositToCurrentAccount(float input, float expectedBalance, bool expectedReturn)
        {
            bool returnBool = _currentAccount.Deposit(input);
            Assert.That(_currentAccount.Balance, Is.EqualTo(expectedBalance));
            Assert.That(_currentAccount.Transactions.Count(), Is.EqualTo(1));
            Assert.That(_currentAccount.Transactions[0].Amount, Is.EqualTo(input));
            Assert.That(_currentAccount.Transactions[0].Balance, Is.EqualTo(expectedBalance));
            Assert.That(_currentAccount.Transactions[0].TypeOfTransaction, Is.EqualTo(Transaction.TransactionType.Credit));
            Assert.That(returnBool, Is.EqualTo(expectedReturn));
        }

        [TestCase(100.00f, 100.00f, true, 2)]
        [TestCase(100.00f, 1000.00f, false, 1)]
        public void TestWithdrawFromCurrentAccount(float initialBalance, float withdraw, bool expectedReturn, int transactions)
        {
            _currentAccount.Deposit(initialBalance);
            bool returnBool = _currentAccount.Withdraw(withdraw);
            if (returnBool)
            {
                Assert.That(_currentAccount.Balance, Is.EqualTo(0));
                Assert.That(_currentAccount.Transactions.Count(), Is.EqualTo(2));
                Assert.That(_currentAccount.Transactions[1].Amount, Is.EqualTo(withdraw));
                Assert.That(_currentAccount.Transactions[1].Balance, Is.EqualTo(0.00f));
                Assert.That(_currentAccount.Balance, Is.EqualTo(0.00f));
                Assert.That(_currentAccount.Transactions[1].TypeOfTransaction, Is.EqualTo(Transaction.TransactionType.Debit));

            }
            Assert.That(returnBool, Is.EqualTo(expectedReturn));
        }

        [TestCase(100.00f, 100.00f, true)]
        [TestCase(100.00f, 1000.00f, false)]
        public void TestWithdrawFromSavingsAccount(float initialBalance, float withdraw, bool expectedReturn)
        {
            _savingsAccount.Deposit(initialBalance);
            bool returnBool = _savingsAccount.Withdraw(withdraw);
            if (returnBool)
            {
                Assert.That(_savingsAccount.Transactions.Count(), Is.EqualTo(2));
                Assert.That(_savingsAccount.Transactions[1].Amount, Is.EqualTo(withdraw));
                Assert.That(_savingsAccount.Transactions[1].Balance, Is.EqualTo(0.00f));
                Assert.That(_currentAccount.Balance, Is.EqualTo(0f));
                Assert.That(_savingsAccount.Transactions[1].TypeOfTransaction, Is.EqualTo(Transaction.TransactionType.Debit));
            }
            Assert.That(returnBool, Is.EqualTo(expectedReturn));
        }

        [Test]
        public void TestBankStatement()
        {
            _savingsAccount.Deposit(1000);
            _savingsAccount.Deposit(2000);
            _savingsAccount.Withdraw(500);
            string bankstatement = _savingsAccount.GetBankStatement();
            List<string> output = GetStringLines(bankstatement);
            Assert.That(_savingsAccount.Balance, Is.EqualTo(2500.00f));
            Assert.That(_savingsAccount.Transactions.Count(), Is.EqualTo(3));
            Assert.That(output[0], Is.EqualTo("date       || credit  || debit  || balance"));
            Assert.That(output[1], Is.EqualTo("22/1/2024 ||  || 500 || 2500.00"));
            Assert.That(output[2], Is.EqualTo("22/1/2024 || 2000 ||  || 3000.00"));
            Assert.That(output[3], Is.EqualTo("22/1/2024 || 1000 ||  || 1000.00"));

        }

        static List<string> GetStringLines(string input)
        {
            // Split the string based on newline characters
            string[] linesArray = input.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            // Convert the array to a List<string>
            List<string> linesList = new List<string>(linesArray);

            return linesList;
        }
    }
}