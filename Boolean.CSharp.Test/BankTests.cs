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
        public void TestCreateNewCustomer()
        {
            Manager m = new Manager();
            WestBranch wb = new WestBranch(m);

            Customer c = new Customer("John Doe", 0101991234,
                "98891337", new DateTime(1990, 1, 1));
            wb.NewCustomer(c);
            
            Assert.That(wb.GetAllCustomers().Contains(c), Is.True);
        }


        [Test]
        public void TestGetCustomer()
        {
            Manager m = new Manager();
            WestBranch wb = new WestBranch(m);

            Customer c = new Customer("John Doe", 0101991234,
                "98891337", new DateTime(1990, 1, 1));
            wb.NewCustomer(c);
            
            Assert.That(wb.GetCustomer(0101991234), Is.EqualTo(c));
        }
        
        
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