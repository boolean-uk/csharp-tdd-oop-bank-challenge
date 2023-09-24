// See https://aka.ms/new-console-template for more information
using Boolean.CSharp.Main;

Console.WriteLine("Hello, World!");


MainMenu menu = new MainMenu();
CurrentAccount newcurrentaccount = new CurrentAccount();
BankTransaction newtransaction = new BankTransaction();
BankTransaction secondtransaction = new BankTransaction();
BankTransaction thirdtransaction = new BankTransaction();

newcurrentaccount.Create_Account("GR2342456708", 500, "Current");

newtransaction.Date = DateTime.Now.ToString("dd/MM/yyyy");
newtransaction.Transaction_type = Boolean.CSharp.Main.Enums.Transaction.Withdraw;
newtransaction.Amount = 500;
newtransaction.OldBalance = newcurrentaccount.balance;
newtransaction.Calculate_Transaction("Withdraw", 500, newcurrentaccount);

menu.TransactionHistory.Add(newtransaction);

secondtransaction.Date = DateTime.Now.ToString("dd/MM/yyyy");
secondtransaction.Transaction_type = Boolean.CSharp.Main.Enums.Transaction.Deposit;
secondtransaction.Amount = 1500;
secondtransaction.OldBalance = newcurrentaccount.balance;
secondtransaction.Calculate_Transaction("Deposit", 1500, newcurrentaccount);

menu.TransactionHistory.Add(secondtransaction);

thirdtransaction.Date = DateTime.Now.ToString("dd/MM/yyyy");
thirdtransaction.Transaction_type = Boolean.CSharp.Main.Enums.Transaction.Deposit;
thirdtransaction.Amount = 700;
thirdtransaction.OldBalance = newcurrentaccount.balance;
thirdtransaction.Calculate_Transaction("Deposit", 700, newcurrentaccount);

menu.TransactionHistory.Add(thirdtransaction);

menu.Write_Statement();