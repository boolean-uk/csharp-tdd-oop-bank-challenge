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

        private void addFundsToCustomerAccount(Customer customer, float amount, bool isTransactional)
        {
            if (isTransactional)
            {
                _controller.depositMoneyIntoTransactionalAccount(amount, customer.ID);
            }
            else
            {
                _controller.depositMoneyIntoSavingsAccount(amount, customer.ID);
            }
        }

        private bool withdrawFundsFromCustomerAccount(Customer customer, float amount, bool isTransactional)
        {
            if (isTransactional)
            {
                return _controller.withdrawMoneyFromTransactionalAccount(amount, customer.ID);
            }
            else
            {
                return _controller.withdrawMoneyFromSavingsAccount(amount, customer.ID);
            }
        }

        private void createBankAccount(Customer customer, Enum branch)
        {
            _controller.createBankAccount(customer, branch);
        }

        private void createBankAccounts(List<Customer> customers, Enum branch)
        {
            customers.ForEach(customer => _controller.createBankAccount(customer, branch));
        }

        private void printBankStatements(List<Customer> customers)
        {
            customers.ForEach(customer => _controller.printBankStatements(customer.ID));
        }

        [Test]
        public void CustomerCreationTest()
        {
            TestSetup();
            CustomerCreation(1);
            List<Customer> customerList = _controller.GetCustomers();
            Assert.That(customerList.Count == 1);
            Assert.That(customerList.First().FirstName == "Test");

            Customer customer = customerList.First();
            createBankAccount(customer, null);

            Assert.That(customerList.First().ID == 1);
        }

        [Test]
        public void CustomerCreationTest2()
        {
            TestSetup();
            CustomerCreation(2);
            List<Customer> customerList = _controller.GetCustomers();
            Assert.That(customerList.Count == 2);
            Assert.That(customerList.First().FirstName == "Test");

            Customer customer = customerList.First();
            createBankAccount(customer, null);


            customer = customerList.Last();
            createBankAccount(customer, null);

            Assert.That(customerList.Last().ID == 2);
        }

        [Test]
        public void CustomerAccountDepositTest()
        {
            TestSetup();
            CustomerCreation(1);
            List<Customer> customerList = _controller.GetCustomers();
            Customer customer = customerList.First();
            createBankAccount(customer, null);
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
            createBankAccount(customer, null);
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
            createBankAccount(customer, null);
            _controller.depositMoneyIntoTransactionalAccount(100.0f, customer.ID);
            BankAccount bankAccount = _controller.getBankAccount(customer.ID);
            Assert.That(bankAccount.getTransactionsAccountBalance() == 100.0f);
            bool successful = _controller.withdrawMoneyFromTransactionalAccount(150.0f, customer.ID);
            bankAccount = _controller.getBankAccount(customer.ID);
            Assert.That(bankAccount.getTransactionsAccountBalance() == 100.0f);
            Assert.IsFalse(successful);
        }

        [Test]
        public void BankStatementTest()
        {

            TestSetup();
            CustomerCreation(2);
            List<Customer> customerList = _controller.GetCustomers();
            Customer customer1 = customerList.First();
            Customer customer2 = customerList.Last();
            createBankAccount(customer1, null);
            createBankAccount(customer2, null);

            addFundsToCustomerAccount(customer1, 100.0f, true);
            addFundsToCustomerAccount(customer2, 200.0f, true);

            addFundsToCustomerAccount(customer1, 100.0f, false);
            addFundsToCustomerAccount(customer2, 200.0f, false);

            withdrawFundsFromCustomerAccount(customer1, 50.0f, true);
            withdrawFundsFromCustomerAccount(customer2, 150.0f, true);

            withdrawFundsFromCustomerAccount(customer1, 50.0f, false);
            withdrawFundsFromCustomerAccount(customer2, 150.0f, false);

            printBankStatements(customerList);

            Assert.Pass();
        }

        [Test]
        public void BankBranchTest()
        {

            TestSetup();
            CustomerCreation(2);
            List<Customer> customerList = _controller.GetCustomers();
            Customer customer1 = customerList.First();
            Customer customer2 = customerList.Last();

            createBankAccount(customer1, Bank.Branch.HR);
            createBankAccount(customer2, Bank.Branch.IT);

            addFundsToCustomerAccount(customer1, 100.0f, true);
            addFundsToCustomerAccount(customer2, 200.0f, true);

            addFundsToCustomerAccount(customer1, 100.0f, false);
            addFundsToCustomerAccount(customer2, 200.0f, false);

            withdrawFundsFromCustomerAccount(customer1, 50.0f, true);
            withdrawFundsFromCustomerAccount(customer2, 150.0f, true);

            withdrawFundsFromCustomerAccount(customer1, 50.0f, false);
            withdrawFundsFromCustomerAccount(customer2, 150.0f, false);


            printBankStatements(customerList);

            Assert.Pass();
        }

        [Test]
        public void OverdraftRequestTest()
        {
            TestSetup();
            CustomerCreation(2);
            List<Customer> customerList = _controller.GetCustomers();
            Customer customer1 = customerList.First();
            Customer customer2 = customerList.Last();
            createBankAccount(customer1, Bank.Branch.HR);
            createBankAccount(customer2, Bank.Branch.IT);

            _controller.requestOverdraft(customer1.ID, 500.0f, "I want to buy chicken nuggets");
            _controller.requestOverdraft(customer2.ID, 5000.0f, "I want to buy HiFi speakers");

            List<OverdraftRequest> requests = _controller.getOverdraftRequests();

            _controller.approveOverdraftRequest(requests.First());

            _controller.getOverdraftRequests();
        }

        [Test]
        public void StressTest()
        {
            TestSetup();
            CustomerCreation(50);
            List<Customer> customerList = _controller.GetCustomers();
            Assert.That(customerList.Count, Is.EqualTo(50));
            createBankAccounts(customerList, Bank.Branch.IT);
            Assert.That(customerList.Last().ID, Is.EqualTo(50));
        }

        [Test]
        public void StressTwoTest()
        {
            TestSetup();
            CustomerCreation(50);
            List<Customer> customerList = _controller.GetCustomers();
            Assert.That(customerList.Count, Is.EqualTo(50));
            createBankAccounts(customerList, Bank.Branch.IT);
            Assert.That(customerList.Last().ID, Is.EqualTo(50));

            addFundsToCustomerAccount(customerList.Last(), 50000.0f, true);
            bool withdrawalSuccess = withdrawFundsFromCustomerAccount(customerList.Last(), 60000.0f, true);
            Assert.IsFalse(withdrawalSuccess);
            withdrawalSuccess = withdrawFundsFromCustomerAccount(customerList.Last(), 60000.0f, false);
            Assert.IsFalse(withdrawalSuccess);

            printBankStatements(customerList);
        }
    }
}