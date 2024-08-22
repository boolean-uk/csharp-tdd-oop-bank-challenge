using Boolean.CSharp.Main;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class BankTest
    {
        private Bank bank;





        [Test]
        public void CreateAccountTest()
        {
            Bank bank = new Bank();
            IPerson person = new Customer();
            SavingAccount savingAccount = new SavingAccount();
            CurrentAccount currentAccount = new CurrentAccount();
            string accountType1 = "Savings";
            string accountType2 = "Current";

            IAccount created1 = bank.CreateAccount(person, accountType1);
            IAccount created2 = bank.CreateAccount(person, accountType2);

            Assert.That(created1.GetType(), Is.EqualTo(savingAccount.GetType()));
            Assert.That(created2.GetType(), Is.EqualTo(currentAccount.GetType()));

        }

    }
}