// See https://aka.ms/new-console-template for more information
using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Users;
using Boolean.CSharp.Main.Accounts;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
Console.WriteLine("Hello, World!");


Customer customer = new Customer();


customer.CreateCurrentAccount("Current Account", Enums.AccountBranch.Oslo);
customer.CreateSavingsAccount("SAvings ACcount", Enums.AccountBranch.Monaco);

customer._currentAccount.Deposit(1000);
customer._currentAccount.Deposit(2000);
customer._currentAccount.Withdraw(500);
customer._currentAccount.ShowTransactions();


customer._savingsAccount.Deposit(100000);
customer._savingsAccount.Deposit(200000);
customer._savingsAccount.Withdraw(30000);
//customer._savingsAccount.RequestOverdraft();

List<Account> accounts = new List<Account>();
accounts.Add(customer._currentAccount);
accounts.Add(customer._savingsAccount);
/*
Manager manager = new Manager(accounts);


manager.CheckOverdrafts();

customer.CheckOverDraft(customer._savingsAccount);*/

// Find your Account SID and Auth Token at twilio.com/console
// and set the environment variables. See http://twil.io/secure
string accountSid = "AC430f8bc216b83a668ab944391adf806f";
string authToken = "68a5822f5d3e2f110d1e4615584f2902";

TwilioClient.Init(accountSid, authToken);

var message = MessageResource.Create(
    body: customer._currentAccount.TransactionsTwilio(),
    from: new Twilio.Types.PhoneNumber("+13025641651"),
    to: new Twilio.Types.PhoneNumber("+4794135572")
);

Console.WriteLine(message.Sid);

