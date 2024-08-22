// See https://aka.ms/new-console-template for more information
using Boolean.CSharp.Main;

Console.WriteLine("Hello, World!");

Bank bank = new Bank();

int id = bank.AddAccount("Anders", "current");

bank.Deposit(id, 3000.00);
bank.Withdraw(id, 2000.00);
bank.Withdraw(id, 1000.00);

Console.WriteLine(bank.PrintBankStateMent("Anders"));