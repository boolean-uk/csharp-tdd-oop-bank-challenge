using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Accounts;
using Boolean.CSharp.Main.Enum;
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

        [Test]
        public void ShouldCalculateBalanceBasedOnTransactionHistory()
        {
            Customer c = new Customer(1, "Elsa");
            Current current = new Current();
            c.AddAccount(current);
            current.Deposit(100);
            current.Deposit(100);

            Assert.That(current.Balance, Is.EqualTo(200d));
        }
        [Test]
        public void ShouldReturnZero()
        {
            Customer c = new Customer(1, "Elsa");
            Current current = new Current();
            c.AddAccount(current);
            Assert.That(current.Balance, Is.EqualTo(0));
        }

        // Req for overdraft.
        // - Connected to the current account which i believe is the one that gets the salary
        // - Should be activated or deactivated

        [Test]
        public void ShouldRequestOverdraft()
        {
            Customer c = new Customer(1, "Elsa");
            Current current = new Current();
            c.AddAccount(current);
            current.WithDraw(50d);
            
            Assert.That(current.OverdraftRequests.Count, Is.EqualTo(1));
        }
        [Test]
        public void ShouldApproveOverdraftRequest()
        {
            Current current = new Current();
            current.WithDraw(30);
            var overdraft = current.OverdraftRequests[0];
            overdraft.Approve();

            current.WithDraw(overdraft);

            Assert.That(current.Transactions.Count, Is.EqualTo(1));
            Assert.That(current.GetBalance(), Is.EqualTo(0));
        }
    }
}
