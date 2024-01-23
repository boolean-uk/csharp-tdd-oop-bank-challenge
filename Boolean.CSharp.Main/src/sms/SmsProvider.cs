using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace Boolean.CSharp.Main.src.sms
{
    public class SmsProvider
    {
        public SmsProvider()
        {
            string accountSid = "TWILIO_ACCOUNT_SID";
            string authToken = "TWILIO_AUTH_TOKEN";

            try
            {
                TwilioClient.Init(accountSid, authToken);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }


        public void SendMessage(string message, string toNumber)
        {
            try
            {
                MessageResource.Create(
                    body: message,
                    from: new Twilio.Types.PhoneNumber("+15017122661"),
                    to: new Twilio.Types.PhoneNumber(toNumber)
                );
            } catch (Exception e)
            {
                Console.WriteLine(message);
            }   
        }  
    }
}
