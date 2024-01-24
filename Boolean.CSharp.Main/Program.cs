using Boolean.CSharp.Main.Accounts;
using Boolean.CSharp.Main.Concretes;
using Boolean.CSharp.Main.Interfaces;

CurrentAccount currentAccount = new CurrentAccount();
// Arrange
ITransaction deposit1 = new Transaction(1000.00d);
currentAccount.AddTransaction(deposit1);
ITransaction deposit2 = new Transaction(2000.00d);
currentAccount.AddTransaction(deposit2);
ITransaction withdrawal = new Transaction(-500);
currentAccount.AddTransaction(withdrawal);

string bankStatement = currentAccount.GenerateBankStatement();

Console.WriteLine(bankStatement);