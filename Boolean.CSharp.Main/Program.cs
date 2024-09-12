// See https://aka.ms/new-console-template for more information
using Boolean.CSharp.Main;
using Boolean.CSharp.Main.CustomerAccounts;
using Boolean.CSharp.Main.Users;
using Twilio.Rest.Insights.V1.Conference;

Console.WriteLine("Hello, World!");
Core core = new Core("iasonasBank");
Account account1 = new CurrentAccount(1000);
Account account2 = new SavingsAccount(500);
User user = new Customer("Iasonas", "Kotsarapoglou", "BlaBla@gmail.com", account1, account2);
core.makeADeposit(user, account1, 500);
core.makeADeposit(user, account1, 200);
core.makeAWithdraw(user, account1, 100);
core.printBankStatement(user, account1);