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

        [Test]
        public void ShouldGetOverdraftIfBankApproves()
        {
            Account ca = new CurrentAccount();
            Account sa = new SavingsAccount();
            List<Account> accounts = new List<Account>() { ca, sa };
            Bank bank = new Bank();
            Customer customer = new Customer(accounts, bank);
            customer.DepositToAccount(0, 500);

            customer.RequestOverdraft(0);
            string result = customer.WithdrawFromAccount(0, 600);

            Assert.That(result, Is.EqualTo("Withdrew 600NOK"));
        }

        [Test]
        public void ShouldNotGetOverdraftIfBankRejects()
        {
            Account ca = new CurrentAccount();
            Account sa = new SavingsAccount();
            List<Account> accounts = new List<Account>() { ca, sa };
            Bank bank = new Bank();
            Customer customer = new Customer(accounts, bank);
            customer.SeemsResponsible = false;
            customer.DepositToAccount(0, 500);

            customer.RequestOverdraft(0);
            string result = customer.WithdrawFromAccount(0, 600);

            Assert.That(result, Is.EqualTo("Insufficent funds"));
        }
    }
}
