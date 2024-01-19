using Boolean.CSharp.Main.Accounts;

Account account = new CurrentAccount();
account.Deposit(100);
account.Withdraw(58);
account.PrintBankStatements();