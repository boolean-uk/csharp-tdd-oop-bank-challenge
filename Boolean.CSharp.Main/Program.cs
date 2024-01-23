// See https://aka.ms/new-console-template for more information
using Boolean.CSharp.Main.extra;
using Boolean.CSharp.Main.src.account;
using Boolean.CSharp.Main.src.transaction;

CurrentAccount current = new CurrentAccount(Branch.Oslo);
current.Deposit(500);
current.Deposit(750);
current.Withdraw(250);
current.Deposit(1000);
current.Withdraw(5000);
current.Deposit(750);
current.Withdraw(3000);
Overdraft overdraft = new Overdraft(5000);
current.RequestOverdraft(overdraft);
overdraft.Approve();
current.Withdraw(3000);
current.Withdraw(400);
overdraft.Reject();
current.Withdraw(50);
current.Deposit(400);
Console.WriteLine(current.BankStatement());
