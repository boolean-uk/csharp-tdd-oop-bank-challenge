using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace Boolean.CSharp.Main.SmSService
{
    public class SmSService
    {
        public SmSService() { }
        public void SendMessage(string userMessage) { 
            string accountSid = Environment.GetEnvironmentVariable("TWILIO_ACCOUNT_SID");
            string authToken = Environment.GetEnvironmentVariable("TWILIO_AUTH_TOKEN");

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                body: userMessage,
                from: new Twilio.Types.PhoneNumber(""),
                to: new Twilio.Types.PhoneNumber("")
            );
        }
    }
}
