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
            View.CreateCustomer("Test", "111111-0000", _main);
            View.GetCustomersList(_main);
        }

        [Test]
        public void CreateSavingsAccount()
        {
            View.CreateCustomer("Test", "111111-0000", _main);
            View.CreateAccount("Account1", "111111-0000", _main);
        }

        [Test]
        public void AddFundsTest() 
        {
            View.CreateCustomer("Test", "123456-0000", _main);
            View.CreateAccount("Account1", "123456-0000", _main);
            View.AddFunds("Account1", "123456-0000", _main, 500);
            View.GetAccountBalance("Account1", "123456-0000", _main);
        }


        [Test]
        public void RemoveFundsTest() 
        {
            View.CreateCustomer("Test", "123456-0000", _main);
            View.CreateAccount("Account1", "123456-0000", _main);
            View.AddFunds("Account1", "123456-0000", _main, 500);
            View.AddFunds("Account1", "123456-0000", _main, 500);
            View.WithdrawFunds("Account1", "123456-0000", _main, 200);
            View.GetAccountBalance("Account1", "123456-0000", _main);

        }

        [Test]
        public void GenerateBankStatmentTest()
        {
            View.CreateCustomer("Test", "123456-0000", _main);
            View.CreateAccount("Account1", "123456-0000", _main);
            View.AddFunds("Account1", "123456-0000", _main, 500);
            View.AddFunds("Account1", "123456-0000", _main, 500);
            View.WithdrawFunds("Account1", "123456-0000", _main, 200);
            View.GenerateBankStatment("Account1", "123456-0000", _main);


        }

    }
}