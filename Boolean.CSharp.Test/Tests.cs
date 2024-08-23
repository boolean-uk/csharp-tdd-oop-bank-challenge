using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Accounts;
using Boolean.CSharp.Main.Enums;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class Tests
    {
        [TestCase(5000)]
        public void TestGetBalance(int depositAmount)
        {
            User user = new User("Jonas", Role.Customer);
            ConsumptionAccount account = new ConsumptionAccount(user, Branch.Oslo);
            account.Deposit(depositAmount);

            int result = account.GetBalance();

            Assert.That(result, Is.EqualTo(depositAmount));
        }

        [TestCase(5000)]
        public void TestDeposit(int depositAmount)
        {
            User user = new User("John", Role.Customer);
            ConsumptionAccount account = new ConsumptionAccount(user, Branch.Trondheim);
            account.Deposit(depositAmount);

            int result = account.GetBalance();

            Assert.That(result, Is.EqualTo(depositAmount));
        }

        [TestCase(5000, 3000, 2000)]
        public void TestWithdraw(int depositAmount, int withdrawAmount, int expectedBalance)
        {
            User user = new User("Marius", Role.Customer);
            ConsumptionAccount account = new ConsumptionAccount(user, Branch.Stavanger);
            account.Deposit(depositAmount);
            account.Withdraw(withdrawAmount);

            int result = account.GetBalance();

            Assert.That(result, Is.EqualTo(expectedBalance));
        }

        [Test]
        public void TestWithdrawWithOverdraftAsManager()
        {
            int depositAmount = 5000;
            int withdrawAmount = 5500;
            int overdraft = 1000;
            int expectedBalance = -500;

            User user = new User("KingBoss", Role.Manager);
            ConsumptionAccount account = new ConsumptionAccount(user, Branch.Stavanger);
            account.Deposit(depositAmount);

            bool overdraftResult = account.SetOverdraft(overdraft, user);
            bool withdrawResult = account.Withdraw(withdrawAmount);
            int result = account.GetBalance();

            Assert.IsTrue(overdraftResult);
            Assert.IsTrue(withdrawResult);
            Assert.That(result, Is.EqualTo(expectedBalance));
        }

        [Test]
        public void TestWithdrawWithOverdraftAsCustomer()
        {
            int depositAmount = 5000;
            int withdrawAmount = 5500;
            int overdraft = 1000;
            int expectedBalance = 5000;

            User user = new User("KingBoss", Role.Customer);
            ConsumptionAccount account = new ConsumptionAccount(user, Branch.Stavanger);
            account.Deposit(depositAmount);

            bool overdraftResult = account.SetOverdraft(overdraft, user);
            bool withdrawResult = account.Withdraw(withdrawAmount);
            int result = account.GetBalance();

            Assert.IsFalse(overdraftResult);
            Assert.IsFalse(withdrawResult);
            Assert.That(result, Is.EqualTo(expectedBalance));
        }

        [Test]
        public void TestGetBankStatement()
        {
            User user = new User("Jonas", Role.Customer);
            ConsumptionAccount account = new ConsumptionAccount(user, Branch.Oslo);
            account.Deposit(1000);
            account.Deposit(2000);
            account.Withdraw(500);
            
            string bankStatement = account.GetBankStatement();

            Assert.IsNotEmpty(bankStatement);
        }

        [Test]
        public void TestSendMessage()
        {
            string accountSid = "";
            string atuhToken = "";
            string yourTwilioPhoneNumberFrom = "";
            string yourPhoneNumber = "";

            User user = new User("Jonas", Role.Customer);
            ConsumptionAccount account = new ConsumptionAccount(user, Branch.Oslo);
            SmsController smsController = new SmsController(accountSid, atuhToken);
            account.Deposit(1000);
            account.Deposit(2000);
            account.Withdraw(500);

            string bankStatement = account.GetBankStatement();
            bool messageSendt = smsController.SendMessage(bankStatement, yourPhoneNumber, yourTwilioPhoneNumberFrom);

            Assert.IsTrue(messageSendt);
        }
    }
}