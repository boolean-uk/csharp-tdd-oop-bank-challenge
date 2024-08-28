using Boolean.CSharp.Main;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CoreTests
    {
        [Test]
        public void Deposit()
        {
            ExpensesAccount account = new (1, "0768631232");

            bool result = account.Deposit(1000f);

            Assert.That(result, Is.True);
        }
        [Test]
        public void DepositNothing()
        {
            ExpensesAccount account = new(1, "0768631232");

            bool result = account.Deposit(0f);

            Assert.That(result, Is.False);
        }
        [Test]
        public void DepositNegative()
        {
            ExpensesAccount account = new(1, "0768631232");

            bool result = account.Deposit(-1000f);

            Assert.That(result, Is.False);
        }
        [Test]
        public void Withdraw()
        {
            ExpensesAccount account = new(1, "0768631232");

            account.Deposit(1000f);
            bool result = account.Withdraw(1000f);

            Assert.That(result, Is.True);

        }
        [Test]
        public void WithdrawNegative()
        {
            ExpensesAccount account = new(1, "0768631232");

            account.Deposit(1000f);
            bool result = account.Withdraw(-1000f);

            Assert.That(result, Is.False);
        }
        [Test]
        public void WithdrawMoreThanBalance()
        {
            ExpensesAccount account = new(1, "0768631232");

            account.Deposit(1000f);
            bool result = account.Withdraw(2000f);

            Assert.That(result, Is.False);
        }
        [Test]
        public void Overdraft()
        {
            ExpensesAccount account = new(1, "0768631232");

            bool result = account.Overdraft(500f);

            Assert.That(result, Is.True);
        }
        [Test]
        public void OverdraftBeyondLimit()
        {
            ExpensesAccount account = new(1, "0768631232");

            bool result = account.Overdraft(1500f);

            Assert.That(result, Is.False);
        }
        [Test]
        public void OverdraftBeyondLimitSeveral()
        {
            ExpensesAccount account = new(1, "0768631232");

            bool result1 = account.Overdraft(500f);
            bool result2 = account.Overdraft(500f);
            bool result3 = account.Overdraft(500f);

            Assert.Multiple(() =>
            {
                Assert.That(result1, Is.True);
                Assert.That(result2, Is.True);
                Assert.That(result3, Is.False);
            });
        }
        [Test]
        public void OverdraftPositiveBalance()
        {
            ExpensesAccount account = new(1, "0768631232");

            account.Deposit(2000f);
            bool result = account.Overdraft(100f);

            // You cant overdraft an amount <= balance
            Assert.That(result, Is.False);
        }
        [Test]
        public void GenerateValidStatement()
        {

        }
        [Test]
        public void GenerateStatementFromNoTransactions()
        {

        }
    }
}