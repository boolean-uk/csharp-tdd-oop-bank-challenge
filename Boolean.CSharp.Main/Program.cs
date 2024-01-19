// See https://aka.ms/new-console-template for more information
using Boolean.CSharp.Main;

Console.WriteLine("Hello, World!");

User user = new User();
var current = user.CreateCurrent();
current.DepositMoney(1000);
current.DepositMoney(2000);
current.WithdrawMoney(500);
current.GenerateBankStatement();

bool pause = true;