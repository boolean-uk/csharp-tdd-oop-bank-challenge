// See https://aka.ms/new-console-template for more information
using Boolean.CSharp.Main.Accounts;
using Boolean.CSharp.Main.Users;

Customer cus = new Customer("Seb");

SavingsAccount sa = new SavingsAccount(cus);


Console.WriteLine($"{sa.AccountId} {sa.Customer.CustomerId} {sa.Customer.name}");


