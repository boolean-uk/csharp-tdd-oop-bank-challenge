using Boolean.CSharp.Main;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class BankTest
    {

        [Test]
        public void CreateAccountTest()
        {
            Bank bank = new Bank();
            IPerson person = new Customer("Test");
            BankBranch branch = new BankBranch(1); 
            SavingAccount savingAccount = new SavingAccount(123);
            CurrentAccount currentAccount = new CurrentAccount(121);
            string accountType1 = "Savings";
            string accountType2 = "Current";
            string accountType3 = "Stocks";

            bool created1 = bank.CreateAccount(person, accountType1,1);
            bool created2 = bank.CreateAccount(person, accountType2, 1);
            bool created3 = bank.CreateAccount(person, accountType3, 1);

            Assert.That(created1, Is.EqualTo(true));
            Assert.That(created2, Is.EqualTo(true));
            Assert.That(created3, Is.EqualTo(false));

        }
        [TestCase (1)]
        [TestCase (2)]
        [TestCase (3)]
        public void AddBankBranchTest(int id)
        {
            Bank bank = new Bank();
            bool added = bank.AddBranch(id);
            
            Assert.That(added, Is.True);
        }
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void GetBankBranchTest(int id)
        {
            Bank bank = new Bank();
            BankBranch branch = bank.GetBranch(id);

            Assert.That(branch.Id, Is.EqualTo(id));
        }

    }
}