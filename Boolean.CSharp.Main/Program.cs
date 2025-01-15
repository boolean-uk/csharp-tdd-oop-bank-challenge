// See https://aka.ms/new-console-template for more information
using Boolean.CSharp.Main;
using Boolean.CSharp.Main.PersonType;
using NUnit.Framework;

Console.WriteLine("Hello, World!");

Customer customer = new Customer("Axel", "Bergen");
customer.CreateAccount("Checkings", "Axel Account");
customer.Deposit(customer.GetAccount("Axel Account"), new CreditTransaction(100));
Manager manager = new Manager();
customer.RequestOverdraft(200, manager.RespondToOverdraft("approve"), customer.GetAccount("Axel Account"));
customer.RequestOverdraft(100, manager.RespondToOverdraft("APPROVE"), customer.GetAccount("Axel Account"));
customer.Withdrawal(customer.GetAccount("Axel Account"), new DebitTransaction(50));
customer.Withdrawal(customer.GetAccount("Axel Account"), new DebitTransaction(150));
customer.Withdrawal(customer.GetAccount("Axel Account"), new DebitTransaction(150));
customer.PrintBankStatement(customer.GetAccount("Axel Account"));
