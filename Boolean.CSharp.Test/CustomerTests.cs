using Boolean.CSharp.Main;
using Boolean.CSharp.Main.BankAccountClasses;
using Boolean.CSharp.Main.Persons;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    public class CustomerTests
    {
        [Test]
        public void CreateCurrentAccount()
        {
            Bank bank = new Bank();
            Customer customer = new Customer(bank, 32, "john");

            customer.CreateAccount("Current account Test");

            Assert.That((bank.BankAccounts.Count == 1), Is.True);
        }

        [Test]
        public void CreateSavingsAccount()
        {
            Bank bank = new Bank();
            Customer customer = new Customer(bank, 32, "john");

            customer.CreateSavingsAccount("Savings account Test");

            Assert.That((bank.BankAccounts.Count == 1), Is.True);
        }

        [Test]
        public void GenerateBankStatement()
        {
            Bank bank = new Bank();
            Customer customer = new Customer(bank, 32, "john");

            customer.CreateSavingsAccount("Bank statement Test");
            customer.GenerateBankStatement("Bank statement Test");

            Assert.Fail();
        }

        [Test]
        public void DepositToAccount()
        {
            Bank bank = new Bank();
            Customer customer = new Customer(bank, 32, "john");

            customer.CreateAccount("Deposit account Test");
            customer.DepositToAccount("Deposit account Test", 500);
            //customer.GenerateBankStatement("Savings account Test");

            Assert.That((customer.GetAccount("Deposit account Test").Balance == 500), Is.True);
        }

        [Test]
        public void WithdrawFromAccount()
        {
            Bank bank = new Bank();
            Customer customer = new Customer(bank, 32, "john");

            customer.CreateAccount("Deposit account Test");
            customer.DepositToAccount("Deposit account Test", 500);
            customer.WithdrawFromAccount("Deposit account Test", 250);

            Assert.That((customer.GetAccount("Deposit account Test").Balance == 250), Is.True);
        }
    }
}