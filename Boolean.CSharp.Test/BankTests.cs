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
    public class BankTests
    {
        private Bank _bank;
        private Branch _branch;
        public BankTests()
        {
            _bank = new Bank();
            _branch = new Branch("G", 23234);
        }

        [TestCase ("Stockholm", 35314)]
        [TestCase ("GothenBorg", 35314)]
        public void CanCreateBank(string name, int code)
        { 
            
        }

        [Test]
        public void CanAddAccount() {
            PersonalAccount p = new PersonalAccount(_branch);
            SavingsAccount s = new SavingsAccount(_branch);
            string personal = _bank.AddAccount(p);
            string savings = _bank.AddAccount(s);
            Assert.That(_bank.Accounts.Count, Is.EqualTo(2));
            Assert.That(personal, Is.EqualTo("Account Added!"));
            Assert.That(savings, Is.EqualTo("Account Added!"));
        }
        [Test]
        public void CanRemoveAccount() {
            PersonalAccount p = new PersonalAccount(_branch);
            SavingsAccount s = new SavingsAccount(_branch);
            _bank.AddAccount(p);
            _bank.AddAccount(s);
            Assert.That(_bank.RemoveAccount(p), Is.EqualTo("Account Removed!"));
            Assert.That(_bank.RemoveAccount(s), Is.EqualTo("Account Removed!"));
        }

        [Test]
        public void CanRequestOverdraft() {
            PersonalAccount p = new PersonalAccount(_branch);
            _bank.AddAccount(p);
            Transaction transaction = _bank.RequestOverdraft(p, 1000);

            Signature manager = new Signature(true);

            string s = _bank.ApproveOverdraft(manager, transaction);

            Assert.That(p.GetBalance(), Is.EqualTo(1000));
        }

        [Test]
        public void CanNotRequestOverdraft() {
            PersonalAccount p = new PersonalAccount(_branch);
            _bank.AddAccount(p);
            Transaction transaction = _bank.RequestOverdraft(p, 1000);

            Signature manager = new Signature(true);

            _bank.DeclineOverdraft(manager, transaction);

            Assert.That(p.GetBalance(), Is.EqualTo(0));
        }

    }
}
