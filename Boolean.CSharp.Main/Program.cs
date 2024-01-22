// See https://aka.ms/new-console-template for more information
using Boolean.CSharp.Main.Classes.Accounts;
using Boolean.CSharp.Main.Classes.User;

Console.WriteLine("Hello, World!");

CustomerUser customer = new CustomerUser();

//  Arrange - set up test values
CurrentAccount testAccount = new CurrentAccount();
customer.CreateAccount(testAccount);

//  Act - use the fucntion we want to test
customer.Deposit(1000.0d, 0);
customer.Deposit(2000.0d, 0);
customer.Withdraw(500, 0);
string result = customer.GenerateStatement(0);
Console.WriteLine(result);