using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Models;
using Boolean.CSharp.Main.Models.Accounts;
using NUnit.Framework;
using static Boolean.CSharp.Main.Models.Accounts.AccountType;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class BankTests
    {
        [SetUp]
        public void SetUp()
        {
            Overdraft.OverdraftRequests.Clear();
        }
        
        [TestCase(0101991234, true)]
        [TestCase(0101994321, false)]
        public void TestCreateNewCustomer(int ssc, bool expected)
        {
            Bank b = new ("Bank");
            Customer c = new ("John Doe", 0101991234,
                "98891337", new DateTime(1990, 1, 1), Branch.Vest);
            b.NewCustomer(c);
            var result = b.GetAllCustomers().Any(x => x.SocialSecurityNumber.Equals(ssc));
            
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void TestGetCustomer()
        {
            Bank b = new ("Bank");
            Customer c = new ("John Doe", 0101991234,
                "98891337", new DateTime(1990, 1, 1), Branch.Vest);
            b.NewCustomer(c);
            
            Assert.That(b.GetCustomer(0101991234), Is.EqualTo(c));
        }

        [Test]
        public void TestCreateAccount()
        {
            Customer c = new ("John Doe", 0101991234,
                "98891337", new DateTime(1990, 1, 1), Branch.Vest);
            c.CreateAccount("Main Account", Spending);
            
            Assert.That(c.Accounts.Count, Is.EqualTo(1));
        }

        [TestCase(Spending)]
        [TestCase(Saving)]
        [TestCase(Credit)]
        public void TestGetAccount(AccountType at)
        {
            Customer c = new ("John Doe", 0101991234,
                "98891337", new DateTime(1990, 1, 1), Branch.Vest);
            c.CreateAccount("Main Account", at);
            
            Assert.That(c.GetAccount("Main Account").AccountType, Is.EqualTo(at));
        }

        [TestCase(true)]
        [TestCase(false)]
        public void TestSetSmsNotification(bool expected)
        {
            Customer c = new ("John Doe", 0101991234,
                "98891337", new DateTime(1990, 1, 1), Branch.Vest);
            var account = c.CreateAccount("Main Account", Spending);
            if (expected) account.ToggleSmsNotification();

            Assert.That(account.SmsNotification, Is.EqualTo(expected));
        }

        [TestCase(1)]
        [TestCase(3)]
        [TestCase(100)]
        public void TestDeposit(int multiply)
        {
            Customer c = new ("John Doe", 0101991234,
                "98891337", new DateTime(1990, 1, 1), Branch.Vest);
            var account = c.CreateAccount("Main Account", Spending);
            for (var i = 0; i < multiply; i++)
            {
                account.Deposit(100);
            }
            Assert.That(account.GetTransactions().Count, Is.EqualTo(multiply));
            Assert.That(account.GetBalance(), Is.EqualTo(100m * multiply));
        }

        [TestCase(200, 300, 2)]
        [TestCase(500, 0, 2)]
        [TestCase(1000, 500, 1)]
        public void TestWithdraw(decimal amount, decimal expected, int transactions)
        {
            Customer c = new ("John Doe", 0101991234,
                "98891337", new DateTime(1990, 1, 1), Branch.Vest);
            var account = c.CreateAccount("Main Account", Spending);
            account.Deposit(500);
            account.Withdraw(amount);
            
            Assert.That(account.GetTransactions().Count, Is.EqualTo(transactions));
            Assert.That(account.GetBalance(), Is.EqualTo(expected));
        }

        [Test]
        public void TestGetTransactions()
        {
            Customer c = new ("John Doe", 0101991234,
                "98891337", new DateTime(1990, 1, 1), Branch.Vest);
            var account = c.CreateAccount("Main Account", Spending);
            account.Deposit(500);
            account.Withdraw(300);
            
            Assert.That(account.GetTransactions().Count, Is.EqualTo(2));
        }
        
        [TestCase(100, 600)]
        [TestCase(-100, 400)]
        [TestCase(-600, 500)]
        public void TestGetBalance(decimal amount, decimal expected) { 
            Customer c = new ("John Doe", 0101991234,
                "98891337", new DateTime(1990, 1, 1), Branch.Vest);
            var account = c.CreateAccount("Main Account", Spending);
            account.Deposit(500);
            if (amount > 0) account.Deposit(amount);
            else account.Withdraw(amount * -1);
            
            var result = account.GetBalance();
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void TestRequestOverdraft()
        {
            Customer c = new ("John Doe", 0101991234,
                "98891337", new DateTime(1990, 1, 1), Branch.Vest);
            var a = c.CreateAccount("Main Account", Spending);
            a.Withdraw(500);
            
            Assert.That(Overdraft.OverdraftRequests.Count, Is.EqualTo(1));
        }

        [Test]
        public void TestManageOverdraftRequests()
        {
            Customer c = new ("John Doe", 0101991234,
                "98891337", new DateTime(1990, 1, 1), Branch.Vest);
            var a = c.CreateAccount("Main Account", Spending);
            a.Withdraw(500);
            Overdraft.ApproveOverdraft(new Manager(), Overdraft.OverdraftRequests.FirstOrDefault()!);
            
            Assert.That(Overdraft.OverdraftRequests.Count, Is.EqualTo(0));
        }
    }
}