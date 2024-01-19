using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Enums;
using Boolean.CSharp.Main.Transactions;
using Boolean.CSharp.Main.Accounts;

Bank bank = new Bank();
bank.CreateAccount("Test", AccountType.Current);

Transaction transaction1 = new Transaction();
transaction1.DateTime = new DateTime(2012, 01, 10);
transaction1.amount = 1000;
transaction1.transactionType = TransactionType.deposit;
transaction1.newBalance = 1000;

Transaction transaction2 = new Transaction();
transaction2.DateTime = new DateTime(2012, 01, 13);
transaction2.amount = 2000;
transaction2.transactionType = TransactionType.deposit;
transaction2.newBalance = 3000;

Transaction transaction3 = new Transaction();
transaction3.DateTime = new DateTime(2012, 01, 14);
transaction3.amount = 500;
transaction3.transactionType = TransactionType.withdraw;
transaction3.newBalance = 2500;

bank.currentAccounts.FirstOrDefault(i => i._CustomerName == "Test").transactions.Add(transaction1);
bank.currentAccounts.FirstOrDefault(i => i._CustomerName == "Test").transactions.Add(transaction2);
bank.currentAccounts.FirstOrDefault(i => i._CustomerName == "Test").transactions.Add(transaction3);



bank.PrintAccount("Test", AccountType.Current);