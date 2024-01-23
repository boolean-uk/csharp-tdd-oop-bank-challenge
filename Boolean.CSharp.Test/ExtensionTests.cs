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

        [Test]
        public void BranchTest()
        {
            //arrange
            Branch branch= new Branch("Bergen", "Bergen");

            //act
            branch.Location = "Oslo";
            branch.Name = "Oslo";

            //assert
            Assert.AreEqual("Oslo", branch.Name);

        }

        [Test]
        public void OverdraftTest()
        {
            //arrange
            Branch branch = new Branch("Bergen", "Bergen");
            CurrentAccount account = new CurrentAccount("Current account 1", branch);

            //act
            account.Withdraw(500);
            account.Withdraw(500);
            //assert
            Assert.AreEqual(-1000, account.Balance);
        }
        [Test]
        public void OverdraftRequestTest()
        {
            //arrange
            Branch branch = new Branch("Bergen", "Bergen");
            CurrentAccount account = new CurrentAccount("Current account 1", branch);

            //act
            account.Withdraw(500);
            account.Withdraw(500);
            account.Withdraw(500);
            account.Withdraw(500);
            //assert
            Assert.IsFalse(account.RequestOverDraft());
        }

    }
}
