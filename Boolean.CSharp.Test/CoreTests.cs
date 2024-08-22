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
            Customer c = new Customer("Dave");
            Assert.IsNotNull(c);
            Assert.That(c.Name.Equals("Dave"));
        }

    }
}