using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Accounts;
using Boolean.CSharp.Main.Accounts.Constants;
using Boolean.CSharp.Main.Users;
using NUnit.Framework;
using System.Transactions;
using Transaction = Boolean.CSharp.Main.Transaction;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CoreTests
    {
        public BankApplication bankApp;
        public Custommer custommer1;

        [SetUp]
        public void Setup()
        {
             bankApp = new BankApplication();

            custommer1 = new Custommer()
            {
                Name = "Kanthee",
                Branch = Branches.Bergen,
                Id = 1111
            };


        }

        [Test]
        public void TestMakeUserAccount()
        {
            

            bankApp.Add(custommer1);
            custommer1.makeAccount(Enums.Saving);
            custommer1.makeAccount(Enums.Current);
            var users = bankApp.seeUsers();

            // There should be 1 user in the bank and the custommer should have 2 accounts.
            Assert.IsTrue(users.Count == 1 && custommer1.getAccAccounts().Count == 2);

        }

        [Test]
        public void TestMakeCurrentAcc()
        {
           

            bankApp.Add(custommer1);
            custommer1.makeAccount(Enums.Current);
            custommer1.makeAccount(Enums.Current);
            int result = custommer1.getAccAccounts().Count(account => account.Value is NormalAcc);

            // The result you return 2 since we have 2 currentAcc.
            Assert.IsTrue(result == 2);

        }

        [Test]
        public void TestMakeSavingAcc()
        {
            

            bankApp.Add(custommer1);
            custommer1.makeAccount(Enums.Current);
            custommer1.makeAccount(Enums.Current);
            custommer1.makeAccount(Enums.Saving);

            int result = custommer1.getAccAccounts().Count(account => account.Value is SavingAcc);

            // The result you return 1 since we have 1 SavingAcc.
            Assert.IsTrue(result == 1);

        }

        [Test]
        public void TestMake1Current2SavingAcc()
        {
          

            bankApp.Add(custommer1);
            custommer1.makeAccount(Enums.Current);
            custommer1.makeAccount(Enums.Saving);
            custommer1.makeAccount(Enums.Saving);

            int result1 = custommer1.getAccAccounts().Count(account => account.Value is SavingAcc);
            int result2 = custommer1.getAccAccounts().Count(account => account.Value is NormalAcc);

            // The result you return 1 since we have 1 SavingAcc.
            Assert.IsTrue(result1 == 2 && result2 == 1);

        }

        [Test]
        public void TestTransaction()
        {
            double amount = 999.0;
            TransactionType type = TransactionType.Deposit;
            String mark = "Saving 01/01/24";
            Transaction transaction1 = new Transaction() { Amount = amount, Type = type, Mark = mark };

            double transactionAmount = transaction1.Amount;
            String transactionMark = transaction1.Mark;
            


            Assert.IsTrue(transactionAmount == amount && transactionMark == transactionMark);

        }



        [Test]
        public void TestDepositFunds()
        {
           
            bankApp.Add(custommer1);
            custommer1.makeAccount(Enums.Current);

            double amount = 999.0;
            TransactionType type = TransactionType.Deposit;
            String mark = "Saving 01/01/24";

            //Get the account ID. Only 1 acc...
            Guid acc = custommer1.getAccAccounts().Keys.First();

            Transaction transaction1 = new Transaction() { Amount = amount, Type = type, Mark = mark };
            custommer1.Deposit(acc, transaction1);
            double balance1 = custommer1.getBalance(acc);
            

            Assert.IsTrue(balance1 == amount);

        }

        [Test]
        public void TestWithdrawFunds1()
        {
           
            bankApp.Add(custommer1);
            custommer1.makeAccount(Enums.Current);
            double amount1 = 999.0;
            TransactionType type1 = TransactionType.Deposit;
            String mark1 = "Saving 01/01/24";

            double amount2 = 555.0;
            TransactionType type2 = TransactionType.Withdraw;
            String mark2 = "Deposit 01/01/24";



            Guid acc = custommer1.getAccAccounts().Keys.First();
            Transaction transaction1 = new Transaction() { Amount = amount1, Type = type1, Mark = mark1 };
            custommer1.Deposit(acc, transaction1);
            Transaction transaction2 = new Transaction() { Amount = amount2, Type = type2, Mark = mark2 };
            custommer1.Withdraw(acc, transaction2);
            double balance1 = custommer1.getBalance(acc);


            Assert.IsTrue(balance1 == amount1-amount2);

        }

        [Test]
        public void TestWithdrawFunds2()
        {
           
            bankApp.Add(custommer1);
            custommer1.makeAccount(Enums.Current);

            double amount2 = 555.0;
            TransactionType type2 = TransactionType.Withdraw;
            String mark2 = "Deposit 01/01/24";

            
            Guid acc = custommer1.getAccAccounts().Keys.First();

            Transaction transaction2 = new Transaction() { Amount = amount2, Type = type2, Mark = mark2 };
            //custommer1.Withdraw(acc, transaction2);
            double balance1 = custommer1.getBalance(acc);

            TestDelegate check0 = () => custommer1.Withdraw(acc, transaction2);
            var check = Assert.Throws<InvalidOperationException>(check0);

            //The check0 should throw invalidException since not enough funds. 
            Assert.AreEqual("Insufficient funds for withdraw.", check.Message);
            Assert.IsTrue(balance1 == 0);

        }








    }
}