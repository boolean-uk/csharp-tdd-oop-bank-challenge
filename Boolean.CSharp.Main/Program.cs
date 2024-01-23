// See https://aka.ms/new-console-template for more information
using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Users;
using Boolean.CSharp.Main.Accounts;

Console.WriteLine("Hello, World!");


Customer customer = new Customer();


customer.CreateCurrentAccount("Current Account", Enums.AccountBranch.Oslo);
customer.CreateSavingsAccount("SAvings ACcount", Enums.AccountBranch.Monaco);

customer._currentAccount.Deposit(1000);
customer._currentAccount.Deposit(2000);
customer._currentAccount.Withdraw(500);
customer._currentAccount.ShowTransactions();


customer._savingsAccount.Deposit(100000);
customer._savingsAccount.Deposit(200000);
customer._savingsAccount.Withdraw(30000);
customer._savingsAccount.RequestOverdraft();

List<Account> accounts = new List<Account>();
accounts.Add(customer._currentAccount);
accounts.Add(customer._savingsAccount);

Manager manager = new Manager(accounts);


manager.CheckOverdrafts();

customer.CheckOverDraft(customer._savingsAccount);

