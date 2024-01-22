// See https://aka.ms/new-console-template for more information
using Boolean.CSharp.Main;

Console.WriteLine("Hello, World!");

User user = new User("Øystein", "Bjørkeng");
SavingsAccount savingsAccount = new SavingsAccount(user);

BankTransaction transaction = new BankTransaction(200.0m, "Credit");
BankTransaction transaction1 = new BankTransaction(200.0m, "Credit");
BankTransaction transaction2 = new BankTransaction(200.0m, "Debit");
BankTransaction transaction3 = new BankTransaction(200.0m, "Debit");

savingsAccount.Deposit(transaction);
savingsAccount.Deposit(transaction1);
savingsAccount.Withdraw(transaction2);
savingsAccount.Withdraw(transaction3);

savingsAccount.PrintStatement();


