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
    public class ExtensionTests
    {
        private Extension _extension;
        private LogTransaction _logger;
        private Branch branch = new Branch("Treasury London", "059900");
        private SavingsAccount _account;
        public ExtensionTests()
        {
            _logger = new LogTransaction();
            _extension = new Extension();
            _account = new SavingsAccount(branch);
        }
        [SetUp]
        public void SetUp()
        {
            _logger = new LogTransaction();
            _extension = new Extension();
            _account = new SavingsAccount(branch);
        }
        [Test]
        public void TestQuestion1()
        {
            _logger.AddLog(300);
            _logger.AddLog(500);
            _logger.Print();
            Assert.That(_logger.CurrentBalance, Is.EqualTo(800));
        }
        [Test]
        public void TestQuestion2()
        {
            OverdraftRequest result = _account.RequestOverdraft(500);
            Assert.That(result.Status, Is.EqualTo(OverdraftStatus.Pending));
            Assert.That(result.Money, Is.EqualTo(500));
        }
        [Test]
        public void ShouldTransferWhenAccepted()
        {
            OverdraftRequest result = _account.RequestOverdraft(500);
            result.Approve();
            Assert.That(result.Status, Is.EqualTo(OverdraftStatus.Accepted));
            Assert.That(_account.Logger.CurrentBalance, Is.EqualTo(-500));
        }
        [Test]
        public void ShouldDecline()
        {
            OverdraftRequest result = _account.RequestOverdraft(500);
            result.Decline();
            Assert.That(result.Status, Is.EqualTo(OverdraftStatus.Declined));
        }
        [Test]
        public void ShouldNotDeclineWhenAlreadyApproved()
        {
            OverdraftRequest result = _account.RequestOverdraft(500);
            result.Approve();
            result.Decline();
            Assert.That(result.Status, Is.EqualTo(OverdraftStatus.Accepted));
        }
        [Test]
        public void ShouldNotApproveWhenAlreadyDeclined()
        {
            OverdraftRequest result = _account.RequestOverdraft(500);
            result.Decline();
            result.Approve();
            Assert.That(result.Status, Is.EqualTo(OverdraftStatus.Declined));
        }
    }
}
