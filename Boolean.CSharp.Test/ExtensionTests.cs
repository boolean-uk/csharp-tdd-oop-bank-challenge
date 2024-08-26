using Boolean.CSharp.Main;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Test
{

    public class ExtensionTests
    {

        [Test]
        public void shouldGetBalance()
        {
            //SetUp
            Customer customer = new Customer("Kaja");
            IAccount current = customer.CreateAccount("Current");
            current.Deposit(1000);
            current.Withdraw(500);
            current.Deposit(4000);
            current.Deposit(60);
            current.Withdraw(300);

            //Execute
            List<ITransaction> transactions = current.GetTransactions();
            decimal balance = transactions.Last().BalanceAfterTransaction;
            
            //Verify

            Assert.IsTrue(balance == 4260);
        }
        
        [Test]
        public void shouldSendStatementToPhone()
        {
            //SetUp
           
            //Execute
            //Verify
            Assert.Fail();
        }
       
        [Test]
        public void shouldSendOverdrafRequest()
        {
            //SetUp
            Customer customer = new Customer("Kaja");
            IAccount current = customer.CreateAccount("Current");
            decimal amount = 1000;
          
            //Execute
            OverdraftRequest request = customer.SendOverdraftRequest(current, amount);
            
            //Verify
            Assert.IsTrue(request.Status == "Pending");
        }
      
        [Test]
        public void shouldApproveOverdraftRequest()
        {
            //SetUp
            Manager manager = new Manager();
            Customer customer = new Customer("Kaja");
            IAccount current = customer.CreateAccount("Current");
            decimal amount = 1000;
            OverdraftRequest request = customer.SendOverdraftRequest(current, amount);

            //Execute
            manager.HandleOverdraftRequest(request, true);

            //Verify
            Assert.IsTrue(current.OverdraftLimit == 1000 && request.Status == "Approved");
        }   
        
        [Test]
        public void shouldRejectOverdraftRequest()
        {
            //SetUp
            Manager manager = new Manager();
            Customer customer = new Customer("Kaja");
            IAccount current = customer.CreateAccount("Current");
            decimal amount = 1000;
            OverdraftRequest request = customer.SendOverdraftRequest(current, amount);

            //Execute
            manager.HandleOverdraftRequest(request, false);

            //Verify
            Assert.IsTrue(request.Status == "Rejected" && current.OverdraftLimit == 0);
        }

    }
}
