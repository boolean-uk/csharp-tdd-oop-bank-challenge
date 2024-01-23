using Boolean.CSharp.Main.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace Boolean.CSharp.Main.Classes
{
    public class TwilioMessageProvider : ITextMessageSender
    {
        public TwilioMessageProvider() { }
        public void SendMessage(string message)
        {
            string accountSID = "TWILIO_ACCOUNT_SID";
            string authToken = "TWILIO_AUTH_TOKEN";

            TwilioClient.Init(accountSID, authToken);

            var messageOut = MessageResource.Create(
                body: message,
                from: new Twilio.Types.PhoneNumber(""),
                to: new Twilio.Types.PhoneNumber("")
            );

            Console.WriteLine(messageOut.Sid);
        }
    }
}
