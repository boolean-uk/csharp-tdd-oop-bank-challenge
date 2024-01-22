// See https://aka.ms/new-console-template for more information
using Boolean.CSharp.Main;

Console.WriteLine("Welcome to your bank management application");

BankManager bankManager = new BankManager();

bankManager.CreateCurrentAccount();

bankManager.CreateSavingsAccount();