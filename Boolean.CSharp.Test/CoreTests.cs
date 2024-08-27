using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Controler;
using Boolean.CSharp.Main.View;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CoreTests
    {
        private Core _core;
        private MainControler _main;

        public CoreTests()
        {
            _core = new Core();
            _main = new MainControler();

        }

        [Test]
        public void CreateCustomer()
        {
            _main.CreateCustomer("Test_1", "111111-0000");
            _main.GetCustomersList();
            string docPath = $"..\\..\\..\\..\\Boolean.CSharp.Main\\DataBaseFolder\\111111-0000\\";
            Assert.True(System.IO.Directory.Exists(docPath));
        }

        [Test]
        public void CreateSavingsAccount()
        {
            _main.CreateCustomer("Test_2", "222222-0000");
            _main.CreateAccount("Account1", "222222-0000");
        }

        [Test]
        public void AddFundsTest() 
        {
            _main.CreateCustomer("Test_3", "123456-0000");
            _main.CreateAccount("Account1", "123456-0000");
            _main.AddFundToAccount(500, "Account1", "123456-0000");   
            _main.GetAccountBalance("Account1", "123456-0000");
        }


        [Test]
        public void RemoveFundsTest() 
        {
            _main.CreateCustomer("Test_3", "123456-0000");
            _main.CreateAccount("Account1", "123456-0000");
            _main.AddFundToAccount(500,"Account1", "123456-0000");
            _main.AddFundToAccount(500, "Account1", "123456-0000");
            _main.WithdrawFundsFromAccount(200, "Account1", "123456-0000");
            _main.GetAccountBalance("Account1", "123456-0000");

        }

        [Test]
        public void GenerateBankStatmentTest()
        {
            _main.CreateCustomer("Test_3", "123456-0000");
            _main.CreateAccount("Account1", "123456-0000"  );
            _main.AddFundToAccount(500, "Account1", "123456-0000");
            _main.AddFundToAccount(500, "Account1", "123456-0000");
            _main.WithdrawFundsFromAccount(200, "Account1", "123456-0000");
            _main.GenerateAccountStatment("Account1", "123456-0000");


        }

    }
}