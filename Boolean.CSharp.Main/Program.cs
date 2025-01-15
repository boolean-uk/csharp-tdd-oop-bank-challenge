using Boolean.CSharp.Main;

Guid id = Guid.NewGuid();
Account acc = new Account(id);

string initialStatement = acc.GetTransactionStatement();
acc.Deposit(1000);
string depositStatement = acc.GetTransactionStatement();
acc.Withdraw(500);
string withdrawStatement = acc.GetTransactionStatement();
// See https://aka.ms/new-console-template for more information
Console.WriteLine(withdrawStatement);
