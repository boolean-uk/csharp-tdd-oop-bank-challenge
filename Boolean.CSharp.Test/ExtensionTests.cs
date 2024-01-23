using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Accounts;
using Boolean.CSharp.Main.Accounts.Constants;
using Boolean.CSharp.Main.Users;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class ExtensionTests
    {
        public BankApplication bankApp;
        public Custommer custommer1;
        public Custommer custommer2;
        public Custommer custommer3;
        public Engineer engineer1;
        public Manager manager1;

        [SetUp]
        public void Setup()
        {
            bankApp = new BankApplication();

             custommer1 = new Custommer()
            {
                Name = "Kanthee",
                Branch = Branches.Bergen,
                Id = 1001
            };
            custommer2 = new Custommer()
            {
                Name = "Kanthee2",
                Branch = Branches.Bergen,
                Id = 1002
            };
            custommer3 = new Custommer()
            {
                Name = "Kanthee3",
                Branch = Branches.Oslo,
                Id = 1003
            };

            engineer1 = new Engineer()
            {
                Name = "Idaa",
                Id = 0001
            };

            manager1 = new Manager()
            {
                Name = "Nigel",
                Id = 9001
            };



            bankApp.Add(custommer1);
            bankApp.Add(engineer1);
            bankApp.Add(custommer2);
            bankApp.Add(custommer3);
            bankApp.Add(manager1);
            custommer1.makeAccount(Enums.Saving);
            custommer1.makeAccount(Enums.Current);
            custommer2.makeAccount(Enums.Current);
            custommer3.makeAccount(Enums.Current);

        }

        [Test]
        public void TestMakeEngineerAccount()
        {


            var users = bankApp.seeUsers();

            // There should be 5 users in the bank and the custommer1 should have 2 accounts.
            Assert.IsTrue(users.Count == 5 && custommer1.getAccAccounts().Count == 2);

        }

        [Test]
        public void TestEngineerCheckCustommerBalance1()
        {


            // As an ennigneer, I want to check the balance of the 1. acc on the custommer1.
            Guid acc1 = custommer1.getAccAccounts().Keys.First();
            double balanceOfAcc1Custommer1 = engineer1.getBalanceOfCustommerAcc(custommer1, acc1);


            // The balance should be 0.
            Assert.IsTrue(balanceOfAcc1Custommer1 == 0);

        }

        [Test]
        public void TestEngineerCheckCustommerBalance()
        {

            Guid acc1 = custommer1.getAccAccounts().Keys.First();
            double amount1 = 999.0;
            TransactionType type1 = TransactionType.Deposit;
            String mark1 = "Saving 01/01/24";
            Transaction transaction1 = new Transaction() { Amount = amount1, Type = type1, Mark = mark1 };

            custommer1.PerformTransaction(acc1, transaction1);

            // As an ennigneer, I want to check the balance of the 1. acc on the custommer1.

            double balanceOfAcc1Custommer1 = engineer1.getBalanceOfCustommerAcc(custommer1, acc1);


            // The balance should be 0.
            Assert.IsTrue(balanceOfAcc1Custommer1 == 999.0);

        }

        [Test]
        public void TestManangerGetAccoutBranches()
        {
            //Make a list of custommers
            List<Custommer> custommers = bankApp.seeUsers().Values.OfType<Custommer>().ToList();
            

            /*int numberOfBranch1 = custommers
            .SelectMany(custommer => custommer.getAccAccounts().Values)
            .Count(account => account._Branch == Branches.Bergen);*/
            
            //Get a number of account that are assigned to branch Bergen and Oslo.
            var numberOfAccountsByBranch = custommers
            .SelectMany(custommer => custommer.getAccAccounts().Values)
             .GroupBy(account => account._Branch)
             .ToDictionary(group => group.Key, group => group.Count());

            //Should be 3 accounts at Bergen and 1 at Oslo.
            Assert.IsTrue(numberOfAccountsByBranch[Branches.Bergen] == 3 && numberOfAccountsByBranch[Branches.Oslo] == 1);

        }

        [Test]
        public void TestRequestOverdraft()
        {
            double amount1 = 100000.00;
            TransactionType type1 = TransactionType.Overdraft;
            String mark1 = "Request some money for my son! PLEASE!";
            Transaction request1 = new Transaction() { Amount = amount1, Mark = mark1, Type = type1};


            Guid acc1 = custommer1.getAccAccounts().Keys.First();
            custommer1.PerformTransaction(acc1, request1);

            //Should be 1 overdraft request in the list.
            Assert.IsTrue(custommer1.getRequest(acc1).Count == 1);

        }

        [Test]
        public void TestRequestReview()
        {
            double amount1 = 100000.00;
            TransactionType type1 = TransactionType.Overdraft;
            String mark1 = "Request some money for my son! PLEASE!";
            Transaction request1 = new Transaction() { Amount = amount1, Mark = mark1, Type = type1 };


            Guid acc1 = custommer1.getAccAccounts().Keys.First();
            custommer1.PerformTransaction(acc1, request1);
            Account account1 = (Account)custommer1.getAccAccounts()[acc1];

            //Should be 1 request waiting for the account manager to review.
            Assert.IsTrue(account1._accountManager.getRequests().Count == 1);

        }

        [Test]
        public void TestRequestReview2()
        {
            double amount1 = 100000.00;
            TransactionType type1 = TransactionType.Overdraft;
            String mark1 = "Request some money for my son! PLEASE!";
            Transaction request1 = new Transaction() { Amount = amount1, Mark = mark1, Type = type1 };

            double amount2 = 100000.00;
            TransactionType type2 = TransactionType.Overdraft;
            String mark2 = "Request some money for my MOM! PLEASE!";
            Transaction request2 = new Transaction() { Amount = amount2, Mark = mark2, Type = type2 };


            Guid acc1 = custommer1.getAccAccounts().Keys.First();
            custommer1.PerformTransaction(acc1, request1);
            custommer1.PerformTransaction(acc1, request2);
            Account account1 = (Account)custommer1.getAccAccounts()[acc1];

            //Should be 2 requests waiting for the account manager to review.
            Assert.IsTrue(account1._accountManager.getRequests().Count == 2);

        }






    }
}
