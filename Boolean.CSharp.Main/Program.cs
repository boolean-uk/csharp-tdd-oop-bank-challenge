// See https://aka.ms/new-console-template for more information
using Boolean.CSharp.Main.Accounts;
using Boolean.CSharp.Main.Enums;
using Boolean.CSharp.Main.Transactions;
using Boolean.CSharp.Main.Users;

Customer cus = new Customer("Seb");

SavingsAccount sa = new SavingsAccount(cus);
sa.Branches = Branches.Oslo;

sa.deposit(1000);

sa.deposit(500);

sa.withdraw(500);

sa.withdraw(500);

sa.deposit(500);


sa.printTransactions();








