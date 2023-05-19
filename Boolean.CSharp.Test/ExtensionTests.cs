using Boolean.CSharp.Main;
using Boolean.CSharp.Main.CustomerAccounts;
using Boolean.CSharp.Main.EngineerAccount;
using Boolean.CSharp.Main.Users;
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
        public ExtensionTests()
        {
            _extension = new Extension("Iasonas Bank");
        }
        [Test]
        public void CheckDepositOnCurrentAccount()
        {
            EngineerAccount account1 = new EngineerCurrentAccount();
            EngineerAccount account2 = new EngineerSavingsAccount();
            User user = new Engineer("Iasonas", "Kotsarapoglou", "BlaBla@gmail.com", (EngineerCurrentAccount)account1, (EngineerSavingsAccount)account2);
            extension.makeADeposit(user, (EngineerCurrentAccount)account1, 50);
            decimal total = 0;
            foreach (var transaction in ((Engineer)user).account1.CurrentTransactions)
            {
                total += transaction.credit;
                total -= transaction.debit;
            }
            Assert.AreEqual(total, 50);
        }

        [Test]
        public void CheckDepositOnSavingsAccount()
        {
            EngineerAccount account1 = new EngineerCurrentAccount();
            EngineerAccount account2 = new EngineerSavingsAccount();
            User user = new Engineer("Iasonas", "Kotsarapoglou", "BlaBla@gmail.com", (EngineerCurrentAccount)account1, (EngineerSavingsAccount)account2);
            extension.makeADeposit(user, (EngineerSavingsAccount)account2, 70);
            decimal total = 0;
            foreach (var transaction in ((Engineer)user).account2.SavingsTransactions)
            {
                total += transaction.credit;
                total -= transaction.debit;
            }
            Assert.AreEqual(total, 70);

        }

        public Extension extension { get { return _extension; } }
    }
}
