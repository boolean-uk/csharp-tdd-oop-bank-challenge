using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace Boolean.CSharp.Main
{

    public class Sms
    {
       
        public Sms()
        {

        }
        public void SendMessage(string message, string telephone)
        {
            var builder = new ConfigurationBuilder()
                .AddUserSecrets<Sms>();
            var configuration = builder.Build();

            string authToken = configuration["Message:AuthToken"];
            string accountSid = "ACecbd16fc7f5567687428fa99ec209fb1";
            TwilioClient.Init(accountSid, authToken);

            var messageOption = new CreateMessageOptions(new PhoneNumber(telephone));
            messageOption.From = new PhoneNumber("+14422281128");
            messageOption.Body = message;

            var msge = MessageResource.Create(messageOption);
            Console.WriteLine(msge);
        }
    }
}
