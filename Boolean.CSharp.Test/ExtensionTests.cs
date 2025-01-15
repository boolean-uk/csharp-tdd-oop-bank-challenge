using Boolean.CSharp.Main;
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
        private Extension _extension;
        public ExtensionTests()
        {
            _extension = new Extension();
        }
        [Test]
        public void RequestOverdraft()
        {
            Bank bank = new Bank();
            Iperson customer = new Customer("11101010111", bank);
            Manager manager = new Manager("22222222222", bank);
            customer.CreateCurrentAccount();
            //request overdraft
            Iaccount account = customer.GetCurrentAccount();
            Request request = account.RequestOverdraft(10000, account.GetAccountID());
            manager.ApproveOverdraft(request);
            account.Withdraw(1000);
            Assert.That(account.CalculateBalance(), Is.EqualTo((decimal)-1000));
        }
        [Test]
        public void RequestAndApproveOverdraft()
        {
            Bank bank = new Bank();
            Iperson customer = new Customer("11101010111", bank);
            Manager manager = new Manager("22222222222", bank);
            customer.CreateCurrentAccount();
            //request overdraft
            Iaccount account = customer.GetCurrentAccount();
            account.Withdraw(1000);
            Assert.That(account.CalculateBalance(), Is.EqualTo(0));
        }
        [Test]
        public void DisapproveOverdraft()
        {
            Bank bank = new Bank();
            Iperson customer = new Customer("11101010111", bank);
            Manager manager = new Manager("22222222222", bank);
            customer.CreateCurrentAccount();
            //request overdraft
            Iaccount account = customer.GetCurrentAccount();
            Request request = account.RequestOverdraft(10000, account.GetAccountID());
            manager.RejectOverdraft(request);
            account.Withdraw(1000);
            Assert.That(account.CalculateBalance(), Is.EqualTo((decimal)0));
        }
    }
}
