// See https://aka.ms/new-console-template for more information
using Boolean.CSharp.Main.Accounts;
using Boolean.CSharp.Main.Enums;
using Boolean.CSharp.Main.Person;
using System.Transactions;

Console.WriteLine("Hello, World!");

Customer customer = new Customer("Ali Haider", 1);
customer.createAccount(AccountType.Current, "1208 90 11111");
IAccount current = customer.accounts[0];

current.deposit(1000);
current.deposit(2000);
current.withdraw(500);

current.GenerateStatement();
