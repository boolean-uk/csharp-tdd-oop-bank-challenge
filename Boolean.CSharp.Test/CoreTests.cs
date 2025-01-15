using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Enums;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CoreTests
    {
        private Bank _bank;

        public CoreTests()
        {
            _bank = new Bank();

        }

        [Test]
        public void TestAddCurrentAccount()
        {
            _bank = new Bank();
            _bank.AddCurrentAccount("Curr", Branch.Oslo);

            Assert.That(_bank.bankAccounts, Is.Not.Empty);
        }


        [Test]
        public void TestAddSavingsAccount()
        {
            _bank = new Bank();
            _bank.AddSavingsAccount("Save", Branch.Stockholm);

            Assert.That(_bank.bankAccounts, Is.Not.Empty);
        }

        [Test]
        public void TestBankStatementAndTransactions()
        {
            _bank = new Bank();
            _bank.AddSavingsAccount("Save", Branch.Bournemouth);
            _bank.bankAccounts[0].depositAmount(400);
            _bank.bankAccounts[0].withdrawAmount(300);

            Assert.That(_bank.bankAccounts[0].transactionHelper(), Is.EqualTo(100));

        }


        [Test]
        public void TestBranch()
        {
            _bank = new Bank();
            _bank.AddSavingsAccount("Save", Branch.Bournemouth);

            Assert.That(_bank.bankAccounts[0].branch, Is.EqualTo(Branch.Bournemouth));
        }

        [Test]
        public void TestGetBalance() 
        {
            _bank = new Bank();
            _bank.AddSavingsAccount("Save", Branch.Bournemouth);

            _bank.bankAccounts[0].depositAmount(200);
            _bank.bankAccounts[0].depositAmount(200);
            _bank.bankAccounts[0].depositAmount(200);

            Assert.That(_bank.bankAccounts[0].getBalance(), Is.EqualTo(600)); //transactionHelper already does this but with an output to the console. This is better if you only want to get the balance and do not want to clutter the console.
        }


        [Test]
        public void TestWithdrawRestriction()
        {
            _bank = new Bank();
            _bank.AddSavingsAccount("Save", Branch.Bournemouth);

            _bank.bankAccounts[0].depositAmount(200);
            _bank.bankAccounts[0].withdrawAmount(300);

            Assert.That(_bank.bankAccounts[0].getBalance(), Is.EqualTo(200));
        }

        [Test]
        public void TestOverdraftRequest()
        {
            _bank = new Bank();
            _bank.AddSavingsAccount("Save", Branch.Bournemouth);

            _bank.bankAccounts[0].RequestOverdraft(200, true);

            Assert.That(_bank.bankAccounts[0].getBalance(), Is.EqualTo(-200));

        }

        [Test]
        public void TestSendToPhone()
        {
            _bank = new Bank();
            _bank.AddSavingsAccount("Save", Branch.Bournemouth);

            _bank.bankAccounts[0].depositAmount(200);
            _bank.bankAccounts[0].withdrawAmount(200);
            _bank.bankAccounts[0].depositAmount(200);
            _bank.bankAccounts[0].depositAmount(200);



        }



    }
}