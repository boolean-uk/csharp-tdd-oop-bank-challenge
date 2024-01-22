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
    public class BankStatementTest
    {
        [Test]
        public void CalculatesNegativeMoneyCorrectly()
        {
            BankStatement statement = new(100, -20);
            Assert.That(statement.Balance, Is.EqualTo(80));
        }

        [Test]
        public void CalculatesPositiveMoneyCorrectly()
        {
            BankStatement statement = new(100, 20);
            Assert.That(statement.Balance, Is.EqualTo(120));
        }
    }
}
