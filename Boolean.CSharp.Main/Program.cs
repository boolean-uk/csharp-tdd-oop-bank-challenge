// See https://aka.ms/new-console-template for more information
using Boolean.CSharp.Main.Users;

Console.WriteLine("Hello, World!");

Customer customer = new Customer();
Engineer engineer = new Engineer();

customer.CreateSavingsAccount(111);
customer.CreateCurrentAccount(222);

customer.Deposit(111, 2000);
customer.Deposit(111, 1000);
customer.Deposit(111, 5000);

customer.Deposit(222, 5000);
customer.Withdraw(222, 500);
customer.Withdraw(222, 500);

customer.GenerateBankStatement(111);
Console.WriteLine("------------------------------------------");
customer.GenerateBankStatement(222);


Console.WriteLine("------------------------------------------");
var balance = engineer.CalculateBalance(customer.GetSpecifiedAccount(111));
Console.WriteLine(balance);
