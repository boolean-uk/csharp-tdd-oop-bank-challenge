using Boolean.CSharp.Main.Accounts;
using Boolean.CSharp.Main;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Test
{
    public class PhoneMessageTest
    {
        [Test]
        public void SendStatement_ReturnsNonNullResult()
        {
            // Arrange
            PhoneMessage phoneMessage = new PhoneMessage();

            // Act
            string result = phoneMessage.SendStatement();

            // Assert
            Assert.IsNotNull(result);
        }

    }
}
