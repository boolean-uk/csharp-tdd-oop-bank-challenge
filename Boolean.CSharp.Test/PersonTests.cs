using Boolean.CSharp.Main;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class PersonTests
    {
        private Bank bank;




        [Test]
        public void AddAccountTest()
        {
            Bank bank = new Bank();
            IPerson person = new Customer("Test");
            BankBranch branch = new BankBranch(1);
            SavingAccount savingAccount = new SavingAccount(121);
            CurrentAccount currentAccount = new CurrentAccount(123);
            string accountType1 = "Savings";
            string accountType2 = "Current";

            bool created1 = bank.CreateAccount(person, accountType1,1);
            bool created2 = bank.CreateAccount(person, accountType2,1);

            Assert.That(created1, Is.EqualTo(true));
            Assert.That(created2, Is.EqualTo(true));

        }

    }
}