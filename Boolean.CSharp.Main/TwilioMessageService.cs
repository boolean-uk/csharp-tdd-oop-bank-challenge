using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio.Types;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace Boolean.CSharp.Main
{
    public class TwilloMessageService
    {
        private readonly string accountSid = "Aaabb"; // Replace with your Twilio Account SID
        private readonly string authToken = "your_auth_token"; // Replace with your Twilio Auth Token
        private readonly string twilioPhoneNumber = "your_twilio_phone_number"; // Replace with your Twilio phone number

        public void SendStatement(string message)
        {
            TwilioClient.Init(accountSid, authToken);

            var toPhoneNumber = "recipient_phone_number"; // Replace with the recipient's phone number

            var messageOptions = new CreateMessageOptions(
                new PhoneNumber(toPhoneNumber))
            {
                Body = message,
                From = new PhoneNumber(twilioPhoneNumber)
            };

            var messageResult = MessageResource.Create(messageOptions);

            Console.WriteLine($"Statement sent to {toPhoneNumber}. SID: {messageResult.Sid}");
        }
    }

}
