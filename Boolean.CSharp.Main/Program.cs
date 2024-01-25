// See https://aka.ms/new-console-template for more information
using Boolean.CSharp.Main.Accounts;
using Boolean.CSharp.Main.Enums;
using Boolean.CSharp.Main.Transactions;
using Boolean.CSharp.Main.Users;

Customer cus = new Customer("Seb", "Oslo");

SavingsAccount sa = new SavingsAccount(cus);

sa.makeTransaction("deposit", 1000);
Console.WriteLine();
sa.makeTransaction("deposit", 500);
Console.WriteLine();
sa.makeTransaction("withdraw", 500);
Console.WriteLine();
sa.makeTransaction("withdraw", 500);
Console.WriteLine();
sa.makeTransaction("deposit", 500);


sa.printTransactions();








