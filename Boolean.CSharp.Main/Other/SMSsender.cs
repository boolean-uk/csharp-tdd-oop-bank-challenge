using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using System;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Rest.Routes.V2;


namespace Boolean.CSharp.Main.Other
{
    public class SMSsender
    {
        // Install the C# / .NET helper library from twilio.com/docs/csharp/install
        private string _SID;
        private string _authToken;

        public SMSsender() {

            _SID = Environment.GetEnvironmentVariable("FAKE-SID");
            _authToken = Environment.GetEnvironmentVariable("FAKE-AuthToken");
        }

        public bool SendMessage(string fromPhoneNumber, string toPhoneNumber, string message)
        {
            if (fromPhoneNumber == null || toPhoneNumber == null || message == "")
                return false;

            // See http://twil.io/secure for more information

            TwilioClient.Init(_SID, _authToken);

            var msg = MessageResource.Create(
                body: message,
                from: new Twilio.Types.PhoneNumber(fromPhoneNumber),
                to: new Twilio.Types.PhoneNumber(toPhoneNumber)
            );

            return true;
        }
    }
}
