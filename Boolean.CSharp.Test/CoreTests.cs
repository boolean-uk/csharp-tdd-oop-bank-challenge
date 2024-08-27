using Boolean.CSharp.Main;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CoreTests
    {
        [Test]
        public void CreateAccTest()
        {
            // init
            Account account = new(5000);
            decimal expected = 5000;

            //run
            decimal compute = account.GetBalance();

            //assert
            Assert.That(compute, Is.EqualTo(expected));
            
        }

    }
}