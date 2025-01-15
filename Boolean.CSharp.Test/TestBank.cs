using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boolean.CSharp.Main;
using IKVM.Runtime;
using java.io;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{

    [TestFixture]
    public class TestBank
    {
        private ByteArrayOutputStream outContent = new ByteArrayOutputStream();
        private Branch mockBranch;
        private Bank bank;
        private Customer customer;

        [SetUp]
        public void setup()
        {
            bank = new Bank();
            customer = new Customer(1, "Harry", "Potter");
            bank.addCustomer(customer);
            mockBranch = new Branch("Mock Branch", "123 Mock Street");
            bank.addBranch(mockBranch);
        }

        [Test]
        public void TestCurrentAccountCreated()
        {
            Assert.IsTrue(bank.createAccount(customer.getId(), "Current Account", 100.0, mockBranch.getName()));
        }

        [Test]
        public void TestDeposit()
        {
            bank.createAccount(customer.getId(), "Saving Account", 0.0, mockBranch.getName());
            int accountNumberForDeposit = customer.getNextAccountNumber() - 1;
            Assert.IsTrue(bank.deposit(customer.getId(), accountNumberForDeposit, 100.0));
        }

        [Test]
        public void TestTransactionPrint()
        {

            bank.createAccount(customer.getId(), "Saving Account", 0.0, mockBranch.getName());
            int accountNumberForDeposit = customer.getNextAccountNumber() - 1;

            bank.deposit(customer.getId(), accountNumberForDeposit, 100.0);
            bank.deposit(customer.getId(), accountNumberForDeposit, 100.0);
            bank.deposit(customer.getId(), accountNumberForDeposit, 100.0);

            var originalOutput = System.Console.Out;
            using (var memoryStream = new MemoryStream())
            using (var writer = new StreamWriter(memoryStream))
            {
                try
                {
                    System.Console.SetOut(writer);
                    bank.printBankStatement(customer.getId(), accountNumberForDeposit);

                    writer.Flush();
                    memoryStream.Position = 0;

                    using (var reader = new StreamReader(memoryStream))
                    {
                        var output = reader.ReadToEnd();
                        Assert.IsTrue(output.Contains("Balance: 300"), "Expected balance not found in output.");
                    }
                }
                finally
                {
                    System.Console.SetOut(originalOutput);
                }
            }
        }


        [Test]
        public void TestWithdraw()
        {
            bank.createAccount(customer.getId(), "Saving Account", 300.0, mockBranch.getName());
            int accountNumberForDeposit = customer.getNextAccountNumber() - 1;

            Assert.IsTrue(bank.withdraw(customer.getId(), accountNumberForDeposit, 300.0));
            System.Console.SetOut(new StreamWriter(new MemoryStream()));
            bank.printBankStatement(customer.getId(), accountNumberForDeposit);
            string output = outContent.toString();
            //Assert.IsTrue(output.Contains("Balance: 0.0"));
            //System.Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
        }

        [Test]
        public void testBalanceBasedOnTransactionHistory()
        {
            bank.createAccount(customer.getId(), "Checking", 500.0, mockBranch.getName());
            bank.deposit(customer.getId(), 1, 200.0);
            bank.withdraw(customer.getId(), 1, 150.0);

            double balance = bank.findCustomerById(customer.getId()).getAccount(1).calculateBalance();
            Assert.AreEqual(550.0, balance, "Balance should be calculated based on transaction history.");
        }
    }

}
