using System;
using System.Collections.Generic;
using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Enums;
using NUnit.Framework;

namespace Boolean.CSharp.Main.Tests
{
    [TestFixture]
    public class BankBranchTest
    {
        private BankBranch bankBranch;
        private OverdraftRequest overdraftRequest;

        [SetUp]
        public void Setup()
        {
            bankBranch = new BankBranch("test branch");
            overdraftRequest = new OverdraftRequest(new Guid(), new BankTransaction(DateTime.Now, "asd", 0.2m));
        }

        [Test]
        public void AddOverdraftRequest()
        {
            bankBranch.AddOverdraftRequest(overdraftRequest);
            List<OverdraftRequest> requests = bankBranch.GetOverdraftRequests();

            Assert.Contains(overdraftRequest, requests);
        }

        [Test]
        public void RemoveOverdraftRequest()
        {
            bankBranch.AddOverdraftRequest(overdraftRequest);
            bankBranch.RemoveOverdraftRequest(overdraftRequest);
            List<OverdraftRequest> requests = bankBranch.GetOverdraftRequests();

            Assert.IsFalse(requests.Contains(overdraftRequest));
        }


        [Test]
        public void GetOverdraftRequests()
        {
            var overdraftRequest2 = new OverdraftRequest(new Guid(), new BankTransaction(DateTime.Now, "asdasd", 2.2m));
            bankBranch.AddOverdraftRequest(overdraftRequest);
            bankBranch.AddOverdraftRequest(overdraftRequest2);

            List<OverdraftRequest> requests = bankBranch.GetOverdraftRequests();

            Assert.Contains(overdraftRequest, requests);
            Assert.Contains(overdraftRequest2, requests);
        }
    }
}