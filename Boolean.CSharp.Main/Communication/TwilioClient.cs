using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio.Rest.Api.V2010.Account;

namespace Boolean.CSharp.Main.Communication
{
    public class TwilioClient : ISmsClient
    {
        public async Task SendSmsAsync(string text, string number)
        {
            string accountSid = Environment.GetEnvironmentVariable("TWILIO_ACCOUNT_SID");
            string authToken = Environment.GetEnvironmentVariable("TWILIO_AUTH_TOKEN");

            Twilio.TwilioClient.Init(accountSid, authToken);

            var message = await MessageResource.CreateAsync(
                body: text,
                from: new Twilio.Types.PhoneNumber("+15017122661"),
                to: new Twilio.Types.PhoneNumber(number));

            Console.WriteLine(message.Body);
        }

        public void Send(string message)
        {
            Console.WriteLine(message);
        }
    }
}
