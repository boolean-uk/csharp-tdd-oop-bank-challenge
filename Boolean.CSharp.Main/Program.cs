// See https://aka.ms/new-console-template for more information
using Boolean.CSharp.Main.Account;
using Boolean.CSharp.Main.Enums;
using Boolean.CSharp.Main.Interfaces;
using Main;

Console.WriteLine("Hello, World!");

//creating a user
User user3 = new User("Thanasakis", "test", "6999999", 0m, AccountType.Saving);
//createing a bank
Bank bank = new Bank("test");

//creating and account for this user
bank.CreateAccount(user3);

//creating transaction and making a transaction for a specific user 
Transaction transaction = new Transaction(DateTime.Today, TransactionType.Credit, 1000m, bank.BankAccounts.ElementAt(0).balance);
bank.MakeTransaction(transaction, user3, bank.BankAccounts.ElementAt(0));

//creating transaction and making a transaction for a specific user 

Transaction transaction2 = new Transaction(DateTime.Now, TransactionType.Debit, 500m, bank.BankAccounts.ElementAt(0).balance);
bank.MakeTransaction(transaction2, user3, bank.BankAccounts.ElementAt(0));


//printing the receipt for the user 
transaction.TransactionsReceipt(user3, bank.BankAccounts.ElementAt(0));
//bank.CreateAccount(user2);

Console.WriteLine(bank.GetBalance(user3,bank.BankAccounts.ElementAt(0)));
    




