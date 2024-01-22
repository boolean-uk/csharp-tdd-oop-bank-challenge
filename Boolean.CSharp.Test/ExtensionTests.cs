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
    public class ExtensionTests
    {
        private Extension _extension;
        private LogTransaction _logger;
        public ExtensionTests()
        {
            _logger = new LogTransaction();
            _extension = new Extension();
        }
        [Test]
        public void TestQuestion1()
        {
            _logger.AddLog(300);
            _logger.AddLog(500);
            _logger.Print();
            Assert.That(_logger.CurrentBalance, Is.EqualTo(800));
        }
        [Test]
        public void TestQuestion2()
        {

        }
    }
}
