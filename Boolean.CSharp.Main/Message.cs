using Boolean.CSharp.Main.Accounts;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace Boolean.CSharp.Main
{
    public class Message


    {
        private readonly string _accountSid;
        private readonly string _authToken;
        private IAccount _account;

        public Message(IAccount account)
        {
            this._account = account;
            var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
            _accountSid = config["Twilio:SID"]!;
            _authToken = config["Twilio:Token"]!;

            TwilioClient.Init(_accountSid, _authToken);
        }

        public void Send()
        {
            var sms = MessageResource.Create(
                body: _account.writeStatement(),
                from: new Twilio.Types.PhoneNumber("+15034875253"),
                to: new Twilio.Types.PhoneNumber("+4746621718")
            );

            Console.WriteLine(sms.Sid);
        }
    }
}
