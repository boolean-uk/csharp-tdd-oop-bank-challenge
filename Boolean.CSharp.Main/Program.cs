// See https://aka.ms/new-console-template for more information
using Boolean.CSharp.Main.Core;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics;

Console.WriteLine("Hello, World!");


CurrentAccount current = new CurrentAccount();
SavingsAccount saving = new SavingsAccount();

saving.Deposit(1000d, new System.DateTime(2012, 01, 10));
saving.Deposit(2000d, new DateTime(2012, 01, 13));
saving.Withdraw(500d, new DateTime(2012, 01, 14));

saving.CreateBankStatement();