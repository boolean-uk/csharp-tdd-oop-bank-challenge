using Twilio.Types;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace Boolean.CSharp.Main
{
    public class SmsController
    {
        private string _accountSid = "";
        private string _authToken = "";
        public SmsController(string accountSid, string authToken)
        {
            _accountSid = accountSid;
            _authToken = authToken;
        }

        public bool SendMessage(string sms, string phoneNumber, string phoneNumberFrom)
        {
            if (string.IsNullOrEmpty(sms) || string.IsNullOrEmpty(_accountSid) || string.IsNullOrEmpty(_authToken))
            {
                return false;
            }

            TwilioClient.Init(_accountSid, _authToken);

            var messageOptions = new CreateMessageOptions(
              new PhoneNumber(phoneNumber));
            messageOptions.From = new PhoneNumber(phoneNumberFrom);
            messageOptions.Body = sms;


            var message = MessageResource.Create(messageOptions);
            return true;
        }
    }
}