using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Model;
using Boolean.CSharp.Main.Controller;
using Boolean.CSharp.Main.View;
using NUnit.Framework;
using System.Reflection;
using NUnit.Framework.Api;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CoreTests
    {
        private Core _core;
        private Main.Controller.Controller _controller;
        private Main.Model.Model _model;
        private Main.View.View _view;

        public CoreTests()
        {
            _core = new Core();
        }

        private void TestSetup()
        {
            _model = new Main.Model.Model();
            _view = new Main.View.View();
            _controller = new Main.Controller.Controller(_model, _view);
        }

        //only to be called after testsetup
        private void CustomerCreation(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                _controller.createPerson(true);
            }
        }

        [Test]
        public void CustomerCreationTest()
        {
            TestSetup();
            CustomerCreation(1);
            //bool isCustomer = _controller.createPerson(true);
            List<Customer> customerList = _controller.GetCustomers();
            //Assert.IsTrue(isCustomer);
            Assert.That(customerList.Count == 1);
            Assert.That(customerList.First().FirstName == "Test");
            
            Customer customer = customerList.First();
            _controller.createBankAccount(customer);

            Assert.That(customerList.First().ID == 1);
        }

        [Test]
        public void CustomerCreationTest2()
        {
            TestSetup();
            CustomerCreation(2);
            //bool isCustomer = _controller.createPerson(true);
            List<Customer> customerList = _controller.GetCustomers();
            //Assert.IsTrue(isCustomer);
            Assert.That(customerList.Count == 2);
            Assert.That(customerList.First().FirstName == "Test");
            
            Customer customer = customerList.First();
            _controller.createBankAccount(customer);


            customer = customerList.Last();
            _controller.createBankAccount(customer);

            Assert.That(customerList.Last().ID == 2);
        }

        [Test]
        public void CustomerAccountDepositTest()
        {
            TestSetup();
            CustomerCreation(1);
            List<Customer> customerList = _controller.GetCustomers();
            Customer customer = customerList.First();
            _controller.createBankAccount(customer);
            _controller.depositMoneyIntoTransactionalAccount(100.0f, customer.ID);
            BankAccount bankAccount = _controller.getBankAccount(customer.ID);
            Assert.That(bankAccount.getTransactionsAccountBalance() == 100.0f);
        
        }

        [Test]
        public void CustomerAccountWithdrawTest()
        {
            TestSetup();
            CustomerCreation(1);
            List<Customer> customerList = _controller.GetCustomers();
            Customer customer = customerList.First();
            _controller.createBankAccount(customer);
            _controller.depositMoneyIntoTransactionalAccount(100.0f, customer.ID);
            BankAccount bankAccount = _controller.getBankAccount(customer.ID);
            Assert.That(bankAccount.getTransactionsAccountBalance() == 100.0f);
            _controller.withdrawMoneyFromTransactionalAccount(50.0f, customer.ID);
            bankAccount = _controller.getBankAccount(customer.ID);
            Assert.That(bankAccount.getTransactionsAccountBalance() == 50.0f);
        }

        [Test]
        public void CustomerAccountWithdrawOverLimitTest()
        {
            TestSetup();
            CustomerCreation(1);
            List<Customer> customerList = _controller.GetCustomers();
            Customer customer = customerList.First();
            _controller.createBankAccount(customer);
            _controller.depositMoneyIntoTransactionalAccount(100.0f, customer.ID);
            BankAccount bankAccount = _controller.getBankAccount(customer.ID);
            Assert.That(bankAccount.getTransactionsAccountBalance() == 100.0f);
            bool successful = _controller.withdrawMoneyFromTransactionalAccount(150.0f, customer.ID);
            bankAccount = _controller.getBankAccount(customer.ID);
            Assert.That(bankAccount.getTransactionsAccountBalance() == 100.0f);
            Assert.IsFalse(successful);
        }
    }
}