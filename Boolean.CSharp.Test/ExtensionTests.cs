using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Accounts;
using Boolean.CSharp.Main.Branch;
using Boolean.CSharp.Main.enums;
using Boolean.CSharp.Main.Transactions;
using Boolean.CSharp.Main.Users;
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
        IBankBranch branch = new LocalBank("123 Bank Road, 987 City");
        DateTime dob = new DateTime(1996, 8, 20);

        [SetUp]
        public void SetUp()
        {
            branch = new LocalBank("123 Bank Road, 987 City");
            dob = new DateTime(1996, 8, 20);
        }

        [Test]
        public void TestBranchAssociation()
        {
            Customer user = new RegularCustomer("Bob", dob, branch);
            // Register customer and make a bank account
            user.RegisterWithBankBranch(branch);
            user.OpenNewAccount(AccountType.General);
            IAccount acc = user.GetAccounts()[0];
            branch.AddAccountToBranch(acc);

            // Act
            IAccount res1 = branch.GetAccounts()[0];
            bool res2 = branch.AddUserToBranch(user);


            // Assert
            Assert.That(res1, Is.EqualTo(acc));
            Assert.That(branch.GetLocation(), Is.EqualTo("123 Bank Road, 987 City"));
            Assert.That(res2, Is.True);

        }

        [Test]
        public void TestTransactionManagerBalanceCalculation()
        {
            // Arrange
            Customer user = new RegularCustomer("Tim", dob, branch);
            user.RegisterWithBankBranch(branch);
            user.OpenNewAccount(AccountType.General);
            IAccount acc = user.GetAccounts()[0];
            IBankTransaction? transactions = (acc as PersonalAccount)?.GetTransactionManager();

            // Act
            transactions.AddDepositTransaction(100);
            decimal res1 = transactions.CalculateAccountBalance();
            transactions.AddDepositTransaction(1000);
            decimal res2 = transactions.CalculateAccountBalance();
            transactions.AddDepositTransaction(10000);
            decimal res3 = transactions.CalculateAccountBalance();
            transactions.AddWithdrawTransaction(50);
            decimal res4 = transactions.CalculateAccountBalance();
            transactions.AddWithdrawTransaction(500);
            decimal res5 = transactions.CalculateAccountBalance();
            transactions.AddWithdrawTransaction(5000);
            decimal res6 = transactions.CalculateAccountBalance();

            // Assert
            Assert.That(res1, Is.EqualTo(100));
            Assert.That(res2, Is.EqualTo(1100));
            Assert.That(res3, Is.EqualTo(11100));
            Assert.That(res4, Is.EqualTo(11050));
            Assert.That(res5, Is.EqualTo(10550));
            Assert.That(res6, Is.EqualTo(5550));
        }

        [Test]
        public void TestAddingUsersToBranch() 
        {
            // Arrange
            Customer user1 = new RegularCustomer("Bob", dob, branch);
            Customer user2 = new RegularCustomer("Bill", dob, branch);
            Customer user3 = new RegularCustomer("Billy", dob, branch);

            IEmployee emp1 = new Manager("Jim");
            IEmployee emp2 = new Manager("Jimmy");

            // Act
            bool res1 = branch.AddUserToBranch(user1);
            bool res2 = branch.AddUserToBranch(user2);
            bool res3 = branch.AddUserToBranch(user3);

            bool res4 = branch.AddEmployeeToBranch(emp1);
            bool res5 = branch.AddEmployeeToBranch(emp2);

            int countRes1 = branch.GetAccounts().Count;
            int countRes2 = branch.GetCustomers().Count;
            int countRes3 = branch.GetEmployees().Count;

            // Assert
            Assert.That(res1, Is.True);
            Assert.That(res2, Is.True);
            Assert.That(res3, Is.True);
            Assert.That(res4, Is.True);
            Assert.That(res5, Is.True);

            Assert.That(countRes1, Is.EqualTo(0));
            Assert.That(countRes2, Is.EqualTo(3));
            Assert.That(countRes3, Is.EqualTo(2));

        }

        [Test]
        public void TestOverdraftGeneralAccount() 
        {
            // Arrange
            Customer user = new RegularCustomer("Bob", dob, branch);
            IEmployee manager = new Manager("Jim");
            user.RegisterWithBankBranch(branch);
            user.OpenNewAccount(AccountType.General);
            IAccount acc = user.GetAccounts()[0];
            branch.AddAccountToBranch(acc);
            acc.Deposit(1000m);

            // Act
            decimal? res1 = (acc as PersonalAccount)?.SetOverdrawLimit(500, user);
            decimal draw1 = acc.Withdraw(1250m);

            decimal? res2 = (acc as PersonalAccount)?.SetOverdrawLimit(750, manager);
            decimal draw2 = acc.Withdraw(1250m);

            // Assert
            Assert.That(res1, Is.EqualTo(0));
            Assert.That(draw1, Is.EqualTo(0m));

            Assert.That(res2, Is.EqualTo(750m));
            Assert.That(draw2, Is.EqualTo(1250m));
        }

        [Test]
        public void TestOverdraftSavingsAccount() 
        {
            // Arrange
            Customer user = new RegularCustomer("Bob", dob, branch);
            IEmployee manager = new Manager("Jim");
            user.RegisterWithBankBranch(branch);
            user.OpenNewAccount(AccountType.Savings);
            IAccount acc = user.GetAccounts()[0];
            branch.AddAccountToBranch(acc);
            acc.Deposit(1000m);

            // Act
            decimal? res1 = (acc as SavingsAccount)?.SetOverdrawLimit(500, user);
            decimal draw1 = acc.Withdraw(1250m);

            decimal? res2 = (acc as SavingsAccount)?.SetOverdrawLimit(750, manager);
            decimal draw2 = acc.Withdraw(1250m);

            decimal draw3 = acc.Withdraw(750m);

            // Assert
            Assert.That(res1, Is.EqualTo(0));
            Assert.That(draw1, Is.EqualTo(0m));

            Assert.That(res2, Is.EqualTo(0));
            Assert.That(draw2, Is.EqualTo(0m));

            Assert.That(draw3, Is.EqualTo(750m));
        }

        [Test]
        public void TestOverdraftRequests() 
        {
            // Arrange
            Customer user = new RegularCustomer("Bob", dob, branch);
            IEmployee manager = new Manager("Jim");
            branch.AddEmployeeToBranch(manager);

            user.RegisterWithBankBranch(branch);
            user.OpenNewAccount(AccountType.General);
            IAccount acc = user.GetAccounts()[0];
            branch.AddAccountToBranch(acc);
            acc.Deposit(1000m);
            string expectedRequestString = 
                $"Requester: Bob, " +
                $"amount: 500, " +
                $"account type: GeneralAccount, " +
                $"submitted: {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}";
            // Cant expect exact second to match, we just remove the time of day
            expectedRequestString = expectedRequestString.Substring(0, expectedRequestString.Length - 9);

            // Act
            decimal res1 = acc.Withdraw(1250m);
            string overdraftRequestBefore = manager.ShowOldestOverdraftRequest();
            user.RequestOverdraft(500m, acc);
            manager.EvaluateOverdraftRequests(true);
            string overdraftRequestAfter = manager.ShowOldestOverdraftRequest();
            string overdraftRequestAfterWithoutTime = overdraftRequestAfter.Substring(0, overdraftRequestAfter.Length - 9);
            decimal res2 = acc.Withdraw(1250m);


            // Assert
            Assert.That(res1, Is.EqualTo(0));
            Assert.That(overdraftRequestBefore, Is.EqualTo(""));
            Assert.That(overdraftRequestAfter, Is.Not.EqualTo(""));
            Assert.That(overdraftRequestAfterWithoutTime, Is.EqualTo(expectedRequestString));
            Assert.That(res2, Is.EqualTo(1250m));

        }

    }
}
