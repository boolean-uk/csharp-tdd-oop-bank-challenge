
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Boolean.CSharp.Extension;

namespace Boolean.CSharp.ExtensionTest
{
    [TestFixture]
    public class BankExtensionTests
    {
        Bank bank;

        [SetUp]

        public void setup() { bank = new Bank(); }
        [Test]

        public void GetBranches() {

            Dictionary<int, string> branchesRes = bank.GetBranches();

            Assert.That(branchesRes[1], Is.EqualTo("UK"));
            Assert.That(branchesRes[2], Is.EqualTo("SWE"));
            Assert.That(branchesRes[3], Is.EqualTo("NOR"));


        }


        [TestCase(1, true)]
        [TestCase("SWE", true)]
        [TestCase("fail", false)]
        public void CheckIfBranchesExist(string branch, bool ExpectCheck) { 
        
            bool res = bank.CheckIfBranchExists(branch);
            Assert.That(res, Is.EqualTo(ExpectCheck));
        
        
        }

        [TestCase(1, "UK", true)]
        [TestCase(2,"SWE", true)]
        [TestCase(99,"BRANCH DOES NOT EXCIST.", false)]
        public void GetBranchNameById(int branch_id, string expectedString, bool ExpectCheck)
        {
            bool checkRes = bank.CheckIfBranchExists(branch_id);

            string branchName = bank.GetBranchNameById(branch_id);
            Assert.That(branchName, Is.EqualTo(expectedString));

            Assert.That(checkRes, Is.EqualTo(ExpectCheck));



        }

    }

    [TestFixture]
    public class AccountExtensionTests
    {

        Bank bank = new Extension.Bank();
        public IEnumerable<Iaccount> AccountTestCases
        {
            get
            {
                yield return new Account(bank, 1);
                yield return new SavingsAccount(bank, 1);
                yield return new CurrentAccount(bank, 1);
            }
        }







        [TestCaseSource(nameof(AccountTestCases))]
        public void AddTransaction(Iaccount account)
        {
            Account accountCasted;

            bool res = account.AddTransaction(100f, null);

            List<Transaction> res2 = account.GetTransactions();
            try
            {

                accountCasted = (Account)account;
            }
            catch (Exception ex)
            {
                Assert.Fail("Could not cast to Account class");
                return;
            }

            Assert.That(res, Is.True);
            Assert.That(res2.Count, Is.EqualTo(1));
            Assert.That(accountCasted.Transactions.Count, Is.EqualTo(1));

        }

    }


    [TestFixture]
    public class AccountCoreExtensionTests
    {

        Bank bank = new Extension.Bank();
        public IEnumerable<Iaccount> AccountTestCases
        {
            get
            {
                yield return new Account(bank, 1);
                yield return new SavingsAccount(bank, 1);
                yield return new CurrentAccount(bank, 1);
            }
        }







        [TestCaseSource(nameof(AccountTestCases))]
        public void AddTransaction(Iaccount account)
        {
            Account accountCasted;

            bool res = account.AddTransaction(100f, null);

            List<Transaction> res2 = account.GetTransactions();
            try
            {

                accountCasted = (Account)account;
            }
            catch (Exception ex)
            {
                Assert.Fail("Could not cast to Account class");
                return;
            }

            Assert.That(res, Is.True);
            Assert.That(res2.Count, Is.EqualTo(1));
            Assert.That(accountCasted.Transactions.Count, Is.EqualTo(1));

        }

        [TestCaseSource(nameof(AccountTestCases))]

        public void NegativeTransaction(Iaccount account)
        {


            bool res = account.AddTransaction(-100f, null);

            List<Transaction> res2 = account.GetTransactions();

            Assert.That(res, Is.True);
            Assert.That(res2.Count, Is.EqualTo(1));

        }

        [TestCaseSource(nameof(AccountTestCases))]

        public void EmptyTransaction(Iaccount account)
        {


            bool res = account.AddTransaction(0f, null);

            List<Transaction> res2 = account.GetTransactions();

            Assert.That(res, Is.False);
            Assert.That(res2.Count, Is.EqualTo(0));

        }

        [TestCaseSource(nameof(AccountTestCases))]

        public void GetBalance(Iaccount account)
        {


            bool res = account.AddTransaction(100f, null);
            bool res2 = account.AddTransaction(350f, null);
            bool res3 = account.AddTransaction(400f, null);

            float res4 = account.GetBalance();

            Assert.That(res, Is.True);
            Assert.That(res2, Is.True);
            Assert.That(res3, Is.True);
            Assert.That(res4, Is.EqualTo(850f));


        }




        [TestCaseSource(nameof(AccountTestCases))]

        public void PrintTransationHistory(Iaccount account)
        {

            DateTime date1 = new DateTime(year: 2012, month: 01, day: 10);
            bool transaction1 = account.AddTransaction(1000f, date1);

            DateTime date2 = new DateTime(year: 2012, month: 01, day: 13);
            bool transaction2 = account.AddTransaction(2000f, date2);

            DateTime date3 = new DateTime(year: 2012, month: 01, day: 14);
            bool transaction3 = account.AddTransaction(-500f, date3);


            string res2 = account.GenerateTransationsHistory();
            string ExpectedResult = string.Format(
                    "date || credit || debit || balance\n" +
                    "14 / 01 / 2012 ||         || 500.00 || 2500.00\n" +
                    "13 / 01 / 2012 || 2000.00 ||        || 3000.00\n" +
                    "10 / 01 / 2012 || 1000.00 ||        || 1000.00\n");

            ExpectedResult = ExpectedResult.Replace(" ", "");
            res2 = res2.Replace(" ", "");
            Assert.That(res2.Trim(), Is.EqualTo(ExpectedResult.Trim()));


        }
    }
}
