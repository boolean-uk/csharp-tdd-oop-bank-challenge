using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Model;
using Boolean.CSharp.Main.Controller;
using Boolean.CSharp.Main.View;
using NUnit.Framework;
using System.Reflection;
using NUnit.Framework.Api;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CoreTests
    {
        private Core _core;
        private Main.Controller.Controller _controller;
        private Main.Model.Model _model = new Main.Model.Model();
        private Main.View.View _view  = new Main.View.View();

        public CoreTests()
        {
            _core = new Core();
            _controller = new Main.Controller.Controller(_model, _view);
        }

        [Test]
        public void TestQuestion1()
        {
            
        }

        [Test]
        public void CustomerCreationTest()
        {
            
        }
    }
}