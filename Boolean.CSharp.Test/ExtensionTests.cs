using Boolean.CSharp.Main;
using Newtonsoft.Json.Linq;
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
        private Customer _user;
        private Manager _manager;
        

        [SetUp]
        public void SetUp()
        {
            _user = new Customer();
            _manager = new Manager();
        }


        [TestCase(AccountType.GENERAL, "ITALY")]
        [TestCase(AccountType.SAVINGS, "FRANCE")]
        [TestCase(AccountType.SAVINGS, "SPAIN")]
        public void AccountsAssosiactedWithBranches(AccountType type, string branch)
        {
            IAccount acc = _user.addAccount(type, branch);
            Assert.AreEqual(acc.BRANCH, branch);

        }

        [TestCase(AccountType.GENERAL, "nothing")]
        [TestCase(AccountType.SAVINGS, "nothing")]
        public void NonexistendBranch(AccountType type, string branch)
        {
            Exception ex = Assert.Throws<System.Exception>(() => _user.addAccount(type, branch));
            Assert.That(ex.Message, Is.EqualTo("Branch does not exist!"));
        }



        [TestCase("N", false)]
        [TestCase("Y", true)]
        public void RequestOverdraft(string str, bool result)
        {
            _manager.registerCustomer(_user);
            var acc = _user.addAccount(AccountType.GENERAL, "ITALY") as GeneralAccount;

            acc.MakeTransaction(500.0F, TransactionType.DEPOSIT);

            var reader = new StringReader(str);
            var writer = new StringWriter();

            Console.SetIn(reader);
            Console.SetOut(writer);

            bool accepted = _user.requestOvedraft(acc.ID, 600.0F);

            string actualMessage = writer.ToString();

            Assert.AreEqual(accepted, result);

        }

        [Test]
        public void OverdraftNotNeeded()
        {
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            _manager.registerCustomer(_user);
            var acc = _user.addAccount(AccountType.GENERAL, "ITALY") as GeneralAccount;

            acc.MakeTransaction(500.0F, TransactionType.DEPOSIT);

            bool accepted = _user.requestOvedraft(acc.ID, 100.0F);

            var outputLines = stringWriter.ToString().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            Assert.That("Your requested amount does not exceed account balance!", Is.EqualTo(outputLines[0]));

        }

        [Test]
        public void noOverdraftsForSavingsAccount()
        {
      
            _manager.registerCustomer(_user);
            var acc = _user.addAccount(AccountType.SAVINGS, "ITALY") as SavingsAccount;

            acc.MakeTransaction(500.0F, TransactionType.DEPOSIT);

            bool accepted = _user.requestOvedraft(acc.ID, 600.0F);

            Assert.IsFalse(accepted);

        }
    }
}
