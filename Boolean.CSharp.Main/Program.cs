// See https://aka.ms/new-console-template for more information
using Boolean.CSharp.Main;
using NUnit.Framework;


Bank bank = new Bank();
User user = new User(bank.GenerateUserId());
user.CreateCurrentAccount();
user.CurrentAccount.Deposit(1000);
user.CurrentAccount.Deposit(2000);
user.CurrentAccount.Withdraw(500);

user.CurrentAccount.GenerateBankStatement();
