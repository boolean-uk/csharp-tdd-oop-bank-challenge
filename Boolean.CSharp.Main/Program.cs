// See https://aka.ms/new-console-template for more information
using Boolean.CSharp.Main;

Console.WriteLine("Hello, World!");


Account account = new CurrentAccount ("123", 100);

account.AddFunds(100);
account.Withdraw(50);
account.ViewTransaction();
