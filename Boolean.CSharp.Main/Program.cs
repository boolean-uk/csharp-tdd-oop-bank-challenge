using Boolean.CSharp.Main.Bank.AccountTypes;
using Boolean.CSharp.Main.Bank;

Branch branch = new Branch();
CurrentAccount currentAccount = new CurrentAccount("Current");
branch.CreateAccount(currentAccount);
List<Transaction> bankStatement = currentAccount.MyTransactions;

currentAccount.MakeDeposit(1000.00M);
currentAccount.MakeDeposit(2000.00M);
currentAccount.MakeWithdrawal(500.00M);

string printBankStatement = currentAccount.Print;

Console.WriteLine(printBankStatement);



// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
