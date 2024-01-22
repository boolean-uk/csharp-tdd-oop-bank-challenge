using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Accounts;
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
        public void ShouldReturnNegativeValue()
        {
            Customer c = new Customer(1, "Elsa");
            Current current = new Current();
            c.AddAccount(current);
            current.WithDraw(100);
            current.WithDraw(100);

            Assert.That(current.Balance, Is.EqualTo(-200d));
        }
        [Test]
        public void ShouldReturnZero()
        {
            Customer c = new Customer(1, "Elsa");
            Current current = new Current();
            c.AddAccount(current);
            Assert.That(current.Balance, Is.EqualTo(0));
        }
        [Test]
        public void test(){

        }
    }
}
