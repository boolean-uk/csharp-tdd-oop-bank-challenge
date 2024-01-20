// See https://aka.ms/new-console-template for more information
using Boolean.CSharp.Main;

Console.WriteLine("Hello, World!");


Customer _user = new Customer();
GeneralAccount _genAccount = new GeneralAccount();

IAccount acc = _user.addAccount(AccountType.GENERAL);


acc.MakeTransaction(1000.0F, TransactionType.DEPOSIT, "10/01/2012");
acc.MakeTransaction(2000.0F, TransactionType.DEPOSIT, "13/01/2012");
acc.MakeTransaction(500.0F, TransactionType.WITHDRAW, "14/01/2012");

acc.ListBankStatement();
