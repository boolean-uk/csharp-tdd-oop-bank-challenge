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
            List<Transaction> transactions = new List<Transaction>();  // Provide some transactions
            PhoneMessage phoneMessage = new PhoneMessage("your_account_sid", "your_auth_token", "your_twilio_phone_number");

            // Act
            string result = phoneMessage.SendStatement(transactions);

            // Assert
            Assert.IsNotNull(result);

        }

        /*
        [Test]
        public void SendStatement_ReturnsExpectedMessage()
        {
            // Arrange
            SavingsAccount savingsAccount = new SavingsAccount { PhoneNumber = "1234567890" };
            PhoneMessage phoneMessage = new PhoneMessage("YourTwilioSid", "YourTwilioToken", "YourTwilioPhoneNumber");

            // Act
            var transactions = savingsAccount.GenerateStatement();
            string result = phoneMessage.SendStatement(transactions);

            // Assert
            string expectedMessage = "Account statement sent to your phone.";
            Assert.AreEqual(expectedMessage, result);
        }
        */


    }
}
