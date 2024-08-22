using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Interface;
using Boolean.CSharp.Main.Models;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class BankTests
    {
        private readonly Bank _bank = new("BooleanBank");
        private Customer _customer = new Customer("John Doe", 0101991234,
            "98891337", new DateTime(1990, 1, 1));

        [Test]
        public void TestCreateNewBranch()
        {
            var m = new Manager();
            var wb = new WestBranch(m);
            _bank.AddBranch(wb);
            
            Assert.That(_bank.GetBranches().Count, Is.EqualTo(1));
        }


        [Test]
        public void TestCreateNewCustomer()
        {
            var m = new Manager();
            var wb = new WestBranch(m);
            wb.NewCustomer(_customer);
            
            Assert.That(wb.GetAllCustomers().Contains(_customer), Is.True);
        }


        [Test]
        public void TestGetCustomer()
        {
            var m = new Manager();
            var wb = new WestBranch(m);
            wb.NewCustomer(_customer);
            
            Assert.That(wb.GetCustomer(0101991234), Is.EqualTo(_customer));
        }


        [Test]
        public void TestCreateAccount()
        {
            _customer.CreateAccount("Main Account", AccountType.SPENDING);
            
            Assert.That(_customer.Accounts.Count, Is.EqualTo(1));
        }

        [Test]
        public void TestGetAccount()
        {
            _customer.CreateAccount("Main Account", AccountType.SPENDING);
            
            Assert.That(_customer.GetAccount("Main Account"), Is.EqualTo(_customer.Accounts[0]));
        }
        
        [Test]
        public void TestRequestOverdraft() { Assert.Fail(); }
        
        [Test]
        public void TestSetSmsNotification() { Assert.Fail(); }
        
        [Test]
        public void TestDeposit() { Assert.Fail(); }
        
        [Test]
        public void TestWithdraw() { Assert.Fail(); }
        
        [Test]
        public void TestGetTransactions() { Assert.Fail(); }
        
        [Test]
        public void TestGetBalance() { Assert.Fail(); }
        
        
        [Test]
        public void TestManageOverdraftRequests() { Assert.Fail(); }
    }
}