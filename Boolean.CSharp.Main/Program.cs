// See https://aka.ms/new-console-template for more information
using Boolean.CSharp.Main;


Customer customer = new();
customer.CreateSavingsAccount("test");
customer.Deposit("test", 500);
customer.Deposit("test", 1000);
customer.Withdraw("test", 750);

customer.CreateCurrentAccount("other test");
customer.Deposit("other test", 1000);
customer.Withdraw("other test", 250);


Console.WriteLine(customer.GenerateStatement());