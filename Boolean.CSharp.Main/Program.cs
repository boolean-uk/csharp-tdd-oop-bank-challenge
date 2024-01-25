// See https://aka.ms/new-console-template for more information


using Boolean.CSharp.Main;
using Boolean.CSharp.Main.AccountFolder;

SavingsAccount savingsAccount = new SavingsAccount();
Transactions transaction = new Transactions(4000, TransactionTypes.Credit);
Transactions transaction2 = new Transactions(2000, TransactionTypes.Debit);
Transactions transaction3 = new Transactions(1000, TransactionTypes.Credit);
Transactions transaction4 = new Transactions(3000, TransactionTypes.Debit);

savingsAccount.Deposit(transaction);
savingsAccount.Withdraw(transaction2);
savingsAccount.Deposit(transaction3);
savingsAccount.Withdraw(transaction4);

savingsAccount.printStatement();

