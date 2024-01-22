using Boolean.CSharp.Main;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CoreTests
    {
        private BaseAccount _core;
        private string _date;
        private Branch branch = new Branch("Treasury London", "059900");

        [SetUp]
        public void SetUp()
        {
            _core = new Account(branch);
            _date = DateTime.Now.ToString("d");
        }

        [Test]
        public void ShouldDeposit()
        {
            bool result = _core.Deposit(500);
            Assert.IsTrue(result);
            Assert.That(_core.Logger.CurrentBalance(), Is.EqualTo(500));
        }

        [Test]
        public void ShouldNotDepositNegativeNumber()
        {
            bool result = _core.Deposit(-500);
            Assert.IsFalse(result);
            Assert.That(_core.Logger.CurrentBalance(), Is.EqualTo(0));
        }

        [Test]
        public void ShouldNotWithdrawEmpty()
        {
            bool result = _core.Withdraw(500);
            Assert.IsFalse(result);
            Assert.That(_core.Logger.CurrentBalance(), Is.EqualTo(0));
        }

        [Test]
        public void ShouldWithdraw()
        {
            _core.Deposit(1500);
            bool result = _core.Withdraw(500);
            Assert.IsTrue(result);
            Assert.That(_core.Logger.CurrentBalance(), Is.EqualTo(1000));
        }
        [Test]
        public void ShouldNotWithdrawNegativeNumber()
        {
            _core.Deposit(1500);
            bool result = _core.Withdraw(-500);
            Assert.IsFalse(result);
            Assert.That(_core.Logger.CurrentBalance(), Is.EqualTo(1500));
        }

        [Test]
        public void ShouldAddDepositLog()
        {
            LogTransaction logger = new LogTransaction();
            Transaction output = logger.AddLog(500);
            Assert.That(output.ToString(), Is.EqualTo($"{_date} ||  500.00 ||         ||  500.00"));
        }
        [Test]
        public void ShouldWithdrawLog()
        {
            LogTransaction logger = new LogTransaction();
            Transaction output = logger.AddLog(-500);
            Assert.That(output.ToString(), Is.EqualTo($"{_date} ||         ||  500.00 || -500.00"));
        }
        [Test]
        public void NothingLog()
        {
            LogTransaction logger = new LogTransaction();
            Transaction output = logger.AddLog(0);
            Assert.That(output.ToString(), Is.EqualTo($"{_date} ||         ||         ||    0.00"));
        }
        [Test]
        public void BrokeLog()
        {
            LogTransaction logger = new LogTransaction();
            Transaction output = logger.AddLog(-300);
            Assert.That(output.ToString(), Is.EqualTo($"{_date} ||         ||  300.00 || -300.00"));
        }
        [Test]
        public void DebtLog()
        {
            LogTransaction logger = new LogTransaction();
            Transaction output = logger.AddLog(-500);
            Assert.That(output.ToString(), Is.EqualTo($"{_date} ||         ||  500.00 || -500.00"));
        }
        [Test]
        public void PrintLog()
        {
            LogTransaction logger = new LogTransaction();
            logger.AddLog(-500);
            logger.AddLog(300);
            logger.Print();
            Assert.Pass();
        }

    }
}