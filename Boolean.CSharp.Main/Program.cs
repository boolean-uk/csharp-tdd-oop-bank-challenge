// See https://aka.ms/new-console-template for more information
using Boolean.CSharp.Main;
using Boolean.CSharp.Main.AccountTypes;
using Boolean.CSharp.Main.Enums;

Console.WriteLine("Hello, World!");


Customer bob = new Customer("123", "Bob");

CurrentAccount newAccount = new CurrentAccount("New Account", Branch.Oslo);

bob.AddAccount(newAccount);

newAccount.Deposit(200m);
newAccount.Withdraw(100m);
newAccount.Deposit(2000m);
newAccount.Deposit(3000m);
newAccount.Withdraw(1000m);

Console.WriteLine(newAccount.GenerateBankStatement());