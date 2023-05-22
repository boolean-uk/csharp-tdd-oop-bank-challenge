using Boolean.CSharp.Source;

CurrentAccount account = new CurrentAccount();
Transaction transaction1 = new Transaction();
transaction1.date = new DateTime(2012,01,10);
transaction1.credit = 1000.00M;
transaction1.newBalance = 1000.00M;

Transaction transaction2 = new Transaction();
transaction2.date = new DateTime(2012, 01, 13);
transaction2.credit = 2000.00M;
transaction2.newBalance = 3000.00M;

Transaction transaction3 = new Transaction();
transaction3.date = new DateTime(2012, 01, 14);
transaction3.debit = 500.00M;
transaction3.newBalance = 2500.00M;

account.transactions.Add(transaction1);
account.transactions.Add(transaction2);
account.transactions.Add(transaction3);

account.BankStatement();

SavingsAccount savingsAccount = new SavingsAccount();
savingsAccount.DepositMoney(2000.00M);
savingsAccount.WithdrawMoney(500.00M);
savingsAccount.BankStatement();