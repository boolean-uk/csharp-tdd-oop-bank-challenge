using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Accounts;

Account account = new CurrentAccount("First Account");
account.Deposit(100);
account.Withdraw(58);
account.PrintBankStatements();