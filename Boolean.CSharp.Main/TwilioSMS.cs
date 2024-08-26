using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace Boolean.CSharp.Main
{
    public class TwilioSMS : ISMSSender
    {
        // Credentials and phone numbers removed, need to fill in the blanks
        // if you want to use this method...
        public async void SendSMS(string message, string phoneNr)
        {
            string accountSid = "";
            string authToken = "";
            string fromPhone = "";
            string toPhone = phoneNr;

            TwilioClient.Init(accountSid, authToken);

            var msg = await MessageResource.CreateAsync(
                body: message,
                from: new Twilio.Types.PhoneNumber(fromPhone),
                to: new Twilio.Types.PhoneNumber(toPhone));

            Console.WriteLine(message);
        }
    }
}
