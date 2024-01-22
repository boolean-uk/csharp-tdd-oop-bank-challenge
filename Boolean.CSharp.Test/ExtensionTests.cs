using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Core;
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
        private CurrentAccount current;
        private SavingsAccount saving;

        [SetUp]
        public void SetUp()
        {
            current = new CurrentAccount();
            saving = new SavingsAccount();

        }

        [Test]
        public void CumulativeDeposit()
        {
            saving.Deposit(15000);
            saving.Deposit(20000);
            Assert.That(saving._savings, Is.EqualTo(35000));
        }
    }
}
