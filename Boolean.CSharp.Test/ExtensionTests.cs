using Boolean.CSharp.Main;
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
        private Extension _extension;
        public ExtensionTests()
        {
            _extension = new Extension();
        }
        [Test]
        public void BankBranchStoreBranchDetails()
        {
            // Arrange
            var branch = new Extension.BankBranch("001", "Main Branch", "Downtown");

            // Act & Assert
            Assert.AreEqual("001", branch.BranchId);
            Assert.AreEqual("Main Branch", branch.BranchName);
            Assert.AreEqual("Downtown", branch.Location);
        }

        [Test]
        public void BankAccountAssociateWithCorrectBranch()
        {
            // Arrange
            var branch = new Extension.BankBranch("001", "Main Branch", "Downtown");
            var account = new Extension.BankAccount("Jane Doe", "123456", "Current", branch, 1000);

            // Act & Assert
            Assert.AreEqual(branch, account.AccountBranch);
        }

        [Test]
        public void RequestOverdraftSetOverdraftLimit()
        {
            // Arrange
            var branch = new Extension.BankBranch("001", "Main Branch", "Downtown");
            var account = new Extension.BankAccount("Jane Doe", "123456", "Current", branch, 1000);

            // Act
            var result = account.RequestOverdraft(500);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(500, account.OverdraftLimit);
        }

        [Test]
        public void ApproveOverdraftShouldApprove()
        {
            // Arrange
            var branch = new Extension.BankBranch("001", "Main Branch", "Downtown");
            var account = new Extension.BankAccount("Jane Doe", "123456", "Current", branch, 1000);

            // Act
            var result = account.ApproveOverdraft(account, 500);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(500, account.OverdraftLimit);
        }

        [Test]
        public void ApproveOverdraftShouldReject()
        {
            // Arrange
            var branch = new Extension.BankBranch("001", "Main Branch", "Downtown");
            var account = new Extension.BankAccount("Jane Doe", "123456", "Current", branch, 0);

            // Simulate an initial negative balance by adding a transaction
            account.TransactionList.Add(new Core.Transaction("Withdrawal", 100, DateTime.Now, -100));

            // Act
            var result = account.ApproveOverdraft(account, 500);

            // Assert
            Assert.IsFalse(result);
        }




        [Test]
        public void SendStatementReturnFormattedStatement()
        {
            // Arrange
            var branch = new Extension.BankBranch("001", "Main Branch", "Downtown");
            var account = new Extension.BankAccount("Jane Doe", "123456", "Current", branch, 1000);
            var affiliate = new Core.BankAffiliate("John Doe", "Branch A");
            affiliate.CreateCurrentAccount(account);
            affiliate.DepositFunds(account, 1000);
            affiliate.WithdrawFunds(account, 500);

            var notifier = new Extension.MessageNotification();

            // Act
            var statement = notifier.SendStatement(account);
            Console.WriteLine("Actual Statement:");
            Console.WriteLine(statement);


            // Assert
            var expected = new StringBuilder()
                .AppendLine("Statement sent to customer:")
                .AppendLine("Date       || Deposit  || Withdrawal || Balance")
                .AppendLine($"{DateTime.Now:dd/MM/yyyy} ||          || 500.00     || 500.00")
                .AppendLine($"{DateTime.Now:dd/MM/yyyy} || 1000.00  ||            || 1000.00")
                .ToString();

            Console.WriteLine("Expected Statement:");
            Console.WriteLine(expected);

            Assert.AreEqual(expected, statement);
        }



        [Test]
        public void SendStatementShouldReturnErrorNoTransactions()
        {
            // Arrange
            var branch = new Extension.BankBranch("001", "Main Branch", "Downtown");
            var account = new Extension.BankAccount("Jane Doe", "123456", "Current", branch, 1000);
            var notifier = new Extension.MessageNotification();

            // Act
            var statement = notifier.SendStatement(account);

            // Assert
            Assert.AreEqual("No transactions available to generate a statement.", statement);
        }
    }
}
