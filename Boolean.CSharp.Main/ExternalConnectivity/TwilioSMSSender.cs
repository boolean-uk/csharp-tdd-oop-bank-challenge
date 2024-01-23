using dotenv.net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace Boolean.CSharp.Main.MessageProvider
{
    public class TwilioSMSSender : ITextSender
    {

        /// <inheritdoc />
        public void SendMessage(string message)
        {
            DotEnv.Load();
            string _accountSID = Environment.GetEnvironmentVariable("TestAccountSID");
            string _authToken = Environment.GetEnvironmentVariable("TestAuthToken");
            TwilioClient.Init(_accountSID, _authToken);

            var msg = MessageResource.Create(
                body: message,
                from: new Twilio.Types.PhoneNumber("+15017122661"),
                to: new Twilio.Types.PhoneNumber("+4793686586")
                ) ;

            Console.WriteLine(msg.Sid);
        }
    }
}
