using Boolean.CSharp.Main;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class ExtensionTests
    {
        public Customer customer;

        [SetUp]
        public void SetUp()
        {
            customer = new Customer();
            //BankManager bankManager;    

        }


        //OverdraftRequests
        [Test]
        [TestCase(10d)]
        [TestCase(500d)]
        [TestCase(0d)]
        
        public void TestQuestion1(double test)
        {
            OverdraftRequest overdraftRequest = new OverdraftRequest(test);

            Assert.That(overdraftRequest, Is.Not.Null);
            Assert.That(overdraftRequest.amountRequested, Is.EqualTo(test));
            Assert.That(overdraftRequest.status, Is.EqualTo(OverdraftRequest.RequestStatus.Waiting_for_answer));
        }
        [Test]
        [TestCase(-10d)]
        public void TestQuestion2(double test)
        {
            OverdraftRequest overdraftRequest = new OverdraftRequest(test);

            Assert.That(overdraftRequest, Is.Not.Null);
            Assert.That(overdraftRequest.amountRequested, Is.EqualTo(0));
        }

        //BankManager
        [Test]
        [TestCase(10d)]
        [TestCase(250d)]
        [TestCase(0d)]
        public void TestQuestion3(double test) 
        {
            OverdraftRequest overdraft = new OverdraftRequest(test);
            BankManager bank = new BankManager(overdraft);

            Assert.That(bank, Is.Not.Null);
            Assert.That(bank.OverdraftRequest, Is.EqualTo(overdraft));

            OverdraftRequest request = bank.LookAtRequests();

            Assert.That(request.amountRequested, Is.EqualTo(test));
            Assert.That(request.status, Is.Not.EqualTo(OverdraftRequest.RequestStatus.Waiting_for_answer));
        }

        [Test]
        [TestCase(110d)] // 10 overdraftRequest //Approved
        [TestCase(150d)] // 50 overdraftRequest //Approved

        public void TestQuestion4(double test)
        {
            customer.CreateAccount("1234", BankBranch.Gothenburg);
           
            Account myAccount = customer.MyBankAccounts.First().Value;
            myAccount.makeAnOverdraftRequests = true;

            myAccount.DepositMoney(500d);

            myAccount.WithdrawMoney(400);

            string testText = myAccount.WithdrawMoney(test);

            Assert.That(testText, Is.EqualTo(new string($"{test} was removed from the Account({myAccount.AccountID})")));
        }


        [TestCase(350d)] // 250 overdraftRequest //denied
        public void TestQuestion5(double test)
        {
            customer.CreateAccount("1234", BankBranch.Gothenburg);
            Account myAccount = customer.MyBankAccounts.First().Value;
            myAccount.makeAnOverdraftRequests = true;

            myAccount.DepositMoney(500d);
            myAccount.WithdrawMoney(400);

            Assert.That(() => myAccount.WithdrawMoney(test), Throws.Exception);
            

            
        }
    }
}
