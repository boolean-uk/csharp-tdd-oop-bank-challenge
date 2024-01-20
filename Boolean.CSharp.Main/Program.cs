// See https://aka.ms/new-console-template for more information
using Boolean.CSharp.Main;

Console.WriteLine("Hello, World!");

User user = new User();
var account = user.CreateSavings(0);
account.DepositMoney(100f);
account.RequestSMSNotification(account, "+123456", "+46123123");

bool pause = true;
