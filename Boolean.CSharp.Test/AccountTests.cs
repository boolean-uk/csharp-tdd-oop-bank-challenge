using Boolean.CSharp.Main;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    public class AccountTests
    {

        [Test]
        public void GetBalanceTest()
        {
            User user = new User();
            Account current = user.CreateCurrent(0);
            float expetecdAmount = 0;
            int nrOfTransactions = 0;

            Assert.That(current.GetBalance(), Is.EqualTo(expetecdAmount));

            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                int rndCase = random.Next(0, 2);
                float rndAmount = random.Next(0, 10000);
                switch (rndCase)
                {
                    case 0:
                        if (current.DepositMoney(rndAmount, ""))
                        {
                            nrOfTransactions++;
                            expetecdAmount += rndAmount;
                        }

                        break;
                    case 1:
                        if (current.WithdrawMoney(rndAmount, ""))
                        {
                            if (expetecdAmount - rndAmount >= 0)
                            {
                                nrOfTransactions++;
                                expetecdAmount -= rndAmount;
                            }
                        }
                        break;
                }
            }
            Assert.That(current.transactions.Count(), Is.EqualTo(nrOfTransactions));
            Assert.That(current.GetBalance(), Is.EqualTo(expetecdAmount));
        }

        [TestCase(0f, 0f, 0, false)]
        [TestCase(-1f, 0f, 0, false)]
        [TestCase(10f, 10f, 1, true)]
        public void DepositMoney(float amount, float balanceAmount, int transactionsCount, bool expectedResult)
        {
            User user = new User();
            Account currentAcount = user.CreateCurrent(0);
            Assert.That(currentAcount.DepositMoney(amount, ""), Is.EqualTo(expectedResult));
            Assert.That(currentAcount.transactions.Count(), Is.EqualTo(transactionsCount));
            Assert.That(currentAcount.GetBalance(), Is.EqualTo(balanceAmount));
        }

        [TestCase(0, "", 0, 1, false)]
        [TestCase(-1f, "", 0, 1, false)]
        [TestCase(10f, "", 10f, 2, true)]
        [TestCase(1000f, "", 0f, 1, false)]
        public void WithdrawMoney(float amount, string description, float balanceChange, int transactionsCount, bool expectedResult)
        {
            float startingAmount = 20;
            User user = new User();
            Account currentAcount = user.CreateCurrent(0);
            currentAcount.DepositMoney(startingAmount, description);
            Assert.That(currentAcount.WithdrawMoney(amount, description), Is.EqualTo(expectedResult));
            Assert.That(currentAcount.transactions.Count(), Is.EqualTo(transactionsCount));
            Assert.That(currentAcount.GetBalance(), Is.EqualTo(startingAmount - balanceChange));
        }

        [Test]
        public void GenerateBankStatmentEmpty()
        {
            User user = new User();
            Account current = user.CreateCurrent(0);
            List<string> bankStatement = current.GenerateBankStatement();
            List<string> expectedResult = new List<string> { "date\t\t||credit||debit\t||balance" };
            Assert.That(bankStatement, Is.EqualTo(expectedResult));
        }

        [Test]
        public void GenerateBankStatment()
        {
            User user = new User();
            Account current = user.CreateCurrent(0);
            current.DepositMoney(1000, "");
            current.DepositMoney(2000, "");
            current.WithdrawMoney(500, "");
            DateTime date = DateTime.Today;
            string formatedDate = date.ToString("dd-MM-yyyy");
            List<string> bankStatement = current.GenerateBankStatement();
            List<string> expectedResult = new List<string>
            {
                "date\t\t||credit||debit\t||balance",
                $"{formatedDate}\t||\t||500\t||2500",
                $"{formatedDate}\t||2000\t||\t||3000",
                $"{formatedDate}\t||1000\t||\t||1000"
            };
            Assert.That(bankStatement, Is.EqualTo(expectedResult));
        }

        [TestCase(1000f, 1, true)]
        [TestCase(1f, 0, false)]
        [TestCase(500f, 0, false)]
        [TestCase(0f, 0, false)]
        [TestCase(-10f, 0, false)]
        public void RequestOverdraft(float overdraftAmount, int overdraftCount, bool expectedResult)
        {
            User user = new User();
            Account current = user.CreateCurrent(0);
            current.DepositMoney(500f, "");
            Assert.That(current.RequestOverdraft(overdraftAmount, ""), Is.EqualTo(expectedResult));
            Assert.That(current.overdraftRequests.Count(), Is.EqualTo(overdraftCount));
        }

        [Test]
        public void RejectOverdraft()
        {
            User user = new User();
            Account current = user.CreateCurrent(0);
            Assert.That(current.RejectOverdraft(), Is.False);
            current.RequestOverdraft(100f, "");
            Assert.That(current.overdraftRequests.Count(), Is.EqualTo(1));
            Assert.That(current.RejectOverdraft(), Is.True);
            Assert.That(current.overdraftRequests.Count(), Is.EqualTo(0));
            Assert.That(current.RejectOverdraft(), Is.False);

        }

        [TestCase(100f)]
        public void ApproveOverdraft(float amount)
        {
            CurrentAccount current = new CurrentAccount(0);
            Assert.That(current.ApproveOverdraft(), Is.False);
            current.RequestOverdraft(amount, "");
            Assert.That(current.overdraftRequests.Count(), Is.EqualTo(1));
            Assert.That(current.ApproveOverdraft(), Is.True);
            Assert.That(current.transactions.Count(), Is.EqualTo(1));
            Assert.That(current.GetBalance, Is.EqualTo(-amount));
            Assert.That(current.overdraftRequests.Count(), Is.EqualTo(0));
            Assert.That(current.ApproveOverdraft(), Is.False);
        }

        [Test]
        public void TestDeclineOverdraft()
        {
            CurrentAccount current = new CurrentAccount(0);
            Assert.That(current.RejectOverdraft(), Is.False);
            current.RequestOverdraft(100f, "");
            Assert.That(current.overdraftRequests.Count(), Is.EqualTo(1));
            Assert.That(current.RejectOverdraft(), Is.True);
            Assert.That(current.overdraftRequests.Count(), Is.EqualTo(0));
            Assert.That(current.transactions.Count(), Is.EqualTo(0));
            Assert.That(current.RejectOverdraft(), Is.False);
        }
    }
}
