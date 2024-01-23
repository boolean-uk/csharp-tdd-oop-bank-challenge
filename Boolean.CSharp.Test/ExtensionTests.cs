using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Bank;
using Boolean.CSharp.Main.Extension;
using Boolean.CSharp.Main.ExtensionTasks.Branch;
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
        
        [Test]
        public void Deposit()
        {
            // arrange
            string firstname = "clark";
            
            string lastname = "julie";
            string dob = "jan 1, 2009";
            DateTime _dob = DateTime.Parse(dob);
            Customer customer = new Customer(firstname, lastname, _dob);
            BankEX bank = new BankEX();
            Guid guid = Guid.NewGuid();
            bool createAccount = bank.CreateCurrentAccount(customer, out guid);


            // act
            bool result = bank.Deposit(guid, 1000, customer);

            AccountEX account = bank.accountDirectory[customer][guid];

            // assert
            Assert.That(result, Is.True);
            Assert.That(account.GetBalance, Is.EqualTo(1000));
        }

        [Test]
        public void GetBalance()
        {
            // arrange
            string firstname = "clark";
            string lastname = "julie";
            string dob = "jan 1, 2009";
            DateTime _dob = DateTime.Parse(dob);
            Customer customer = new Customer(firstname, lastname, _dob);
            BankEX bank = new BankEX();
            Guid guid = Guid.NewGuid();
            bool createAccount = bank.CreateCurrentAccount(customer, out guid);
            bool depositOK = bank.Deposit(guid, 1000, customer);
            bool deposit_2_OK = bank.Deposit(guid, 500, customer);
            bool withdrawOK = bank.Withdraw(guid, 200, customer);
            AccountEX account = bank.accountDirectory[customer][guid];

            // act            
            double result = account.GetBalance();

            // assert
            Assert.That(result, Is.EqualTo(1300));            
        }

        [Test]
        public void Branch()
        {
            // arrange
            string firstname = "clark";
            string lastname = "julie";
            string dob = "jan 1, 2009";
            DateTime _dob = DateTime.Parse(dob);
            Customer customer = new Customer(firstname, lastname, _dob);
            BankEX bank = new BankEX();
            Guid guid = Guid.NewGuid();
            bool createAccount = bank.CreateCurrentAccount(customer, out guid);
            AccountEX account = bank.accountDirectory[customer][guid];


            // act
            Branches branch = account.branch._name;            

            // assert
            Assert.That(branch, Is.EqualTo(Branches.California));            
        }

        [Test]
        public void RequestOverdraft()
        {
            // arrange
            string firstname = "clark";
            string lastname = "julie";
            string dob = "jan 1, 2009";
            DateTime _dob = DateTime.Parse(dob);
            Customer customer = new Customer(firstname, lastname, _dob);
            BankEX bank = new BankEX();
            Guid guid = Guid.NewGuid();
            bool createAccount = bank.CreateCurrentAccount(customer, out guid);
            AccountEX account = bank.accountDirectory[customer][guid];

            // act
            bool result = bank.RequestOverdraft(customer,guid, 1000);
            int overdrafts = bank.overdraftDirectory.Count();       

            // assert
            Assert.That(result, Is.True);
            Assert.That(overdrafts, Is.EqualTo(1));
        }


        [Test]
        public void AcceptOverdraft()
        {
            // arrange
            string firstname = "clark";
            string lastname = "julie";
            string dob = "jan 1, 2009";
            DateTime _dob = DateTime.Parse(dob);
            Customer customer = new Customer(firstname, lastname, _dob);
            BankEX bank = new BankEX();
            Guid guid = Guid.NewGuid();
            bool createAccount = bank.CreateCurrentAccount(customer, out guid);
            bool requestOverdraft = bank.RequestOverdraft(customer, guid, 1000);

            // act
            bool result = bank.AcceptOverdraft(customer, guid);             

            // assert
            Assert.That(result, Is.True);               
        }

        [Test]
        public void RejectOverdraft()
        {
            // arrange
            string firstname = "clark";
            string lastname = "julie";
            string dob = "jan 1, 2009";
            DateTime _dob = DateTime.Parse(dob);
            Customer customer = new Customer(firstname, lastname, _dob);
            BankEX bank = new BankEX();
            Guid guid = Guid.NewGuid();
            bool createAccount = bank.CreateCurrentAccount(customer, out guid);
            bool requestOverdraft = bank.RequestOverdraft(customer, guid, 1000);

            // act
            bool result = bank.RejectOverdraft(customer, guid);

            // assert
            Assert.That(result, Is.True);
        }
    }
}
