using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Accounts;


Customer customer = new Customer(1, "Elsa");
Current current = new Current();
Savings savings = new Savings();
customer.AddAccount(current);
customer.AddAccount(savings);

Console.WriteLine($"--------- Barclays ---------");
Console.WriteLine($"\nHello, {customer.Name}\n*Deposit £50 to your Savings account*\n");
savings.Deposit(50);
string statement = "";
statement = customer.GetTransactionDetails(savings);
customer.DisplayTransactions(statement);
Console.WriteLine("\nDoing another deposit of £200 to Savings account\n");
savings.Deposit(200);
statement = customer.GetTransactionDetails(savings);
customer.DisplayTransactions(statement);
Console.WriteLine("\n*Withdraw £130 from your Savings account*\n");
savings.WithDraw(130);
statement = customer.GetTransactionDetails(savings);
customer.DisplayTransactions(statement);
// Sending sms with bankstatement
// Requieres user secret to work
Sms sms = new Sms();
customer.Telephone = "+4795028563";
sms.SendMessage(customer.GetTransactionDetails(savings), customer.Telephone);
