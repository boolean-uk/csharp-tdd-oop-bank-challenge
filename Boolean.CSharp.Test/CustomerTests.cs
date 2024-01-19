using Boolean.CSharp.Main;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CustomerTests
    {
        [Test]
        public void TestCustomers()
        {
            //Setup
            Customer customer = new("U");

            //Execute
            string name = customer.GetName();

            //Verify
            Assert.That(name, Is.EqualTo("U"));
        }
    }
}
