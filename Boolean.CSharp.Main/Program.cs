using Boolean.CSharp.Main;

Customer customer = new Customer();
var account = customer.createAccount(123, AccountType.savings, "London");
account.deposit(1000f);
account.withdraw(25.99f);
//account.requestOverdraft(100f);
account.printStatement();
Console.WriteLine("");