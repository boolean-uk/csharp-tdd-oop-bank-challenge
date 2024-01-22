using Boolean.CSharp.Main.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.TwiML.Voice;

namespace Boolean.CSharp.Main
{
    public class TwilioSMSProvider : ISmsSender
    {
        public TwilioSMSProvider()
        {

        }
        public void SendSMS(string smsMessage)
        {
            //string accountSid = ConfigurationManager.AppSettings["TWILIO_ACCOUNT_SID"];
            //string authToken = ConfigurationManager.AppSettings["TWILIO_AUTH_TOKEN"];

            TwilioClient.Init("", "");

            var message = MessageResource.Create(
                body: smsMessage,
                from: new Twilio.Types.PhoneNumber(""),
                to: new Twilio.Types.PhoneNumber("")
            );

            Console.WriteLine(message.Sid);
        }
    }
}
