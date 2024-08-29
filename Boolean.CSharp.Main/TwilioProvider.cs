using System;
using System.Collections.Generic;
using System;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using System.Threading.Tasks;
using Twilio.Types;

namespace Boolean.CSharp.Main
{
    public class TwilioProvider : ISMSProvider
    {
        public void SendSMS(string phonenr, string statement)
        {

            // Find your Account SID and Auth Token at twilio.com/console
            // and set the environment variables. See http://twil.io/secure
            string accountSid = Environment.GetEnvironmentVariable("ASID");
            string authToken = Environment.GetEnvironmentVariable("ATOKEN");
            string sendnr = Environment.GetEnvironmentVariable("TWPHNR");

            TwilioClient.Init(accountSid, authToken);

            var messageOptions = new CreateMessageOptions(
              new PhoneNumber(phonenr));
            messageOptions.From = new PhoneNumber(sendnr);
            messageOptions.Body = statement;


            var message = MessageResource.Create(messageOptions);
            Console.WriteLine(statement);

        }
    }
}   

