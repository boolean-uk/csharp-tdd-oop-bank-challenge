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
customer.DisplayTransactions(savings);
Console.WriteLine("\nDoing another deposit of £200 to Savings account\n");
savings.Deposit(200);
customer.DisplayTransactions(savings);
Console.WriteLine("\n*Withdraw £130 from your Savings account*\n");
savings.WithDraw(130);
customer.DisplayTransactions(savings);
