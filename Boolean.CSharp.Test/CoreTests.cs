using Boolean.CSharp.Main;
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

        [TestCase("Ola", "current")]
        [TestCase("Lise", "savings")]
        public void CreateCurrentAccount(string name, string bankType)
        {
            Bank bank = new Bank();

            bool result = bank.AddAccount(name, bankType);

            Assert.That(result, Is.True);
        }



        public void TestGenerateBankStatement()
        {
            Bank bank = new Bank();
            string user = "Bob";

            //Deposit and withdraw

            string result = bank.PrintBankStateMent(user);

            Assert.NotNull(result);
        }
    }
}