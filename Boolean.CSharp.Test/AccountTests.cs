using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Enums;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class AccountTests
    {
        // User Story: I want to create a current account
        [Test]
        public void CreateCurrentAccountTest()
        {
            CurrentAccount current = new CurrentAccount(1, BranchLocation.London);

            Assert.AreEqual(8, current.Number.Length);
        }

        // User Story: I want to create a savings account
        [Test]
        public void CreateSavingsAccountTest()
        {
            SavingsAccount savings = new SavingsAccount(1, BranchLocation.London);

            Assert.AreEqual(8, savings.Number.Length);
        }

        // User Story: I want accounts to be associated with specific branches
        [Test]
        public void CurrentAccountBranchShouldBeLondonTest()
        {
            BranchLocation branch = BranchLocation.London;
            CurrentAccount current = new CurrentAccount(1, branch);

            Assert.AreEqual(branch, current.Branch);
        }

        // User Story: I want accounts to be associated with specific branches
        [Test]
        public void SavingsAccountBranchShouldBeAthensTest()
        {
            BranchLocation branch = BranchLocation.Athens;
            SavingsAccount savings = new SavingsAccount(1, branch);

            Assert.AreEqual(branch, savings.Branch);
        }

        // User Story: I want to deposit [...] funds
        [Test]
        public void DepositFundsToCurrentAccountTest()
        {
            decimal amount = 2000.00m;
            CurrentAccount current = new CurrentAccount(1, BranchLocation.Athens);

            current.Deposit(amount);

            Assert.AreEqual(amount, current.GetBalance());
        }

        // User Story: I want to deposit [...] funds
        [Test]
        public void DepositFundsToSavingsAccountTest()
        {
            decimal amount = 1000.00m;
            SavingsAccount savings = new SavingsAccount(1, BranchLocation.Athens);

            savings.Deposit(amount);

            Assert.AreEqual(amount, savings.GetBalance());
        }

        // User Story: I want to [...] withdraw funds
        [Test]
        public void WithdrawFundsFromCurrentAccountTest()
        {
            decimal depositAmount = 2000.00m;
            decimal withdrawAmount = 500.00m;
            decimal expected = depositAmount - withdrawAmount;
            CurrentAccount current = new CurrentAccount(1, BranchLocation.Amsterdam);

            current.Deposit(depositAmount);
            current.Withdraw(withdrawAmount);

            Assert.AreEqual(expected, current.GetBalance());
        }

        // User Story: I want to [...] withdraw funds
        [Test]
        public void WithdrawFundsFromSavingsAccountTest()
        {
            decimal depositAmount = 1000.00m;
            decimal withdrawAmount = 50.00m;
            decimal expected = depositAmount - withdrawAmount;
            SavingsAccount savings = new SavingsAccount(1, BranchLocation.Athens);

            savings.Deposit(depositAmount);
            savings.Withdraw(withdrawAmount);

            Assert.AreEqual(expected, savings.GetBalance());
        }

        // User Story: I want to generate bank statements with transaction dates, amounts, and balance at the time of transaction
        [Test]
        public void BankStatementOfCurrentAccountTest()
        {
            string date = DateTime.Now.ToString("dd/MM/yyyy");
            string expected = $"date       || credit  || debit  || balance\n{date} ||         || 500.00 || 2500.00\n{date} || 2000.00 ||        || 3000.00\n{date} || 1000.00 ||        || 1000.00";
            CurrentAccount current = new CurrentAccount(1, BranchLocation.London);

            current.Deposit(1000.00m);
            current.Deposit(2000.00m);
            current.Withdraw(500.00m);

            Assert.AreEqual(expected, current.GetBankStatement());
        }

        // User Story: I want to generate bank statements with transaction dates, amounts, and balance at the time of transaction
        [Test]
        public void BankStatementOfSavingsAccountTest()
        {
            string date = DateTime.Now.ToString("dd/MM/yyyy");
            string expected = $"date       || credit  || debit  || balance\n{date} || 1000.00 ||        || 3500.00\n{date} ||         || 500.00 || 2500.00\n{date} || 3000.00 ||        || 3000.00";
            SavingsAccount savings = new SavingsAccount(1, BranchLocation.London);

            savings.Deposit(3000.00m);
            savings.Withdraw(500.00m);
            savings.Deposit(1000.00m);

            Assert.AreEqual(expected, savings.GetBankStatement());
        }
    }
}