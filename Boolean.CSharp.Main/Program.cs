using Boolean.CSharp.Main.Accounts;
using Boolean.CSharp.Main.Branches;
using Boolean.CSharp.Main.Models;

Account account = new CurrentAccount(new Branch("Central Bank", "The most central of banks"), "First Account");
account.Deposit(100);
account.Withdraw(58);
account.PrintBankStatements();

Customer customer = new();
customer.CreateAccount(account);

Request request = new("I need money", 120, account);
Customer.RequestOverdraft(request);
// account.MessageStatements();

account.Branch.ReviewRequests();