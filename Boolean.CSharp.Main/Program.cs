using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Accounts;
using Boolean.CSharp.Main.Branches;

Account account = new CurrentAccount(new Branch("Central Bank", "The most central of banks"), "First Account");
account.Deposit(100);
account.Withdraw(58);
account.PrintBankStatements();

Customer customer = new();
customer.CreateAccount(account);

Request request = new("I need money", 120, account);
customer.RequestOverdraft(request);

account.Branch.ReviewRequests();