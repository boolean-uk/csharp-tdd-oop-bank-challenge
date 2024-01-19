using System.Text;
using Boolean.CSharp.Main;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class AccountTests
    {
        private Bank _bank;
        private Branch _branch;

        public AccountTests()
        {
            _bank = new Bank();
            _branch = new Branch("Sweden", 35253);
        }

        [Test]
        public void CanInstansiateAccount() {
            PersonalAccount personal = new PersonalAccount(_branch);
            SavingsAccount saving = new SavingsAccount(_branch);
            Assert.That(personal.Branch, Is.EqualTo(_branch));
            Assert.That(personal.Signature.IsManager, Is.EqualTo(false));
            Assert.That(personal.Transactions.Count, Is.EqualTo(0));
            
            Assert.That(saving.Branch, Is.EqualTo(_branch));
            Assert.That(saving.Signature.IsManager, Is.EqualTo(false));
            Assert.That(saving.Transactions.Count, Is.EqualTo(0));

        }

        [TestCase (100)]
        [TestCase (500)]
        public void CanDeposit(int value) {
            PersonalAccount personal = new PersonalAccount(_branch);
            Transaction transaction = personal.Deposit(value);
            Assert.That(transaction.Amount, Is.EqualTo(value));
        }

        [TestCase (100)]
        [TestCase (500)]
        public void CanWithdrawl(int value) {
            PersonalAccount personal = new PersonalAccount(_branch);
            personal.Deposit(500);
            Console.WriteLine(value);
            Transaction transaction = personal.Withdrawl(value);
            Assert.That(transaction.Balance, Is.EqualTo(500-value));
            Assert.That(transaction.Amount, Is.EqualTo(value));
        }

        [Test]
        public void CanPrintReceipt() {
            PersonalAccount p = new PersonalAccount(_branch);
            Transaction t = p.Deposit(100);
            StringBuilder b = p.PrintReceipt();

            Assert.That(b.ToString(), Does.Contain($"{t.Amount}"));
            Assert.That(b.ToString(), Does.Contain($"{t.Balance}"));
        }
    }
}