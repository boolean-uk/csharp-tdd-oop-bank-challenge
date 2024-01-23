using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace Boolean.CSharp.Main.Classes
{
    /// <summary>
    /// Extremely lazy, barebones implementation. In an optimal world I would have linked the Sid and AuthToken to launchsettings.json. 
    /// As it was not created and that it has been a long day and I haven't quite figured out how to generate one yet I just directly pasted
    /// </summary>
    public static class TwilioHelper
    {
        private static string accountSid = "Nope";
        private static string authToken = "You won't get it.";

        public static string SendSMS(string phoneNumber, string messageToCustomer)
        {

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                body: messageToCustomer,
                from: new Twilio.Types.PhoneNumber("Not happening"),
                to: new Twilio.Types.PhoneNumber(phoneNumber)
            );

            return $"Message should have been sent to {phoneNumber}, bro";
        }
    }
}
