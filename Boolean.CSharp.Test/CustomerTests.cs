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
            Customer customer = new("U", "+4712345678");

            //Execute
            string name = customer.GetName();
            string phone = customer.GetPhone();

            //Verify
            Assert.That(name, Is.EqualTo("U"));
            Assert.That(phone, Is.EqualTo("+4712345678"));
        }
    }
}
