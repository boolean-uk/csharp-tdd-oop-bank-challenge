using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boolean.CSharp.Main;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class BranchTests
    {
        [Test]
        public void branchTest()
        {
            Branch branch = new Branch("Gåsebu Branch");

            Assert.AreEqual("Gåsebu Branch", branch.Name());
        }

    }
}
