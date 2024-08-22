using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Models;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class BankTests
    {
        private Bank _bank;

        public BankTests()
        {
            _bank = new Bank("BooleanBank");
        }

        [Test]
        public void TestCreateNewBranch()
        {
            Manager m = new Manager();
            WestBranch wb = new WestBranch(m);
            _bank.AddBranch(wb);
            
            Assert.That(_bank.GetBranches().Count, Is.EqualTo(1));
        }
        
        
        [Test]
        public void TestCreateNewCustomer() {}
        
        
        [Test]
        public void TestGetCustomer() {}
        
        
        [Test]
        public void TestCreateAccount() {}
        
        [Test]
        public void TestGetAccount() {}
        
        [Test]
        public void TestRequestOverdraft() {}
        
        [Test]
        public void TestSetSmsNotification() {}
        
        [Test]
        public void TestDeposit() {}
        
        [Test]
        public void TestWithdraw() {}
        
        [Test]
        public void TestGetTransactions() {}
        
        [Test]
        public void TestGetBalance() {}
        
        
        [Test]
        public void TestManageOverdraftRequests() {}
    }
}