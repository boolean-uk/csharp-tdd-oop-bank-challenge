using Boolean.CSharp.Main;

Customer customer = new Customer("testcostumer", "83747564");
BankBranch branch = new BankBranch("testbranch");
Account _account = new Account("testaccount", customer.userId, branch);

_account.deposit(1000);
_account.deposit(2000);
_account.withdraw(500);

Console.WriteLine(new BankStatement(_account.accountId, _account.transactions).ToString());

