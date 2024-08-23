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
   
        }


        [Test]
        public void RemoveFundsTest() 
        {
    
        }

        [Test]
        public void UpdateFundsTest()
        {
            


        }

    }
}