using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace Boolean.CSharp.Main
{
    /*This class will have a reference to the associated bank account and a method to 
     * send the account statement as a message to the customer's phone.*/
    public class PhoneMessage
    {
        private readonly string accountSid;
        private readonly string authToken;
        private readonly string fromPhoneNumber;

        public PhoneMessage(string accountSid, string authToken, string fromPhoneNumber)
        {
            this.accountSid = accountSid;
            this.authToken = authToken;
            this.fromPhoneNumber = fromPhoneNumber;
        }
        //Installed Twilio NuGet Package: Install-Package Twilio

        public string SendStatement(List<Transaction> transactions)
        {
            TwilioClient.Init(accountSid, authToken);

            // For simplicity, a placeholder message is used here
            string statementMessage = "Your account statement goes here.";

            var message = MessageResource.Create(
                body: statementMessage,
                from: new Twilio.Types.PhoneNumber(fromPhoneNumber),
                to: new Twilio.Types.PhoneNumber("recipient_phone_number")
            );

            return $"Message SID: {message.Sid}";
        }
    }
}
