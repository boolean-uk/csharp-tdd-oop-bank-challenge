// See https://aka.ms/new-console-template for more information
using Boolean.CSharp.Main;
using System.Reflection.Metadata;

Console.WriteLine("Hello, World!");

Customer customer = new Customer();
Manager manager = new Manager();

manager.registerCustomer(customer);

GeneralAccount acc = (GeneralAccount)customer.addAccount(AccountType.GENERAL, "ITALY");

acc.MakeTransaction(500.0F, TransactionType.DEPOSIT);
acc.MakeTransaction(600.0F, TransactionType.WITHDRAW);

bool res= customer.requestOvedraft(acc.ID, 600.0F);
Console.WriteLine(res);
Console.WriteLine(acc.getBalance());