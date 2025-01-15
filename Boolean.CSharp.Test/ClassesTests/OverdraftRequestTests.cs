using NUnit.Framework;
using System;
using Boolean.CSharp.Main.Classes;

namespace Boolean.CSharp.Test
{
    public class OverdraftRequestTests
    {
        private Bank bank;
        private Customer customer;
        private Account account;

        [SetUp]
        public void Setup()
        {
            bank = new Bank("Experis Bank", "Bergen Branch");
            customer = new Customer("Jone", "Hjorteland", "jonehjorteland@experis.no", "Vestre Strømkaien 13, 5008 Bergen", bank);
            account = new Account("Savings", customer, "Bergen Branch");
        }

        [Test]
        public void TestOverdraftRequestConstructor()
        {
            decimal requestedAmount = 1000m;

            var overdraftRequest = new OverdraftRequest(customer, account, requestedAmount);

            Assert.AreEqual(customer, overdraftRequest.Customer);
            Assert.AreEqual(account, overdraftRequest.Account);
            Assert.AreEqual(requestedAmount, overdraftRequest.RequestedAmount);
            Assert.IsFalse(overdraftRequest.IsApproved);
            Assert.IsFalse(overdraftRequest.IsProcessed);
            Assert.IsNotNull(overdraftRequest.RequestId);
        }

        [Test]
        public void TestApproveOverdraftRequest()
        {
            decimal requestedAmount = 1000m;
            var overdraftRequest = new OverdraftRequest(customer, account, requestedAmount);

            overdraftRequest.Approve();

            Assert.IsTrue(overdraftRequest.IsApproved);
            Assert.IsTrue(overdraftRequest.IsProcessed);
        }

        [Test]
        public void TestRejectOverdraftRequest()
        {
            decimal requestedAmount = 1000m;
            var overdraftRequest = new OverdraftRequest(customer, account, requestedAmount);

            overdraftRequest.Reject();

            Assert.IsFalse(overdraftRequest.IsApproved);
            Assert.IsTrue(overdraftRequest.IsProcessed);
        }

        [Test]
        public void TestApproveAfterRejectThrowsException()
        {
            decimal requestedAmount = 1000m;
            var overdraftRequest = new OverdraftRequest(customer, account, requestedAmount);

            overdraftRequest.Reject();

            Assert.Throws<InvalidOperationException>(() => overdraftRequest.Approve(), "This request has already been processed.");
        }

        [Test]
        public void TestRejectAfterApproveThrowsException()
        {
            decimal requestedAmount = 1000m;
            var overdraftRequest = new OverdraftRequest(customer, account, requestedAmount);

            overdraftRequest.Approve();

            Assert.Throws<InvalidOperationException>(() => overdraftRequest.Reject(), "This request has already been processed.");
        }

        [Test]
        public void TestGetAmountMethod()
        {
            decimal requestedAmount = 1000m;
            var overdraftRequest = new OverdraftRequest(customer, account, requestedAmount);

            Assert.AreEqual(requestedAmount, overdraftRequest.GetAmount());
        }

        [Test]
        public void TestToStringMethod()
        {
            decimal requestedAmount = 1000m;
            var overdraftRequest = new OverdraftRequest(customer, account, requestedAmount);

            string result = overdraftRequest.ToString();

            Assert.IsTrue(result.Contains("Overdraft Request ID"));
            Assert.IsTrue(result.Contains(customer.FirstName));
            Assert.IsTrue(result.Contains(customer.LastName));
            Assert.IsTrue(result.Contains(account.AccountType));
            Assert.IsTrue(result.Contains(requestedAmount.ToString("C")));
            Assert.IsTrue(result.Contains(overdraftRequest.RequestDate.ToString("dd/MM/yyyy")));
            Assert.IsTrue(result.Contains("Processed: False"));
            Assert.IsTrue(result.Contains("Approved: False"));
        }
    }
}
