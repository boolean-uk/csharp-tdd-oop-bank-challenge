// See https://aka.ms/new-console-template for more information
using Boolean.CSharp.Main.extra;
Console.WriteLine("Hello, World!");


CurrentAccount current = new CurrentAccount();
current.Deposit(500);
current.Deposit(750);
current.Withdraw(250);
current.Deposit(1000);
current.Withdraw(5000);
current.Deposit(750);
Console.WriteLine(current.BankStatement());
