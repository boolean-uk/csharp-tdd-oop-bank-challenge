// See https://aka.ms/new-console-template for more information
using Boolean.CSharp.Main;
using Boolean.CSharp.Main.AccountType;
using Boolean.CSharp.Test;

Bank bank = new Bank();
Branch branch = new Branch("Corps", bank);
Customer customer = new Customer("John", branch);
branch.CustomerList.Add(customer);
IAccount account = branch.CreateAccount(customer, 'c');
customer.Deposit(account, 100);     // 100
customer.Deposit(account, 200);     // 300
customer.Deposit(account, 300);     // 600
customer.Deposit(account, 200);     // 800
customer.Withdraw(account, 300);    // 500
customer.Deposit(account, 200);     // 700

Console.WriteLine(account.transactionListToString());
