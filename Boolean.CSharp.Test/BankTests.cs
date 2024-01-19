using Boolean.CSharp.Main;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class BankTests
    {
        public BankTests()
        {
            
        }
        [TestCase ("Stockholm", 35314)]
        [TestCase ("GothenBorg", 35314)]
        public void CanCreateBank(string name, int code)
        { 
            Branch branch = new Branch(name, code);
            Assert.That(branch.Address, Is.EqualTo(name));
            Assert.That(branch.SortCode, Is.EqualTo(code));
        }

    }
}
