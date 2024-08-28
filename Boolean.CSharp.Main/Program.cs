

using Boolean.CSharp.Main;

Account account = new CurrentAccount(Branch.Bergen);
account.Deposit(1000, TransactionType.Deposit);
account.Deposit(2000, TransactionType.Deposit);
account.Withdraw(500, TransactionType.Withdraw);



Console.WriteLine();

account.GenerateBankStatement();



