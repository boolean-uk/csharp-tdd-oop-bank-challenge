using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boolean.CSharp.Main;
using IKVM.Runtime;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    public class TestBranch
    {
        [Test]
        public void TestAccountAssociationWithBranch()
        {
            Bank bank = new Bank();
            Branch branch = new Branch("Oslo", "123 City Street");
            bank.addBranch(branch);
            Customer customer = new Customer(1, "John", "Doe");
            bank.addCustomer(customer);

            // Create account and associate it with the branch
            bool accountCreated = bank.createAccount(customer.getId(), "Checking", 1000.0, branch.getName());
            Account account = customer.getAccount(1);

            Assert.IsNotNull(account, "Account should not be null");
            Assert.IsTrue(accountCreated, "Account should be created successfully");
            Assert.AreEqual(branch, account.getBranch(), "Account should be associated with the correct branch");
            Assert.IsTrue(branch.getAccounts().Contains(account), "Branch should contain the created account");
        }
    }
}
