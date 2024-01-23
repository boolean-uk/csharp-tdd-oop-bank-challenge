// See https://aka.ms/new-console-template for more information
using Boolean.CSharp.Main.Accounts;
using Boolean.CSharp.Main.Customer;
using Boolean.CSharp.Main.User;

Customer user = new Customer("dave",Boolean.CSharp.Main.Branch.First);
user.CreateSpendingAccount("Spending", user.Branch);
var accounts = user.GetAccounts();
Manager manager = new Manager();
accounts[0].MakeTransaction(Boolean.CSharp.Main.TransactionType.Credit, 500d);
var request = accounts[0].CreateOverdraftRequest(2000d);
manager.EditRequest(request, Boolean.CSharp.Main.OverdraftStatus.Approved);
accounts[0].MakeTransaction(Boolean.CSharp.Main.TransactionType.Debit, 1500d);
accounts[0].MakeTransaction(Boolean.CSharp.Main.TransactionType.Debit, 1000d);
accounts[0].MakeTransaction(Boolean.CSharp.Main.TransactionType.Debit, 1000d);

accounts[0].WriteStatement();
