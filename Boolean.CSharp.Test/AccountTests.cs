using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Accounts;
using Boolean.CSharp.Main.Enum;
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
    public class AccountTests
    {
        [Test]
        public void GetBalanceTest()
        {
            Savings savings = new Savings();

            Transactions transactions = new Transactions(500, DateTime.Now, TransactionType.CREDIT);
            savings._transactions.Add(transactions);

            double expected = 500;

            double result = savings.getBalance();

            Assert.That(expected == result);
        }

        [Test]
        public void DepositTest()
        {
            Savings savings = new Savings();

            double expected = 500.30;

            double result = savings.deposit(500.30);

            Assert.That(expected == result);
        }

        [Test]
        public void WithdrawTest()
        {
            Savings savings = new Savings();

            Transactions transactions = new Transactions(500, DateTime.Now, TransactionType.CREDIT);
            savings._transactions.Add(transactions);

            double expected = 300;

            double result = savings.withdraw(300);

            Assert.That(expected == result);
        }

        [Test]
        public void BankStatementTest()
        {
            Savings savings = new Savings();

            Transactions transactions1 = new Transactions(1000, DateTime.Now, TransactionType.CREDIT);
            Transactions transactions2 = new Transactions(2000, DateTime.Now, TransactionType.CREDIT);
            Transactions transactions3 = new Transactions(500, DateTime.Now, TransactionType.DEBIT);

            savings._transactions.Add(transactions1);
            savings._transactions.Add(transactions2);
            savings._transactions.Add(transactions3);

            Assert.That(2500 == savings.getBalance());
        }
    }
}
