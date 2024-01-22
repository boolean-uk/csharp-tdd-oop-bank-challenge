using Twilio;
using Twilio.Rest.Api.V2010.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Twillo : IMessenger
    {
        private string accountSid, authToken;
        public Twillo() 
        {
            accountSid = "AC89efc7377e74a2cda9dde441ed88bc73";
            authToken = "d5c7357eed86c4a8bb92612da02dabca";

            TwilioClient.Init(accountSid, authToken);
        }

        public void send(string message)
        {
            var messageOptions = new CreateMessageOptions(
                new PhoneNumber("+4701234567"));
            messageOptions.From = new PhoneNumber("+15022204634");
            messageOptions.Body = message;


            var SMS = MessageResource.Create(messageOptions);
            Console.WriteLine(SMS.Body);
        }
    }
}
