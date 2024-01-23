// See https://aka.ms/new-console-template for more information
using Boolean.CSharp.Main;
using NUnit.Framework;


HeadQuarters bank = new HeadQuarters();
Private user = new Private(bank.GenerateUserId());
user.CreateCurrentAccount();
user.CurrentAccount.Deposit(1000);
user.CurrentAccount.Deposit(2000);
user.CurrentAccount.Withdraw(500);

user.CurrentAccount.GenerateBankStatement();

Business Engineer = new Business(bank.GenerateUserId());

Engineer.CreateCurrentAccount();
Engineer.CurrentAccount.Deposit(1000);
Console.WriteLine("Engineer Customer - balance Calculated by transaction history: {0}", Engineer.CurrentAccount.CalculateBalance());
Engineer.CurrentAccount.Deposit(6000);
Console.WriteLine("Engineer Customer - balance Calculated by transaction history: {0}", Engineer.CurrentAccount.CalculateBalance());
Engineer.CurrentAccount.Withdraw(500);
Console.WriteLine("Engineer Customer - balance Calculated by transaction history: {0}", Engineer.CurrentAccount.CalculateBalance());

