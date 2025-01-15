using Boolean.CSharp.Main;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    public class CoreTests
    {
        [Test]
        public void TestAddtoAccount()
        {
            User user = new User("Aksel");
            Assert.That(user.Admin, Is.False);
            user.CreateAccount(user.Name, "Oslo", "a");
            Assert.That(user.Accounts.Count(), Is.EqualTo(1));
            Assert.That(user.Accounts[0].Total(), Is.EqualTo(0m));
            user.Accounts[0].Deposit(999.1m);
            Assert.That(user.Accounts[0].Total(), Is.EqualTo(999.1m));
            Assert.That(user.Accounts[0].Withdraw(1000000000m), Is.False);
            Assert.That(user.Accounts[0].Withdraw(999.1m), Is.True);

            user.Accounts[0].Deposit(999.1m);
            user.Accounts[0].Withdraw(999m);
            Assert.That(user.Accounts[0].Total(), Is.EqualTo(0.1m));
            Assert.That(user.Accounts[0].Transactions.Count, Is.EqualTo(4));

        }
        [Test]

        public void TestBankStatement()
        {
            User user = new User("Aksel");
            user.CreateAccount(user.Name, "Oslo", "a");
            user.Accounts[0].Deposit(100.1m);
            user.Accounts[0].Withdraw(10.0m);

            Assert.That(user.Accounts[0].BankStatement(), Does.Contain("credit"));
            Assert.That(user.Accounts[0].BankStatement(), Does.Contain("10,0"));
            Assert.That(user.Accounts[0].BankStatement(), Does.Contain("90,1"));
        }
    }
}