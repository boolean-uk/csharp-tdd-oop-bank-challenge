using Boolean.CSharp.Main;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CoreTests
    {
        private BaseAccount _core;

        [SetUp]
        public void SetUp()
        {
            _core = new Account();
        }

        [Test]
        public void ShouldDeposit()
        {
            bool result = _core.Deposit(500);
            Assert.IsTrue(result);
            Assert.That(_core.Money, Is.EqualTo(500));
        }

        [Test]
        public void ShouldNotDepositNegativeNumber()
        {
            bool result = _core.Deposit(-500);
            Assert.IsFalse(result);
            Assert.That(_core.Money, Is.EqualTo(0));
        }

        [Test]
        public void ShouldNotWithdrawEmpty()
        {
            bool result = _core.Withdraw(500);
            Assert.IsFalse(result);
            Assert.That(_core.Money, Is.EqualTo(0));
        }

        [Test]
        public void ShouldWithdraw()
        {
            _core.Deposit(1500);
            bool result = _core.Withdraw(500);
            Assert.IsTrue(result);
            Assert.That(_core.Money, Is.EqualTo(1000));
        }
        [Test]
        public void ShouldNotWithdrawNegativeNumber()
        {
            _core.Deposit(1500);
            bool result = _core.Withdraw(-500);
            Assert.IsFalse(result);
            Assert.That(_core.Money, Is.EqualTo(1500));
        }

        [Test]
        public void ShouldAddDepositLog()
        {
            LogTransaction logger = new LogTransaction();
            string output = logger.AddLog(500, 1500);
            Assert.That(output, Is.EqualTo("19/01/2024 ||  500.00 ||         || 1500.00"));
        }
        [Test]
        public void ShouldWithdrawLog()
        {
            LogTransaction logger = new LogTransaction();
            string output = logger.AddLog(-500, 1500);
            Assert.That(output, Is.EqualTo("19/01/2024 ||         ||  500.00 || 1500.00"));
        }
        [Test]
        public void NothingLog()
        {
            LogTransaction logger = new LogTransaction();
            string output = logger.AddLog(0, 1500);
            Assert.That(output, Is.EqualTo("19/01/2024 ||         ||         || 1500.00"));
        }
        [Test]
        public void BrokeLog()
        {
            LogTransaction logger = new LogTransaction();
            string output = logger.AddLog(-300, 0);
            Assert.That(output, Is.EqualTo("19/01/2024 ||         ||  300.00 ||    0.00"));
        }
        [Test]
        public void DebtLog()
        {
            LogTransaction logger = new LogTransaction();
            string output = logger.AddLog(-500, -100);
            Assert.That(output, Is.EqualTo("19/01/2024 ||         ||  500.00 || -100.00"));
        }

    }
}