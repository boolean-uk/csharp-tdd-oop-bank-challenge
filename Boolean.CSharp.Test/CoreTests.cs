using Boolean.CSharp.Main;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CoreTests
    {
        [Test]
        public void CreateCurrentAccount()
        {
            User user = new User();
            Account currentAcount = user.CreateCurrent();
            Assert.That(currentAcount, Is.TypeOf<CurrentAccount>());
            Assert.That(currentAcount.GetBalance(), Is.EqualTo(0));

        }

        [Test]
        public void CreateSavingsAccount()
        {
            User user = new User();
            Account savings = user.CreateSavings();
            Assert.That(savings.GetBalance(), Is.EqualTo(0));
            Assert.That(savings, Is.TypeOf<SavingsAccount>());
        }

        [TestCase(0f, 0f, false)]
        [TestCase(-1f, 0f, false)]
        [TestCase(10f, 10f, true)]
        public void DepositMoney(float amount, float balanceAmount, bool expectedResult)
        {
            User user = new User();
            Account currentAcount = user.CreateCurrent();
            Assert.That(currentAcount.DepositMoney(amount), Is.EqualTo(expectedResult));
            Assert.That(currentAcount.GetBalance(), Is.EqualTo(balanceAmount));
        }

        [TestCase(0, 0, false)]
        [TestCase(-1f, 0, false)]
        [TestCase(10f, 10f, true)]
        [TestCase(1000f, 0f, false)]
        public void WithdrawMoney(float amount, float balanceChange, bool expectedResult)
        {
            float startingAmount = 20;
            User user = new User();
            Account currentAcount = user.CreateCurrent();
            currentAcount.DepositMoney(startingAmount);
            Assert.That(currentAcount.WithdrawMoney(amount), Is.EqualTo(expectedResult));
            Assert.That(currentAcount.GetBalance(), Is.EqualTo(startingAmount - balanceChange));
        }

        [Test]
        public void GetBalanceTest()
        {
            User user = new User();
            Account current = user.CreateCurrent();
            float expetecdAmount = 0;
            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                int rndCase = random.Next(0, 2);
                float rndAmount = random.Next(0, 10000);
                switch (rndCase)
                {
                    case 0:
                        if (current.DepositMoney(rndAmount))
                        {
                            expetecdAmount += rndAmount;
                        }

                        break;
                    case 1:
                        if (current.WithdrawMoney(rndAmount))
                        {
                            expetecdAmount -= rndAmount;
                        }
                        break;
                    default:
                        Assert.Fail();
                        break;
                }
            }
            Assert.That(current.GetBalance(), Is.EqualTo(expetecdAmount));
        }

        [TestCase(10f, 10f, true)]
        public void Transaction(float amount, float balance, bool isCredit)
        {
            DateTime date = DateTime.Today;
            Transaction transaction = new Transaction(amount, balance, isCredit);
            Assert.That(transaction.Amount, Is.EqualTo(amount));
            Assert.That(transaction.IsCredit, Is.True);
            Assert.That(date, Is.EqualTo(transaction.transactionDate));
        }

        [Test]
        public void GenerateBankStatmentEmpty()
        {
            User user = new User();
            Account current = user.CreateCurrent();
            List<string> bankStatement = current.GenerateBankStatement();
            List<string> expectedResult = new List<string> { "date\t\t||credit||debit\t||balance" };
            Assert.That(bankStatement, Is.EqualTo(expectedResult));
        }

        //Hmmm
        [Test]
        public void GenerateBankStatment()
        {
            User user = new User();
            Account current = user.CreateCurrent();
            current.DepositMoney(1000);
            current.DepositMoney(2000);
            current.WithdrawMoney(500);
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


    }
}