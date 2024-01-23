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
            accountSid = "Cannot edit environment variables";
            authToken = "Some random text";

            try { TwilioClient.Init(accountSid, authToken); }
            catch (Twilio.Exceptions.ApiException e) { Console.WriteLine(e.Message); }
            
        }

        public void send(string message)
        {
            var messageOptions = new CreateMessageOptions(
                new Twilio.Types.PhoneNumber("+4701234567"));
            messageOptions.From = new Twilio.Types.PhoneNumber("+15022204634");
            messageOptions.Body = message;

            try
            {
                var SMS = MessageResource.Create(messageOptions);
            }
            catch (Twilio.Exceptions.ApiException e)
            {
                { Console.WriteLine(e.Message); }
            }
        }
    }
}
