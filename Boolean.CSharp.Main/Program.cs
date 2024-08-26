

using Boolean.CSharp.Main;

Account account = new CurrentAccount();
account.Deposit(1000, TransactionType.Deposit);
account.Deposit(2000, TransactionType.Deposit);
account.Withdraw(500, TransactionType.Withdraw);

account.GenerateBankStatement();



