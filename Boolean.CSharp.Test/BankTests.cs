using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Models;
using Boolean.CSharp.Main.Models.Accounts;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class BankTests
    {
        [Test]
        public void TestCreateNewBranch()
        { 
            Bank b = new("BooleanBank");
            var m = new Manager();
            var wb = new WestBranch(m);
            b.AddBranch(wb);
            
            Assert.That(b.GetBranches().Count, Is.EqualTo(1));
        }


        [Test]
        public void TestCreateNewCustomer()
        {
            Customer c = new ("John Doe", 0101991234,
                "98891337", new DateTime(1990, 1, 1));
            var m = new Manager();
            var wb = new WestBranch(m);
            wb.NewCustomer(c);
            
            Assert.That(wb.GetAllCustomers().Contains(c), Is.True);
        }


        [Test]
        public void TestGetCustomer()
        {
            Customer c = new ("John Doe", 0101991234,
                "98891337", new DateTime(1990, 1, 1));
            var m = new Manager();
            var wb = new WestBranch(m);
            wb.NewCustomer(c);
            
            Assert.That(wb.GetCustomer(0101991234), Is.EqualTo(c));
        }


        [Test]
        public void TestCreateAccount()
        {
            
            Customer c = new ("John Doe", 0101991234,
                "98891337", new DateTime(1990, 1, 1));
            c.CreateAccount("Main Account", AccountType.Spending);
            
            Assert.That(c.Accounts.Count, Is.EqualTo(1));
        }

        [Test]
        public void TestGetAccount()
        {
            Customer c = new ("John Doe", 0101991234,
                "98891337", new DateTime(1990, 1, 1));
            c.CreateAccount("Main Account", AccountType.Spending);
            
            Assert.That(c.GetAccount("Main Account").AccountType, Is.EqualTo(AccountType.Spending));
        }

        [Test]
        public void TestSetSmsNotification()
        {
            Customer c = new ("John Doe", 0101991234,
                "98891337", new DateTime(1990, 1, 1));
            var account = c.CreateAccount("Main Account", AccountType.Spending);
            account.ToggleSmsNotification();

            Assert.That(account.SmsNotification, Is.True);
        }

        [Test]
        public void TestDeposit()
        {
            Customer c = new ("John Doe", 0101991234,
                "98891337", new DateTime(1990, 1, 1));
            var account = c.CreateAccount("Main Account", AccountType.Spending);
            account.Deposit(500);
            
            Assert.That(account.GetTransactions().Count, Is.EqualTo(1));
        }

        [Test]
        public void TestWithdraw()
        {
            Customer c = new ("John Doe", 0101991234,
                "98891337", new DateTime(1990, 1, 1));
            var account = c.CreateAccount("Main Account", AccountType.Spending);
            account.Deposit(500);
            account.Withdraw(300);
            
            Assert.That(account.GetTransactions().Count, Is.EqualTo(2));
        }

        [Test]
        public void TestGetTransactions()
        {
            Customer c = new ("John Doe", 0101991234,
                "98891337", new DateTime(1990, 1, 1));
            var account = c.CreateAccount("Main Account", AccountType.Spending);
            account.Deposit(500);
            account.Withdraw(300);
            
            Assert.That(account.GetTransactions().Count, Is.EqualTo(2));
        }
        
        [Test]
        public void TestGetBalance() { 
            Customer c = new ("John Doe", 0101991234,
                "98891337", new DateTime(1990, 1, 1));
            var account = c.CreateAccount("Main Account", AccountType.Spending);
            account.Deposit(500);
            account.Withdraw(300);
            
            var result = account.GetBalance();
            Assert.That(result, Is.EqualTo(200));
        }

        [Test]
        public void TestRequestOverdraft()
        {
            Customer c = new ("John Doe", 0101991234,
                "98891337", new DateTime(1990, 1, 1));
            c.CreateAccount("Main Account", AccountType.Spending);
            c.RequestOverDraft(c.GetAccount("Main Account"), 500);
            
            Assert.That(Overdraft.OverdraftRequests.Count, Is.EqualTo(1));
        }

        [Test]
        public void TestManageOverdraftRequests()
        {
            Customer c = new ("John Doe", 0101991234,
                "98891337", new DateTime(1990, 1, 1));
            c.CreateAccount("Main Account", AccountType.Spending);
            c.RequestOverDraft(c.GetAccount("Main Account"), 500);
            
            var m = new Manager();
            var or = Overdraft.OverdraftRequests.FirstOrDefault()!;
            Overdraft.ApproveOverdraft(m, or);
            
            Assert.That(Overdraft.ApprovedOverdrafts.Count, Is.EqualTo(1));
        }
    }
}