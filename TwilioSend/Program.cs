// See https://aka.ms/new-console-template for more information

using System;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Boolean.CSharp.Main;

MessageDraft draft = new MessageDraft();
HeadQuarters bank = new HeadQuarters();
Private user = new Private(bank.GenerateUserId());
Manager BankManager = new Manager(bank.GenerateUserId());
user.CreateCurrentAccount();
user.CurrentAccount.Deposit(1000);
user.CurrentAccount.Deposit(2000);
user.CurrentAccount.Withdraw(500);
user.CurrentAccount.RequestOverdraft(20000);

BankManager.ManageOverdraftRequests(user.CurrentAccount);
user.CurrentAccount.Deposit(2750);

draft.SetBody(user.CurrentAccount.GenerateBankStatement());


string accountSid = Environment.GetEnvironmentVariable("TWILIO_ACCOUNT_SID");
string authToken = Environment.GetEnvironmentVariable("TWILIO_AUTH_TOKEN");


if (accountSid != null) { 
TwilioClient.Init(accountSid, authToken);
string bodyFromDraft = draft.GetBody();
var message = MessageResource.Create(
        body: bodyFromDraft,
        from: new Twilio.Types.PhoneNumber("+14436489614"),
        to: new Twilio.Types.PhoneNumber("+475555555")
);

Console.WriteLine(message.Sid);
}