using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace Boolean.CSharp.Main.Entities
{
    public static class NotificationSender
    {
        public static void SendTransactionConfirmation(string tr, int phonenumber)
        {
            string accountsid = Environment.GetEnvironmentVariable("TWILIO_ACT_ID");
            string authtoken = Environment.GetEnvironmentVariable("TWILIO_AUTH_TOKEN");

            TwilioClient.Init(accountsid, authtoken);
            string phone = "+47" + phonenumber;

            var message = MessageResource.Create(
                    body: tr,
                    from: new Twilio.Types.PhoneNumber("+16502295844"),
                    to: new Twilio.Types.PhoneNumber(phone)
            );
        }
    }
}
