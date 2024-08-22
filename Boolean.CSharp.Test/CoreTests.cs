using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Model;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CoreTests
    {
        private Core _core;

        public CoreTests()
        {
            _core = new Core();

        }

        [Test]
        public void CreateCustomer()
        {

        }

        [Test]
        public void CreateSavingsAccount()
        {
            SavingsAccount s = new SavingsAccount("Test");
        }

        [Test]
        public void AddFundsTest() 
        {
            SavingsAccount s = new SavingsAccount("Test");
            s.DepositFunds(500);
            s.DepositFunds(500);
        }


        [Test]
        public void RemoveFundsTest() 
        {
            SavingsAccount s = new SavingsAccount("Test");
            s.DepositFunds(500);
            s.DepositFunds(500);
            s.WithdrawFunds(500);
        }

        [Test]
        public void UpdateFundsTest()
        {
            SavingsAccount s = new SavingsAccount("Test");
            s.DepositFunds(500);
            s.DepositFunds(500);
            s.WithdrawFunds(500);

            foreach (string line in s.GenerateBankStatment()) {
                Console.WriteLine(line);
            }


        }

    }
}