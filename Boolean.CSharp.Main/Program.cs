using Boolean.CSharp.Main.Models.Accounts;
using Boolean.CSharp.Main.Models;

var account = new CurrentAccount(Branch.UK, "1234567890");

account.Deposit(1000); 
account.Deposit(500);  
account.Withdraw(200); 

account.OverdraftLimit = 500; 
account.Withdraw(1000);       

BankStatement bankStatement = new BankStatement(account);

string statement = bankStatement.GetStatement();
Console.WriteLine(statement);