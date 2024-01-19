using Boolean.CSharp.Main;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CoreTests
    {
        private Account account;
        private Customer customer;

        [SetUp]
        public void SetUp() 
        {
            account = new Account("12321");
            customer = new Customer();
        }

        //Customer Test

        [Test]
        [TestCase("12345")]
        [TestCase("")]
        public void Test1(string AccountID)
        {
            // Customer CreateAcount()
            customer.CreateAccount(AccountID);

            Assert.That(customer.MyBankAccounts.ContainsKey(AccountID), Is.EqualTo(true));

            Assert.That(customer.MyBankAccounts.Count, Is.EqualTo(1));

            account = customer.MyBankAccounts[AccountID];

            Assert.That(account.AccountID, Is.EqualTo(AccountID));

        }


        // Account Test
        [Test]
        [TestCase("12321")]
        [TestCase("")]
        public void Test2(string ID) 
        {

            account = new Account(ID);

            Assert.That(account.Balance, Is.EqualTo(0));
            Assert.That(account.AccountID, Is.EqualTo(ID));

            
        }

        [Test]
        [TestCase(0d,0d)]
        [TestCase(10d, 10d)]
        [TestCase(500d, 500d)]
        public void GetAccountBalanceTest(double amountIn, double balance)
        {
            customer.CreateAccount("123");
            account = customer.MyBankAccounts["123"];
            account.DepositMoney(amountIn);
            string testString = account.GetAcountBalance();

            Assert.That(testString, Is.EqualTo(balance));
        }

    }
}