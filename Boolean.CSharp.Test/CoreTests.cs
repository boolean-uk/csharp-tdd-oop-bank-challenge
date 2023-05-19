using Boolean.CSharp.Main;
using Boolean.CSharp.Main.CustomerAccounts;
using Boolean.CSharp.Main.Users;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CoreTests
    {
        private Core _core;

        public CoreTests()
        {
            _core = new Core("Iasonas Bank");

        }

        [Test]
        public void CheckDepositOnCurrentAccount()
        {
            Account account1 = new CurrentAccount(1000);
            Account account2 = new SavingsAccount(500);
            User user = new Customer("Iasonas", "Kotsarapoglou", "BlaBla@gmail.com", account1 , account2);
            core.makeADeposit(user, ((Customer)user).account1, 20);
            Assert.AreEqual(((Customer)user).account1.Balance, 1020);
        }

        [Test]
        public void CheckDepositOnSavingsAccount()
        {
            Account account1 = new CurrentAccount(1000);
            Account account2 = new SavingsAccount(500);
            User user = new Customer("Iasonas", "Kotsarapoglou", "BlaBla@gmail.com", account1, account2);
            core.makeADeposit(user, ((Customer)user).account2, 20);
            Assert.AreEqual(((Customer)user).account2.Balance, 520);
        }

        [Test]
        public void CheckWithdrawOnCurrentAccount()
        {
            Account account1 = new CurrentAccount(1000);
            Account account2 = new SavingsAccount(500);
            User user = new Customer("Iasonas", "Kotsarapoglou", "BlaBla@gmail.com", account1, account2);
            core.makeAWithdraw(user, ((Customer)user).account1, 20);
            Assert.AreEqual(((Customer)user).account1.Balance, 980);
        }

        [Test]
        public void CheckWithdrawOnSavingsAccount()
        {
            Account account1 = new CurrentAccount(1000);
            Account account2 = new SavingsAccount(500);
            User user = new Customer("Iasonas", "Kotsarapoglou", "BlaBla@gmail.com", account1, account2);
            core.makeAWithdraw(user, ((Customer)user).account2, 20);
            Assert.AreEqual(((Customer)user).account2.Balance, 480);
        }

        [Test]
        public void checkCurrentAccountBankStatement()
        {
            Account account1 = new CurrentAccount(1000);
            Account account2 = new SavingsAccount(500);
            User user = new Customer("Iasonas", "Kotsarapoglou", "BlaBla@gmail.com", account1, account2);
            Assert.AreEqual(((Customer)user).account1.CurrentTransactions, core.printBankStatement(user, account1));

        }


        [Test]
        public void checkSavingsAccountBankStatement()
        {
            Account account1 = new CurrentAccount(1000);
            Account account2 = new SavingsAccount(500);
            User user = new Customer("Iasonas", "Kotsarapoglou", "BlaBla@gmail.com", account1, account2);
            Assert.AreEqual(((Customer)user).account2.SavingsTransactions, core.printBankStatement(user, account2));

        }


        public Core core { get { return _core; } }

    }
}