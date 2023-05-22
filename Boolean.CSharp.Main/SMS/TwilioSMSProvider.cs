using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace BankingApp.Boolean.CSharp.Main
{
    public class TwilioSMSProvider
    {
        public TwilioSMSProvider() { }

        public void SendSMS(string smsMessage)
        {

            // Find your Account SID and Auth Token at twilio.com/console
            // and set the environment variables. See http://twil.io/secure
            string accountSid = "";
            string authToken = "";

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                body: "Hi there",
                from: new Twilio.Types.PhoneNumber("+"),
                to: new Twilio.Types.PhoneNumber("+")
            );

            Console.WriteLine(message.Sid);
        }
    }
    
}
