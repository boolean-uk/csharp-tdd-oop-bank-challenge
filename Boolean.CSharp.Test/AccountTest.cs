using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Account;
using Boolean.CSharp.Main.Entities;
using Boolean.CSharp.Main.Enum;
using Boolean.CSharp.Main.Person;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class AccountTest
    {


        public AccountTest()
        {

        }

        [TestCase(500, TransactionType.Deposit, 500)]
        [TestCase(3.50, TransactionType.Deposit, 3.50)]
        [TestCase(2500, TransactionType.Withdrawal, 2500)]
        public void TestMakeTransaction(double amount, TransactionType t, double expected)
        {
            Manager m = new Manager();
            BankAccount act = new CurrentAccount(BankBranches.Bergen, 123);

            BankTransaction tr = new BankTransaction(amount, t);
            double newbalance = act.MakeTransaction(tr);
            Assert.That(newbalance, Is.EqualTo(expected));
        }

        [Test]
        public void TestMakeOverdraftTransaction()
        {
            Manager m = new Manager();
            BankAccount act = new CurrentAccount(BankBranches.Bergen, 123);
            BankTransaction tr = new BankTransaction(500, TransactionType.Withdrawal);
            act.MakeTransaction(tr);

            List<Tuple<BankAccount, BankTransaction>> overdraftrequests = m.GetOverdraftRequests();

            Assert.That(overdraftrequests.Count(), Is.EqualTo(1));
            
            m.ApproveRequest(overdraftrequests[0]);

            Assert.That(act.GetBalance(), Is.EqualTo(-500));
            Assert.That(m.GetOverdraftRequests().Count(), Is.EqualTo(0));
        }
    }
}