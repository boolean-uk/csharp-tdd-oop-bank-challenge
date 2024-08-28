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

            (bool, double) expected = (true, 5000);

            (bool, double) result = gimmeMoreMoney.PendingRequest;

            Assert.AreEqual(expected, result);

        }
    }
}
