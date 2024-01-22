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
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void TestMakeUserAccount()
        {
            BankApplication bankApp = new BankApplication();
            Custommer custommer1 = new Custommer()
            {
                Name = "Kanthee",
                Branch = Branches.Bergen,
                Id = 1111
            };

            bankApp.Add(custommer1);
            custommer1.makeAccount(AccountType.Saving);
            custommer1.makeAccount(AccountType.Current);
            var users = bankApp.seeUsers();

            // There should be 1 user in the bank and the custommer should have 2 accounts.
            Assert.IsTrue(users.Count == 1 && custommer1.getAccAccounts().Count == 2);

        }

        [Test]
        public void TestMakeCurrentAcc()
        {
            BankApplication bankApp = new BankApplication();
            Custommer custommer1 = new Custommer()
            {
                Name = "Kanthee",
                Branch = Branches.Bergen,
                Id = 1111
            };

            bankApp.Add(custommer1);
            custommer1.makeAccount(AccountType.Current);
            custommer1.makeAccount(AccountType.Current);
            int result = custommer1.getAccAccounts().Count(account => account is NormalAcc);

            // The result you return 2 since we have 2 currentAcc.
            Assert.IsTrue(result == 2);

        }

        [Test]
        public void TestMakeSavingAcc()
        {
            BankApplication bankApp = new BankApplication();
            Custommer custommer1 = new Custommer()
            {
                Name = "Kanthee",
                Branch = Branches.Bergen,
                Id = 1111
            };

            bankApp.Add(custommer1);
            custommer1.makeAccount(AccountType.Current);
            custommer1.makeAccount(AccountType.Current);
            custommer1.makeAccount(AccountType.Saving);

            int result = custommer1.getAccAccounts().Count(account => account is SavingAcc);

            // The result you return 1 since we have 1 SavingAcc.
            Assert.IsTrue(result == 1);

        }

        [Test]
        public void TestMake1Current2SavingAcc()
        {
            BankApplication bankApp = new BankApplication();
            Custommer custommer1 = new Custommer()
            {
                Name = "Kanthee",
                Branch = Branches.Bergen,
                Id = 1111
            };

            bankApp.Add(custommer1);
            custommer1.makeAccount(AccountType.Current);
            custommer1.makeAccount(AccountType.Saving);
            custommer1.makeAccount(AccountType.Saving);

            int result1 = custommer1.getAccAccounts().Count(account => account is SavingAcc);
            int result2 = custommer1.getAccAccounts().Count(account => account is NormalAcc);

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
            BankApplication bankApp = new BankApplication();
            Custommer custommer1 = new Custommer()
            {
                Name = "Kanthee",
                Branch = Branches.Bergen,
                Id = 1111
            };
            bankApp.Add(custommer1);
            custommer1.makeAccount(AccountType.Current);

            double amount = 999.0;
            TransactionType type = TransactionType.Deposit;
            String mark = "Saving 01/01/24";
            string acc = "Bergen-00001";
            Transaction transaction1 = new Transaction() { Amount = amount, Type = type, Mark = mark };
            custommer1.Deposit(acc, transaction1);
            double balance1 = custommer1.getBalance(acc);
            

           
            Assert.IsTrue(balance1 == amount);

        }






    }
}