using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Controler;
using Boolean.CSharp.Main.View;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class ExtensionTests
    {
        private Extension _extension;
        private MainControler _main;
        public ExtensionTests()
        {
            _extension = new Extension();
            _main = new MainControler();
        }

        
        [Test]
        public void ApproveOverdraftTest()
        {
            _main.CreateCustomer("Test", "123456-0000");
            _main.CreateAccount("Account1", "123456-0000");
            _main.AddFundToAccount(500, "Account1", "123456-0000");
            _main.AddFundToAccount(500, "Account1", "123456-0000");
            _main.WithdrawFundsFromAccount(2000, "Account1", "123456-0000");
            
        }
    }
}
