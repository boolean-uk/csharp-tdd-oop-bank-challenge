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

        [TestCase(2500, 500, TransactionType.Deposit, 3000)]
        [TestCase(17, 3.50, TransactionType.Deposit, 20.50)]
        [TestCase(2500, 500, TransactionType.Withdrawal, 2000)]
        public void TestMakeTransaction(double balance, double amount, TransactionType t, double expected)
        {
            BankTransaction preload = new BankTransaction(balance, TransactionType.Deposit);
            Customer customer = new Customer("Espen", "Luna", 93458577);
            Manager m = new Manager();
            BankAccount act = new CurrentAccount(BankBranches.Bergen, 123, "Brukskonto1", customer);
            act.MakeTransaction(preload);

            BankTransaction tr = new BankTransaction(amount, t);
            double newbalance = act.MakeTransaction(tr);
            Assert.That(newbalance, Is.EqualTo(expected));
        }

        [Test]
        public void TestMakeOverdraftTransaction()
        {
            Manager m = new Manager();
            Customer customer = new Customer("Espen", "Luna", 93458577);
            BankAccount act = new CurrentAccount(BankBranches.Bergen, 123, "Brukskonto1", customer);
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