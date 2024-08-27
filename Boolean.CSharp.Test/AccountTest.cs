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
    public class AccountTest
    {

        [TestCase (1000, 2000, 3000)] 
        [TestCase (0, 1050, 1050)] 
        [TestCase (5000, -10, 5000)] 
        public void DepositTest(decimal balance, decimal deposit, decimal expected)
        {
            IAccount current = new CurrentAccount(132);
            IAccount saving = new SavingAccount(131);

            current.AccountBalance.Add(current.AccountNumber, balance);
            saving.AccountBalance.Add(saving.AccountNumber, balance);

            decimal actual = current.Deposit(deposit);
            decimal actual1 = saving.Deposit(deposit);

            Assert.That(actual, Is.EqualTo(expected));
            Assert.That(actual1, Is.EqualTo(expected));
        }

        [TestCase(1000, 1000, 0)]
        [TestCase(2000, 1000, 1000)]
        [TestCase(50, 100, -50)]
        [TestCase(0, 2500, 0)]
        public void WhitdrawalTest(decimal balance, decimal whitdrawal, decimal expected)
        {
            IAccount current = new CurrentAccount(132);
            IAccount saving = new SavingAccount(131);

            current.AccountBalance.Add(current.AccountNumber, balance);
            saving.AccountBalance.Add(saving.AccountNumber, balance);

            decimal actual = current.Withdraw(whitdrawal);
            decimal actual1 = saving.Withdraw(whitdrawal);

            Assert.That(actual, Is.EqualTo(expected));
            Assert.That(actual1, Is.EqualTo(expected));
        }
    }
}
