using Boolean.CSharp.Main;

var account = new Account { Name = "main account" };
account.Deposit(140.0m);
account.Deposit(39.99m);
account.Withdraw(15.15m);
Console.WriteLine(account.GetTransactionLog());
