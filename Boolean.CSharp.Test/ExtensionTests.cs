using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Accounts;
using Boolean.CSharp.Main.Branch;
using Boolean.CSharp.Main.enums;
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

        [Test]
        public void TestBranchAssociation()
        {
            // Generate branch
            IBankBranch branch = new LocalBank("123 Bank Road, 987 City");
            // Genereate a customer
            DateTime dob = new DateTime(1996, 8, 20);
            Customer user = new RegularCustomer("Bob", dob);
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
        public void TestAddingUsersToBranch() 
        {
            // Arrange
            IBankBranch branch = new LocalBank("123 Bank Road, 987 City");
            DateTime dob = new DateTime(1996, 8, 20);
            Customer user1 = new RegularCustomer("Bob", dob);
            Customer user2 = new RegularCustomer("Bill", dob);
            Customer user3 = new RegularCustomer("Billy", dob);

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
            IBankBranch branch = new LocalBank("123 Bank Road, 987 City");
            DateTime dob = new DateTime(1996, 8, 20);
            Customer user = new RegularCustomer("Bob", dob);
            IEmployee manager = new Manager("Jim");
            user.RegisterWithBankBranch(branch);
            user.OpenNewAccount(AccountType.General);
            IAccount acc = user.GetAccounts()[0];
            branch.AddAccountToBranch(acc);
            acc.Deposit(1000m);

            // Act
            decimal res1 = (acc as GeneralAccount).SetOverdrawLimit(500, user);
            decimal draw1 = acc.Withdraw(1250m);

            decimal res2 = (acc as GeneralAccount).SetOverdrawLimit(750, manager);
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
            IBankBranch branch = new LocalBank("123 Bank Road, 987 City");
            DateTime dob = new DateTime(1996, 8, 20);
            Customer user = new RegularCustomer("Bob", dob);
            IEmployee manager = new Manager("Jim");
            user.RegisterWithBankBranch(branch);
            user.OpenNewAccount(AccountType.Savings);
            IAccount acc = user.GetAccounts()[0];
            branch.AddAccountToBranch(acc);
            acc.Deposit(1000m);

            // Act
            decimal? res1 = (acc as GeneralAccount)?.SetOverdrawLimit(500, user);
            decimal draw1 = acc.Withdraw(1250m);

            decimal? res2 = (acc as GeneralAccount)?.SetOverdrawLimit(750, manager);
            decimal draw2 = acc.Withdraw(1250m);

            decimal draw3 = acc.Withdraw(750m);

            // Assert
            Assert.That(res1, Is.Null);
            Assert.That(draw1, Is.EqualTo(0m));

            Assert.That(res2, Is.Null);
            Assert.That(draw2, Is.EqualTo(0m));

            Assert.That(draw3, Is.EqualTo(750m));
        }
    }
}
