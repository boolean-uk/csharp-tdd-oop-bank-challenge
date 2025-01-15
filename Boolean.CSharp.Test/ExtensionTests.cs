using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Interface;
using Boolean.CSharp.Main.PersonType;
using NUnit.Framework;
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
        private Extension _extension;
        public ExtensionTests()
        {
            _extension = new Extension();
        }
        [Test]
        public void GetAccountBalanceFromTransactionHistory()
        {
            Customer customer = new Customer("Engineer", "Oslo");
            customer.CreateAccount("Checkings", "Engineer Account");
            customer.Deposit(customer.GetAccount("Engineer Account"), new CreditTransaction(100));
            customer.Withdrawal(customer.GetAccount("Engineer Account"),  new DebitTransaction(50));
            Assert.That(customer.GetAccountBalanceFromTransactions(customer.GetAccount("Engineer Account")), Is.EqualTo(50));
            
        }
        [Test]
        public void AllowAccountLocations()
        {
            Customer customer = new Customer("Axel", "Bergen");
            Customer customer2 = new Customer("Ax", "Bergen");

            Manager manager = new Manager();
            customer.CreateAccount("Checkings", "Chill Account");
            customer2.CreateAccount("Checkings", "J");
            customer.CreateAccount("Savings", "save");
            manager.AddAccount(customer.GetAccount("Chill Account"));
            manager.AddAccount(customer.GetAccount("save"));
            manager.AddAccount(customer2.GetAccount("J"));

            List<IAccount> accs = manager.GetAccounts("Bergen");
            Assert.That(accs.Count, Is.EqualTo(3));
            
        }

        [Test]
        public void AllowAccountLocationsMultiple()
        {
            Customer customer = new Customer("Axel", "Bergen");
            Customer customer2 = new Customer("Ax", "Trondheim");

            Manager manager = new Manager();
            customer.CreateAccount("Checkings", "Chill Account");
            customer2.CreateAccount("Checkings", "J");
            customer.CreateAccount("Savings", "save");
            manager.AddAccount(customer.GetAccount("Chill Account"));
            manager.AddAccount(customer.GetAccount("save"));
            manager.AddAccount(customer2.GetAccount("J"));

            List<IAccount> accs = manager.GetAccounts("Bergen");
            List<IAccount> accs2 = manager.GetAccounts("Trondheim");
            Assert.That(accs.Count, Is.EqualTo(2));
            Assert.That(accs2.Count, Is.EqualTo(1));
        }

        [Test]
        public void RequestOverDraft()
        {
            Customer customer = new Customer("Axel", "Bergen");
            Manager manager = new Manager();
            customer.CreateAccount("Checkings", "A");
            customer.RequestOverdraft(200, manager.RespondToOverdraft("approve"), customer.GetAccount("A"));
            
            customer.Deposit(customer.GetAccount("A"), new CreditTransaction(300));
            customer.Withdrawal(customer.GetAccount("A"), new DebitTransaction(400));

            Assert.That(customer.GetAccount("A").accountBalance , Is.EqualTo(-100));
        }

        [Test]
        public void TooMuchOverdraft()
        {
            Customer customer = new Customer("Axel", "Bergen");
            Manager manager = new Manager();
            customer.CreateAccount("Checkings", "A");
            customer.RequestOverdraft(200, manager.RespondToOverdraft("approve"), customer.GetAccount("A"));

            customer.Deposit(customer.GetAccount("A"), new CreditTransaction(300));
            
            Assert.Throws<Exception>(() =>
            {
                customer.Withdrawal(customer.GetAccount("A"), new DebitTransaction(550));
            });

        }

        [Test]
        public void RejectOverdraft()
        {
            Customer customer = new Customer("Axel", "Bergen");
            Manager manager = new Manager();
            customer.CreateAccount("Checkings", "A");
            customer.RequestOverdraft(200, manager.RespondToOverdraft("reject"), customer.GetAccount("A"));

            customer.Deposit(customer.GetAccount("A"), new CreditTransaction(300));

            Assert.Throws<Exception>(() =>
            {
                customer.Withdrawal(customer.GetAccount("A"), new DebitTransaction(490));
            });

        }

        [Test]
        public void ExactOverdraft()
        {
            Customer customer = new Customer("Axel", "Bergen");
            Manager manager = new Manager();
            customer.CreateAccount("Checkings", "A");
            customer.RequestOverdraft(290, manager.RespondToOverdraft("approve"), customer.GetAccount("A"));

            customer.Deposit(customer.GetAccount("A"), new CreditTransaction(200));

            Assert.DoesNotThrow(() =>
            {
                customer.Withdrawal(customer.GetAccount("A"), new DebitTransaction(490));
            });

            Assert.That(customer.GetAccount("A").accountBalance, Is.EqualTo(-290));
        }
    }
}
