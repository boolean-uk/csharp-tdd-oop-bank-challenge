// See https://aka.ms/new-console-template for more information
using Boolean.CSharp.Main;

Console.WriteLine("Hello, World!");

Account account = new("test");
account.Deposit(500);
account.Deposit(1000);
account.Withdraw(750);
Console.WriteLine(account.GenerateStatement());