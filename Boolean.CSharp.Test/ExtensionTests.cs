using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Objects;
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
        public void CalculateBalanceTest()
        {
            //arrange
            Branch branch = new Branch("Bergen", "Bergen");
            CurrentAccount account = new CurrentAccount("Current account 1", branch);
            account.Deposit(600);
            account.Withdraw(200);

            //act
            double result = account.AccountStatement.CalculateBalance();

            //assert
            Assert.AreEqual(400, result);
        }
        
    }
}
