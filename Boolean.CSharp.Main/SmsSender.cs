namespace Boolean.CSharp.Main;

using System;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

public class SmsSender : IMessage
{

    public void SendMessage(string message)
    {
        string accountSid = Environment.GetEnvironmentVariable("TWILIO_ACCOUNT_SID");
        string authToken = Environment.GetEnvironmentVariable("TWILIO_AUTH_TOKEN");

        TwilioClient.Init(accountSid, authToken);

            var toSend = MessageResource.Create(
                body: message,
                from: new Twilio.Types.PhoneNumber("+15017122661"),
                to: new Twilio.Types.PhoneNumber("+15558675310")
            );

        Console.WriteLine(toSend.Sid);
    }
}
