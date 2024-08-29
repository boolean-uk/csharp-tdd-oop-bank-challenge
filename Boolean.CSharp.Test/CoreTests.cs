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
            CurrentAccount account = new (1, "0768631232");

            bool result = account.Deposit(1000f);

            Assert.That(result, Is.True);
        }
        [Test]
        public void DepositNothing()
        {
            CurrentAccount account = new(1, "0768631232");

            bool result = account.Deposit(0f);

            Assert.That(result, Is.False);
        }
        [Test]
        public void DepositNegative()
        {
            CurrentAccount account = new(1, "0768631232");

            bool result = account.Deposit(-1000f);

            Assert.That(result, Is.False);
        }
        [Test]
        public void Withdraw()
        {
            CurrentAccount account = new(1, "0768631232");

            account.Deposit(1000f);
            bool result = account.Withdraw(1000f);

            Assert.That(result, Is.True);

        }
        [Test]
        public void WithdrawNegative()
        {
            CurrentAccount account = new(1, "0768631232");

            account.Deposit(1000f);
            bool result = account.Withdraw(-1000f);

            Assert.That(result, Is.False);
        }
        [Test]
        public void WithdrawMoreThanBalance()
        {
            CurrentAccount account = new(1, "0768631232");

            account.Deposit(1000f);
            bool result = account.Withdraw(2000f);

            Assert.That(result, Is.False);
        }
        [Test]
        public void Overdraft()
        {
            CurrentAccount account = new(1, "0768631232");

            bool result = account.Overdraft(500f);

            Assert.That(result, Is.True);
        }
        [Test]
        public void OverdraftBeyondLimit()
        {
            CurrentAccount account = new(1, "0768631232");

            bool result = account.Overdraft(1500f);

            Assert.That(result, Is.False);
        }
        [Test]
        public void OverdraftBeyondLimitSeveral()
        {
            CurrentAccount account = new(1, "0768631232");

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
            CurrentAccount account = new(1, "0768631232");

            account.Deposit(2000f);
            bool result = account.Overdraft(100f);

            // You cant overdraft an amount <= balance
            Assert.That(result, Is.False);
        }
        [Test]
        public void GenerateValidStatement()
        {
            var root = "C:\\Users\\AMetaj\\source\\repos\\csharp-tdd-oop-bank-challenge\\Boolean.CSharp.Test";
            var dotenv = Path.Combine(root, ".env");
            DotEnv.Load(dotenv);
            string expectedOutput = "date       || credit  || debit  || balance\r\n14/01/2012 ||         || 500.00 || 2500.00\r\n13/01/2012 || 2000.00 ||        || 3000.00\r\n10/01/2012 || 1000.00 ||        || 1000.00";
            IStatement statementbuilder = new StatementBuilder();
            ISMSProvider smsprovider = new TwilioProvider();
            string phonenr = Environment.GetEnvironmentVariable("PHONE_NUMBER");
            if (phonenr is null) throw new Exception("Phone number is null in test");
            int branch = 1;
            CurrentAccount account = new(branch, phonenr, smsprovider, statementbuilder);
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            account.Deposit(1000f);
            account.Deposit(2000f);
            account.Withdraw(500f);

            account.GenerateStatement();

            var output = stringWriter.ToString();
            Assert.That(output, Is.EqualTo(expectedOutput));

        }
        [Test]
        public void GenerateStatementFromNoTransactions()
        {
            string expectedOutput = "\r\n";
            var root = "C:\\Users\\AMetaj\\source\\repos\\csharp-tdd-oop-bank-challenge\\Boolean.CSharp.Test";
            var dotenv = Path.Combine(root, ".env");
            DotEnv.Load(dotenv);
            IStatement statementbuilder = new StatementBuilder();
            ISMSProvider smsprovider = new TwilioProvider();
            string phonenr = Environment.GetEnvironmentVariable("PHONE_NUMBER");
            if (phonenr is null) throw new Exception("Phone number is null in test");
            int branch = 1;
            CurrentAccount account = new(branch, phonenr, smsprovider, statementbuilder);
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            account.GenerateStatement();

            var output = stringWriter.ToString();
            Assert.That(output, Is.EqualTo(expectedOutput));
        }
    }
}