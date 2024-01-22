using Boolean.CSharp.Main;
using NUnit.Framework;
using NUnit.Framework.Internal;

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

            Assert.That(testString, Is.EqualTo(balance.ToString()));
        }

        [Test]
        [TestCase(0d, 0d)]
        [TestCase(500d, 50d)]
        [TestCase(75d, 25d)]
        public void DepostiMoneyTest(double amountIn, double secondAmountIn)
        {
            customer.CreateAccount("123");
            account = customer.MyBankAccounts["123"];
            string test = account.DepositMoney(amountIn);

            Assert.That(test, Is.EqualTo(new string($"{amountIn} was added to the Account({account.AccountID})")));

            Assert.That(account.Balance, Is.EqualTo(amountIn));
            test =account.DepositMoney(secondAmountIn);

            Assert.That(account.Balance, Is.EqualTo(amountIn + secondAmountIn));

            Assert.That(test, Is.EqualTo(new string($"{secondAmountIn} was added to the Account({account.AccountID})")));

        }

        [Test]
        [TestCase(-50d)]
        public void DepostiMoneyTest(double amountIn)
        {
            customer.CreateAccount("123");
            account = customer.MyBankAccounts["123"];
           

            Assert.That(() => account.DepositMoney(amountIn), Throws.Exception);
        }


       [Test]
        [TestCase(0d, 0d)]
        [TestCase(500d, 50d)]
        [TestCase(75d, 25d)]
        public void WithdrawMoneyTest(double amountOut, double secondAmountOut)
        {
            customer.CreateAccount("123");
            account = customer.MyBankAccounts["123"];
            account.DepositMoney(1000d);

            string test = account.WithdrawMoney(amountOut);
            Assert.That(account.Balance, Is.EqualTo(1000d - amountOut));

            Assert.That(test, Is.EqualTo(new string($"{amountOut} was removed from the Account({account.AccountID})")));

            test = account.WithdrawMoney(secondAmountOut);


            Assert.That(account.Balance, Is.EqualTo(1000d - (amountOut + secondAmountOut)));

            Assert.That(test, Is.EqualTo(new string($"{secondAmountOut} was removed from the Account({account.AccountID})")));
        }

        [TestCase(-500d)]
        [TestCase(1200)]
        public void WithdrawMoneyTest2(double amountOut)
        {
            customer.CreateAccount("123");
            account = customer.MyBankAccounts["123"];
            account.DepositMoney(1000d);

            Assert.That(() => account.WithdrawMoney(amountOut), Throws.Exception);
        }

            [Test]
        [TestCase(1000d,500d,250d)]
        [TestCase(1000d, 0d, 250d)]
        [TestCase(1000d, 500d, 0d)]
        
        public void GetTransactionHistoryTest(double moneyIn1, double moneyOut, double moneyIn2)
        {
            List<string> history = new List<string>();

            customer.CreateAccount("123");
            account = customer.MyBankAccounts["123"];
            account.DepositMoney(moneyIn1);

            account.WithdrawMoney(moneyOut);

            account.DepositMoney(moneyIn2);


            history = account.GetTransactionHistory();


            Assert.That(history.Count, Is.EqualTo(4));
            Assert.That(history[1], Is.EqualTo($"2024-01-22 || +{moneyIn1} || -0 || {moneyIn1}"));
            Assert.That(history[2], Is.EqualTo($"2024-01-22 || +0 || -{moneyOut} || {moneyIn1 - moneyOut}"));
            Assert.That(history[3], Is.EqualTo($"2024-01-22 || +{moneyIn2} || -0 || {moneyIn1 + moneyIn2 - moneyOut}"));
        }

        


    }
}