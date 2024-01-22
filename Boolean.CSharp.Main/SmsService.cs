using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace Boolean.CSharp.Main
{
    public interface ISmsService
    {
        void Send(string message, string phone);
    }
    public class SmsService : ISmsService
    {
        public SmsService()
        {
            // Hardcoded since this is just pseudocode, but you would use the commented code instead for a proper implementation.
            // string accountSid = Environment.GetEnvironmentVariable("TWILIO_ACCOUNT_SID");
            // string authToken = Environment.GetEnvironmentVariable("TWILIO_AUTH_TOKEN");
            try
            {
                TwilioClient.Init("someAccountSidThatIsVeryReal", "someAuthTokenThatIsVeryReal");
            }
            catch (Twilio.Exceptions.ApiException)
            {
                //Console.WriteLine("Error authenticating Twilio, likely due to invalid Sid and Token.\nAs this was only pseudocoded you will need to replace it with your own keys in SmsService.cs for testing.\nIf you are not interested in testing sms functionality you can safely ignore this error.");
            }
        }

        public void Send(string message, string phone)
        {
            try
            {
                MessageResource.Create(body: message, from: "+4787654321", to: phone);
            }
            catch (Twilio.Exceptions.ApiException)
            {
                //Console.WriteLine("Error sending Twilio message, likely due to invalid Sid and Token.\nAs this was only pseudocoded you will need to replace it with your own keys in SmsService.cs for testing.\nIf you are not interested in testing sms functionality you can safely ignore this error.");
            }
        }
    }
}
