using Boolean.CSharp.Main;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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

        // Transaction based balance was implemented alongside core usecase3
        // Accounts were implemented with branches from the start as bank is abstract. So everything belongs to a branch, derived from bank

        [Test]
        public void RequestOverdraftTest()
        {
            Branch gringotts = new Branch("Hogsmeade");

            Customer customer = new Customer("John Doe");

            Current gimmeMoreMoney = gringotts.CreateCurrentAccount(gringotts, customer, "000001");

            gringotts.RequestOverdraft(gimmeMoreMoney.AccountNr, 5000);

            bool expectedstatus = true;
            double expectedamount = 5000;

            bool statusresult = gimmeMoreMoney.PendingRequest;
            double requestamount = gimmeMoreMoney.RequestedOverdraft;


            Assert.AreEqual(expectedstatus, statusresult);
            Assert.AreEqual(expectedamount, requestamount);

        }

        [Test]
        public void ApproveOverdraftTest()
        {
            Branch gringotts = new Branch("Hogsmeade");

            Customer customer = new Customer("John Doe");

            Current gimmeMoreMoney = gringotts.CreateCurrentAccount(gringotts, customer, "000001");

            gringotts.RequestOverdraft(gimmeMoreMoney.AccountNr, 5000);

            bool expectedstatus = false;
            double expectedamount = 0.0;
            double overdraftIsSet = 5000;

            gringotts.ManageRequest(gimmeMoreMoney.AccountNr, true);

            bool statusresult = gimmeMoreMoney.PendingRequest;
            double requestamount = gimmeMoreMoney.RequestedOverdraft;
            double result = gimmeMoreMoney.Overdraft;

            Assert.AreEqual(expectedstatus, statusresult);
            Assert.AreEqual(expectedamount, requestamount);
            Assert.AreEqual(result, overdraftIsSet);
        }

        [Test]
        public void DenyOverdraftTest()
        {
            Branch gringotts = new Branch("Hogsmeade");

            Customer customer = new Customer("John Doe");

            Current gimmeMoreMoney = gringotts.CreateCurrentAccount(gringotts, customer, "000001");

            gringotts.RequestOverdraft(gimmeMoreMoney.AccountNr, 5000);

            bool expectedstatus = false;
            double expectedamount = 0.0;
            double overdraftIsSet = 0.0;

            gringotts.ManageRequest(gimmeMoreMoney.AccountNr, false);

            bool statusresult = gimmeMoreMoney.PendingRequest;
            double requestamount = gimmeMoreMoney.RequestedOverdraft;
            double result = gimmeMoreMoney.Overdraft;

            Assert.AreEqual(expectedstatus, statusresult);
            Assert.AreEqual(expectedamount, requestamount);
            Assert.AreEqual(result, overdraftIsSet);
        }

        [Test]
        public void DeclineWithdrawalTest()
        {
            Branch gringotts = new Branch("Hogsmeade");

            Customer customer = new Customer("John Doe");

            Current gimmeMoreMoney = gringotts.CreateCurrentAccount(gringotts, customer, "000001");

            gringotts.RequestOverdraft(gimmeMoreMoney.AccountNr, 5000);

            double expected = 0;

            gringotts.ManageRequest(gimmeMoreMoney.AccountNr, true);

            gringotts.Withdraw(gimmeMoreMoney.AccountNr, 10000);

            double result = gimmeMoreMoney.GetBalance();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void AcceptWithdrawalTest()
        {
            Branch gringotts = new Branch("Hogsmeade");

            Customer customer = new Customer("John Doe");

            Current gimmeMoreMoney = gringotts.CreateCurrentAccount(gringotts, customer, "000001");

            gringotts.RequestOverdraft(gimmeMoreMoney.AccountNr, 10000);

            double expected = -10000;

            gringotts.ManageRequest(gimmeMoreMoney.AccountNr, true);

            gringotts.Withdraw(gimmeMoreMoney.AccountNr, 10000);

            double result = gimmeMoreMoney.GetBalance();

            Assert.AreEqual(expected, result);
        }
    }
}
