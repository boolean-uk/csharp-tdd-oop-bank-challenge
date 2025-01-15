using NUnit.Framework;
using System;
using Boolean.CSharp.Main.Classes;

namespace Boolean.CSharp.Tests
{
    [TestFixture]
    public class TransactionTests
    {
        private Transaction depositTransaction;
        private Transaction withdrawalTransaction;

        [SetUp]
        public void SetUp()
        {
            depositTransaction = new Transaction("Deposit", 500m, 500m);
            withdrawalTransaction = new Transaction("Withdrawal", 200m, 300m);
        }

        [Test]
        public void transactionCreationShouldInitializeCorrectly()
        {
            Assert.AreEqual("Deposit", depositTransaction.Type);
            Assert.AreEqual(500m, depositTransaction.Amount);
            Assert.AreEqual(500m, depositTransaction.Balance);
            Assert.AreNotEqual(Guid.Empty, depositTransaction.TransactionId);
            Assert.AreNotEqual(DateTime.MinValue, depositTransaction.Date);
        }

        [Test]
        public void toStringShouldReturnCorrectTransactionInformation()
        {
            var expectedToString = $"{depositTransaction.Date.ToShortDateString()} | Deposit    | {500m:C} | {500m:C}";
            Assert.AreEqual(expectedToString, depositTransaction.ToString());
        }

        [Test]
        public void toStringShouldReturnCorrectWithdrawalTransactionInformation()
        {
            var expectedToString = $"{withdrawalTransaction.Date.ToShortDateString()} | Withdrawal | {200m:C} | {300m:C}";
            Assert.AreEqual(expectedToString, withdrawalTransaction.ToString());
        }

        [Test]
        public void transactionAmountShouldBePositiveForDeposit()
        {
            Assert.AreEqual(500m, depositTransaction.Amount);
            Assert.AreNotEqual(0m, depositTransaction.Amount);
        }

        [Test]
        public void transactionAmountShouldBePositiveForWithdrawal()
        {
            Assert.AreEqual(200m, withdrawalTransaction.Amount);
            Assert.AreNotEqual(0m, withdrawalTransaction.Amount);
        }

        [Test]
        public void transactionTypeShouldBeValid()
        {
            Assert.AreEqual("Deposit", depositTransaction.Type);
            Assert.AreEqual("Withdrawal", withdrawalTransaction.Type);
        }
    }
}
