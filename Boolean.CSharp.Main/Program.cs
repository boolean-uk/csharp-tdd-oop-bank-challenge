// See https://aka.ms/new-console-template for more information
using Boolean.CSharp.Main;
using Twilio;
using Twilio.Rest.Api.V2010.Account;


Console.WriteLine("Hello, World!");
dotenv.SetEnvironmentVariable();
string accountSid = Environment.GetEnvironmentVariable("TWILIO_ACCOUNT_SID");
string authToken = Environment.GetEnvironmentVariable("TWILIO_AUTH_TOKEN");

///Print statements
User user = new User("Øystein", "Bjørkeng", "Åsaveien 7a");
SavingsAccount savingsAccount = new SavingsAccount(user);

BankTransaction transaction = new BankTransaction(200.0m, TransactionType.Credit);
BankTransaction transaction1 = new BankTransaction(200.0m, TransactionType.Credit);
BankTransaction transaction2 = new BankTransaction(200.0m, TransactionType.Debit);
BankTransaction transaction3 = new BankTransaction(200.0m, TransactionType.Debit);

savingsAccount.Deposit(transaction);
savingsAccount.Deposit(transaction1);
savingsAccount.Withdraw(transaction2);
savingsAccount.Withdraw(transaction3);

string messageBody = savingsAccount.SMSStatement();
TwilioClient.Init(accountSid, authToken);

var message = MessageResource.Create(
    body: messageBody,
    from: new Twilio.Types.PhoneNumber(Environment.GetEnvironmentVariable("SEND_FROM_NUMBER")),
    to: new Twilio.Types.PhoneNumber(Environment.GetEnvironmentVariable("SEND_TO_NUMBER"))
    );


//savingsAccount.PrintStatement();


