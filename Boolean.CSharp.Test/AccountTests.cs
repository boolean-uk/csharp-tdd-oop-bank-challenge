using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Enums;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class AccountTests
    {
        private Customer customer = new Customer("Konstantina", "Athens, Greece", "+30 694 663 2041");

        private BankManager manager = new BankManager("Georgia", "Athens, Greece", "+30 694 663 3636");

        // User Story: I want to create a current account
        [Test]
        public void CreateCurrentAccountTest()
        {
            CurrentAccount current = new CurrentAccount(customer, BranchLocation.London);

            Assert.AreEqual(8, current.Number.Length);
        }

        // User Story: I want to create a savings account
        [Test]
        public void CreateSavingsAccountTest()
        {
            SavingsAccount savings = new SavingsAccount(customer, BranchLocation.London);

            Assert.AreEqual(8, savings.Number.Length);
        }

        // User Story: I want accounts to be associated with specific branches
        [Test]
        public void CurrentAccountBranchShouldBeLondonTest()
        {
            BranchLocation branch = BranchLocation.London;
            CurrentAccount current = new CurrentAccount(customer, branch);

            Assert.AreEqual(branch, current.Branch);
        }

        // User Story: I want accounts to be associated with specific branches
        [Test]
        public void SavingsAccountBranchShouldBeAthensTest()
        {
            BranchLocation branch = BranchLocation.Athens;
            SavingsAccount savings = new SavingsAccount(customer, branch);

            Assert.AreEqual(branch, savings.Branch);
        }

        // User Story: I want to deposit [...] funds
        [Test]
        public void DepositFundsToCurrentAccountTest()
        {
            decimal amount = 2000.00m;
            CurrentAccount current = new CurrentAccount(customer, BranchLocation.Athens);

            current.Deposit(amount);

            Assert.AreEqual(amount, current.GetBalance());
        }

        // User Story: I want to deposit [...] funds
        [Test]
        public void DepositFundsToSavingsAccountTest()
        {
            decimal amount = 1000.00m;
            SavingsAccount savings = new SavingsAccount(customer, BranchLocation.Athens);

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
            CurrentAccount current = new CurrentAccount(customer, BranchLocation.Amsterdam);

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
            SavingsAccount savings = new SavingsAccount(customer, BranchLocation.Athens);

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
            CurrentAccount current = new CurrentAccount(customer, BranchLocation.London);

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
            SavingsAccount savings = new SavingsAccount(customer, BranchLocation.London);

            savings.Deposit(3000.00m);
            savings.Withdraw(500.00m);
            savings.Deposit(1000.00m);

            Assert.AreEqual(expected, savings.GetBankStatement());
        }

        // User Story: I want to be able to request an overdraft on my account
        [Test]
        public void RequestOverdraftOnCurrentAccountTest()
        {
            decimal amount = 2000.00m;
            CurrentAccount current = new CurrentAccount(customer, BranchLocation.Athens);

            int result = current.RequestOverdraft(customer, amount);

            Assert.IsTrue(result > 0);
        }

        // User Story: I want to be able to request an overdraft on my account
        [Test]
        public void RequestOverdraftOnSavingsAccountTest()
        {
            decimal amount = 2000.00m;
            SavingsAccount savings = new SavingsAccount(customer, BranchLocation.Athens);

            int result = savings.RequestOverdraft(customer, amount);

            Assert.IsTrue(result > 0);
        }

        // User Story: I want to approve [...] overdraft requests
        [Test]
        public void ApproveOverdraftRequestOnCurrentAccountTest()
        {
            decimal amount = 200.00m;
            CurrentAccount current = new CurrentAccount(customer, BranchLocation.Athens);
            int overdraftId = current.RequestOverdraft(customer, amount);

            bool result = current.ApproveOverdraftRequest(manager, overdraftId);

            Assert.IsTrue(result);
        }

        // User Story: I want to approve [...] overdraft requests
        [Test]
        public void ApproveOverdraftRequestOnSavingsAccountTest()
        {
            decimal amount = 200.00m;
            SavingsAccount savings = new SavingsAccount(customer, BranchLocation.Athens);
            int overdraftId = savings.RequestOverdraft(customer, amount);

            bool result = savings.ApproveOverdraftRequest(manager, overdraftId);

            Assert.IsTrue(result);
        }

        // User Story: I want to approve [...] overdraft requests
        [Test]
        public void FailToApproveOverdraftRequestOnCurrentAccountTest()
        {
            CurrentAccount current = new CurrentAccount(customer, BranchLocation.Athens);

            bool result = current.ApproveOverdraftRequest(manager, 100);

            Assert.IsFalse(result);
        }

        // User Story: I want to approve [...] overdraft requests
        [Test]
        public void FailToApproveOverdraftRequestOnSavingsAccountTest()
        {
            SavingsAccount savings = new SavingsAccount(customer, BranchLocation.Athens);

            bool result = savings.ApproveOverdraftRequest(manager, 100);

            Assert.IsFalse(result);
        }

        // User Story: I want to [...] reject overdraft requests
        [Test]
        public void RejectOverdraftRequestOnCurrentAccountTest()
        {
            decimal amount = 2000.00m;
            CurrentAccount current = new CurrentAccount(customer, BranchLocation.Athens);
            int overdraftId = current.RequestOverdraft(customer, amount);

            bool result = current.RejectOverdraftRequest(manager, overdraftId);

            Assert.IsTrue(result);
        }

        // User Story: I want to [...] reject overdraft requests
        [Test]
        public void RejectOverdraftRequestOnSavingsAccountTest()
        {
            decimal amount = 2000.00m;
            SavingsAccount savings = new SavingsAccount(customer, BranchLocation.Athens);
            int overdraftId = savings.RequestOverdraft(customer, amount);

            bool result = savings.RejectOverdraftRequest(manager, overdraftId);

            Assert.IsTrue(result);
        }

        // User Story: I want to [...] reject overdraft requests
        [Test]
        public void FailToRejectOverdraftRequestOnCurrentAccountTest()
        {
            CurrentAccount current = new CurrentAccount(customer, BranchLocation.Athens);

            bool result = current.RejectOverdraftRequest(manager, 100);

            Assert.IsFalse(result);
        }

        // User Story: I want to [...] reject overdraft requests
        [Test]
        public void FailToRejectOverdraftRequestOnSavingsAccountTest()
        {
            SavingsAccount savings = new SavingsAccount(customer, BranchLocation.Athens);

            bool result = savings.RejectOverdraftRequest(manager, 100);

            Assert.IsFalse(result);
        }

        // User Story: I want to deposit and withdraw funds (using overdrafts as well)
        [Test]
        public void DontWithdrawIfFundsNotAvailableInCurrentAccount()
        {
            CurrentAccount current = new CurrentAccount(customer, BranchLocation.Athens);
            current.Deposit(150.00m);
            int overdraftId = current.RequestOverdraft(customer, 50.00m);
            Assert.IsTrue(current.ApproveOverdraftRequest(manager, overdraftId));

            bool result = current.Withdraw(400.00m);

            Assert.IsFalse(result);
        }

        [Test]
        public void DontWithdrawIfFundsNotAvailableInSavingsAccount()
        {
            SavingsAccount savings = new SavingsAccount(customer, BranchLocation.Athens);

            bool result = savings.Withdraw(400.00m);

            Assert.IsFalse(result);
        }

        // User Story: I want to deposit and withdraw funds (using overdrafts as well)
        [Test]
        public void ShouldCreateCorrectBankStatement()
        {
            string date = DateTime.Now.ToString("dd/MM/yyyy");
            string expected = $"date       || credit  || debit  || balance\n{date} ||  500.00 ||        || 150.00\n{date} ||         ||  50.00 || -350.00\n{date} ||  100.00 ||        || -300.00\n{date} ||         || 400.00 || -400.00";
            decimal amount1 = 200.00m, amount2 = 300.00m;
            CurrentAccount current = new CurrentAccount(customer, BranchLocation.Athens);
            int overdraftId = current.RequestOverdraft(customer, amount1);
            Assert.IsTrue(current.ApproveOverdraftRequest(manager, overdraftId));
            overdraftId = current.RequestOverdraft(customer, amount2);
            Assert.IsTrue(current.ApproveOverdraftRequest(manager, overdraftId));
            current.Withdraw(400.00m);
            current.Deposit(100.00m);
            current.Withdraw(50.00m);
            current.Deposit(500.00m);

            Assert.AreEqual(expected, current.GetBankStatement());
        }
    }
}