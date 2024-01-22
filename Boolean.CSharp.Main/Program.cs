// See https://aka.ms/new-console-template for more information
using Boolean.CSharp.Main;


BankAccount userAccount = new CurrentAccount("1");

// Make transactions
userAccount.Deposit(1000);
userAccount.Withdraw(200);
userAccount.Deposit(500);

// Print the bank statement
userAccount.PrintStatement();