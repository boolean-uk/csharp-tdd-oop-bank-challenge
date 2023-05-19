using Boolean.CSharp.Main;
using Boolean.CSharp.Main.CustomerAccounts;
using Boolean.CSharp.Main.EngineerAccount;
using Boolean.CSharp.Main.ManagerAccount;
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

        [Test]
        public void checkDepositManager()
        {
            List<string> branches1 = new List<string>();
            branches1.Add("Nike");
            List<string> branches2 = new List<string>();
            branches2.Add("Adidas");
            ManagerAccount account1 = new ManagerCurrentAccount(100, branches1);
            ManagerAccount account2 = new ManagerSavingsAccount(100, branches2);
            User user = new Manager("Iasonas", "Kotsarapoglou", "BlaBla@gmail.com", (ManagerCurrentAccount)account1, (ManagerSavingsAccount)account2);
            extension.makeADepositManager(user, (ManagerCurrentAccount)account1, 50);
            extension.makeADepositManager(user, (ManagerSavingsAccount)account2, 100);
            Assert.AreEqual(((Manager)user).account1.balance, 150);
            Assert.AreEqual(((Manager)user).account2.balance, 200);
        }

        [Test]
        public void checkWithdrawManager()
        {
            List<string> branches1 = new List<string>();
            branches1.Add("Nike");
            List<string> branches2 = new List<string>();
            branches2.Add("Adidas");
            ManagerAccount account1 = new ManagerCurrentAccount(100, branches1);
            ManagerAccount account2 = new ManagerSavingsAccount(100, branches2);
            User user = new Manager("Iasonas", "Kotsarapoglou", "BlaBla@gmail.com", (ManagerCurrentAccount)account1, (ManagerSavingsAccount)account2);
            extension.makeAWithdrawManager(user, (ManagerCurrentAccount)account1, 50);
            extension.makeAWithdrawManager(user, (ManagerSavingsAccount)account2, 100);
            Assert.AreEqual(((Manager)user).account1.balance, 50);
            Assert.AreEqual(((Manager)user).account2.balance, 0);
        }

        [Test]
        public void checkBranches()
        {
            List<string> branches1 = new List<string>();
            branches1.Add("Nike");
            List<string> branches2 = new List<string>();
            branches2.Add("Adidas");
            ManagerAccount account1 = new ManagerCurrentAccount(100, branches1);
            ManagerAccount account2 = new ManagerSavingsAccount(100, branches2);
            User user = new Manager("Iasonas", "Kotsarapoglou", "BlaBla@gmail.com", (ManagerCurrentAccount)account1, (ManagerSavingsAccount)account2);
            extension.addBranchToAccount((Manager)user, account1, "Puma");
            extension.addBranchToAccount((Manager)user, account2, "Puma");
            extension.addBranchToAccount((Manager)user, account2, "Tommy");
            Assert.AreEqual(((Manager)user).account1.branchesAcc1.Count, 2);
            Assert.AreEqual(((Manager)user).account2.branchesAcc2.Count, 3);

        }

        [Test]
        public void checkFunds()
        {
            Account account1 = new CurrentAccount(1000);
            Account account2 = new SavingsAccount(500);
            User user1 = new Customer("Iasonas", "Kotsarapoglou", "BlaBla@gmail.com", account1, account2);
            List<string> branches1 = new List<string>();
            branches1.Add("Nike");
            List<string> branches2 = new List<string>();
            branches2.Add("Adidas");
            ManagerAccount account3 = new ManagerCurrentAccount(100, branches1);
            ManagerAccount account4 = new ManagerSavingsAccount(100, branches2);
            User user2 = new Manager("Nigel", "Sibbert", "BlaBla@gmail.com", (ManagerCurrentAccount)account3, (ManagerSavingsAccount)account4);
            extension.requestFound(user1, user2, account1, 200);
            Assert.AreEqual(((Customer)user1).account1.Balance, 1200);
            Assert.AreEqual(extension.funds.Count, 0);
        }

        public Extension extension { get { return _extension; } }
    }
}
