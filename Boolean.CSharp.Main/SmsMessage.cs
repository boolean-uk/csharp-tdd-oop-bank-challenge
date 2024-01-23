namespace Boolean.CSharp.Main;

using System;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

public class SmsMessage : IMessage
{

    public void sendMessage(string message)
    {
        string accountSid = "sid";
        string authToken = "token";

        TwilioClient.Init(accountSid, authToken);

        var toSend = MessageResource.Create(
            body: message,
            from: new Twilio.Types.PhoneNumber("+15017122661"),
            to: new Twilio.Types.PhoneNumber("+4797025959")
        );

        Console.WriteLine(toSend.Sid);
    }
}
