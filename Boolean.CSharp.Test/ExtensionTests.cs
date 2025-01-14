using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Models.Accounts;
using Boolean.CSharp.Main.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class ExtensionTests
    {
        private Bank _bank;
        private Customer _customer1;
        private Customer ;
        private CurrentAccount _currentAccount1;

        [SetUp]
        public void Setup()
        {
            _bank = new Bank();
            _customer1 = new Customer();

            _currentAccount1 = _customer1.CreateAccount(AccountType.Current, Branch.Oslo) as CurrentAccount;

            _bank.AddCustomer(_customer1);
        }




        [Test]
        public void TestRequestOverdraft()
        {
            _currentAccount1.RequestOverdraft(1000);
            Assert.That(_currentAccount1.OverdraftRequests.Count, Is.EqualTo(1));
            Assert.That(_currentAccount1.OverdraftRequests.First().Amount, Is.EqualTo(1000));
            Assert.That(_currentAccount1.OverdraftRequests.First().Approved, Is.False);

        }
        [Test]
        public void TestApproveRejectOverdraft()
        {
            OverdraftRequest request1 = _currentAccount1.RequestOverdraft(1000);

            request1.Approve(Role.Customer);
            Assert.That(_currentAccount1.GetOverdraftLimit(), Is.EqualTo(0));
            request1.Approve(Role.Manager);
            Assert.That(_currentAccount1.GetOverdraftLimit(), Is.EqualTo(1000));

            //I dont know how overdrafts work, but in this bank, a new request will set it to the amount, and not extend it by the amount
            OverdraftRequest request2 = _currentAccount1.RequestOverdraft(2000);
            request2.Approve(Role.Manager);
            Assert.That(_currentAccount1.GetOverdraftLimit(), Is.EqualTo(2000));

        }
    }
}
