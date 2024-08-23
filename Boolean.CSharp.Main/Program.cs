using Boolean.CSharp.Main.Accounts;
using Boolean.CSharp.Main.Enums;
using Boolean.CSharp.Main;
using NUnit.Framework;

User user = new User("Jonas", Role.Customer);
ConsumptionAccount account = new ConsumptionAccount(user, Branch.Oslo);
account.Deposit(1000);
account.Deposit(2000);
account.Withdraw(500);

string bankStatement = account.GetBankStatement();

Console.WriteLine(bankStatement);
