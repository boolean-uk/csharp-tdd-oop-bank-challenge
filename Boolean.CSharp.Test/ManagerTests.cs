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
    public class ManagerTests
    {
        [Test]
        public void TestManagerValues()
        {
            Manager manager = new Manager("Kristian");

            Assert.That(manager.Name, Is.EqualTo("Kristian"));
        }

        [Test]
        public void TestUpdateOverdraftRequests()
        {
            OverdraftRequest overdraft = new OverdraftRequest(0, 100);
            OverdraftRequest overdraft1 = new OverdraftRequest(1, 200);

            List<OverdraftRequest> requests = new List<OverdraftRequest>()
            {
                overdraft, overdraft1
            };

            Manager manager = new Manager("Kristian");
            manager.OverdraftRequests = requests;

            Assert.That(manager.OverdraftRequests.Count, Is.EqualTo(2));
        }

        [Test]
        public void TestApproveAllOverdraftRequests()
        {
            OverdraftRequest overdraft = new OverdraftRequest(0, 100);
            OverdraftRequest overdraft1 = new OverdraftRequest(1, 200);

            List<OverdraftRequest> requests = new List<OverdraftRequest>()
            {
                overdraft, overdraft1
            };

            Manager manager = new Manager("Kristian");
            manager.OverdraftRequests = requests;
            manager.ApproveAllOverdraftRequests();

            Assert.That(manager.OverdraftRequests[0].Status, Is.EqualTo(OverdraftStatus.Approved));
            Assert.That(manager.OverdraftRequests[1].Status, Is.EqualTo(OverdraftStatus.Approved));
        }

        [Test]
        public void TestApproveOverdraftRequestsAmount()
        {
            OverdraftRequest overdraft = new OverdraftRequest(0, 100);
            OverdraftRequest overdraft1 = new OverdraftRequest(1, 200);

            List<OverdraftRequest> requests = new List<OverdraftRequest>()
            {
                overdraft, overdraft1
            };

            Manager manager = new Manager("Kristian");
            manager.OverdraftRequests = requests;
            manager.ApproveOverdraftRequestsAmount(100);

            Assert.That(manager.OverdraftRequests[0].Status, Is.EqualTo(OverdraftStatus.Approved));
            Assert.That(manager.OverdraftRequests[1].Status, Is.EqualTo(OverdraftStatus.Pending));
        }

        [Test]
        public void TestApproveOverdraftRequestsId()
        {
            OverdraftRequest overdraft = new OverdraftRequest(0, 100);
            OverdraftRequest overdraft1 = new OverdraftRequest(1, 200);

            List<OverdraftRequest> requests = new List<OverdraftRequest>()
            {
                overdraft, overdraft1
            };

            Manager manager = new Manager("Kristian");
            manager.OverdraftRequests = requests;
            manager.ApproveOverdraftRequestsId(1);

            Assert.That(manager.OverdraftRequests[0].Status, Is.EqualTo(OverdraftStatus.Pending));
            Assert.That(manager.OverdraftRequests[1].Status, Is.EqualTo(OverdraftStatus.Approved));
        }

        [Test]
        public void TestRejectAllOverdraftRequests()
        {
            OverdraftRequest overdraft = new OverdraftRequest(0, 100);
            OverdraftRequest overdraft1 = new OverdraftRequest(1, 200);

            List<OverdraftRequest> requests = new List<OverdraftRequest>()
            {
                overdraft, overdraft1
            };

            Manager manager = new Manager("Kristian");
            manager.OverdraftRequests = requests;
            manager.RejectAllOverdraftRequests();

            Assert.That(manager.OverdraftRequests[0].Status, Is.EqualTo(OverdraftStatus.Rejected));
            Assert.That(manager.OverdraftRequests[1].Status, Is.EqualTo(OverdraftStatus.Rejected));
        }

        [Test]
        public void TestRejectOverdraftRequestsAmount()
        {
            OverdraftRequest overdraft = new OverdraftRequest(0, 100);
            OverdraftRequest overdraft1 = new OverdraftRequest(1, 200);

            List<OverdraftRequest> requests = new List<OverdraftRequest>()
            {
                overdraft, overdraft1
            };

            Manager manager = new Manager("Kristian");
            manager.OverdraftRequests = requests;
            manager.RejectOverdraftRequestsAmount(101);

            Assert.That(manager.OverdraftRequests[0].Status, Is.EqualTo(OverdraftStatus.Pending));
            Assert.That(manager.OverdraftRequests[1].Status, Is.EqualTo(OverdraftStatus.Rejected));
        }

        [Test]
        public void TestRejectOverdraftRequestsId()
        {
            OverdraftRequest overdraft = new OverdraftRequest(0, 100);
            OverdraftRequest overdraft1 = new OverdraftRequest(1, 200);

            List<OverdraftRequest> requests = new List<OverdraftRequest>()
            {
                overdraft, overdraft1
            };

            Manager manager = new Manager("Kristian");
            manager.OverdraftRequests = requests;
            manager.RejectOverdraftRequestsId(1);

            Assert.That(manager.OverdraftRequests[0].Status, Is.EqualTo(OverdraftStatus.Pending));
            Assert.That(manager.OverdraftRequests[1].Status, Is.EqualTo(OverdraftStatus.Rejected));
        }

        [Test]
        public void AddOverdraftRequest()
        {
            OverdraftRequest overdraft = new OverdraftRequest(0, 100);
            Manager manager = new Manager("Kristian");
            manager.AddOverdraftRequest(overdraft);

            Assert.That(manager.OverdraftRequests.Count, Is.EqualTo(1));
        }
    }
}
