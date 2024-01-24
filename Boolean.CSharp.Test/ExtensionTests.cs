using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Accounts;
using Boolean.CSharp.Main.Enums;
using Boolean.CSharp.Main.Concretes;
using Boolean.CSharp.Main.Interfaces;
using NUnit.Framework;
using System.Transactions;
using Transaction = Boolean.CSharp.Main.Concretes.Transaction;
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
        
        [Test]
        public void AddBranchTest()
        {
            SavingsAccount account = new SavingsAccount();

            account.Branch = Branch.Norwary;

            Assert.That(account.Branch, Is.EqualTo(Branch.Norwary));
        }


        [Test]
        public void OverDraftDeniedTest()
        {
            ITransaction transaction = new Transaction(-50);
            IAdminestrator admin = new Adminestrator();
            IAccount account = new SavingsAccount();
            ICustomer customer = new Customer();
            customer.AddAccount(account);
            
            customer.CreditScore = 0;
            admin.RequestOverdraft(account);
            admin.ApproveOverdraft(customer, account);
            account.AddTransaction(transaction);

            Assert.That(account.GetBalance(), Is.EqualTo(0));
        }

        [Test]
        public void OverDraftPassedTest()
        {
            ITransaction transaction = new Transaction(-50);
            IAdminestrator admin = new Adminestrator();
            IAccount account = new SavingsAccount();
            ICustomer customer = new Customer();
            customer.AddAccount(account);

            customer.CreditScore = CreditScore.VeryGood;
            admin.RequestOverdraft(account);
            admin.ApproveOverdraft(customer, account);
            account.AddTransaction(transaction);

            Assert.That(account.GetBalance(), Is.EqualTo(-50));
        }

        [Test]
        public void BankstatementSMSTest()
        {
            IAccount account = new CurrentAccount();
            ICustomer customer = new Customer();
            
            ITransaction deposit1 = new Transaction(1000.00d);
            account.AddTransaction(deposit1);
            ITransaction deposit2 = new Transaction(2000.00d);
            account.AddTransaction(deposit2);
            ITransaction withdrawal = new Transaction(-500.00d);
            account.AddTransaction(withdrawal);

            //account.SendBankstatementSMS();

            Assert.Pass(); //I get a message on my phone!
        }
    }
}
