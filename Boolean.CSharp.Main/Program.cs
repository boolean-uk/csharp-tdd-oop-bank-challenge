// See https://aka.ms/new-console-template for more information
using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Classes.Accounts;
using Boolean.CSharp.Main.Classes.User;

Console.WriteLine("Hello, World!");

//  Arrange - set up test values
CustomerUser customer = new CustomerUser();
CurrentAccount testAccount = new CurrentAccount();
customer.CreateAccount(testAccount);

//  Act - use the fucntion we want to test
customer.Deposit(1000.0d, 0);
customer.Deposit(2000.0d, 0);
customer.Withdraw(500, 0);
ManagerUser manager = new ManagerUser();
manager.ManageRequest(customer.RequestOverdraft(1000, 0), eStatus.Approved);
customer.Withdraw(3000d, 0);
customer.Deposit(700d, 0);

////  Assert - check the results
//string result = customer.GenerateStatement(0);
//Console.WriteLine(result);
customer.SendAccountText(0);