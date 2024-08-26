// See https://aka.ms/new-console-template for more information
using Boolean.CSharp.Main.Acounts;

Console.WriteLine("Hello, World!");

SavingsAccount savings = new SavingsAccount();

savings.Deposit(1000);
savings.Deposit(2000);
savings.Withdraw(500);

Console.WriteLine(savings.printStatement());