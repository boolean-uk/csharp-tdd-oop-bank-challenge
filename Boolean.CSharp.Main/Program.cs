// See https://aka.ms/new-console-template for more information
using Boolean.CSharp.Main.Accounts;
using Boolean.CSharp.Main.Customer;

Customer user = new Customer("dave",Boolean.CSharp.Main.Branch.First);
user.CreateSpendingAccount("Spending", user.Branch);
var accounts = user.GetAccounts();
accounts[0].makeTransaction(Boolean.CSharp.Main.TransactionType.Credit, 500d);
accounts[0].makeTransaction(Boolean.CSharp.Main.TransactionType.Credit, 5000d);
accounts[0].makeTransaction(Boolean.CSharp.Main.TransactionType.Debit, 1000d);
accounts[0].makeTransaction(Boolean.CSharp.Main.TransactionType.Credit, 500d);
accounts[0].WriteStatement();
