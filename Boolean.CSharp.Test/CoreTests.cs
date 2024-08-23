using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Controler;
using Boolean.CSharp.Main.Model;
using Boolean.CSharp.Main.View;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Assert.True(true);
        }

        [Test]
        public void CreateSavingsAccount()
        {
            
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