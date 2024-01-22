// See https://aka.ms/new-console-template for more information
using Boolean.CSharp.Main;

Console.WriteLine("Hello, World!");

User user = new User("Øystein", "Bjørkeng");
SavingsAccount savingsAccount = new SavingsAccount("My savings account", user, 2000.0m);

Transaction transaction = new Transaction(200.0m, "Credit");
Transaction transaction1 = new Transaction(200.0m, "Credit");
Transaction transaction2 = new Transaction(200.0m, "Debit");
Transaction transaction3 = new Transaction(200.0m, "Debit");

savingsAccount.Deposit(transaction);
savingsAccount.Deposit(transaction1);
savingsAccount.Withdraw(transaction2);
savingsAccount.Withdraw(transaction3);

savingsAccount.PrintStatement();


