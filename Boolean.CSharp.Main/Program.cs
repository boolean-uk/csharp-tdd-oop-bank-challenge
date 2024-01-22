// See https://aka.ms/new-console-template for more information
using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Accounts;
using Boolean.CSharp.Main.Accounts.Constants;
using Boolean.CSharp.Main.Users;
using NUnit.Framework;

Console.WriteLine("Hello, World!");

 BankApplication bankApp = new BankApplication();

 Custommer custommer1 = new Custommer()
{
    Name = "Kanthee",
    Branch = Branches.Bergen,
    Id = 1111
};
bankApp.Add(custommer1);


custommer1.makeAccount(Enums.Current);
double amount1 = 999.0;
TransactionType type1 = TransactionType.Deposit;
String mark1 = "Saving1 01/01/24";

double amount2 = 555.0;
TransactionType type2 = TransactionType.Withdraw;
String mark2 = "Deposit1 01/01/24";

double amount3 = 5556.0;
TransactionType type3 = TransactionType.Deposit;
String mark3 = "Saving2 01/01/24";


Guid acc = custommer1.getAccAccounts().Keys.First();
Transaction transaction1 = new Transaction() { Amount = amount1, Type = type1, Mark = mark1 };
custommer1.Deposit(acc, transaction1);
Transaction transaction2 = new Transaction() { Amount = amount2, Type = type2, Mark = mark2 };
custommer1.Withdraw(acc, transaction2);
Transaction transaction3 = new Transaction() { Amount = amount3, Type = type3, Mark = mark3 };
custommer1.Deposit(acc, transaction3);



double balance1 = custommer1.getBalance(acc);


IAccount accc = custommer1.getAccAccounts()[acc];
accc.writeStatement();

