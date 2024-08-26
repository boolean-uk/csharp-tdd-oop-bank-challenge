using Boolean.CSharp.Main;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class BankTests
    {

        [Test]
        public void Test1CreateACurrentAccount()
        {
            // Create account...
            CurrentAccount currentAccount = new CurrentAccount();
            Assert.IsNotNull(currentAccount);
        }

        [Test]
        public void Test2DepositAndWithdrawFromCurrentAccount()
        {
            // Store and use money...
            CurrentAccount currentAccount = new CurrentAccount();
            bool result1 = currentAccount.Deposit(1000);
            bool result2 = currentAccount.Withdraw(500);
            Assert.IsTrue(result1);
            Assert.IsTrue(result2);

            Assert.That(currentAccount.Balance == 500);
        }

        [Test]
        public void Test3CreateASavingsAccount()
        {
            SavingsAccount savingsAccount = new SavingsAccount();
            Assert.IsNotNull(savingsAccount);
        }

        [Test]
        public void Test4DepositAndWithdrawFromSavingsAccount()
        {
            SavingsAccount savingsAccount = new SavingsAccount();
            savingsAccount.Deposit(1000);
            savingsAccount.Withdraw(500);
            Assert.That(savingsAccount.Balance == 500);
        }

        [Test]
        public void Test5GenerateBankStatement()
        {
            BankStatement bankStatement = new BankStatement(DateTime.Now, 500, "Deposit", 500);
            Assert.IsNotNull(bankStatement);
            Assert.AreEqual(500, bankStatement.Balance);
            Assert.AreEqual("Deposit", bankStatement.Type);
        }

        [Test]
        public void Test6GetBankStatementsFromAccount()
        {
            BankAccount bankAccount = new CurrentAccount();
            bankAccount.Deposit(1000);
            bankAccount.Deposit(2000);
            bankAccount.Withdraw(500);
            Assert.That(bankAccount.BankStatements.Count == 3);
            Assert.That(bankAccount.BankStatements.ElementAt(1).Balance == 3000);
            Assert.That(bankAccount.BankStatements.ElementAt(0).Type.Equals("Withdraw"));
        }

        [Test]
        public void Test7PrintBankStatement()
        {
            BankAccount bankAccount = new CurrentAccount();
            bankAccount.Deposit(1000.00m);
            bankAccount.Deposit(2000.00m);
            bankAccount.Withdraw(500.00m);
            string printedStatement = bankAccount.PrintBankStatements();
            Assert.That(printedStatement.Contains("date"));
            Assert.That(printedStatement.Contains("credit"));
            Assert.That(printedStatement.Contains("debit"));
            Assert.That(printedStatement.Contains("balance"));
            Assert.That(printedStatement.Contains("1000"));
            Assert.That(printedStatement.Contains("2000"));
            Assert.That(printedStatement.Contains("500"));
            Assert.That(printedStatement.Contains("3000"));
            Assert.That(printedStatement.Contains("2500"));
        }

        [Test]
        public void Test8AddBranchToAccount()
        {
            BankAccount bankAccount = new CurrentAccount();
            bankAccount.Branch = new BankBranch("Bob's Bank", "London");
            string result1 = bankAccount.Branch.Name;
            Assert.That(result1.Equals("Bob's Bank"));
        }

        [Test]
        public void Test9RequestOverdraft()
        {
            BankAccount bankAccount = new CurrentAccount();
            bankAccount.RequestOverdraft(500, new Manager("Bob", 1234));
            decimal amount = bankAccount.Balance;
            Assert.That(amount == -500m);
        }

        [Test]
        public void Test10RequestOverdraftFail()
        {
            BankAccount bankAccount = new CurrentAccount();
            bool result1 = bankAccount.RequestOverdraft(999999999999999, new Manager("Bob", 1234));
            Assert.IsFalse(result1);
        }

        [Test]
        public void Test11PrintStatementWithOverdraft()
        {
            BankAccount bankAccount = new CurrentAccount();
            Manager manager = new Manager("Bob", 1234);
            bankAccount.Deposit(1000.00m);
            bankAccount.Deposit(2000.00m);
            bankAccount.Withdraw(500.00m);
            bankAccount.Withdraw(2500.00m);
            bankAccount.RequestOverdraft(500.00m, manager);
            bankAccount.RequestOverdraft(200.00m, manager);
            string printedStatement = bankAccount.PrintBankStatements();
            Assert.That(printedStatement.Contains("-500"));
            Assert.That(printedStatement.Contains("-700"));
        }
    }
}