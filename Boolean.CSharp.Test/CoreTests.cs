using System.Text;
using Boolean.CSharp.Main;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CoreTests
    {
        private Core _core;

        public CoreTests()
        {
            _core = new Core();

        }

        [Test]
        public void CreateCurrentAccountAddNewAccount()
        {
            // Arrange
            var affiliate = new Core.BankAffiliate("John Doe", "Branch A");
            var account = new Core.BankAccount("Jane Doe", "123456", "Current");

            // Act
            var result = affiliate.CreateCurrentAccount(account);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void CreateCurrentAccountNoDuplicate()
        {
            // Arrange
            var affiliate = new Core.BankAffiliate("John Doe", "Branch A");
            var account = new Core.BankAccount("Jane Doe", "123456", "Current");
            affiliate.CreateCurrentAccount(account);

            // Act
            var result = affiliate.CreateCurrentAccount(account);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void CreateSavingsAccountAddAccountToListWhenAccountDoesNotExist()
        {
            // Arrange
            var affiliate = new Core.BankAffiliate("John Doe", "Branch A");
            var account = new Core.BankAccount("Jane Doe", "654321", "Savings");

            // Act
            var result = affiliate.CreateSavingsAccount(account);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void DepositFundsUpdateBalance()
        {
            // Arrange
            var affiliate = new Core.BankAffiliate("John Doe", "Branch A");
            var account = new Core.BankAccount("Jane Doe", "123456", "Current");
            affiliate.CreateCurrentAccount(account);

            // Act
            affiliate.DepositFunds(account, 1000);

            // Assert
            Assert.AreEqual(1000, account.GetBalance);
            Assert.AreEqual(1, account.TransactionList.Count);
            Assert.AreEqual("Deposit", account.TransactionList[0].Type);
            Assert.AreEqual(1000, account.TransactionList[0].Amount);
        }

        [Test]
        public void WithdrawFundsUpdateBalance()
        {
            // Arrange
            var affiliate = new Core.BankAffiliate("John Doe", "Branch A");
            var account = new Core.BankAccount("Jane Doe", "123456", "Current");
            affiliate.CreateCurrentAccount(account);
            affiliate.DepositFunds(account, 1000);

            // Act
            affiliate.WithdrawFunds(account, 500);

            // Assert
            Assert.AreEqual(500, account.GetBalance);
            Assert.AreEqual(2, account.TransactionList.Count);
            Assert.AreEqual("Withdrawal", account.TransactionList[1].Type);
            Assert.AreEqual(500, account.TransactionList[1].Amount);
        }

        [Test]
        public void WithdrawFundsAllowOverdraft()
        {
            // Arrange
            var affiliate = new Core.BankAffiliate("John Doe", "Branch A");
            var account = new Core.BankAccount("Jane Doe", "123456", "Current");
            affiliate.CreateCurrentAccount(account);
            affiliate.DepositFunds(account, 500);

            // Act
            affiliate.WithdrawFunds(account, 1000);

            // Assert
            Assert.AreEqual(-500, account.GetBalance);
        }


        [Test]
        public void GenerateBankStatementSuccess()
        {
            // Arrange
            var account = new Core.BankAccount("Jane Doe", "123456", "Current");
            var affiliate = new Core.BankAffiliate("John Doe", "Branch A");
            affiliate.CreateCurrentAccount(account);
            affiliate.DepositFunds(account, 1000);
            affiliate.WithdrawFunds(account, 500);

            var bankStatement = new Core.BankStatement();

            // Act
            var statement = bankStatement.GenerateBankStatement(account);
            Console.WriteLine(statement);

            // Assert
            var expected = new StringBuilder()
                .AppendLine("Date       || Deposit  || Withdrawal || Balance")
                .AppendLine($"{DateTime.Now:dd/MM/yyyy} ||          || 500.00     || 500.00")
                .AppendLine($"{DateTime.Now:dd/MM/yyyy} || 1000.00  ||            || 1000.00")
                .ToString();

            Console.WriteLine(expected);

            Assert.AreEqual(expected, statement);
        }





        [Test]
        public void GenerateBankStatementError()
        {
            // Arrange
            var account = new Core.BankAccount("Jane Doe", "123456", "Current");
            var bankStatement = new Core.BankStatement();

            // Act
            var statement = bankStatement.GenerateBankStatement(account);

            // Assert
            Assert.AreEqual("No transactions available.", statement);
        }
    }

}
