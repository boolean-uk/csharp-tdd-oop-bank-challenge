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
        public void setup() {
            _customer = new Customer();
            _bankStatementBuilder = new BankStatementBuilder();
            _bank = new Bank(_bankStatementBuilder);
            _currentAccount = _bank.createCurrentAccount(_customer, "init current");
            _savingsAccount = _bank.createSavingsAccount(_customer, "init savings");
        }

        [Test]
        public void TestCreateCurrentAccount()
        {
            _bank.createCurrentAccount(_customer, "Food account");
            _bank.createSavingsAccount(_customer, "Stock Savings");
            Assert.That(_customer.Accounts.Count(), Is.EqualTo(4));
            Assert.That(_customer.Accounts[3].AccountName, Is.EqualTo("Stock Savings"));
            Assert.That(_customer.Accounts[2].AccountName, Is.EqualTo("Food account"));
        }

        [TestCase(100.00f, 100.00f, true)]
        public void TestDepositToSavingsAccount(float input, float expectedBalance, bool expectedReturn)
        {
            _savingsAccount.Withdraw(_savingsAccount.Balance);
            bool returnBool = _savingsAccount.Deposit(input);
            Assert.That(_savingsAccount.Balance, Is.EqualTo(expectedBalance));
            Assert.That(returnBool, Is.EqualTo(expectedReturn));
        }

        [TestCase(100.00f, 100.00f, true)]
        public void TestDepositToCurrentAccount(float input, float expectedBalance, bool expectedReturn)
        {
            _savingsAccount.Withdraw(_savingsAccount.Balance);
            bool returnBool = _currentAccount.Deposit(input);
            Assert.That(_currentAccount.Balance, Is.EqualTo(expectedBalance));
            Assert.That(returnBool, Is.EqualTo(expectedReturn));
        }

        [TestCase(100.00f, 100.00f, true)]
        [TestCase(100.00f, 1000.00f, false)]
        public void TestWithdrawFromCurrentAccount(float initialBalance, float withdraw, bool expectedReturn)
        {
            _currentAccount.Deposit(initialBalance);
            bool returnBool = _currentAccount.Withdraw(withdraw);
            Assert.That(returnBool, Is.EqualTo(expectedReturn));
        }

        [TestCase(100.00f, 100.00f, true)]
        [TestCase(100.00f, 1000.00f, false)]
        public void TestWithdrawFromSavingsAccount(float initialBalance, float withdraw, bool expectedReturn)
        {
            _savingsAccount.Deposit(initialBalance);
            bool returnBool = _savingsAccount.Withdraw(withdraw);
            Assert.That(returnBool, Is.EqualTo(expectedReturn));
        }

        
        [Test]
        public void TestBankStatement()
        {
            _savingsAccount.Deposit(1000);
            _savingsAccount.Deposit(2000);
            _savingsAccount.Withdraw(500);
            int day = new DateTime().Day;
            int month = new DateTime().Month;
            int year = new DateTime().Year;
            string dmy = day.ToString() + "/" + month.ToString() + "/" + year.ToString();
            string returnBool = _savingsAccount.GetBankStatement();
            Console.WriteLine(returnBool);
            Assert.That(returnBool.Contains("2500"), Is.EqualTo(true));
            Assert.That(returnBool.Contains(dmy), Is.EqualTo(true));
        }
    }
}