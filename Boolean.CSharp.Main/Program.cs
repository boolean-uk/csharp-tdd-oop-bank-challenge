// See https://aka.ms/new-console-template for more information
using Boolean.CSharp.Main;

Console.WriteLine("Hello, World!");

Customer customer = new Customer();
customer.CreateAccount(AccountType.Savings, Branch.Oslo);
var account = customer.accounts[0];

account.Deposit(500);
account.Deposit(634);
account.Withdraw(23);
account.Withdraw(58);

account.TextBankStatement();