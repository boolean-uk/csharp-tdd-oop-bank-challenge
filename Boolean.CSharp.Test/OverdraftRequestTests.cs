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
    public class OverdraftRequestTests
    {
        [Test]
        public void TestOverdraftRequestValues()
        {
            OverdraftRequest request = new OverdraftRequest(0, 100);

            Assert.That(request.Id, Is.EqualTo(0));
            Assert.That(request.Amount, Is.EqualTo(100));
            Assert.That(request.RequestTime.Date, Is.EqualTo(DateTime.Now.Date));
            Assert.That(request.Status, Is.EqualTo(OverdraftStatus.Pending));
        }

        [Test]
        public void TestOverdraftStatusChange()
        {
            OverdraftRequest request = new OverdraftRequest(0, 100);
            request.Status = OverdraftStatus.Approved;

            Assert.That(request.Status, Is.EqualTo(OverdraftStatus.Approved));
        }

        [Test]
        public void TestOverdraftZero() 
        {
            OverdraftRequest request = new OverdraftRequest(0, 0);

            Assert.That(request.Status, Is.EqualTo(OverdraftStatus.Approved));
        }

        [Test]
        public void TestOverdraftNegative()
        {
            OverdraftRequest request = new OverdraftRequest(0, -10);

            Assert.That(request.Status, Is.EqualTo(OverdraftStatus.Rejected));
        }
    }
}
