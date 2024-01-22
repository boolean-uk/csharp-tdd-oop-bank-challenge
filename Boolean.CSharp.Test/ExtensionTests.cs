using Boolean.CSharp.Main;
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
        public Engineer engineer1;

        [SetUp]
        public void Setup()
        {
            bankApp = new BankApplication();

            custommer1 = new Custommer()
            {
                Name = "Kanthee",
                Branch = Branches.Bergen,
                Id = 1000
            };

            engineer1 = new Engineer() { 
                Name = "Idaa",
                Id = 0001
            };

            bankApp.Add(custommer1);
            bankApp.Add(engineer1);
            custommer1.makeAccount(Enums.Saving);
            custommer1.makeAccount(Enums.Current);

        }

        [Test]
        public void TestMakeEngineerAccount()
        {

         
            var users = bankApp.seeUsers();

            // There should be 2 users in the bank and the custommer should have 2 accounts.
            Assert.IsTrue(users.Count == 2 && custommer1.getAccAccounts().Count == 2);

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

            custommer1.Deposit(acc1, transaction1);

            // As an ennigneer, I want to check the balance of the 1. acc on the custommer1.
            
            double balanceOfAcc1Custommer1 = engineer1.getBalanceOfCustommerAcc(custommer1, acc1);


            // The balance should be 0.
            Assert.IsTrue(balanceOfAcc1Custommer1 == 999.0);

        }





    }
}
