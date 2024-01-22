
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


        [TestCase("1", true)]
        [TestCase("SWE", true)]
        [TestCase("fail", false)]
        public void CheckIfBranchesExist(string branch, bool ExpectCheck) {
            bool res;
            if(int.TryParse(branch, out int integerSearch)) 
                { res = bank.CheckIfBranchExists(integerSearch); }
            else {res = bank.CheckIfBranchExists(branch); }
        
            
            Assert.That(res, Is.EqualTo(ExpectCheck));
        
        
        }

        [TestCase(1, "UK", true)]
        [TestCase(2,"SWE", true)]
        [TestCase(99,"BRANCH DOES NOT EXIST.", false)]
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

        static Bank bank = new Extension.Bank();
        static public  IEnumerable<Iaccount> AccountTestCases
        {
            get
            {
                yield return new Account(bank, 1);
                yield return new SavingsAccount(bank, 1);
                yield return new CurrentAccount(bank, 1);
            }
        }







        [TestCase(1, "UK")]
        [TestCase(2, "SWE")]
        [TestCase(99, "BRANCH DOES NOT EXIST.")]
        public void NewAccountHasBranches(int branch_id, string expectedBranchString)
        {
            Account account = new Account(bank, branch_id);

            string branchStringRes = account.BranchName();

            Assert.That(branchStringRes, Is.EqualTo(expectedBranchString));
            Assert.That(account.GetBalance(), Is.EqualTo(0));
            Assert.That(account.GetTransactions().Count, Is.EqualTo(0));


        }

        [TestCase(1, "UK", 3, true, "NOR")]
        [TestCase(2, "SWE", 99, false, "SWE")]
        [TestCase(99, "BRANCH DOES NOT EXIST.", 1, true, "UK")]
        public void AccountBranchChange(int branch_id, string expectedBranchString, int new_branch, bool branchChangeSuccess, string new_branch_name )
        {
            Account account = new Account(bank, branch_id);

            string branchStringRes = account.BranchName();

            Assert.That(branchStringRes, Is.EqualTo(expectedBranchString));
            Assert.That(account.GetBalance(), Is.EqualTo(0));
            Assert.That(account.GetTransactions().Count, Is.EqualTo(0));

            bool resChangeSuccess = account.UpdateBranch(new_branch);
            Assert.That(resChangeSuccess, Is.EqualTo(branchChangeSuccess));

            string resNewBranchName = account.BranchName();


            Assert.That(resNewBranchName, Is.EqualTo(new_branch_name));



        }

        [TestCaseSource(nameof(AccountTestCases))]
        public void CantOverdraft(Iaccount account)
        {


            bool res = account.AddTransaction(-100f, null);

            List<Transaction> res2 = account.GetTransactions();

            Assert.That(res, Is.False);
            Assert.That(res2.Count, Is.EqualTo(0));

        }

        [TestCaseSource(nameof(AccountTestCases))]
        public void RequestOverdraft(Iaccount account)
        {


            bool resOverdraft1 = account.RequestOverdraft(-100f);
            bool resOverdraft2 = account.RequestOverdraft(-200f);
            bool res2 = account.AddTransaction(100f, null);

            List<Transaction> res3 = account.GetTransactions();

            Assert.That(resOverdraft1, Is.True);
            Assert.That(resOverdraft2, Is.False);
            Assert.That(res3.Count, Is.EqualTo(1));

        }

        [TestCaseSource(nameof(AccountTestCases))]
        public void RequestOverdraftAndApproveRequest(Iaccount account)
        {


            bool resOverdraft1 = account.RequestOverdraft(-100f);
            bool resOverdraft2 = account.RequestOverdraft(-200f);
            bool res2 = account.AddTransaction(100f, null);

            account.ApproveOverdraftRequest();

            List<Transaction> res3 = account.GetTransactions();
            float res4 = account.GetBalance();

            Assert.That(resOverdraft1, Is.True);
            Assert.That(resOverdraft2, Is.False);
            Assert.That(res3.Count, Is.EqualTo(2));
            Assert.That(res4, Is.EqualTo(0f));


        }

        [TestCaseSource(nameof(AccountTestCases))]
        public void RequestOverdraftAndApproveRequest2(Iaccount account)
        {


            bool resOverdraft1 = account.RequestOverdraft(-100f);
            bool resOverdraft2 = account.RequestOverdraft(-200f);


            bool resOverdraftReq = account.ApproveOverdraftRequest();

            List<Transaction> res3 = account.GetTransactions();
            float res4 = account.GetBalance();

            Assert.That(resOverdraft1, Is.True);
            Assert.That(resOverdraftReq, Is.True);
            Assert.That(resOverdraft2, Is.False);
            Assert.That(res3.Count, Is.EqualTo(1));
            Assert.That(res4, Is.EqualTo(-100f));
        }


        [TestCaseSource(nameof(AccountTestCases))]
        public void DenyOverdraftRequest1(Iaccount account)
        {


            bool resOverdraft1 = account.RequestOverdraft(-100f);
            bool resOverdraft2 = account.RequestOverdraft(-200f);
            bool res2 = account.AddTransaction(100f, null);

            bool resOverdraftReq = account.DenyOverdraftRequest();

            List<Transaction> res3 = account.GetTransactions();
            float res4 = account.GetBalance();

            Assert.That(resOverdraft1, Is.True);
            Assert.That(resOverdraftReq, Is.True);
            Assert.That(res3.Count, Is.EqualTo(1));
            Assert.That(res4, Is.EqualTo(100f));


        }

        [TestCaseSource(nameof(AccountTestCases))]
        public void DenyOverdraftRequest2(Iaccount account)
        {

            

            bool resOverdraft1 = account.RequestOverdraft(-100f);
            bool resOverdraft2 = account.RequestOverdraft(-200f);

            bool resOverdraftReq = account.DenyOverdraftRequest();

            List<Transaction> res3 = account.GetTransactions();
            float res4 = account.GetBalance();

            Assert.That(resOverdraft1, Is.True);
            Assert.That(resOverdraftReq, Is.True);
            Assert.That(res3.Count, Is.EqualTo(0));
            Assert.That(res4, Is.EqualTo(0f));
        }

    }



    [TestFixture]
    public class AccountCoreExtensionTests
    {

        static Bank bank = new Extension.Bank();
        public static IEnumerable<Iaccount> AccountTestCases
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

            Assert.That(res, Is.False);
            Assert.That(res2.Count, Is.EqualTo(0));

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
