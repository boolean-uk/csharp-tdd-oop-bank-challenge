// See https://aka.ms/new-console-template for more information


using Boolean.CSharp.Main.Accounts;
using Boolean.CSharp.Main.Branch;
using Boolean.CSharp.Main.enums;
using Boolean.CSharp.Main.Users;


DateTime dob = new DateTime(1996, 8, 20);
IBankBranch branch = new LocalBank("123 Bank Road, 987 City");

Customer user = new RegularCustomer("Bob", dob);
user.OpenNewAccount(AccountType.General);
IAccount account = user.GetAccounts()[0];
DateTime now = DateTime.Now;
DateTime tomorrow = DateTime.Now.AddDays(1);

// TODO: Look into mocking the DateTime that will be generated
account.Deposit(1000m);  // 2012-01-10
account.Deposit(2000m);  // 2012-01-13
account.Withdraw(500m);  // 2012-01-14

account.PrintBankStatement(now, tomorrow);