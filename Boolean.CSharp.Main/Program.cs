// See https://aka.ms/new-console-template for more information
using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Objects;

Console.WriteLine("Welcome to your bank management application");

BankManager bankManager = new BankManager();
Branch branch = new Branch("Bergen", "Bergen");

bankManager.CreateCurrentAccount("Current account 2", branch);

bankManager.CreateSavingsAccount("Savings account 2", branch);